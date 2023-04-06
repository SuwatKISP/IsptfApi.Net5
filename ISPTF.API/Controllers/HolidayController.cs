using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public HolidayController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAll(string? holyear, string? holdate)
        {
            DynamicParameters param = new();
            if (holyear == "*" || holyear == null)
            {
                param.Add("@Hol_Year", "*");
            }
            else
            {
                param.Add("@Hol_Year", holyear);
            }
            //param.Add("@Hol_Date", DateTime.Now);
            //param.Add("@Hol_Date", holdate);
            if (holdate == "*" || holdate == null)
            {
                param.Add("@Hol_Date", "*");
            }
            else
            {
                param.Add("@Hol_Date", holdate);
            }
            param.Add("@CRsp", dbType: DbType.Int32,
                  direction: System.Data.ParameterDirection.Output,
                  size: 128);
            //param.Add("@CCustRsp", dbType: DbType.String,
            //       direction: System.Data.ParameterDirection.Output,
            //       size: 5215585);
            try
            {
                var results = await _db.LoadData<PHoliday, dynamic>(
                         storedProcedure: "usp_pholidayselect",
                         param);
                var crsp = param.Get<dynamic>("@CRsp");
                //var ccustrsp = param.Get<dynamic>("@CCustRsp");
                if (crsp > 0)
                {
                    //Response.ContentType = "application/json";
                    //return Ok(ccustrsp);
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Holiday Year/Date not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<PHoliday>>> HolidayInsert([FromBody] PHoliday code)
        {
            DynamicParameters param = new();
            param.Add("@Hol_Year", code.hol_Year);
            param.Add("@Hol_Date", code.hol_Date);
            param.Add("@Hol_Desc", code.hol_Desc);
            param.Add("@Hol_RecStat", code.hol_RecStat);
            param.Add("@UpdateDate", code.updateDate);
            param.Add("@UserCode", code.userCode);
            param.Add("@AuthDate", code.authDate);
            param.Add("@AuthCode", code.authCode);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);

            //param.Add("@CCustRsp", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);
            try
            {
                var results = await _db.LoadData<PHoliday, dynamic>(
                    storedProcedure: "usp_pholidayinsert",
                    param);
                var ccode = param.Get<dynamic>("@CRsp");
                //var ccustrsp = param.Get<dynamic>("@CCustRsp");
                if (ccode > 0)
                {
                    //return Ok(ccustrsp);
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Holiday exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("update")]
        public async Task<ActionResult<List<PHoliday>>> HolidayUpdate([FromBody] PHoliday code)
        {
            DynamicParameters param = new();
            param.Add("@Hol_Year", code.hol_Year);
            param.Add("@Hol_Date", code.hol_Date);
            param.Add("@Hol_Desc", code.hol_Desc);
            param.Add("@Hol_RecStat", code.hol_RecStat);
            param.Add("@UpdateDate", code.updateDate);
            param.Add("@UserCode", code.userCode);
            param.Add("@AuthDate", code.authDate);
            param.Add("@AuthCode", code.authCode);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);
            //param.Add("@CCustRsp", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);
            try
            {
                var results = await _db.LoadData<PHoliday, dynamic>(
                    storedProcedure: "usp_pholidayupdate",
                    param);
                var ccode = param.Get<dynamic>("@CRsp");
                //var ccustrsp = param.Get<dynamic>("@CCustRsp");
                if (ccode > 0)
                {
                    //return Ok(ccustrsp);
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Holiday not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("delete")]
        public async Task<ActionResult<string>> HolidayDelete([FromBody] PHolidayCodeReq code)
        {
            DynamicParameters param = new();
            param.Add("@Hol_Year", code.hol_Year);
            param.Add("@Hol_Date", code.hol_Date);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pholidaydelete", param);
                var resp = param.Get<int>("@CRsp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Holiday year/date is deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Holiday Year/Date not exist";
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
