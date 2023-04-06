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
    public class SystemDateTimeController : ControllerBase
    {
        private readonly ILogger<SystemDateTimeController> _logger;
        private readonly IConfiguration _config;

        public SystemDateTimeController(ISqlDataAccess db, ILogger<SystemDateTimeController> logger,IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public ActionResult<SystemDateTime> Get()
        {
            DynamicParameters param = new();
            var sql = "select dbo.systemdatetime() as SysDateTime";
            var connectionId = "DefaultConnection";
            try
            {
                using (var connection = new SqlConnection(_config.GetConnectionString(connectionId)))
                {
                    var results = connection.Query<SystemDateTime>(sql, param);
                    
                    return Ok(results);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
