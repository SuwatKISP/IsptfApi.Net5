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
    public class TitleController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public TitleController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<MTitle>> GetAll(string? titlecode, string? titleflag)
        {
            DynamicParameters param = new DynamicParameters();
            if (titlecode == "*" || titlecode == null)
            {
                param.Add("@Title_Code", "*");
            }
            else
            {
                param.Add("@Title_Code", titlecode);
            }
            if (titleflag == "*" || titleflag == null)
            {
                param.Add("@Title_Flag", "*");
            }
            else
            {
                param.Add("@Title_Flag", titleflag);
            }
            var results = await _db.LoadData<MTitle, dynamic>(
                storedProcedure: "usp_mtitleselect",
                param);
            return results;
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<MTitle>>> Insert([FromBody] MTitle title)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Title_Code", title.title_Code);
            param.Add("@Title_Name", title.title_Name);
            param.Add("@createdate", title.createDate);
            param.Add("@updatedate", title.updateDate);
            param.Add("@usercode", title.userCode);
            param.Add("@Title_Flag", title.title_Flag);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MTitle, dynamic>(
                    storedProcedure: "usp_mtitleinsert",
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
                    response.Message = "Title code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update")]
        public async Task<ActionResult<List<MTitle>>> Update([FromBody] MTitle title)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Title_code", title.title_Code);
            param.Add("@Title_Name", title.title_Name);
            param.Add("@createdate", title.createDate);
            param.Add("@updatedate", title.updateDate);
            param.Add("@usercode", title.userCode);
            param.Add("@Title_Flag", title.title_Flag);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MTitle, dynamic>(
                    storedProcedure: "usp_mtitleupdate",
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
                    response.Message = "Title code not exist";
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
        public async Task<ActionResult<string>> Delete([FromBody] MTitleReq titlereq)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Title_Code", titlereq.title_Code);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mtitledelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Title code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Title code not exist";
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
