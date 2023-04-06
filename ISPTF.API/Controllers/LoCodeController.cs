using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LocodeController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public LocodeController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<MLoCode>> GetAll(string? locode)
        {
            DynamicParameters param = new DynamicParameters();
            if (locode == "*" || locode == null)
            {
                param.Add("@Lo_Code", "*");
            }
            else
            {
                param.Add("@Lo_Code", locode);
            }
            var results = await _db.LoadData<MLoCode, dynamic>(
                storedProcedure: "usp_mlocodeselect",
                param);
            return results;
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<MLoCode>>> Insert([FromBody] MLoCode locode)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Lo_Code", locode.lo_Code);
            param.Add("@Lo_Name", locode.lo_Name);
            param.Add("@Lo_RcCode", locode.lo_RcCode);
            param.Add("@createdate", locode.createDate);
            param.Add("@updatedate", locode.updateDate);
            param.Add("@usercode", locode.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MLoCode, dynamic>(
                    storedProcedure: "usp_mlocodeinsert",
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
                    response.Message = "Lo code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<ActionResult<List<MLoCode>>> Update([FromBody] MLoCode locode)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Lo_Code", locode.lo_Code);
            param.Add("@Lo_Name", locode.lo_Name);
            param.Add("@Lo_RcCode", locode.lo_RcCode);
            param.Add("@createdate", locode.createDate);
            param.Add("@updatedate", locode.updateDate);
            param.Add("@usercode", locode.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MLoCode, dynamic>(
                    storedProcedure: "usp_mlocodeupdate",
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
                    response.Message = "Lo code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<string>> Delete([FromBody] MLoCodeReq locodereq)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Lo_Code", locodereq.lo_Code);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mlocodedelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Lo code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Lo code not exist";
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
