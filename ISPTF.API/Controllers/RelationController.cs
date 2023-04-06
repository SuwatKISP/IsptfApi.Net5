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
    public class RelationController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public RelationController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<MRelation>> GetAll(string? relcode)
        {
            DynamicParameters param = new DynamicParameters();
            if (relcode == "*" || relcode == null)
            {
                param.Add("@Rel_Code", "*");
            }
            else
            {
                param.Add("@Rel_Code", relcode);
            }
            var results = await _db.LoadData<MRelation, dynamic>(
                        storedProcedure: "usp_mrelationselect",
                        param);
            return results;
        }
        [HttpPost("insert")]
        public async Task<ActionResult<List<MRelation>>> RelationInsert([FromBody] MRelation relation)
        {
            DynamicParameters param = new();
            param.Add("@Rel_Code", relation.rel_Code);
            param.Add("@Rel_Desc", relation.rel_Desc);
            param.Add("@CreateDate", relation.createDate);
            param.Add("@UpdateDate", relation.updateDate);
            param.Add("@UserCode", relation.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MRelation, dynamic>(
                    storedProcedure: "usp_mrelationinsert",
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
                    response.Message = "Relation code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        public async Task<ActionResult<List<MRelation>>> RelationUpdate([FromBody] MRelation relation)
        {
            DynamicParameters param = new();
            param.Add("@Rel_Code", relation.rel_Code);
            param.Add("@Rel_Desc", relation.rel_Desc);
            param.Add("@CreateDate", relation.createDate);
            param.Add("@UpdateDate", relation.updateDate);
            param.Add("@UserCode", relation.userCode);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MRelation, dynamic>(
                    storedProcedure: "usp_mrelationupdate",
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
                    response.Message = "Relation code not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("delete")]
        public async Task<ActionResult<string>> RelationDelete([FromBody] MRelationReq relcodereq)
        {
            DynamicParameters param = new();
            param.Add("@Rel_Code", relcodereq.rel_Code);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_mrelationdelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Relation code deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Relation code not exist";
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
