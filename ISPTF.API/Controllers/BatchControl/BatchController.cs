using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.BatchControl;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISPTF.API.Controllers.BatchControl
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public BatchController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("BatchLogQuery")]
        public async Task<IEnumerable<BatchLogQuery>> GetAll(string WorkDate)
        {
            DynamicParameters param = new();
            param.Add("@WorkDate", WorkDate);

            var results = await _db.LoadData<BatchLogQuery, dynamic>(
                        storedProcedure: "usp_Batch_LogQuery",
                        param);
            return results;
        }
        // BatchLogQuery
        [HttpGet("BTBatchLogQuery")]
        public async Task<IEnumerable<BTBatchLogQuery>> GetAllBT(string WorkDate)
        {
            DynamicParameters param = new();
            param.Add("@WorkDate", WorkDate);

            var results = await _db.LoadData<BTBatchLogQuery, dynamic>(
                        storedProcedure: "usp_BatchBT_LogQuery",
                        param);
            return results;
        }
        // BatchLogQuery
    }//main
}

