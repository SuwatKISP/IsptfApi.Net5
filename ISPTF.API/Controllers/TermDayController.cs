using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace ISPTF.API.Controllers
{
    public class TermDayController : Controller
    {
        private readonly ISqlDataAccess _db;
        public TermDayController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("listpage")]
        public async Task<IEnumerable<TermDayReq>> GetAll(string? TermType, string? CCY_Flag)
        {
            DynamicParameters param = new DynamicParameters();
            if (TermType == "" || TermType == null)
            {
                param.Add("@TermType", "");
            }
            else
            {
                param.Add("@TermType", TermType);
            }
            if (CCY_Flag == "" || CCY_Flag == null)
            {
                param.Add("@CCY_Flag", "");
            }
            else
            {
                param.Add("@CCY_Flag", CCY_Flag);
            }

            var results = await _db.LoadData<TermDayReq, dynamic>(
                        storedProcedure: "usp_AQuote_TermDaySelect",
                        param);
            return results;
        }
        // listpage
        [HttpGet("select")]
        public async Task<IEnumerable<TermDayRsp>> GetSelect(string? TermType, string? TermDesc)
        {
            DynamicParameters param = new();
            param.Add("@TermType", TermType);
            param.Add("@TermDesc", TermDesc);

            var results = await _db.LoadData<TermDayRsp, dynamic>(
                        storedProcedure: "usp_AQuote_TermDaySelect",
                        param);
            return results;
        }
        // Select
  

        
    }
}
