using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InRateCodeController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public InRateCodeController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<MinRateCode>> GetAll(string? inratecode,string? inrateccyflag)
        {
            DynamicParameters param = new DynamicParameters();
            if (inratecode == "" || inratecode == null)
            {
                param.Add("@InRate_Code", "");
            }
            else
            {
                param.Add("@InRate_Code", inratecode);
            }
            if (inrateccyflag == "" || inrateccyflag == null)
            {
                param.Add("@InRate_CcyFlag", "");
            }
            else
            {
                param.Add("@InRate_CcyFlag", inrateccyflag);
            }

            var results = await _db.LoadData<MinRateCode, dynamic>(
                        storedProcedure: "usp_minratecodeselect",
                        param);
            return results;
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<MinRateCode>>>MinRateCodeInsert([FromBody] MinRateCode minratecode)
        {
            DynamicParameters param = new();
            param.Add("@InRate_Code", minratecode.inRate_Code);
            param.Add("@InRate_Name", minratecode.inRate_Name);
            param.Add("@InRate_CcyFlag",minratecode.inRate_CcyFlag);
            param.Add("@CreateDate", minratecode.createDate);
            param.Add("@UpdateDate",minratecode.updateDate);
            param.Add("@UserCode", minratecode.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MinRateCode, dynamic>(
                    storedProcedure: "usp_minratecodeinsert",
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
                    response.Message = "InRate code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<List<MinRateCode>>> MinRateCodeUpdate([FromBody] MinRateCode minratecode)
        {
            DynamicParameters param = new();
            param.Add("@InRate_Code", minratecode.inRate_Code);
            param.Add("@InRate_Name", minratecode.inRate_Name);
            param.Add("@InRate_CcyFlag", minratecode.inRate_CcyFlag);
            param.Add("@CreateDate", minratecode.createDate);
            param.Add("@UpdateDate", minratecode.updateDate);
            param.Add("@UserCode", minratecode.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MinRateCode, dynamic>(
                    storedProcedure: "usp_minratecodeupdate",
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
                    response.Message = "InRate code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<ActionResult<string>> MinRateCodeDelete([FromBody] MinRateCodeReq minratecode)
        {
            DynamicParameters param = new();
            param.Add("@InRate_Code", minratecode.InRate_Code);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_minratecodedelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "InRate code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "InRate code not exist";
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
