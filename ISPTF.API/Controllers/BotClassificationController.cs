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
    public class BotClassificationController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public BotClassificationController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<BOT_Classification>> GetAll(string? clscmid,string? prnclid)
        {
            DynamicParameters param = new DynamicParameters();
            if (clscmid == "" || clscmid == null)
            {
                param.Add("@CL_SCM_ID", "");
            }
            else
            {
                param.Add("@CL_SCM_ID", clscmid);
            }
            if (prnclid == "" || prnclid == null)
            {
                param.Add("@PRN_CL_ID", "");
            }
            else
            {
                param.Add("@PRN_CL_ID", prnclid);
            }
            var results = await _db.LoadData<BOT_Classification, dynamic>(
                        storedProcedure: "usp_botclassificationselect",
                        param);
            return results;
        }

        [HttpGet("selectCLID")]
        public async Task<IEnumerable<BOT_Classification>> GetCLID(string? clid)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CL_ID", clid);

            //if (clid == "" || clid == null)
            //{
            //    param.Add("@CL_ID", "");
            //}

            var results = await _db.LoadData<BOT_Classification, dynamic>(
                        storedProcedure: "usp_BotClassificationCLIDSelect",
                        param);
            return results;
        }

        [HttpPost("insert")]
        public async Task<ActionResult<List<BOT_Classification>>> BotClassificationInsert([FromBody] BOT_Classification botclassification)
        {
            DynamicParameters param = new();
            param.Add("@CL_SCM_ID", botclassification.CL_SCM_ID);
            param.Add("@CL_SCM_NM", botclassification.CL_SCM_NM);
            param.Add("@CL_ID",botclassification.CL_ID);
            param.Add("@CL_NM_ENG", botclassification.CL_NM_ENG);
            param.Add("@CL_NM_THAI", botclassification.CL_NM_THAI);
            param.Add("@CL_NM_USED", botclassification.CL_NM_USED);
            param.Add("@PRN_CL_ID", botclassification.PRN_CL_ID);
            param.Add("@CL_ATTRIB", botclassification.CL_ATTRIB);
            param.Add("@SEQ_ID", botclassification.SEQ_ID);
            param.Add("@SEQ_NO", botclassification.SEQ_NO);
            param.Add("@LASTSEQ", botclassification.LASTSEQ);
            param.Add("@STATUS", botclassification.STATUS);
            param.Add("@LASTUPDATE", botclassification.LASTUPDATE);
            param.Add("@USERID", botclassification.USERID);
            param.Add("@RWA", botclassification.RWA);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<BOT_Classification, dynamic>(
                    storedProcedure: "usp_botclassificationinsert",
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
                    response.Message = "BOT code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("update")]
        public async Task<ActionResult<List<BOT_Classification>>> BotISICUpdate([FromBody] BOT_Classification botclassification)
        {
            DynamicParameters param = new();
            param.Add("@CL_SCM_ID", botclassification.CL_SCM_ID);
            param.Add("@CL_SCM_NM", botclassification.CL_SCM_NM);
            param.Add("@CL_ID", botclassification.CL_ID);
            param.Add("@CL_NM_ENG", botclassification.CL_NM_ENG);
            param.Add("@CL_NM_THAI", botclassification.CL_NM_THAI);
            param.Add("@CL_NM_USED", botclassification.CL_NM_USED);
            param.Add("@PRN_CL_ID", botclassification.PRN_CL_ID);
            param.Add("@CL_ATTRIB", botclassification.CL_ATTRIB);
            param.Add("@SEQ_ID", botclassification.SEQ_ID);
            param.Add("@SEQ_NO", botclassification.SEQ_NO);
            param.Add("@LASTSEQ", botclassification.LASTSEQ);
            param.Add("@STATUS", botclassification.STATUS);
            param.Add("@LASTUPDATE", botclassification.LASTUPDATE);
            param.Add("@USERID", botclassification.USERID);
            param.Add("@RWA", botclassification.RWA);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<BOT_Classification, dynamic>(
                    storedProcedure: "usp_botclassificationupdate",
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
                    response.Message = "BOT code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<ActionResult<string>> BotClassificationDelete([FromBody] BOT_ClassificationReq botclass)
        {
            DynamicParameters param = new();
            param.Add("@CL_ID", botclass.CL_ID);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_botclassificationdelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "CL code deleted";
                    return Ok(response);
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

    }
}
