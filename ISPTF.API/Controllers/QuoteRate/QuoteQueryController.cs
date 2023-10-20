using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.QuoteRate;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ISPTF.API.Controllers.QuoteRate
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteQueryController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public QuoteQueryController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("listpage")]
        // Listpage  add parameter  ,int? Page, int? PageSize
        public async Task<IEnumerable<QuoteQINTListDay>> GetAll(string RateDate, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@RateDate", RateDate);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (RateDate == null)
            {
                param.Add("@Status", "");
            }

            var results = await _db.LoadData<QuoteQINTListDay, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteQINTListDay",
                        param);
            return results;
        }
        // Listpage    }
        [HttpGet("listhistory")]
        // Listpage  add parameter  ,int? Page, int? PageSize
        public async Task<IEnumerable<QuoteQINTListHist>> GetAllX(string RateDate, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@RateDate", RateDate);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (RateDate == null)
            {
                param.Add("@Status", "");
            }

            var results = await _db.LoadData<QuoteQINTListHist, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteQINTListHist",
                        param);
            return results;
        }
        // ListpageHist    }
        public async Task<IEnumerable<QuoteQINTListLog>> GetAllG(string RateDate, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@RateDate", RateDate);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (RateDate == null)
            {
                param.Add("@Status", "");
            }

            var results = await _db.LoadData<QuoteQINTListLog, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteQINTListLog",
                        param);
            return results;
        }
        // ListpageLog    }
        [HttpGet("selectLog")]
        public async Task<IEnumerable<QuoteQINTSelectLog>> GetSel(string Txn_ID,int SeqNo)
        {
            DynamicParameters param = new();
            param.Add("@Txn_ID", Txn_ID);
            param.Add("@SeqNo", SeqNo);

            var results = await _db.LoadData<QuoteQINTSelectLog, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteQINTSelectLog",
                        param);
            return results;
        }
        // Select
    }
}
