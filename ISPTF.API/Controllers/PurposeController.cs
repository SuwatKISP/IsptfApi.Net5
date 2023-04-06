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
    public class PurposeController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public PurposeController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAll(string? code)
        {
            DynamicParameters param = new();
            if (code == "*" || code == null)
            {
                param.Add("@Pur_code", "*");
            }
            else
            {
                param.Add("@Pur_code", code);
            }
            param.Add("@CRsp", dbType: DbType.Int32,
                  direction: System.Data.ParameterDirection.Output,
                  size: 128);
            //param.Add("@CCustRsp", dbType: DbType.String,
            //       direction: System.Data.ParameterDirection.Output,
            //       size: 5215585);
            try
            {
                var results = await _db.LoadData<MPurpose, dynamic>(
                         storedProcedure: "usp_mpurposeselect",
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
                    response.Message = "Purpose code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<MPurposeRsp>>> PurposeInsert([FromBody] MPurpose code)
        {
            DynamicParameters param = new();
            param.Add("@Pur_Code", code.pur_Code);
            param.Add("@Pur_Desc", code.pur_Desc);
            param.Add("@UserCode", code.userCode);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);

            //param.Add("@CCustRsp", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);
            try
            {
                var results = await _db.LoadData<MPurpose, dynamic>(
                    storedProcedure: "usp_mpurposeinsert",
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
                    response.Message = "Purpose code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("update")]
        public async Task<ActionResult<List<MPurposeRsp>>> PurposeUpdate([FromBody] MPurpose code)
        {
            DynamicParameters param = new();
            param.Add("@Pur_Code", code.pur_Code);
            param.Add("@Pur_Desc", code.pur_Desc);
            param.Add("@UserCode", code.userCode);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);

            //param.Add("@CCustRsp", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);
            try
            {
                var results = await _db.LoadData<MPurpose, dynamic>(
                    storedProcedure: "usp_mpurposeupdate",
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
                    response.Message = "Purpose code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("delete")]
        public async Task<ActionResult<string>>PurposDelete([FromBody] MPurposeCodeReq code)
        {
            DynamicParameters param = new();
            param.Add("@Pur_Code", code.pur_Code);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mpurposedelete", param);
                var resp = param.Get<int>("@CRsp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Purpose code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Purpose code not exist";
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
