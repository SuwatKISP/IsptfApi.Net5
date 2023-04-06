using Dapper;
using ISPTF.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers.Functions
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlQueryStringController : ControllerBase
    {
        private readonly IConfiguration _config;
        public SqlQueryStringController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("sqlquerystring")]
        public ActionResult<dynamic> PostQuery([FromBody] SqlQueryString sqlstring)
        {
            //DynamicParameters param = new();
            var connectionId = "DefaultConnection";
            try
            {
                using (var connection = new SqlConnection(_config.GetConnectionString(connectionId)))
                {
                    var results = connection.Query<dynamic>(sqlstring.SqlQueryStr);

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
