using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.InUse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers.InUse
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateInUseController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public UpdateInUseController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpPost("")]
        public async Task<ActionResult<List<UpdateInUseReq>>> Update([FromBody] UpdateInUseReq updateinuse)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Module", updateinuse.Module);
            param.Add("@FuncType", updateinuse.Function);
            param.Add("@DocNumber", updateinuse.DocNumber);
            param.Add("@EventNo", updateinuse.EventNo);
            param.Add("@InUse", updateinuse.InUse);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                var results = await _db.LoadData<UpdateInUseReq, dynamic>(
                    storedProcedure: "usp_UpdateInUse",
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
                    response.Message = "Update InUse Not Complete";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CheckInuse")]
        public async Task<ActionResult<List<CheckInUseReq>>> chkinuse([FromBody] CheckInUseReq updateinuse)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Module", updateinuse.Module);
            param.Add("@DocNumber", updateinuse.DocNumber);
            param.Add("@EventNo", updateinuse.EventNo);
            param.Add("@RecType", updateinuse.RecordType);

            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            param.Add("@ResInuse", dbType: DbType.String,
           direction: System.Data.ParameterDirection.Output,
           size: 5215585);
            try
            {
                var results = await _db.LoadData<UpdateInUseReq, dynamic>(
                    storedProcedure: "usp_CheckInUse",
                    param);
                var resp = param.Get<int>("@Resp");
                var resinuse = param.Get<string>("@ResInuse");
                if (resp == 1)
                {
                    return Ok(resinuse);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Update InUse Not Complete";
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
