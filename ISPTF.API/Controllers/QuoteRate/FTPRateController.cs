using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.QuoteRate;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISPTF.API.Controllers.QuoteRate
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FTPRateController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public FTPRateController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("listpage")]
        public async Task<IEnumerable<FTPRateListRsp>> GetAll(string? RateDate, string? Rate_Type, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@RateDate", RateDate);
            param.Add("@Rate_Type", Rate_Type);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);


            if (Rate_Type == null)
            {
                param.Add("@Rate_Type", "");
            }

            var results = await _db.LoadData<FTPRateListRsp, dynamic>(
                        storedProcedure: "usp_AQuote_FTPRateList",
                        param);
            return results;
        }
        // listpage
        [HttpGet("select")]
        public async Task<IEnumerable<FTPRateSelectRsp>> GetSelect(string RateDate,string Rate_Type, string CurCode, string TermType)
        {
            DynamicParameters param = new();
            param.Add("@RateDate", RateDate);
            param.Add("@Rate_Type", Rate_Type);
            param.Add("@CurCode", CurCode);
            param.Add("@TermType", TermType);

            var results = await _db.LoadData<FTPRateSelectRsp, dynamic>(
                        storedProcedure: "usp_AQuote_FTPRateSelect",
                        param);
            return results;
        }
        // Select
        [HttpPost("Save")]
        public async Task<ActionResult<List<FTPRateSaveRsp>>> Insert([FromBody] FTPRateSaveRsp drate)
        {
            DynamicParameters param = new DynamicParameters();
            //RateDate, Rate_Type, CurCode, TermType, Rate, Delete_Flag, Load_Flag, ZZStrdate, ZZdate, ZZUser, FileName
            param.Add("@RateDate", drate.RateDate);
            param.Add("@Rate_Type", drate.Rate_Type);
            param.Add("@CurCode", drate.CurCode);
            param.Add("@TermType", drate.TermType);
            param.Add("@Rate", drate.Rate);
            param.Add("@Delete_Flag", drate.Delete_Flag);
            param.Add("@Load_Flag", drate.Load_Flag);
            param.Add("@ZZStrdate", drate.ZZStrdate);
            param.Add("@ZZdate", drate.ZZdate);
            param.Add("@ZZUser", drate.ZZUser);
            param.Add("@FileName", drate.FileName);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<FTPRateSaveRsp, dynamic>(
                    storedProcedure: "usp_AQuote_FTPRateUpdate",
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
        public async Task<ActionResult<string>> Delete([FromBody] FTPRateDeleteReq dLrate)
        {
            DynamicParameters param = new();
            param.Add("@RateDate", dLrate.RateDate);
            param.Add("@Rate_Type", dLrate.Rate_Type);
            param.Add("@CurCode", dLrate.CurCode);
            param.Add("@TermType", dLrate.TermType);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_AQuote_FTPRateDelete", param);
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
        [HttpGet("GetTerm")]
        public async Task<IEnumerable<FTPRateTermRsp>> GetTerm(string TermType, string CurCode)
        {
            DynamicParameters param = new();
            param.Add("@TermType", TermType);
            param.Add("@CurCode", CurCode);

            if (TermType == null)
            {
                param.Add("@TermType", "");
            }

            var results = await _db.LoadData<FTPRateTermRsp, dynamic>(
                        storedProcedure: "usp_AQuote_FTPTermSelect",
                        param);
            return results;
        }
        // Term Select
    }//main
}
