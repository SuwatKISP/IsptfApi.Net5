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




namespace ISPTF.API.Controllers.SetSWIFTValueController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetSWIFTValueController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public SetSWIFTValueController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("select")]
        public async Task<IEnumerable<MSetSWIFTValueRsp>> GetAll(string centercode, string parameter)
        {
            DynamicParameters param = new();
            param.Add("@CenterCode", centercode);
            param.Add("@Parameter", parameter);

            var results = await _db.LoadData<MSetSWIFTValueRsp, dynamic>(
                        storedProcedure: "usp_SetSWValueSelect",
                        param);
            return results;
        }
        [HttpGet("editlist")]
        public async Task<IEnumerable<MSetSWIFTValueRsp>> GetSetSWValue( string ? centercode, string ? parameter, string Page, string PageSize)
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
            if (parameter == null)
            {
                param.Add("@Parameter", "");
            }
            else
            {
                param.Add("@Parameter", parameter);
            }
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            var results = await _db.LoadData<MSetSWIFTValueRsp, dynamic>(
                        storedProcedure: "usp_SetSWValueGet",
                        param);
            return results; 
        }
 
        [HttpPost("insert")]
        public async Task<ActionResult<List<MSetSWIFTValue>>> Insert([FromBody] MSetSWIFTValue SWValue)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CenterCode", SWValue.CenterCode);
            param.Add("@Parameter", SWValue.Parameter);
            param.Add("@DataValue", SWValue.DataValue);
            param.Add("@SwiftAuto", SWValue.SwiftAuto);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MSetSWIFTValue, dynamic>(
                    storedProcedure: "usp_SetSWValueInsert",
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
                    response.Message = "Set Swift Value code exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//insert
        [HttpPost("update")]
        public async Task<ActionResult<List<MSetSWIFTValue>>> Update([FromBody] MSetSWIFTValue SWValue)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CenterCode", SWValue.CenterCode);
            param.Add("@Parameter", SWValue.Parameter);
            param.Add("@DataValue", SWValue.DataValue);
            param.Add("@SwiftAuto", SWValue.SwiftAuto);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<MSetSWIFTValue, dynamic>(
                    storedProcedure: "usp_SetSWValueUpdate",
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
                    response.Message = "Set Swift Value not exist";
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
