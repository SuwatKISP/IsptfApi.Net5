using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models;

namespace ISPTF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlQueryController : ControllerBase
    {
        private readonly IConfiguration _config;
        public SqlQueryController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("sqlquery")]
        public async Task<ActionResult<SqlQuery>> SqlQuerySelect(SqlQuery sqlquery)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters param = new();
                
                param.Add("@TableName", sqlquery.TableName);
                param.Add("@FieldName", sqlquery.FieldName);
                if (sqlquery.Condition == "*" || sqlquery.Condition == null)
                {
                    param.Add("@Condition", "*");
                }
                else
                {
                    param.Add("@Condition", sqlquery.Condition);
                }
                param.Add("@OrderName", sqlquery.OrderName);
                param.Add("@RowCount", sqlquery.RowCount);

                try
                {
                    var tblpages = await connection.QueryAsync
                    ("usp_sqlquery", param, commandType: CommandType.StoredProcedure);
                    Console.WriteLine(tblpages);
                    return Ok(tblpages);
                    //return Ok(new
                    //{
                    //    Success = true,
                    //    Message = "Branch items returned.",
                    //    branchs
                    //});
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }
}
