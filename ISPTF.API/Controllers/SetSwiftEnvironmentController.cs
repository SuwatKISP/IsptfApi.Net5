using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace ISPTF.API.Controllers.SetSwiftEnvironmentController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetSwiftEnvironmentController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public SetSwiftEnvironmentController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("select")]
        public async Task<IEnumerable<MSetSwiftEnvironmentRsp>> GetAll(string centercode, string datavalue)
        {
            DynamicParameters param = new();
            param.Add("@CenterCode", centercode);
            param.Add("@DataValue", datavalue);

            var results = await _db.LoadData<MSetSwiftEnvironmentRsp, dynamic>(
                        storedProcedure: "usp_SetSWEnviSelect",
                        param);
            return results;
        }
        [HttpGet("editlist")]
        public async Task<IEnumerable<MSetSwiftEnvironmentRsp>> GetSetSWEnvi( string ? centercode, string ? datavalue, string Page, string PageSize)
        {
            DynamicParameters param = new();

            if (centercode == null)
            {
                param.Add("@CenterCode", "");
            }
            else
            {
                param.Add("@CenterCode", centercode);
            }
            if (datavalue == null)
            {
                param.Add("@datavalue", "");
            }
            else
            {
                param.Add("@datavalue", datavalue);
            }
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            var results = await _db.LoadData<MSetSwiftEnvironmentRsp, dynamic>(
                        storedProcedure: "usp_SetSWEnviGet",
                        param);
            return results; 
        }
 
        [HttpPost("insert")]
        public async Task<ActionResult<List<MSetSwiftEnvironment>>> Insert([FromBody] MSetSwiftEnvironment SWValue)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CenterCode", SWValue.CenterCode);
            param.Add("@DataValue", SWValue.DataValue);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MSetSwiftEnvironment, dynamic>(
                    storedProcedure: "usp_SetSWEnviInsert",
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
                    response.Message = "Set Swift Environment  exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//insert
        [HttpPost("update")]
        public async Task<ActionResult<List<MSetSwiftEnvironment>>> Update([FromBody] MSetSwiftEnvironment SWValue)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CenterCode", SWValue.CenterCode);
            param.Add("@DataValue", SWValue.DataValue);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MSetSwiftEnvironment, dynamic>(
                    storedProcedure: "usp_SetSWEnviUpdate",
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
                    response.Message = "Set Swift Environment not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//update
   
   
    }//main
}
