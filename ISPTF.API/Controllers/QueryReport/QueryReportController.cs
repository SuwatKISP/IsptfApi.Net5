using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.API.Controllers.QueryReport
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueryReportController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public QueryReportController(ISqlDataAccess db)
        {
            _db = db;
        }
        [HttpGet("pMonthlyInterest/selectDistinct")]
        public async Task<IEnumerable<pMonthlyInterestSelect>> GetAll(string? DocMonth, DateTime? CalDate)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@DocMonth", DocMonth);
            param.Add("@CalDate", CalDate);


            var results = await _db.LoadData<pMonthlyInterestSelect, dynamic>(
                storedProcedure: "usp_pMonthlyInterestSelectDis",
                param);
            return results;
        }
        [HttpGet("ViewMapAccount/selectSAPAccount")]
        public async Task<IEnumerable<ViewMapAccountSelect>> GetselectSAT(string? Acc_Code)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Acc_Code", Acc_Code);

            var results = await _db.LoadData<ViewMapAccountSelect, dynamic>(
                storedProcedure: "usp_ViewMapAccountSelect",
                param);
            return results;
        }
    }
}
