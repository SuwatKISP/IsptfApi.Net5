using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ExportADV;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using ISPTF.Models.LoginRegis;
using System.Transactions;
using Microsoft.AspNetCore.Http;

namespace ISPTF.API.Controllers.ExportADV
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXADVAdvicingController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public EXADVAdvicingController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("OriginalLCLoad")]
        public async Task<ActionResult<OriginalLCLoadListPageResponse>> LoadList(string? CenterID, string? LCNo, string? MTType, string? BenName, string? Page, string? PageSize)
        {
            OriginalLCLoadListPageResponse response = new OriginalLCLoadListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_OriginalLCLoadListPageRsp>();
                return BadRequest(response);
            }
            //if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "USER_ID is required";
            //    response.Data = new List<Q_IssuePCNewListPageRsp>();
            //    return BadRequest(response);
            //}

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                //param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@LCNo", LCNo);
                param.Add("@MTType", MTType);
                param.Add("@BenName", BenName);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (LCNo == null)
                {
                    param.Add("@LCNo", "");
                }
                if (MTType == null)
                {
                    param.Add("@MTType", "");
                }
                if (BenName == null)
                {
                    param.Add("@BenName", "");
                }

                var results = await _db.LoadData<Q_OriginalLCLoadListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXAD_AdvisingLCOriginalLoadListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_OriginalLCLoadListPageRsp>)results;

                try
                {
                    response.Page = int.Parse(Page);
                    response.Total = response.Data[0].RCount;
                    response.TotalPage = Convert.ToInt32(Math.Ceiling(response.Total / decimal.Parse(PageSize)));
                }
                catch (Exception)
                {
                    response.Page = 0;
                    response.Total = 0;
                    response.TotalPage = 0;
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<Q_OriginalLCLoadListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("list")]
        public async Task<ActionResult<AdvisingListPageResponse>> List(string? TypeLC, string? ListType, string? CenterID, string? EXPORT_ADVICE_NO, string? LC_NO, string? BENEFICIARY_ID, string? BENEFICIARY_INFO, string? Page, string? PageSize)
        {
            AdvisingListPageResponse response = new AdvisingListPageResponse();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(TypeLC) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "TypeLC, ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_AdvisingListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_AdvisingListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@TypeLC", TypeLC);
                param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@EXPORT_ADVICE_NO", EXPORT_ADVICE_NO);
                param.Add("@LC_NO", LC_NO);
                param.Add("@BENEFICIARY_ID", BENEFICIARY_ID);
                param.Add("@BENEFICIARY_INFO", BENEFICIARY_INFO);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_ADVICE_NO == null)
                {
                    param.Add("@EXPORT_ADVICE_NO", "");
                }
                if (LC_NO == null)
                {
                    param.Add("@LC_NO", "");
                }
                if (BENEFICIARY_ID == null)
                {
                    param.Add("@BENEFICIARY_ID", "");
                }
                if (BENEFICIARY_INFO == null)
                {
                    param.Add("@BENEFICIARY_INFO", "");
                }

                var results = await _db.LoadData<Q_AdvisingListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXAD_AdvisingLCListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_AdvisingListPageRsp>)results;

                try
                {
                    response.Page = int.Parse(Page);
                    response.Total = response.Data[0].RCount;
                    response.TotalPage = Convert.ToInt32(Math.Ceiling(response.Total / decimal.Parse(PageSize)));
                }
                catch (Exception)
                {
                    response.Page = 0;
                    response.Total = 0;
                    response.TotalPage = 0;
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<Q_AdvisingListPageRsp>();
            }
            return BadRequest(response);
        }



        [HttpGet("test")]
        public async Task<ActionResult<PEXADResponse>> Test()
        {
            PEXADResponse response = new();
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //var seq = await EXADVHelper.GetSeqNo(_context.pExads, EXPORT_ADVICE_NO);
                    var exad = await EXADVHelper.GetExad(_context, "950EAD21000001", "MASTER", "P", 1);
                    exad.EXPORT_ADVICE_NO = "TEST001";
                    exad.RECORD_TYPE = "MASTER";
                    exad.REC_STATUS = "P";
                    exad.EVENT_NO = 1;

                    var exad2 = await EXADVHelper.GetExad(_context, "TEST001", "MASTER", "P", 1);
                    if (exad2 == null)
                    {
                        exad = await EXADVHelper.InsertExad(_context, exad);
                    }
                    else
                    {
                        var newExad = exad;
                        newExad.EVENT_MODE = "X";
                        await EXADVHelper.UpdateExad(_context, newExad);
                    }

                    //await EXADVHelper.DeleteExad(_context.pExads, exad);

                    // Commit
                    // await _context.SaveChangesAsync();
                    transaction.Complete();
                    response.Code = Constants.RESPONSE_OK;
                    response.Data.PEXAD = exad;
                    return Ok(response);
                }
                catch (Exception e)
                {
                    response.Message = e.ToString();
                }
                response.Code = Constants.RESPONSE_ERROR;
                response.Data = new();
                return BadRequest(response);
            }
        }

        [HttpGet("select")]
        public async Task<ActionResult<PEXADPPaymentResponse>> Select(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO)
        {
            PEXADPPaymentResponse response = new();
            response.Data = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || EVENT_NO == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
                return BadRequest(response);
            }

            try
            {
                // pExad
                var exad = await EXADVHelper.GetExad(_context, EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO);

                if (exad != null)
                {
                    // pPayment
                    if (exad.PAYMENT_INSTRU=="1")
                    {
                        response.Data.PPAYMENT = await EXHelper.GetPPayment(_context, exad.RECEIPT_NO);
                    }
                    response.Code = Constants.RESPONSE_OK;
                    response.Data.PEXAD = exad;
                    return Ok(response);
                }
                response.Message = "Export Advice L/C does not exist";
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            return BadRequest(response);
        }

        // **************************************************************** NOT FINISH YET ****************************************************************
        /*
        [HttpPost("save")] 
        public async Task<ActionResult<PEXADResponse>> Save([FromBody] PEXADRequest pexadreq)
        {
            PEXADResponse response = new();

            // Validate
            if (pexadreq == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "pExad is required.";
                response.Data = new();
                return BadRequest(response);
            }

            // Get USER_ID, CenterID
            pexadreq.USER_ID = User.Identity.Name;
            pexadreq.CenterID = HttpContext.User.FindFirst("UserBranch").Value.ToString();

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // Get Requirement
                        bool updateExadSWIn = false;
                        bool keepDocRegister = false;
                        int seq;
                        pExad exad;

                        //Get RECEIPT_NO pexadreq.RECEIPT_NO = ?
                        if (pexadreq.EVENT_TYPE == "Full Advice" || pexadreq.EVENT_TYPE == "Pre Advice")
                        {
                            seq = 1;
                            updateExadSWIn = true;
                            keepDocRegister = true;
                        }
                        else if (pexadreq.EVENT_TYPE == "Amend" || pexadreq.EVENT_TYPE == "Advice Mail")
                        {
                            seq = await EXADVHelper.GetSeqNo(_context, pexadreq.EXPORT_ADVICE_NO);
                        }

                        // 0 - Insert exad if not exist #2861
                        exad = await EXADVHelper.InsertExad(_context, pexadreq);

                        // 1 - Delete pPayment, pPayDetail, pDailyGL if *UNPAID* #2980
                        if (exad.PAYMENT_INSTRU == "2")
                        {
                            //Delete pPayment
                            var payments = await EXHelper.DeletePPayment(_context, pexadreq.RECEIPT_NO);

                            //Delete pPayDetail
                            var payDetails = await EXHelper.DeletePPayDetail(_context, pexadreq.RECEIPT_NO);

                            //Delete pDailyGL
                            var dailyGLs = await EXHelper.DeletePDailyGL(_context, pexadreq.VOUCH_ID, pexadreq.EVENT_DATE);
                        }

                        
                        // 2 - Insert pPayment if not exist #2989 #334
                        var payment = (
                            from row in _context.pPayments
                            where row.RpReceiptNo == pexadreq.EXPORT_ADVICE_NO
                            select row).FirstOrDefault();
                        if (payment == null)
                        {
                            //_context.pPayments.Add(ppaymentreq);
                        }

                        // 3 - Delete pPayDetail and insert new #2989 #369
                        var paydetails = (from row in _context.pPayDetails
                                        where row.DpReceiptNo == pexadreq.RECEIPT_NO
                                        select row).ToListAsync();
                        foreach (var row in await paydetails)
                        {
                            _context.pPayDetails.Remove(row);
                        }

                        // Insert and/or Update pPayDetail ***** Crete new one because we already delete it above(3) -*-
                        EXADVHelper.InsertPPayDetails(_context, pexadreq);

                        // 4 -

                        // Commit
                        // await _context.SaveChangesAsync();
                        transaction.Complete();
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }

                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export Advice Saved";
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            response.Data = new();
            return BadRequest(response);
        }
        
        public async Task<int> SaveUser(int seqNo, string RECORD_TYPE, string EVENT_TYPE, string REC_STATUS)
        {
            return 0;
        }
        */
    }
}