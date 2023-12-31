﻿using Dapper;
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
            param.Add("@Quote_Rate", Quote.Quote_Rate);
            param.Add("@TPR", Quote.TPR);
            param.Add("@Status", Quote.Status);
            param.Add("@Txndate", Quote.Txndate);
            param.Add("@TF_inputer", Quote.TF_inputer);
            param.Add("@TF_Inputer_Date", Quote.TF_Inputer_Date);
            param.Add("@TF_Sale", Quote.TF_Sale);
            param.Add("@TF_Sale_Date", Quote.TF_Sale_Date);
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
            param.Add("@QuoteCost", Quote.QuoteCost);
            param.Add("@QuoteSpread", Quote.QuoteSpread);
            param.Add("@ReleaseFlag", Quote.ReleaseFlag);
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
            param.Add("@RM1", Quote.RM1);
            param.Add("@RM2", Quote.RM2);
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
                    response.Message = " Quote Rate deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = " Record not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//delete

        [HttpPost("cancel")]
        public async Task<ActionResult<string>> Cancel([FromBody] QuoteINTCancelReq Quote)
        {

            DynamicParameters param = new();
            param.Add("@Txn_ID", Quote.Txn_ID);
            param.Add("@RM1", Quote.RM1);
            param.Add("@RM2", Quote.RM2);
            param.Add("@Delete_user", Quote.Delete_user);
            param.Add("@Resp", dbType: DbType.Int32,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_AQuote_QuoteINTCancel", param);
                var resp = param.Get<int>("@Resp");
                if (resp == 1)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = " Quote Rate Cancelled ";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = " Record not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }//delete

        [HttpGet("listpageCFR")]
        public async Task<IEnumerable<QuoteCFRListRsp>> GetCFR(string CustCode, string Facility_No, int? Page, int? PageSize)
        {
            DynamicParameters param = new();
            param.Add("@CustCode", CustCode);
            param.Add("@Facility_No", Facility_No);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            var results = await _db.LoadData<QuoteCFRListRsp, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteCFRList",
                        param);
            return results;
        }
        // Confirm Use CFR
        [HttpGet("getCFRUsed")]
        public async Task<IEnumerable<QuoteCFRUsed>> GetUse(string CustCode, string Facility_No, string CurCode, 
                                                                                           string CFR_1, string CFR_2, double CFR_3, string TxnDate,int? TDay,double RateQuote)
        {
            DynamicParameters param = new();
            param.Add("@CustCode", CustCode);
            param.Add("@Facility_No", Facility_No);
            param.Add("@CurCode", CurCode);
            param.Add("@CFR_1", CFR_1);
            param.Add("@CFR_2", CFR_2);
            param.Add("@CFR_3", CFR_3);
            param.Add("@TxnDate", TxnDate);
            param.Add("@TDay", TDay);
            param.Add("@RateQuote", RateQuote);

            var results = await _db.LoadData<QuoteCFRUsed, dynamic>(
                        storedProcedure: "usp_AQuote_QuoteCFRUsed",
                        param);
            return results;
        }
        // Select
    }//main
}


