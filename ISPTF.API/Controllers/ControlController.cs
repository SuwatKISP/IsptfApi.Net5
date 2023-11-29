using Dapper;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public class ControlController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public ControlController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<MControl>> GetAll(string? ctltype, string? ctlcode,string? ctlid,string? ctldesc, string? ctlname)
        {

            ctlid = "";
            ctldesc = "";
            ctlname = "";
            DynamicParameters param = new DynamicParameters();
            if (ctltype == "*" || ctltype == null)
            {
                param.Add("@CTL_Type", "*");
            }
            else
            {
                param.Add("@CTL_Type", ctltype);
            }

            if (ctlcode == "*" || ctlcode == null)
            {
                param.Add("@CTL_code", "*");
            }
            else
            {
                param.Add("@CTL_code", ctlcode);
            }

            if (ctlid == "*" || ctlid == null)
            {
                param.Add("@CTL_ID", "*");
            }
            else
            {
                param.Add("@CTL_ID", ctlid);
            }
            if (ctldesc == "*" || ctldesc == null)
            {
                param.Add("@CTL_DESC", "*");
            }
            else
            {
                param.Add("@CTL_DESC", ctldesc);
            }

            if (ctlname == "*" || ctlname == null)
            {
                param.Add("@CTL_Name", "*");
            }
            else
            {
                param.Add("@CTL_Name", ctlname);
            }
            
            var results = await _db.LoadData<MControl, dynamic>(
                storedProcedure: "usp_mcontrolselect",
                param);
            return results;
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<MControl>>> Insert([FromBody] MControl control)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CTL_Type", control.ctL_Type);
            param.Add("@CTL_Code", control.ctL_Code);
            param.Add("@CTL_ID", control.ctL_ID);
            param.Add("@CTL_Name", control.ctL_Name);
            param.Add("@CTL_Desc", control.ctL_Desc);
            param.Add("@CTL_Note1", control.ctL_Note1);
            param.Add("@CTL_Note2", control.ctL_Note2);
            param.Add("@CTL_Val1", control.ctL_Val1);
            param.Add("@CTL_Val2", control.ctL_Val2);
            param.Add("@CTL_Seq1", control.ctL_Seq1);
            param.Add("@CTL_Seq2", control.ctL_Seq2);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MControl, dynamic>(
                    storedProcedure: "usp_mcontrolinsert",
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
                    response.Message = "Control ID exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            await _db.SaveData(
                storedProcedure: "usp_mcontrolinsert",
                param);
        }
        [HttpPost("update")]
        public async Task<ActionResult<List<MControl>>> Update([FromBody] MControl control)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CTL_Type", control.ctL_Type);
            param.Add("@CTL_Code", control.ctL_Code);
            param.Add("@CTL_ID", control.ctL_ID);
            param.Add("@CTL_Name", control.ctL_Name);
            param.Add("@CTL_Desc", control.ctL_Desc);
            param.Add("@CTL_Note1", control.ctL_Note1);
            param.Add("@CTL_Note2", control.ctL_Note2);
            param.Add("@CTL_Val1", control.ctL_Val1);
            param.Add("@CTL_Val2", control.ctL_Val2);
            param.Add("@CTL_Seq1", control.ctL_Seq1);
            param.Add("@CTL_Seq2", control.ctL_Seq2);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MControl, dynamic>(
                    storedProcedure: "usp_mcontrolupdate",
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
                    response.Message = "CL code not exist";
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
        public async Task<ActionResult<string>> Delete([FromBody] MControlReq mcontrolreq)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CTL_Type", mcontrolreq.ctL_Type);
            param.Add("@CTL_code", mcontrolreq.ctL_Code);
            param.Add("@CTL_ID", mcontrolreq.ctL_ID);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mcontroldelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Control code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Control  code not exist";
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
