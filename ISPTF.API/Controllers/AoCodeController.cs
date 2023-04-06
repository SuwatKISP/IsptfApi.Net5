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
    public class AoCodeController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public AoCodeController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<MAoCode>> GetAll( string aocode)
        {
            DynamicParameters param = new DynamicParameters();
            if (aocode == "*" || aocode == null)
            {
                param.Add("@Ao_code", "*");
            }
            else
            {
                param.Add("@Ao_code", aocode);
            }
            var results = await _db.LoadData<MAoCode, dynamic>(
                        storedProcedure: "usp_maocodeselect",
                        param);
            return results;
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<MAoCode>>> Insert([FromBody] MAoCode aocode)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Ao_Code", aocode.ao_Code);
            param.Add("@Ao_Name", aocode.ao_Name);
            param.Add("@Ao_RcCode", aocode.ao_RcCode);
            param.Add("@createdate", aocode.createDate);
            param.Add("@updatedate", aocode.updateDate);
            param.Add("@usercode", aocode.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MAoCode, dynamic>(
                    storedProcedure: "usp_maocodeinsert",
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
                    response.Message = "Ao code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
        [HttpPost("update")]
        public async Task<ActionResult<List<MAoCode>>>Update([FromBody] MAoCode aocode)
        {
            DynamicParameters param = new ();
            param.Add("@Ao_Code", aocode.ao_Code);
            param.Add("@Ao_Name", aocode.ao_Name);
            param.Add("@Ao_RcCode", aocode.ao_RcCode);
            param.Add("@createdate", aocode.createDate);
            param.Add("@updatedate", aocode.updateDate);
            param.Add("@usercode", aocode.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MAoCode, dynamic>(
                    storedProcedure: "usp_maocodeupdate",
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(results);
                    //return Ok("Branch code deleted");
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Ao code not exist";
                    return BadRequest(response);
                    //return BadRequest("Branch code not exist");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<string>> Delete([FromBody] MAoCodeReq aocodereq)
        { 
            DynamicParameters param = new DynamicParameters();
            param.Add("@Ao_Code", aocodereq.ao_Code);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_maocodedelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Ao code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Ao code not exist";
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
