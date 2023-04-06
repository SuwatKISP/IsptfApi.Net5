using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.MidRate;
using ISPTF.Models.MCampaign;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace ISPTF.API.Controllers.MCampagin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaginController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public CampaginController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("selectActive")]
        public async Task<IEnumerable<MCampaignRsp>> GetAll()
        {
            DynamicParameters param = new();
            //param.Add("@Rate_Date", RateDate);

            var results = await _db.LoadData<MCampaignRsp, dynamic>(
                        storedProcedure: "usp_mCampaign_Select",
                        param);
            return results;
        }

        //[HttpGet("editlist")]
        //public async Task<IEnumerable<PMidRateRsp>> GetMidRateByDate(DateTime RateDate, string ?recstatus, string ?RateCcy,string Page, string PageSize)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@Rate_Date", RateDate);
        //    if (RateCcy == null)
        //    {
        //        param.Add("@Rate_Ccy", "");
        //    }
        //    else
        //    {
        //        param.Add("@Rate_Ccy", RateCcy);
        //    }
        //    if (recstatus == null)
        //    {
        //        param.Add("@RecStatus", "");
        //    }
        //    else
        //    {
        //        param.Add("@RecStatus", recstatus);
        //    }
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    var results = await _db.LoadData<PMidRateRsp, dynamic>(
        //                storedProcedure: "usp_pMidRateGetRateByDate",
        //                param);
        //    return results; 
        //}
 
        //[HttpPost("insert")]
        //public async Task<ActionResult<List<PMidRate>>> Insert([FromBody] PMidRate MidRate)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@Rate_Date", MidRate.Rate_Date);
        //    param.Add("@Rate_Time", MidRate.Rate_Time);
        //    param.Add("@Rate_Ccy", MidRate.Rate_Ccy);
        //    param.Add("@Rate_MidRate", MidRate.Rate_MidRate);
        //    param.Add("@Rate_Reuter", MidRate.Rate_Reuter);
        //    param.Add("@RecStatus", MidRate.RecStatus);
        //    param.Add("@UserCode", MidRate.UserCode);
        //    param.Add("@Resp", dbType: DbType.Int32,
        //       direction: System.Data.ParameterDirection.Output,
        //       size: 5215585);
        //    try
        //    {
        //        var results = await _db.LoadData<PMidRate, dynamic>(
        //            storedProcedure: "usp_pMidRateInsert",
        //            param);
        //        var resp = param.Get<int>("@Resp");
        //        if (resp == 1)
        //        {

        //            return Ok(results);
        //        }
        //        else
        //        {

        //            ReturnResponse response = new();
        //            response.StatusCode = "400";
        //            response.Message = "Mid Rate code exist";
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}//insert
        //[HttpPost("update")]
        //public async Task<ActionResult<List<PMidRate>>> Update([FromBody] PMidRate MidRate)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@Rate_Date", MidRate.Rate_Date);
        //    param.Add("@Rate_Time", MidRate.Rate_Time);
        //    param.Add("@Rate_Ccy", MidRate.Rate_Ccy);
        //    param.Add("@Rate_MidRate", MidRate.Rate_MidRate);
        //    param.Add("@Rate_Reuter", MidRate.Rate_Reuter);
        //    param.Add("@RecStatus", MidRate.RecStatus);
        //    param.Add("@UserCode", MidRate.UserCode);
        //    param.Add("@Resp", dbType: DbType.Int32,
        //        direction: System.Data.ParameterDirection.Output,
        //        size: 5215585);
        //    try
        //    {
        //        var results = await _db.LoadData<PMidRate, dynamic>(
        //            storedProcedure: "usp_pMidRateUpdate",
        //            param);
        //        var resp = param.Get<int>("@Resp");
        //        if (resp == 1)
        //        {
        //            return Ok(results);
        //        }
        //        else
        //        {
        //            ReturnResponse response = new();
        //            response.StatusCode = "400";
        //            response.Message = "Mid Rate not exist";
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}//update
        //[HttpPost("delete")]
        //public async Task<ActionResult<string>> Delete([FromBody] PMidRate MidRate)
        //{
        //    DynamicParameters param = new();
        //    param.Add("@Rate_Date", MidRate.Rate_Date);
        //    param.Add("@Rate_Time", MidRate.Rate_Time);
        //    param.Add("@Rate_Ccy", MidRate.Rate_Ccy);
        //    param.Add("@Resp", dbType: DbType.Int32,
        //        direction: System.Data.ParameterDirection.Output,
        //        size: 5215585);
        //    try
        //    {
        //        await _db.SaveData(
        //          storedProcedure: "usp_pMidRateDelete", param);
        //        var resp = param.Get<int>("@Resp");
        //        if (resp == 1)
        //        {

        //            ReturnResponse response = new();
        //            response.StatusCode = "200";
        //            response.Message = "Mid Rate deleted";
        //            return Ok(response);
        //        }
        //        else
        //        {

        //            ReturnResponse response = new();
        //            response.StatusCode = "400";
        //            response.Message = "Mid Rate not exist";
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}//delete
        //[HttpPost("release")]
        //public async Task<ActionResult<List<PMidRate>>> Release([FromBody] PMidRate MidRate)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@Rate_Date", MidRate.Rate_Date);
        //    param.Add("@Rate_Time", MidRate.Rate_Time);
        //    param.Add("@Rate_Ccy", MidRate.Rate_Ccy);
        //    param.Add("@RecStatus", MidRate.RecStatus);
        //    param.Add("@AuthCode", MidRate.AuthCode);
        //    param.Add("@Resp", dbType: DbType.Int32,
        //        direction: System.Data.ParameterDirection.Output,
        //        size: 5215585);
        //    try
        //    {
        //        var results = await _db.LoadData<PMidRate, dynamic>(
        //            storedProcedure: "usp_pMidRateRelease",
        //            param);
        //        var resp = param.Get<int>("@Resp");
        //        if (resp == 1)
        //        {
        //            return Ok(results);
        //        }
        //        else
        //        {
        //            ReturnResponse response = new();
        //            response.StatusCode = "400";
        //            response.Message = "Mid Rate not exist";
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
       // }//Release
    }//main
}
