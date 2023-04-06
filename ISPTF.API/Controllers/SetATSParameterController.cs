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


namespace ISPTF.API.Controllers.SetATSParameterController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetATSParameterController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public SetATSParameterController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("SetATSParameterGet")]
        public async Task<IEnumerable<MSetATSParameter>> GetAll()
        {
            DynamicParameters param = new();
            var results = await _db.LoadData<MSetATSParameter, dynamic>(
                        storedProcedure: "usp_ATSParameterGet",param);
            return results;
        }
        [HttpPost("SetATSParameter")]
        public async Task<ActionResult<List<MSetATSParameter>>> SetATSParameter([FromBody] MSetATSParameter ATSValue)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@TRStartDate", ATSValue.TRStartDate);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<MSetATSParameter, dynamic>(
                    storedProcedure: "usp_SetATSParameter",
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
    }//main
}
