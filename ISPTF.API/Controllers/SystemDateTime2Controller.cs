using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers.Functions
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemDateTime2Controller : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public SystemDateTime2Controller(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<SystemDateTime2>> GetSysDateTime()
        {
            var sysdatetime=ISPTF.Commons.ModDate.GetSystemDateTime();
            DynamicParameters param = new();
            var results = await _db.LoadData<SystemDateTime2, dynamic>(
            storedProcedure: "usp_GetSysDateTime2",param);
            return results;
           
        }
    }
}
