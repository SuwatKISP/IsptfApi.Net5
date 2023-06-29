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

        [HttpGet("RemittanceReport/DailyTransaction/ListRefundTax")]
        public async Task<IEnumerable<TmpRefundTaxReport>> GetRemittRefundTax(string? CenterID, string? CustCode , DateTime? TranDateFrom, DateTime? TranDateTo, string? Module)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@modTrd", "N");
            param.Add("@CenterID", CenterID);
            param.Add("@CustCode", CustCode);
            param.Add("@TranDateFrom", TranDateFrom);
            param.Add("@TranDateTo", TranDateTo);
            param.Add("@Module", Module);

            if (Module == "" || Module == null)
            {
                param.Add("@Module", null);
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }


            var results = await _db.LoadData<TmpRefundTaxReport, dynamic>(
                storedProcedure: "usp_QReport_DailyTran_RefundTax",
                param);
            return results;
        }

        [HttpGet("RemittanceReport/QueryDataComm")]
        public async Task<IEnumerable<TmpCommReport>> GetRemittDailyComm(string? CenterID, string? CustCode, string? CollRefund, DateTime? TranDate)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CenterID", CenterID);
            param.Add("@CustCode", CustCode);
            param.Add("@CollRefund", CollRefund);
            param.Add("@TranDate", TranDate);

            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }

            var results = await _db.LoadData<TmpCommReport, dynamic>(
                storedProcedure: "usp_QReport_Remitt_Commission",
                param);
            return results;
        }

        [HttpGet("TradeFinanceReport/DailyTransaction/ListRefundTax")]
        public async Task<IEnumerable<TmpRefundTaxReport>> GetTradeRefundTax(string? CenterID, string? CustCode , DateTime? TranDateFrom, DateTime? TranDateTo,string? Module)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@modTrd", "Y");
            param.Add("@CenterID", CenterID);
            param.Add("@CustCode", CustCode);
            param.Add("@TranDateFrom", TranDateFrom);
            param.Add("@TranDateTo", TranDateTo);
            param.Add("@Module", Module);

            if (Module == "" || Module == null)
            {
                param.Add("@Module", null);
            }
            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }
            var results = await _db.LoadData<TmpRefundTaxReport, dynamic>(
                storedProcedure: "usp_QReport_DailyTran_RefundTax",
                param);
            return results;
        }

        [HttpGet("TradeFinanceReport/QueryDataFX")]
        public async Task<IEnumerable<TmpForwardReport>> GetTradDataFX(string? CenterID, string? CustCode, DateTime? TranDate)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CenterID", CenterID);
            param.Add("@CustCode", CustCode);
            param.Add("@TranDate", TranDate);

            if (CustCode == null)
            {
                param.Add("@CustCode", "");
            }

            var results = await _db.LoadData<TmpForwardReport, dynamic>(
                storedProcedure: "usp_QReport_Trade_DailyFX",
                param);
            return results;
        }

        [HttpGet("TradeFinanceReport/1PResponse")]
        public async Task<IEnumerable<TmpCon1PReport>> Get1P(string? CenterID, string? UserCode, string? ProductCode , DateTime? TranDateFrom, DateTime? TranDateTo)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CenterID", CenterID);
            param.Add("@UserCode", UserCode);
            param.Add("@ProductCode", ProductCode);
            param.Add("@TranDateFrom", TranDateFrom);
            param.Add("@TranDateTo", TranDateTo);

            //if (CustCode == null)
            //{
            //    param.Add("@CustCode", "");
            //}

            var results = await _db.LoadData<TmpCon1PReport, dynamic>(
                storedProcedure: "usp_QReport_Trade_1PResponse",
                param);
            return results;
        }






    }
}
