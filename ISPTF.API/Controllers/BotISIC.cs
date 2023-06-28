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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BotISICController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public BotISICController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<BOT_ISIC>> GetAll(string? clfmcode)
        {
            DynamicParameters param = new DynamicParameters();
            if (clfmcode == "" || clfmcode == null)
            {
                param.Add("@CL_FM_CODE", "");
            }
            else
            {
                param.Add("@CL_FM_CODE", clfmcode);
            }
            var results = await _db.LoadData<BOT_ISIC, dynamic>(
                        storedProcedure: "usp_botisicselect",
                        param);
            return results;
        }

        [HttpGet("selectCLFMCode")]
        public async Task<IEnumerable<BOT_ISIC>> GetClfmCode(string? clfmcode)
        {
            DynamicParameters param = new DynamicParameters();

                param.Add("@CL_FM_CODE", clfmcode);

            var results = await _db.LoadData<BOT_ISIC, dynamic>(
                        storedProcedure: "usp_BotISIC_CL_FM_Code_Select",
                        param);
            return results;
        }

        [HttpPost("insert")]
        public async Task<ActionResult<List<BOT_ISIC>>> BotISICInsert([FromBody] BOT_ISIC botisic)
        {
            DynamicParameters param = new();
            param.Add("@CL_Code", botisic.CL_CODE);
            param.Add("CL_FI_Code", botisic.CL_FI_CODE);
            param.Add("CL_FM_Code", botisic.CL_FM_CODE);
            param.Add("@CL_NM_THAI", botisic.CL_NM_THAI);
            param.Add("@CL_NM_ENG", botisic.CL_NM_ENG);
            param.Add("@CL_PCHILD", botisic.CL_PCHILD);
            param.Add("@ATTRIBUTE", botisic.ATTRIBUTE);
            param.Add("@SEQ_ID", botisic.SEQ_ID);
            param.Add("@LASTSEQ", botisic.LASTSEQ);
            param.Add("@STATUS", botisic.STATUS);
            param.Add("@LASTUPDATE", botisic.LASTUPDATE);
            param.Add("@USERID", botisic.USERID);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<BOT_ISIC, dynamic>(
                    storedProcedure: "usp_botisicinsert",
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
                    response.Message = "CL code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<List<BOT_ISIC>>> BotISICUpdate([FromBody] BOT_ISIC botisic)
        {
            DynamicParameters param = new();
            param.Add("@CL_Code", botisic.CL_CODE);
            param.Add("CL_FI_Code", botisic.CL_FI_CODE);
            param.Add("CL_FM_Code", botisic.CL_FM_CODE);
            param.Add("@CL_NM_THAI", botisic.CL_NM_THAI);
            param.Add("@CL_NM_ENG", botisic.CL_NM_ENG);
            param.Add("@CL_PCHILD", botisic.CL_PCHILD);
            param.Add("@ATTRIBUTE", botisic.ATTRIBUTE);
            param.Add("@SEQ_ID", botisic.SEQ_ID);
            param.Add("@LASTSEQ", botisic.LASTSEQ);
            param.Add("@STATUS", botisic.STATUS);
            param.Add("@LASTUPDATE", botisic.LASTUPDATE);
            param.Add("@USERID", botisic.USERID);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<BOT_ISIC, dynamic>(
                    storedProcedure: "usp_botisicupdate",
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
                    response.Message = "CL code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<ActionResult<string>> BotISICDelete([FromBody] BOT_ISICReq botisic)
        {
            DynamicParameters param = new();
            param.Add("@CL_FM_CODE", botisic.CL_FM_CODE);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_botisicdelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp != 0)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "CL FM code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "CL FM code not exist";
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
