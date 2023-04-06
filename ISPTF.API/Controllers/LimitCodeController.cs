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
    public class LimitCodeController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public LimitCodeController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetAll(string? limitcode)
        {
            DynamicParameters param = new();
            if (limitcode == "*" || limitcode == null)
            {
                param.Add("@Limit_code", "*");
            }
            else
            {
                param.Add("@Limit_code", limitcode);
            }
            param.Add("@CRsp", dbType: DbType.Int32,
                  direction: System.Data.ParameterDirection.Output,
                  size: 128);
            //param.Add("@CCustRsp", dbType: DbType.String,
            //       direction: System.Data.ParameterDirection.Output,
            //       size: 5215585);
            try
            {
                var results = await _db.LoadData<MLimitCodeRsp, dynamic>(
                         storedProcedure: "usp_mlimitcodeselect",
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
                    response.Message = "Limit code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<MLimitCodeRsp>>> LimitCodeInsert([FromBody] MLimitCode limitcode)
        {
            DynamicParameters param = new();
            param.Add("@Limit_Code", limitcode.limit_Code);
            param.Add("@Limit_Name", limitcode.limit_Name);
            param.Add("@Limit_UseFor", limitcode.limit_UseFor);
            param.Add("@Limit_UseCcy", limitcode.limit_UseCcy);
            param.Add("@Limit_IMEX", limitcode.limit_IMEX);
            param.Add("@Limit_IMLC", limitcode.limit_IMLC);
            param.Add("@Limit_IMTR", limitcode.limit_IMTR);
            param.Add("@Limit_EXLC", limitcode.limit_EXLC);
            param.Add("@Limit_EXBC", limitcode.limit_EXBC);
            param.Add("@Limit_EXPC", limitcode.limit_EXPC);
            param.Add("@Limit_DLC", limitcode.limit_DLC);
            param.Add("@Limit_IMP", limitcode.limit_IMP);
            param.Add("@Limit_EXP", limitcode.limit_EXP);
            param.Add("@Limit_LG", limitcode.limit_LG);
            param.Add("@UserCode", limitcode.userCode);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);

            //param.Add("@CCustRsp", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);
            try
            {
                var results = await _db.LoadData<MLimitCode, dynamic>(
                    storedProcedure: "usp_mlimitcodeinsert",
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
                    response.Message = "Limit code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("update")]
        public async Task<ActionResult<List<MLimitCodeRsp>>> LimitCodeUpdate([FromBody] MLimitCode limitcode)
        {
            DynamicParameters param = new();
            param.Add("@Limit_Code", limitcode.limit_Code);
            param.Add("@Limit_Name", limitcode.limit_Name);
            param.Add("@Limit_UseFor", limitcode.limit_UseFor);
            param.Add("@Limit_UseCcy", limitcode.limit_UseCcy);
            param.Add("@Limit_IMEX", limitcode.limit_IMEX);
            param.Add("@Limit_IMLC", limitcode.limit_IMLC);
            param.Add("@Limit_IMTR", limitcode.limit_IMTR);
            param.Add("@Limit_EXLC", limitcode.limit_EXLC);
            param.Add("@Limit_EXBC", limitcode.limit_EXBC);
            param.Add("@Limit_EXPC", limitcode.limit_EXPC);
            param.Add("@Limit_DLC", limitcode.limit_DLC);
            param.Add("@Limit_IMP", limitcode.limit_IMP);
            param.Add("@Limit_EXP", limitcode.limit_EXP);
            param.Add("@Limit_LG", limitcode.limit_LG);
            param.Add("@UserCode", limitcode.userCode);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);

            //param.Add("@CCustRsp", dbType: DbType.String,
            //   direction: System.Data.ParameterDirection.Output,
            //   size: 5215585);
            try
            {
                var results = await _db.LoadData<MLimitCode, dynamic>(
                    storedProcedure: "usp_mlimitcodeupdate",
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
                    response.Message = "Limit code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("delete")]
        public async Task<ActionResult<string>> LimitCodeDelete([FromBody] MLimitCodeReq limitcode)
        {
            DynamicParameters param = new();
            param.Add("@Limit_Code", limitcode.Limit_Code);
            param.Add("@CRsp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 128);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mlimitcodedelete", param);
                var resp = param.Get<int>("@CRsp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Limit code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Limit code not exist or was already used, Cannot delete";
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
