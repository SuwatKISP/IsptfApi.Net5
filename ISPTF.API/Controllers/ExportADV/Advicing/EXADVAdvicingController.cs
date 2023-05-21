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
    //[Authorize]
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
                    response.Data = exad;
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

        /*
        [HttpPost("save")]
        public async Task<ActionResult<PEXADResponse>> Save([FromBody] PEXADRequest pexadreq, [FromBody] pPayment ppaymentreq)
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
                        // -1 - Get Requirement
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
                            seq = await EXADVHelper.GetSeqNo(_context.pExads, pexadreq.EXPORT_ADVICE_NO);
                        }

                        // 0 - Insert exad if not exist #2861
                        exad = await EXADVHelper.InsertIfNotExistExad(_context.pExads, pexadreq);

                        // 1 - Delete pPayment, pPayDetail, pDailyGL if *UNPAID* #2980
                        if (exad.PAYMENT_INSTRU == "2")
                        {
                            //Delete pPayment
                            var payments = await EXADVHelper.DeletePPayment(_context.pPayments, pexadreq.RECEIPT_NO);

                            //Delete pPayDetail
                            var payDetails = await EXADVHelper.DeletePPayDetail(_context.pPayDetails, pexadreq.RECEIPT_NO);

                            //Delete pDailyGL
                            var dailyGLs = await EXADVHelper.DeletePDailyGL(_context.pDailyGLs, pexadreq.VOUCH_ID, pexadreq.EVENT_DATE);
                        }

                        
                        // 2 - Insert pPayment if not exist #2989 #334
                        var payment = (
                            from row in _context.pPayments
                            where row.RpReceiptNo == pexadreq.EXPORT_ADVICE_NO
                            select row).FirstOrDefault();
                        if (payment == null)
                        {
                            _context.pPayments.Add(ppaymentreq);
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
                        pPayDetail paydetail;
                        var dpSeq = 1;
                        if (pexadreq.ADVICE_COM != null)
                        {
                            paydetail = new();
                            paydetail.DpReceiptNo = pexadreq.RECEIPT_NO;
                            paydetail.DpSeq = dpSeq;
                            paydetail.DpPayName = "ADVICE L/C COMM.";
                            paydetail.DpPayAmt = pexadreq.ADVICE_COM;
                            _context.pPayDetails.Add(paydetail);
                            dpSeq++;
                        }
                        if (pexadreq.AMEND_COM != null)
                        {
                            paydetail = new();
                            paydetail.DpReceiptNo = pexadreq.RECEIPT_NO;
                            paydetail.DpSeq = dpSeq;
                            paydetail.DpPayName = "AMENDMENT L/C COMM.";
                            paydetail.DpPayAmt = pexadreq.ADVICE_COM;
                            _context.pPayDetails.Add(paydetail);
                            dpSeq++;
                        }
                        if (pexadreq.TRANSFER_COM != null)
                        {
                            paydetail = new();
                            paydetail.DpReceiptNo = pexadreq.RECEIPT_NO;
                            paydetail.DpSeq = dpSeq;
                            paydetail.DpPayName = "TRANSFER L/C COMM.";
                            paydetail.DpPayAmt = pexadreq.ADVICE_COM;
                            _context.pPayDetails.Add(paydetail);
                            dpSeq++;
                        }
                        if (pexadreq.AMENDTRN_COM != null)
                        {
                            paydetail = new();
                            paydetail.DpReceiptNo = pexadreq.RECEIPT_NO;
                            paydetail.DpSeq = dpSeq;
                            paydetail.DpPayName = "AMEND TRANSFER L/C COMM.";
                            paydetail.DpPayAmt = pexadreq.ADVICE_COM;
                            _context.pPayDetails.Add(paydetail);
                            dpSeq++;
                        }
                        if (pexadreq.CABLE_COM != null)
                        {
                            paydetail = new();
                            paydetail.DpReceiptNo = pexadreq.RECEIPT_NO;
                            paydetail.DpSeq = dpSeq;
                            paydetail.DpPayName = "CABLE CHARGE";
                            paydetail.DpPayAmt = pexadreq.ADVICE_COM;
                            _context.pPayDetails.Add(paydetail);
                            dpSeq++;
                        }
                        if (pexadreq.CONFIRM_COM != null)
                        {
                            paydetail = new();
                            paydetail.DpReceiptNo = pexadreq.RECEIPT_NO;
                            paydetail.DpSeq = dpSeq;
                            paydetail.DpPayName = "CONFIRM L/C COMM";
                            paydetail.DpPayAmt = pexadreq.ADVICE_COM;
                            _context.pPayDetails.Add(paydetail);
                            dpSeq++;
                        }
                        if (pexadreq.OTHER_CHARGE != null)
                        {
                            paydetail = new();
                            paydetail.DpReceiptNo = pexadreq.RECEIPT_NO;
                            paydetail.DpSeq = dpSeq;
                            paydetail.DpPayName = "OTHER CHARGE";
                            paydetail.DpPayAmt = pexadreq.ADVICE_COM;
                            _context.pPayDetails.Add(paydetail);
                            dpSeq++;
                        }
                        if (pexadreq.PAY_REFUND == "Y")
                        {
                            paydetail = new();
                            paydetail.DpReceiptNo = pexadreq.RECEIPT_NO;
                            paydetail.DpSeq = dpSeq;
                            paydetail.DpPayName = "REFUND TAX AMT.";
                            paydetail.DpPayAmt = pexadreq.ADVICE_COM;
                            _context.pPayDetails.Add(paydetail);
                            dpSeq++;
                        }

                        // 4 -
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
        }*/
    }
}