﻿using Dapper;
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
using ISPTF.API.Controllers.ExportLC;

namespace ISPTF.API.Controllers.ExportADV
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXADVChargeFromIssueBankController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public EXADVChargeFromIssueBankController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }


        [HttpGet("list")]
        public async Task<ActionResult<ChargeFromIssueBankListPageResponse>> List(string? ListType, string? CenterID, string? EXPORT_ADVICE_NO, string? LC_NO, string? BENEFICIARY_ID, string? BENEFICIARY_INFO, string? Page, string? PageSize)
        {
            ChargeFromIssueBankListPageResponse response = new ChargeFromIssueBankListPageResponse();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_ChargeFromIssueBankListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_ChargeFromIssueBankListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
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

                var results = await _db.LoadData<Q_ChargeFromIssueBankListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXAD_ChargeFromIssueBankListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_ChargeFromIssueBankListPageRsp>)results;

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
                response.Data = new List<Q_ChargeFromIssueBankListPageRsp>();
            }
            return BadRequest(response);
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

        [HttpPost("save")]
        public ActionResult<PEXADPPaymentResponse> Save([FromBody] PEXADPPaymentRequest pexadppaymentrequest)
        {
            PEXADPPaymentResponse response = new();
            response.Data = new();

            // Validate
            if (pexadppaymentrequest.pExad == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "pExad is required.";
                response.Data = new();
                return BadRequest(response);
            }

            // Get USER_ID, CenterID
            pexadppaymentrequest.pExad.USER_ID = User.Identity.Name;
            pexadppaymentrequest.pExad.CenterID = HttpContext.User.FindFirst("UserBranch").Value.ToString();

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // Get Requirement
                        var seq = EXADVHelper.GetSeqNo(_context, pexadppaymentrequest.pExad.EXPORT_ADVICE_NO);
                        var pExadEvent = SaveUser(pexadppaymentrequest.pExad, pexadppaymentrequest.pPayment, seq, "EVENT", "Charge Issue", "P");

                        // Commit
                        _context.SaveChanges();
                        transaction.Complete();
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        transaction.Dispose();
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }

                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export Advice Saved";
                    response.Data.PEXAD = pexadppaymentrequest.pExad;
                    response.Data.PPAYMENT = pexadppaymentrequest.pPayment;
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

        [HttpPost("delete")]
        public async Task<ActionResult<EXADVResultResponse>> Delete(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO)
        {
            EXADVResultResponse response = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || EVENT_NO == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
                return BadRequest(response);
            }

            // Get USER_ID, CenterID
            var USER_ID = User.Identity.Name;
            var CenterID = HttpContext.User.FindFirst("UserBranch").Value.ToString();

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var pExadEvent = (from row in _context.pExads
                                          where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                row.RECORD_TYPE == RECORD_TYPE &&
                                                row.EVENT_NO == EVENT_NO &&
                                                row.REC_STATUS == REC_STATUS
                                          select row).AsNoTracking().FirstOrDefault();

                        if (pExadEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export Advice no does not exist.";
                            return BadRequest(response);
                        }

                        var seq = EVENT_NO;

                        var pExadRelesed = (from row in _context.pExads
                                            where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                    row.EVENT_NO == seq &&
                                                    row.RECORD_TYPE == "R"
                                            select row).AsNoTracking().FirstOrDefault();
                        if (pExadRelesed == null)
                        {
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'T' WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE = 'EVENT' AND REC_STATUS IN ('P','W') AND EVENT_NO = {seq}");
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R' , EVENT_NO = {seq} WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE ='MASTER'");
                        }
                        else
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Can not delete MASTER of EVENT record is rec_status = R";
                            return BadRequest(response);
                        }

                        // Commit
                        await _context.SaveChangesAsync();
                        transaction.Complete();
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        transaction.Dispose();
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }

                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export Advice Deleted";
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            return BadRequest(response);
        }

        [HttpPost("release")]
        public async Task<ActionResult<EXADVResultResponse>> Release(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO)
        {
            EXADVResultResponse response = new();
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS) || EVENT_NO == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
                return BadRequest(response);
            }

            // Get USER_ID, CenterID
            var USER_ID = User.Identity.Name;
            var CenterID = HttpContext.User.FindFirst("UserBranch").Value.ToString();

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // Get Requirement
                        var pExadEvent_temp = (from row in _context.pExads
                                               where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                     row.RECORD_TYPE == "EVENT" &&
                                                     row.EVENT_NO == EVENT_NO
                                               select row).AsNoTracking().FirstOrDefault();

                        if (pExadEvent_temp == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export Advice no does not exist.";
                            return BadRequest(response);
                        }

                        // var seq = EVENT_NO;
                        var seq = EXADVHelper.GetSeqNo(_context, pExadEvent_temp.EXPORT_ADVICE_NO);

                        var pExadEvent = (from row in _context.pExads
                                          where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                              row.RECORD_TYPE == "EVENT" &&
                                              row.EVENT_NO == seq
                                          select row).AsNoTracking().FirstOrDefault();
                        if (pExadEvent != null)
                        {
                            pExadEvent.AUTH_CODE = USER_ID;
                            pExadEvent.CenterID = CenterID;
                            pExadEvent = SaveSup(pExadEvent);
                            _context.pExads.Update(pExadEvent);
                        }

                        var pExadMaster = (from row in _context.pExads
                                           where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                   row.RECORD_TYPE == "MASTER" 
                                           select row).AsNoTracking().FirstOrDefault();
                        if (pExadMaster != null)
                        {
                            pExadMaster.AUTH_CODE = USER_ID;
                            pExadMaster.CenterID = CenterID;
                            pExadMaster = SaveMaster(pExadMaster, pExadEvent, "Charge Issue");
                            _context.pExads.Update(pExadMaster);
                        }

                        // Commit
                        await _context.SaveChangesAsync();

                        // Update REC_STATUS
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R' WHERE EXPORT_ADVICE_NO = '{pExadEvent_temp.EXPORT_ADVICE_NO}' AND RECORD_TYPE='EVENT' AND EVENT_NO = {seq}");
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R',EVENT_NO ={seq} WHERE EXPORT_ADVICE_NO = '{pExadEvent_temp.EXPORT_ADVICE_NO}' AND RECORD_TYPE='MASTER' ");

                        transaction.Complete();
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        transaction.Dispose();
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }

                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export Advice Released";
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                response.Message = e.ToString();
            }
            response.Code = Constants.RESPONSE_ERROR;
            return BadRequest(response);


        }
        private pExad SaveUser(pExad pExad, pPayment pPayment, int seqNo, string RECORD_TYPE, string EVENT_TYPE, string REC_STATUS)
        {
            var pExadEvent = (from row in _context.pExads
                              where
                                    row.EXPORT_ADVICE_NO == pExad.EXPORT_ADVICE_NO &&
                                    row.RECORD_TYPE == RECORD_TYPE &&
                                    row.REC_STATUS == REC_STATUS &&
                                    row.EVENT_NO == seqNo
                              select row).AsNoTracking().FirstOrDefault();
            if (pExadEvent == null)
            {
                pExadEvent = pExad;
                pExadEvent.RECORD_TYPE = RECORD_TYPE;
                pExadEvent.EVENT_TYPE = EVENT_TYPE;
                pExadEvent.REC_STATUS = REC_STATUS;
                pExadEvent.EVENT_NO = seqNo;
                pExadEvent.EVENT_MODE = "E";
                pExadEvent.BUSINESS_TYPE = "8";
                pExadEvent.TRANSACTION_TYPE = "8";
                pExadEvent.LC_TYPE = "2";
                _context.Add(pExadEvent);
            }
            else
            {
                pExadEvent = pExad;
                pExadEvent.EVENT_MODE = "E";
                pExadEvent.BUSINESS_TYPE = "8";
                pExadEvent.TRANSACTION_TYPE = "8";
                pExadEvent.LC_TYPE = "2";
                _context.Update(pExadEvent);
                _context.SaveChanges();
            }
            string eventTran;
            if (pExadEvent.PAY_REC_TYPE == "1")
            {
                eventTran = "CLAIM ISSUING";
                pExadEvent.CHARGE_FOR = "P";
                pExadEvent.CLAIM_ADV_COM = pExadEvent.ADVICE_COM;
                pExadEvent.CLAIM_AMEND_COM = pExadEvent.AMEND_COM;
                pExadEvent.CLAIM_OTHER_CHARGE = pExadEvent.OTHER_CHARGE;
                pExadEvent.CLAIM_CABLE_CHARGE = pExadEvent.CABLE_COM;
            }
            else if(pExadEvent.PAY_REC_TYPE == "2")
            {
                eventTran = "CHARGE ISSUING";
                pExadEvent.CHARGE_FOR = "R";
                pExadEvent.REC_ADV_COM = pExadEvent.ADVICE_COM;
                pExadEvent.REC_AMEND_COM = pExadEvent.AMEND_COM;
                pExadEvent.REC_OTHER_CHARGE = pExadEvent.OTHER_CHARGE;
                pExadEvent.REC_CABLE_CHARGE = pExadEvent.CABLE_COM;
            }
            _context.SaveChanges();
            if (pExadEvent.PAYMENT_INSTRU == "1")
            {
                PaymentSave(pExad, pPayment);
            }
            else
            {
                // Delete pPayment
                var pPaymentDel = (from row in _context.pPayments
                                   where row.RpReceiptNo == pExadEvent.RECEIPT_NO
                                   select row).ToList();
                foreach (var row in pPaymentDel)
                {
                    _context.pPayments.Remove(row);
                }
                // Delete pPayDetail
                var pPayDetailDel = (from row in _context.pPayDetails
                                     where row.DpReceiptNo == pExadEvent.RECEIPT_NO
                                     select row).ToList();
                foreach (var row in pPayDetailDel)
                {
                    _context.pPayDetails.Remove(row);
                }
                // Delete pDailyGL
                var pDailyGLDel = (from row in _context.pDailyGLs
                                   where row.VouchID == pExadEvent.VOUCH_ID &&
                                         row.VouchDate == pExadEvent.EVENT_DATE
                                   select row).ToList();
                foreach (var row in pDailyGLDel)
                {
                    _context.pDailyGLs.Remove(row);
                }

                // Update Master
                _context.Database.ExecuteSqlRaw($"UPDATE pExad SET REC_STATUS = 'P' WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE='MASTER'");
            }
            return pExadEvent;
        }

        private void PaymentSave(pExad exad, pPayment pPaymentReq)
        {
            if (exad.RECEIPT_NO == null)
            {
                exad.RECEIPT_NO = EXHelper.GetReceiptNo(_context, exad.USER_ID, exad.CenterID);
            }

            var pPaymentEvent = (from row in _context.pPayments
                                 where row.RpReceiptNo == exad.RECEIPT_NO
                                 select row).AsNoTracking().FirstOrDefault();
            if (pPaymentEvent == null)
            {
                pPaymentEvent = new();
                pPaymentEvent = pPaymentReq;
                pPaymentEvent.RpReceiptNo = exad.RECEIPT_NO;
                pPaymentEvent.RpModule = "EXAD";
                pPaymentEvent.RpEvent = "1";
                pPaymentEvent.RpPayDate = exad.EVENT_DATE;
                pPaymentEvent.RpStatus = "A";
                pPaymentEvent.UserCode = exad.USER_ID;
                pPaymentEvent.UpdateDate = DateTime.Now;
                pPaymentEvent.AuthCode = "";
                pPaymentEvent.AuthDate = null;
                _context.pPayments.Add(pPaymentEvent);
            }
            else
            {
                pPaymentReq.RpModule = "EXAD";
                pPaymentReq.RpEvent = "1";
                pPaymentReq.RpPayDate = exad.EVENT_DATE;
                pPaymentReq.RpStatus = "A";
                pPaymentReq.UserCode = exad.USER_ID;
                pPaymentReq.UpdateDate = DateTime.Now;
                pPaymentReq.AuthCode = "";
                pPaymentReq.AuthDate = null;
                _context.pPayments.Update(pPaymentReq);
            }

            // Delete pPayDetail
            var pPayDetailDel = (from row in _context.pPayDetails
                                 where row.DpReceiptNo == exad.RECEIPT_NO
                                 select row).ToList();
            foreach (var row in pPayDetailDel)
            {
                _context.pPayDetails.Remove(row);
            }

            pPayDetail paydetail;
            var dpSeq = 1;
            if (exad.ADVICE_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "ADVICE L/C COMM.";
                paydetail.DpPayAmt = exad.ADVICE_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.AMEND_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "AMENDMENT L/C COMM.";
                paydetail.DpPayAmt = exad.AMENDTRN_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.TRANSFER_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "TRANSFER L/C COMM.";
                paydetail.DpPayAmt = exad.TRANSFER_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.AMENDTRN_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "AMEND TRANSFER L/C COMM.";
                paydetail.DpPayAmt = exad.AMENDTRN_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.CABLE_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "CABLE CHARGE";
                paydetail.DpPayAmt = exad.CABLE_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.CONFIRM_COM != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "CONFIRM L/C COMM";
                paydetail.DpPayAmt = exad.CONFIRM_COM;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.OTHER_CHARGE != null)
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "OTHER CHARGE";
                paydetail.DpPayAmt = exad.OTHER_CHARGE;
                _context.pPayDetails.Add(paydetail);
                dpSeq++;
            }
            if (exad.PAY_REFUND == "Y")
            {
                paydetail = new();
                paydetail.DpReceiptNo = exad.RECEIPT_NO;
                paydetail.DpSeq = dpSeq;
                paydetail.DpPayName = "REFUND TAX AMT.";
                paydetail.DpPayAmt = exad.REFUND_TAX * -1;
                _context.pPayDetails.Add(paydetail);
            }
        }

        private pExad SaveSup(pExad pExadEvent)
        {
            pExadEvent.AUTH_DATE = DateTime.Now;

            // Update pPayment
            var pPayment = (from row in _context.pPayments
                            where row.RpReceiptNo == pExadEvent.RECEIPT_NO
                            select row).FirstOrDefault();
            if (pPayment != null)
            {
                pPayment.RpRecStatus = "R";
                pPayment.AuthDate = DateTime.Now;
                pPayment.AuthCode = pExadEvent.USER_ID;
            }

            var pTransfer = (from row in _context.pTransfers
                             where row.EXPORT_ADVICE_NO == pExadEvent.EXPORT_ADVICE_NO &&
                                   row.REC_STATUS == "P" &&
                                   row.RECORD_TYPE == "EVENT"
                             select row).FirstOrDefault();
            if (pTransfer != null)
            {
                pTransfer.REC_STATUS = "R";
                pTransfer.AUTH_DATE = DateTime.Now;
                pTransfer.AUTH_CODE = pExadEvent.USER_ID;
            }

            // Update pDailyGL
            var pDailyGL = (from row in _context.pDailyGLs
                            where row.TranDocNo == pExadEvent.EXPORT_ADVICE_NO &&
                                  row.TranEvent == "TRANSFER" &&
                                  row.VouchDate == pExadEvent.EVENT_DATE
                            select row).ToList();
            foreach (var row in pDailyGL)
            {
                row.SendFlag = "R";
            }
            return pExadEvent;
        }

        private pExad SaveMaster(pExad pExadMaster, pExad pExadTemp, string EVENT_TYPE)
        {
            var vch = pExadTemp.VOUCH_ID; // ???????
            pExadMaster.EVENT_TYPE = EVENT_TYPE;
            pExadMaster.GENACC_FLAG = "Y";
            pExadMaster.GENACC_DATE = DateTime.Now;
            pExadMaster.EVENT_MODE = "E";
            pExadMaster.VOUCH_ID = "";
            pExadMaster.BUSINESS_TYPE = "8";
            pExadMaster.REIM_BK_ID = pExadTemp.REIM_BK_ID;
            pExadMaster.REIM_BK_NAME = pExadTemp.REIM_BK_NAME;
            pExadMaster.NOSTRO = pExadTemp.NOSTRO;
            pExadMaster.CLAIM_CCY = pExadTemp.CLAIM_CCY;
            pExadMaster.ISSUE_CCYAMT = pExadTemp.ISSUE_CCYAMT;
            pExadMaster.EXCH_RATE = pExadTemp.EXCH_RATE;
            pExadMaster.ADVICE_COM = pExadTemp.ADVICE_COM;
            pExadMaster.AMEND_COM = pExadTemp.AMEND_COM;
            pExadMaster.TRANSFER_COM = pExadTemp.TRANSFER_COM;
            pExadMaster.CABLE_COM = pExadTemp.CABLE_COM;
            pExadMaster.CONFIRM_COM = pExadTemp.CONFIRM_COM;
            pExadMaster.OTHER_CHARGE = pExadTemp.OTHER_CHARGE;
            pExadMaster.TOTAL_AMOUNT = pExadTemp.TOTAL_AMOUNT;
            pExadMaster.TOTAL_CHARGE = pExadTemp.TOTAL_CHARGE;
            pExadMaster.REFUND_TAX = pExadTemp.REFUND_TAX;
            pExadMaster.PAY_REFUND = pExadTemp.PAY_REFUND;
            pExadMaster.ALLOCATION = pExadTemp.ALLOCATION;
            pExadMaster.METHOD = pExadTemp.METHOD;

            if (pExadTemp.PAY_REC_TYPE == "1")
            {
                pExadMaster.CHARGE_FOR = pExadTemp.CHARGE_FOR;
                pExadMaster.CLAIM_ADV_COM = pExadTemp.CLAIM_ADV_COM;
                pExadMaster.CLAIM_AMEND_COM = pExadTemp.CLAIM_AMEND_COM;
                pExadMaster.CLAIM_OTHER_CHARGE = pExadTemp.CLAIM_OTHER_CHARGE;
                pExadMaster.CLAIM_CABLE_CHARGE = pExadTemp.CLAIM_CABLE_CHARGE;
            }
            else if (pExadTemp.PAY_REC_TYPE == "2")
            {
                pExadMaster.CHARGE_FOR = pExadTemp.CHARGE_FOR;
                pExadMaster.REC_ADV_COM = pExadTemp.REC_ADV_COM;
                pExadMaster.REC_AMEND_COM = pExadTemp.REC_AMEND_COM;
                pExadMaster.REC_OTHER_CHARGE = pExadTemp.REC_OTHER_CHARGE;
                pExadMaster.REC_CABLE_CHARGE = pExadTemp.REC_CABLE_CHARGE;
            }

            if (pExadTemp.PAYMENT_INSTRU == "1")
            {
                pExadMaster.RECEIPT_NO = pExadTemp.RECEIPT_NO;
                pExadMaster.PAYMENT_INSTRU = "1";
                pExadTemp.UNADVICE_COM = pExadTemp.UNADVICE_COM - pExadTemp.ADVICE_COM;
                pExadTemp.UNAMEND_COM = pExadTemp.UNAMEND_COM - pExadTemp.AMEND_COM;
                pExadTemp.UNTRANSFER_COM = pExadTemp.UNTRANSFER_COM - pExadTemp.TRANSFER_COM;
                pExadTemp.UNCABLE_COM = pExadTemp.UNCABLE_COM - pExadTemp.CABLE_COM;
                pExadTemp.UNCONFIRM_COM = pExadTemp.UNCONFIRM_COM - pExadTemp.CONFIRM_COM;
                pExadTemp.UNOTHER_CHARGE = pExadTemp.UNOTHER_CHARGE - pExadTemp.OTHER_CHARGE;
                if (pExadTemp.UNADVICE_COM < 0)
                    pExadTemp.UNADVICE_COM = 0;
                if (pExadTemp.UNAMEND_COM < 0)
                    pExadTemp.UNAMEND_COM = 0;
                if (pExadTemp.UNTRANSFER_COM < 0)
                    pExadTemp.UNTRANSFER_COM = 0;
                if (pExadTemp.UNCABLE_COM < 0)
                    pExadTemp.UNCABLE_COM = 0;
                if (pExadTemp.UNCONFIRM_COM < 0)
                    pExadTemp.UNCONFIRM_COM = 0;
                if (pExadTemp.UNOTHER_CHARGE < 0)
                    pExadTemp.UNOTHER_CHARGE = 0;
            }
            else
            {
                pExadMaster.RECEIPT_NO = "";
                pExadMaster.PAYMENT_INSTRU = "2";
                pExadTemp.UNADVICE_COM = pExadTemp.UNADVICE_COM + pExadTemp.ADVICE_COM;
                pExadTemp.UNAMEND_COM = pExadTemp.UNAMEND_COM + pExadTemp.AMEND_COM;
                pExadTemp.UNTRANSFER_COM = pExadTemp.UNTRANSFER_COM + pExadTemp.TRANSFER_COM;
                pExadTemp.UNCABLE_COM = pExadTemp.UNCABLE_COM + pExadTemp.CABLE_COM;
                pExadTemp.UNCONFIRM_COM = pExadTemp.UNCONFIRM_COM + pExadTemp.CONFIRM_COM;
                pExadTemp.UNOTHER_CHARGE = pExadTemp.UNOTHER_CHARGE + pExadTemp.OTHER_CHARGE;
            }

            // Update pDailyGL
            var pDailyGL = (from row in _context.pDailyGLs
                            where row.VouchID == vch &&
                                  row.VouchDate == pExadTemp.EVENT_DATE
                            select row).ToList();
            foreach (var row in pDailyGL)
            {
                row.SendFlag = "R";

            }
            return pExadMaster;
        }
    }
}