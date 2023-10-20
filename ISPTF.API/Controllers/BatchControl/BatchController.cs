using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.BatchControl;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using static ISPTF.API.Startup;

namespace ISPTF.API.Controllers.BatchControl
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public BatchController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("BatchLogQuery")]
        public async Task<IEnumerable<BatchLogQuery>> GetAll(DateTime WorkDate)
        {
            DynamicParameters param = new();
            param.Add("@WorkDate", WorkDate);

            var results = await _db.LoadData<BatchLogQuery, dynamic>(
                        storedProcedure: "usp_Batch_LogQuery",
                        param);
            return results;
        }
        // BatchLogQuery
        [HttpGet("BTBatchLogQuery")]
        public async Task<IEnumerable<BTBatchLogQuery>> GetAllBT(string WorkDate)
        {
            DynamicParameters param = new();
            param.Add("@WorkDate", WorkDate);

            var results = await _db.LoadData<BTBatchLogQuery, dynamic>(
                        storedProcedure: "usp_BatchBT_LogQuery",
                        param);
            return results;
        }
        // BatchLogQuery
        [HttpGet("StartEndDay/select")]
        public async Task<IEnumerable<BatchStartEndDayRes>> StartEndtDay(string DateFlag)
        {
            DynamicParameters param = new();
            param.Add("@DateFlag", DateFlag);

            var results = await _db.LoadData<BatchStartEndDayRes, dynamic>(
                        storedProcedure: "usp_Batch_StartEndDay_select",
                        param);
            return results;
        }

        // BatchLogQuery
        [HttpGet("DailyBatch/select")]
        public async Task<IEnumerable<BatchDailySelectRes>> DailyBatchSelect()
        {
            DynamicParameters param = new();

            var results = await _db.LoadData<BatchDailySelectRes, dynamic>(
                        storedProcedure: "usp_BatchDaily_select",
                        param);
            return results;
        }

        [HttpGet("StartEndDay/checkpending")]
        public async Task<IEnumerable<BatchStartEndDayPending>> ChkPending()
        {
            DynamicParameters param = new();
            var results = await _db.LoadData<BatchStartEndDayPending, dynamic>(
                        storedProcedure: "usp_Batch_StartEndDay_checkpending",
                        param);
            return results;
        }

        [HttpPost("StartEndDay/save")]
        public async Task<ActionResult<BatchStartEndDayRes>> Save([FromBody] BatchStartEndDayReq data)
        {
            DynamicParameters param = new DynamicParameters();
            //RateDate, Rate_Type, CurCode, TermType, Rate, Delete_Flag, Load_Flag, ZZStrdate, ZZdate, ZZUser, FileName
            if (data.TodayDate ==null || data.NextDate ==null || data.DateFlag ==null || data.UserCode ==null)
            {
                ReturnResponse response = new();
                response.StatusCode = "400";
                response.Message = "Error for Request data";
                return BadRequest(response);
            }
            param.Add("@DateFlag", data.DateFlag);
            param.Add("@TodayDate", data.TodayDate);
            param.Add("@NextDate", data.NextDate);
            param.Add("@NextDate", data.NextDate);
            param.Add("@UserCode", data.UserCode);

            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<BatchStartEndDayRes, dynamic>(
                    storedProcedure: "usp_Batch_StartEndDay_save",
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(results);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Error for Start-End of Day";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//Save

        [HttpPost("DailyBatch/save")]
    //    public async Task<ActionResult><SendMailResultResponse>> SaveDaily([FromBody] BatchDailyReq data)
       public async Task<ActionResult<SendMailResultResponse>> SaveDaily([FromBody] BatchDailyReq data)
        {
            try
            {
                if (data.RerunGFMS =="Y")
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);
                    var results = await _db.LoadData<SendMailResultResponse, dynamic>(
                        storedProcedure: "usp_RerunGFMS",
                        param);
                    var resp = param.Get<int>("@Resp");
                        if (resp == 1)
                        {

                        }
                        else
                        {
                            ReturnResponse response2 = new();
                            response2.StatusCode = "400";
                            response2.Message = "Error for Rerun";
                            return BadRequest(response2);
                        }
                }
                SendMailResultResponse response = new SendMailResultResponse();
                var AppPath = ConfigurationHelper.config.GetSection("AppPath");

                ProcessStartInfo startInfo = new ProcessStartInfo(string.Concat(AppPath.Value, "batch.bat"));
                startInfo.Arguments = data.RerunGFMS; 
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                System.Diagnostics.Process.Start(startInfo);

   //             // Start the child process.
   //             Process p = new Process();
   //             // Redirect the output stream of the child process.
   //             p.StartInfo.UseShellExecute = false;
   //             p.StartInfo.RedirectStandardOutput = true;
   //             p.StartInfo.FileName = AppPath.Value+ "batch.bat";
   //             p.Start();
   //.
   //             string output = p.StandardOutput.ReadToEnd();
   //             p.WaitForExit();

   //             string pathToProgram= AppPath.Value + "batch.bat";
   //             var process = Process.Start(pathToProgram);

   //             process.WaitForExit();

   //             var exitCode = process.ExitCode;


   //             Process.Start(@"C:\temp\publish\SOC");
            

   //             string command = " -h"; //common help flag for console apps
   //             System.Diagnostics.Process pRun;
   //             pRun = new System.Diagnostics.Process();
   //             pRun.EnableRaisingEvents = true;
   //            // pRun.Exited += new EventHandler(pRun_Exited);
   //             pRun.StartInfo.FileName = AppPath.Value + "batch.bat";
   //             pRun.StartInfo.Arguments = command;
   //             pRun.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;

   //             pRun.Start();
   //             pRun.WaitForExit();

                response.Code = "200";
                response.Message = "";
                return Ok(response);


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//SaveDaily
        [HttpPost("DailyInterface/DMS")]
       // public async Task<ActionResult> SaveDMS([FromBody] BatchDailyReq data)
        public async Task<ActionResult<SendMailResultResponse>> SaveDMS([FromBody] BatchDailyReq data)
        {
            try
            {
                var RunDate = data.RunBatchDate.Value.ToString("yyyyMMdd");
                SendMailResultResponse response = new SendMailResultResponse();
                var AppPath = ConfigurationHelper.config.GetSection("AppPath");
                ProcessStartInfo startInfo = new ProcessStartInfo(string.Concat(AppPath.Value, "GenerateDMS.exe"));
                startInfo.Arguments = RunDate;
                //+ "\"";
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                System.Diagnostics.Process.Start(startInfo);

                response.Code = "200";
                response.Message = "";
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//SaveDaily
    }//main
}

