using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static ISPTF.API.Startup;

namespace ISPTF.API.Controllers
{
    //[Authorize]
    //[EnableCors("MyAllowSpecificOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ILogger<BranchController> _logger;

        public BranchController(ISqlDataAccess db,ILogger<BranchController> logger)
        {
            _db = db;
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IEnumerable<MBranch>> GetAll(string? brancode)
        {
            //var baseurl=ConfigurationHelper.config.GetSection("BaseUrlApi");
            
            //_logger.LogInformation("Start : Getting item details for {BranCode}", brancode);

            //List<string> list = new();

            //list.Add("A");
            //list.Add("B");

            //_logger.LogInformation($"Completed : Item details for  {{{string.Join(", ", list)}}}");
            Log.Information("Request : {@brancode}", brancode);
            DynamicParameters param = new ();
            if (brancode == "*" || brancode == null)
            {
                param.Add("@Bran_code", "*");
            }
            else
            {
                param.Add("@Bran_code", brancode);
            }
            var results = await _db.LoadData<MBranch, dynamic>(
                        storedProcedure: "usp_mbranchselect",
                        param);

            Log.Information("Response : {@results}", results);
            return results.ToList();
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<MBranch>>> BranchInsert([FromBody] MBranch branch)
        {
            Log.Information("CustomerNew Request : {@branch}", branch);
            DynamicParameters param = new();
            param.Add("@Bran_Code", branch.bran_Code);
            param.Add("@Bran_Name", branch.bran_Name);
            param.Add("@Prov_Code", branch.prov_Code);
            param.Add("@Bran_GL", branch.bran_GL);
            param.Add("@Bran_BA", branch.bran_BA);
            param.Add("@Bran_Cost", branch.bran_Code);
            param.Add("@Bran_Profit", branch.bran_Profit);
            if (branch.createDate.HasValue)
            {
                param.Add("@CreateDate", branch.createDate);
            }
            else
            {
                param.Add("@CreateDate", null);
            }
            if (branch.updateDate.HasValue)
            {
                param.Add("@UpdateDate", branch.updateDate);
            }
            else
            {
                param.Add("@UpdateDate", null);
            }
            //param.Add("@CreateDate", branch.CreateDate);
            //param.Add("@UpdateDate", branch.UpdateDate);
            param.Add("@UserCode", branch.userCode);
            param.Add("@OnePUse", branch.onePUse);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results=await _db.LoadData<MBranch,dynamic>(
                    storedProcedure: "usp_mbranchinsert", 
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    Log.Debug("Example" + DateTime.Now);
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Branch code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return  BadRequest( ex.Message);
            }

        }
      
        [HttpPost("update")]
        public async Task<ActionResult<List<MBranch>>> BranchUpdate([FromBody] MBranch branch)
        {
            DynamicParameters param = new();
            param.Add("@Bran_Code", branch.bran_Code);
            param.Add("@Bran_Name", branch.bran_Name);
            param.Add("@Prov_Code", branch.prov_Code);
            param.Add("@Bran_GL", branch.bran_GL);
            param.Add("@Bran_BA", branch.bran_BA);
            param.Add("@Bran_Cost", branch.bran_Code);
            param.Add("@Bran_Profit", branch.bran_Profit);
            param.Add("@CreateDate", branch.createDate);
            param.Add("@UpdateDate", branch.updateDate);
            param.Add("@UserCode", branch.userCode);
            param.Add("@OnePUse", branch.onePUse);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MBranch, dynamic>(
                    storedProcedure: "usp_mbranchupdate",
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
                    response.Message = "Branch code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            //try
            //{
            //    await _db.SaveData(
            //      storedProcedure: "usp_mbranchupdate",param);
            //    var resp = param.Get<string>("@Resp");
            //    return Ok(resp);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
          
        }
        [HttpPost("delete")]
        public async Task<ActionResult<string>> BranchDelete([FromBody] MBranchReq brancode)
        {
            DynamicParameters param = new();
            param.Add("@Bran_Code", brancode.Bran_Code);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mbranchdelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Branch code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Branch code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

    }
}
