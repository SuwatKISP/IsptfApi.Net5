using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.GetAny;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models.MidRate;

namespace ISPTF.API.Controllers.GetAny
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAnyController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public GetAnyController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("ComSpreadRate")]
        public async Task<IEnumerable<ComSpreadRateRsp>> GetComSpreadRate(string? As_Cust, string? As_Mod, string? As_Exp)
        {
            DynamicParameters param = new();
            param.Add("@as_cust", As_Cust);
            param.Add("@as_mod", As_Mod);
            param.Add("@as_Exp", As_Exp);

            var results = await _db.LoadData<ComSpreadRateRsp, dynamic>(
                        storedProcedure: "usp_CompSpreadRate",
                        param);
            return results;
        }

        [HttpGet("GetBaseDay")]
//        public async Task<IEnumerable<ComSpreadRateRsp>> GetBaseDay(string? As_CCY)
        public async Task<ActionResult<List<GetBaseDayRsp>>> GetBaseDay(string? As_CCY)
        {
            DynamicParameters param = new();
            param.Add("@as_ccy", As_CCY);

            param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            param.Add("@BaseDay", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            try
            {
                var results = await _db.LoadData<GetBaseDayRsp, dynamic>(
                           storedProcedure: "usp_GetBaseDay",
                           param);

                var resp = param.Get<dynamic>("@Resp");
                var baseday = param.Get<dynamic>("@BaseDay");

                if (resp > 0)
                {
                    return Ok(baseday);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Not Found";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("CompDiscRate")]
        //        public async Task<IEnumerable<ComSpreadRateRsp>> GetBaseDay(string? As_CCY)
        public async Task<ActionResult<List<CompDiscRateRsp>>> GetCompDiscRate(string? As_Cust, string? As_Mod, string? As_Exp,string? As_CCY)
        {
            DynamicParameters param = new();
            param.Add("@as_cust", As_Cust);
            param.Add("@as_mod", As_Mod);
            param.Add("@as_Exp", As_Exp);
            param.Add("@as_ccy", As_CCY);

            param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            param.Add("@CompDiscRate", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            try
            {
                var results = await _db.LoadData<CompDiscRateRsp, dynamic>(
                           storedProcedure: "usp_CompDiscRate",
                           param);

                var resp = param.Get<dynamic>("@Resp");
                var compdiscrate = param.Get<dynamic>("@CompDiscRate");

                if (resp > 0)
                {
                    return Ok(compdiscrate);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Not Found";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAmendNoADV")]
        //        public async Task<IEnumerable<ComSpreadRateRsp>> GetBaseDay(string? As_CCY)
        public async Task<ActionResult<List<GetAmendNoRsp>>> GetAmendNo(string? EXPORT_ADVICE_NO)
        {
            DynamicParameters param = new();
            param.Add("@EXPORT_ADVICE_NO", @EXPORT_ADVICE_NO);

            param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            param.Add("@AmendNo", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
            try
            {
                var results = await _db.LoadData<GetAmendNoRsp, dynamic>(
                           storedProcedure: "[usp_GetAmendNoEXAD]",
                           param);

                var resp = param.Get<dynamic>("@Resp");
                var amendno = param.Get<dynamic>("@AmendNo");

                if (resp > 0)
                {
                    return Ok(amendno);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Not Found";
                    return BadRequest(response);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBeneCovering")]
        public async Task<IEnumerable<GetBeneCoveringRsp>> GetBeneCovering(string? asBen)
        {
            DynamicParameters param = new();
            param.Add("@asBen", asBen);

            var results = await _db.LoadData<GetBeneCoveringRsp, dynamic>(
                        storedProcedure: "usp_GetBeneCovering",
                        param);
            return results;
        }


        [HttpGet("CalDueDate")]
        public async Task<ActionResult<CalDueDateRsp>> CalDueDate(DateTime CalDate, int DaysAdd)
        {
            CalDueDateRsp response = new CalDueDateRsp();
            // Call Store Procedure
            try
            {

                DynamicParameters param = new();
                param.Add("@CalDate", CalDate);
                param.Add("@DaysAdd", DaysAdd);

                var results = await _db.LoadData<CalDueDateRsp, dynamic>(
                            storedProcedure: "usp_CalDueDate",
                            param);
                return Ok(results);
            }
            catch (Exception e)
            {
                return BadRequest(response);
            }
        }

        [HttpGet("AutoTmpMidRate")]
        public async Task<IEnumerable<PMidRateRsp>> AutoTmpMidRate()
        {
            DynamicParameters param = new();
            var results = await _db.LoadData<PMidRateRsp, dynamic>(
                        storedProcedure: "usp_Auto_TmpMidRate", param);
            return results;
        }

        [HttpGet("CheckGLBalance")]
        public async Task<IEnumerable<CheckGLBalanceRsq>> CheckGLBalance(DateTime VouchDate,string VouchID)
        {
            DynamicParameters param = new();
            param.Add("@VouchID", VouchID);
            param.Add("@VouchDate", VouchDate);
            var results = await _db.LoadData<CheckGLBalanceRsq, dynamic>(
                        storedProcedure: "usp_Auto_CheckGLBalance", param);
            return results;
        }
    }
}
