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
    public class MapSWIFTController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public MapSWIFTController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAll(string? mttype, string? fdnumber)
        {
            DynamicParameters param = new();
            if (mttype == "*" || mttype == null)
            {
                param.Add("@MTType", "*");
            }
            else
            {
                param.Add("@MTType", mttype);
            }
            if (fdnumber == "*" || fdnumber == null)
            {
                param.Add("@fdnumber", "*");
            }
            else
            {
                param.Add("@FDNumber", fdnumber);
            }
            param.Add("@CRsp", dbType: DbType.Int32,
                  direction: System.Data.ParameterDirection.Output,
                  size: 128);
            //param.Add("@CCustRsp", dbType: DbType.String,
            //       direction: System.Data.ParameterDirection.Output,
            //       size: 5215585);
            try
            {
                var results = await _db.LoadData<MMapSWIFT, dynamic>(
                         storedProcedure: "usp_mmapswiftselect",
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
                    response.Message = "MTType / FDNumber not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<PHoliday>>> MapSwiftInsert([FromBody] MMapSWIFT code)
        {
            DynamicParameters param = new();
            param.Add("@MTType", code.mtType);
            param.Add("@FDNumber", code.fdNumber);
            param.Add("@FDName", code.fdName);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);

            //param.Add("@CCustRsp", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);
            try
            {
                var results = await _db.LoadData<MMapSWIFT, dynamic>(
                    storedProcedure: "usp_mmapswiftinsert",
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
                    response.Message = "MTType / FDNumber exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("update")]
        public async Task<ActionResult<List<PHoliday>>> MapSWIFTUpdate([FromBody] MMapSWIFT code)
        {
            DynamicParameters param = new();
            param.Add("@MTType", code.mtType);
            param.Add("@FDNumber", code.fdNumber);
            param.Add("@FDName", code.fdName);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);
            //param.Add("@CCustRsp", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);
            try
            {
                var results = await _db.LoadData<MMapSWIFT, dynamic>(
                    storedProcedure: "usp_mmapswiftupdate",
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
                    response.Message = "MTType / FDNumber not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("delete")]
        public async Task<ActionResult<string>> MapSWIFTDelete([FromBody] MMapSWIFTCodeReq code)
        {
            DynamicParameters param = new();
            param.Add("@MTType", code.mtType);
            param.Add("@FDNumber", code.fdNumber);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mmapswiftdelete", param);
                var resp = param.Get<int>("@CRsp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "MTType / FDNumber is deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "MTType / FDNumber not exist";
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
