using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.TradeCreditLimit.QuoteRate;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISPTF.API.Controllers.TradeCreditLimit.QuoteRate
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DRateController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public DRateController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("listpage")]
        public async Task<IEnumerable<DRateListRsp>> GetAll(string RateDate)
        {
            DynamicParameters param = new();
            param.Add("@R_date", RateDate);

            var results = await _db.LoadData<DRateListRsp, dynamic>(
                        storedProcedure: "usp_AQuote_RateCodeList",
                        param);
            return results;
        }
        // listpage
        [HttpGet("select")]
        public async Task<IEnumerable<DRateSelectRsp>> GetSelect(string RateDate)
        {
            DynamicParameters param = new();
            param.Add("@R_date", RateDate);

            var results = await _db.LoadData<DRateSelectRsp, dynamic>(
                        storedProcedure: "usp_AQuote_RateCodeSelect",
                        param);
            return results;
        }
        // Select
        [HttpPost("Save")]
        public async Task<ActionResult<List<DRateCode>>> Insert([FromBody] DRateCode drate)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@R_date", drate.R_date);
            param.Add("@RateMLR", drate.RateMLR);
            param.Add("@RateMOR", drate.RateMOR);
            param.Add("@RateSIBOR1", drate.RateSIBOR1);
            param.Add("@RateSIBOR3", drate.RateSIBOR3);
            param.Add("@RateSIBOR6", drate.RateSIBOR6);
            param.Add("@RateSIBOR9", drate.RateSIBOR9);
            param.Add("@RateLIBOR1", drate.RateLIBOR1);
            param.Add("@RateLIBOR3", drate.RateLIBOR3);
            param.Add("@RateLIBOR6", drate.RateLIBOR6);
            param.Add("@RateLIBOR9", drate.RateLIBOR9);
            param.Add("@Rate_ALCO", drate.Rate_ALCO);
            param.Add("@User_T", drate.User_T);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<DRateCode, dynamic>(
                    storedProcedure: "usp_AQuote_RateCodeSave",
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
                    response.Message = "Rate Code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//Save
        [HttpPost("delete")]
        public async Task<ActionResult<string>> Delete([FromBody] DRateDeleteReq drate)
        {

            DynamicParameters param = new();
            param.Add("@R_date", drate.R_date);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_AQuote_RateCodeDelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = " Rate deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = " Rate not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//delete
    }//main
}
