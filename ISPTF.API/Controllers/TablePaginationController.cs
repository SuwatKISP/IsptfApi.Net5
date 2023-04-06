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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TablePaginationController : ControllerBase
    {
        private readonly IConfiguration _config;
        public TablePaginationController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        [Route("tablepage")]
        public async Task<ActionResult<TablePaginationRowCount>> PaginationSelect(TablePagination tablePagination)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {
                DynamicParameters param = new DynamicParameters();
                if (tablePagination.Condition == "*" || tablePagination.Condition == null)
                {
                    param.Add("@Condition", "*");
                }
                else
                {
                    param.Add("@Condition", tablePagination.Condition);
                }
                param.Add("@TableName",tablePagination.TableName);
                //param.Add("@ConditionName", tablePagination.ConditionName);
                //param.Add("@ConditionValue", tablePagination.ConditionValue);
                param.Add("@OrderName",tablePagination.OrderName);
                param.Add("@Page", tablePagination.Page);
                param.Add("@PageSize",tablePagination.PageSize);
            
                try
                {
                    var tblpages = await connection.QueryAsync
                    ("usp_variabletable", param, commandType: CommandType.StoredProcedure);
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
