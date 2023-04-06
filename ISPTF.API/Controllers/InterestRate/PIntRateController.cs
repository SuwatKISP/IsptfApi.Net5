using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.InterestRate;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers.InterestRate
{
    [Route("api/[controller]")]
    [ApiController]
    public class PIntRateController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public PIntRateController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("select")]
        public async Task<IEnumerable<PIntRateRsp>> GetAll(string RateCode ,DateTime RateDate, string RateTime)
        {
            DynamicParameters param = new();
            param.Add("@IRate_Code", RateCode);
            param.Add("@IRate_EffDate", RateDate);
            param.Add("@IRate_EffTime", RateTime);

            var results = await _db.LoadData<PIntRateRsp, dynamic>(
                        storedProcedure: "usp_pIntRateSelect",
                        param);
            return results;
        }
        [HttpGet("editlist")]
        public async Task<IEnumerable<PIntRateRsp>> GetIntRate(string ?RateCode, string ?recstatus,string Page, string PageSize)
        {
            DynamicParameters param = new();

            if (RateCode == null)
            {
                param.Add("@IRate_Code", "");
            }
            else
            {
                param.Add("@IRate_Code", RateCode);
            }
            if (recstatus == null)
            {
                param.Add("@RecStatus", "");
            }
            else
            {
                param.Add("@RecStatus", recstatus);
            }
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            var results = await _db.LoadData<PIntRateRsp, dynamic>(
                        storedProcedure: "usp_pIntRateGetRate",
                        param);
            return results; 
        }
 
        [HttpPost("insert")]
        public async Task<ActionResult<List<PIntRate>>> Insert([FromBody] PIntRate IntRate)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@IRate_Code", IntRate.IRate_Code);
            param.Add("@IRate_EffDate", IntRate.IRate_EffDate);
            param.Add("@IRate_EffTime", IntRate.IRate_EffTime);
            param.Add("@IRate_Rate", IntRate.IRate_Rate);
            param.Add("@RecStatus", IntRate.RecStatus);
            param.Add("@UserCode", IntRate.UserCode);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<PIntRate, dynamic>(
                    storedProcedure: "usp_pIntRateInsert",
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
                    response.Message = "Int Rate code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//insert
        [HttpPost("update")]
        public async Task<ActionResult<List<PIntRate>>> Update([FromBody] PIntRate IntRate)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@IRate_Code", IntRate.IRate_Code);
            param.Add("@IRate_EffDate", IntRate.IRate_EffDate);
            param.Add("@IRate_EffTime", IntRate.IRate_EffTime);
            param.Add("@IRate_Rate", IntRate.IRate_Rate);
            param.Add("@RecStatus", IntRate.RecStatus);
            param.Add("@UserCode", IntRate.UserCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PIntRate, dynamic>(
                    storedProcedure: "usp_pIntRateUpdate",
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
                    response.Message = "Int Rate not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//update
        [HttpPost("delete")]
        public async Task<ActionResult<string>> Delete([FromBody] PIntRate IntRate)
        {
            DynamicParameters param = new();
            param.Add("@IRate_Code", IntRate.IRate_Code);
            param.Add("@IRate_EffDate", IntRate.IRate_EffDate);
            param.Add("@IRate_EffTime", IntRate.IRate_EffTime);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pIntRateDelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Int Rate deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Int Rate not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }//delete
        [HttpPost("release")]
        public async Task<ActionResult<List<PIntRate>>> Release([FromBody] PIntRate IntRate)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@IRate_Code", IntRate.IRate_Code);
            param.Add("@IRate_EffDate", IntRate.IRate_EffDate);
            param.Add("@IRate_EffTime", IntRate.IRate_EffTime);
            param.Add("@RecStatus", IntRate.RecStatus);
            param.Add("@AuthCode", IntRate.AuthCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<PIntRate, dynamic>(
                    storedProcedure: "usp_pIntRateRelease",
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
                    response.Message = "Int Rate not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//Release
    }//main
}
