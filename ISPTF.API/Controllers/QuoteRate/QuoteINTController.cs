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
    public class QuoteINTController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public QuoteINTController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("listpage")]
        // Listpage  add parameter  ,int? Page, int? PageSize
        public async Task<IEnumerable<QuoteINTListRsp>> GetAll(string Status, string RefNo,int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@Status", Status);
            param.Add("@RefNo", RefNo);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (Status == null)
            {
                param.Add("@Status", "");
            }
            if (RefNo == null)
            {
                param.Add("@RefNo", "");
            }

            var results = await _db.LoadData<QuoteINTListRsp, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteINTList",
                        param);
            return results;
        }
        // Listpage
        [HttpGet("select")]
        public async Task<IEnumerable<QuoteINTSelect>> GetSel(string Txn_ID)
        {
            DynamicParameters param = new();
            param.Add("@Txn_ID", Txn_ID);

            var results = await _db.LoadData<QuoteINTSelect, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteINTSelect",
                        param);
            return results;
        }
        // Select
        [HttpPost("Save")]
        public async Task<ActionResult<List<QuoteINTSaveRsp>>> Insert([FromBody] QuoteINTSaveRsp Quote)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Txn_ID", Quote.Txn_ID);
            param.Add("@Customer", Quote.Customer);
            param.Add("@Name", Quote.Name);
            param.Add("@BD", Quote.BD);
            param.Add("@Reference", Quote.Reference);
            param.Add("@Type", Quote.Type);
            param.Add("@curr", Quote.curr);
            param.Add("@Against", Quote.Against);
            param.Add("@amount", Quote.amount); 
            param.Add("@value_Date", Quote.value_Date);
            param.Add("@Expiry_Date", Quote.Expiry_Date);
            param.Add("@Tenor", Quote.Tenor);
            param.Add("@CFR_1", Quote.CFR_1);
            param.Add("@CFR_2", Quote.CFR_2);
            param.Add("@CFR_3", Quote.CFR_3);
            param.Add("@CFR_Rate", Quote.CFR_Rate);
            param.Add("@Quote_Rate", Quote.CFR_Rate);
            param.Add("@TPR", Quote.CFR_Rate);
            param.Add("@Status", Quote.Status);
            param.Add("@Txndate", Quote.Txndate);
            param.Add("@TF_inputer", Quote.TF_inputer);
            param.Add("@TF_Inputer_Date", Quote.TF_Inputer_Date);
            param.Add("@TF_Sale", Quote.Status);
            param.Add("@TF_Sale_Date", Quote.TF_Sale);
            param.Add("@Delete_Flag", Quote.Delete_Flag);
            param.Add("@Time_stamp", Quote.Time_stamp);
            param.Add("@Use_Tx", Quote.Use_Tx);
            param.Add("@Delete_user", Quote.Delete_user);
            param.Add("@use_Tx_user", Quote.use_Tx_user);
            param.Add("@RM1", Quote.RM1);
            param.Add("@RM2", Quote.RM2);
            param.Add("@Cust_AoCode", Quote.Cust_AoCode);
            param.Add("@Cust_AoLev1", Quote.Cust_AoLev1);
            param.Add("@Cust_AoLev2", Quote.Cust_AoLev2);
            param.Add("@Cust_AoLev3", Quote.Cust_AoLev3);
            param.Add("@ZZUser", Quote.ZZUser);
            param.Add("@EditApprove_Flag", Quote.EditApprove_Flag);
            param.Add("@EditApprove_UID", Quote.EditApprove_UID);
            param.Add("@EditApprove_Seq", Quote.EditApprove_Seq);
            param.Add("@ZZStrdate", Quote.ZZStrdate);
            param.Add("@ZZDate", Quote.ZZDate);
            param.Add("@Facility_No", Quote.Facility_No);
            param.Add("@ReBOT", Quote.ReBOT);
            param.Add("@APPV_NO", Quote.APPV_NO);
            param.Add("@AUTOISP", Quote.AUTOISP);
            param.Add("@TranSEQ", Quote.TranSEQ);
            param.Add("@CFRRemark", Quote.CFRRemark);
            param.Add("@Resp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<QuoteINTSaveRsp, dynamic>(
                    storedProcedure: "usp_AQuote_QuoteINTUpdate",
                    param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {
                    return Ok(results);
                }
                else
                {
                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Quote Rate dose not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//Save
        [HttpPost("delete")]
        public async Task<ActionResult<string>> Delete([FromBody] QuoteINTDeleteReq Quote)
        {

            DynamicParameters param = new();
            param.Add("@Txn_ID", Quote.Txn_ID);
            param.Add("@Delete_user", Quote.Delete_user);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_AQuote_QuoteINTDelete", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = " Rate deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = " Rate not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//delete
        [HttpGet("listpageCFR")]
        public async Task<IEnumerable<QuoteCFRListRsp>> GetCFR(string CustCode, string CurCode, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@CustCode", CustCode);
            param.Add("@CurCode", CurCode);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (CurCode == null)
            {
                param.Add("@CurCode", "");
            }

            var results = await _db.LoadData<QuoteCFRListRsp, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteCFRList",
                        param);
            return results;
        }
        // Confirm Use CFR
        [HttpGet("UseCFR")]
        public async Task<IEnumerable<QuoteCFRUsedRsp>> GetUse(string CustCode, string Facility_No, string CurCode, 
                                                                                           string prdcode, string CFR_1, string CFR_2, double CFR_3, string remark,
                                                                                           string TxnDate,int? TDay, double CFR_Rate,double Quote_Rate, 
                                                                                           double TPR, string CCY_Flag)
        {
            DynamicParameters param = new();
            param.Add("@CustCode", CustCode);
            param.Add("@Facility_No", Facility_No);
            param.Add("@CurCode", CurCode);
            param.Add("@prdcode", prdcode);
            param.Add("@CFR_1", CFR_1);
            param.Add("@CFR_2", CFR_2);
            param.Add("@spread", CFR_3);
            param.Add("@remark", remark);
            param.Add("@TxnDate", TxnDate);
            param.Add("@TDay", TDay);
            param.Add("@CFR_Rate", CFR_Rate);
            param.Add("@Quote_Rate", Quote_Rate);
            param.Add("@TPR", TPR);
            param.Add("@CCY_Flag", CCY_Flag);

            var results = await _db.LoadData<QuoteINTSelect, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteCFRUsed",
                        param);
            return results;
        }
        // Select
    }//main
}


