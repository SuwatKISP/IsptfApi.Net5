﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.ExportLC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCPurchasePaymentController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "8";
        private const string EVENT_TYPE = "Payment Purchase";
        public EXLCPurchasePaymentController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCPurchasePaymentListResponse>> List(string? ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? Page, string? PageSize)
        {
            EXLCPurchasePaymentListResponse response = new EXLCPurchasePaymentListResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(@ListType) ||
                string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(Page) ||
                string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCPurchasePaymentListPageRsp>();
                return BadRequest(response);
            }

            if (@ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required for RELEASE";
                response.Data = new List<Q_EXLCPurchasePaymentListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@BENName", BENName);
                param.Add("@USER_ID", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_LC_NO == null)
                {
                    param.Add("@EXPORT_LC_NO", "");
                }
                if (BENName == null)
                {
                    param.Add("@BENName", "");
                }

                var results = await _db.LoadData<Q_EXLCPurchasePaymentListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_PurchasePaymentListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCPurchasePaymentListPageRsp>)results;

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
                response.Data = new List<Q_EXLCPurchasePaymentListPageRsp>();
            }
            return BadRequest(response);
        }

        //[HttpGet("query")]
        //public async Task<IEnumerable<Q_EXBCPurchasePaymentQueryPageRsp>> GetAllQuery( string? CenterID, string? EXPORT_BC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        //{
        //    DynamicParameters param = new();

        //    //param.Add("@ListType", @ListType);
        //    param.Add("@CenterID", CenterID);
        //    param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
        //    param.Add("@BENName", BENName);
        //    param.Add("@USER_ID", USER_ID);
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    if (EXPORT_BC_NO == null)
        //    {
        //        param.Add("@EXPORT_BC_NO", "");
        //    }
        //    if (BENName == null)
        //    {
        //        param.Add("@BENName", "");
        //    }

        //    var results = await _db.LoadData<Q_EXBCPurchasePaymentQueryPageRsp, dynamic>(
        //                storedProcedure: "usp_q_EXLC_PurchasePaymentQueryPage",
        //                param);
        //    return results;
        //}


        [HttpGet("select")]
        public async Task<ActionResult<EXLCPurchasePaymentSelectResponse>> Select(string? EXPORT_LC_NO, string? EVENT_NO, string? LFROM)
        {
            EXLCPurchasePaymentSelectResponse response = new EXLCPurchasePaymentSelectResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) ||
                EVENT_NO == null ||
                string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXLCPEXPaymentRsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@EVENT_NO", EVENT_NO);
                param.Add("@LFROM", LFROM);

                param.Add("@PExLcRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@PEXLCPEXPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<PEXLCPEXPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_PurchasePayment_Select",
                           param);

                var PExLcRsp = param.Get<dynamic>("@PExLcRsp");
                var pexlcpexpaymentrsp = param.Get<dynamic>("@PEXLCPEXPaymentRsp");

                if (PExLcRsp > 0 && !string.IsNullOrEmpty(pexlcpexpaymentrsp))
                {
                    PEXLCPEXPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXLCPEXPaymentRsp>(pexlcpexpaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Error selecting Purchase Payment";
                    response.Data = new PEXLCPEXPaymentRsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXLCPEXPaymentRsp();
            }
            return BadRequest(response);
        }

        [HttpPost("save")]
        public ActionResult<PEXLCPPaymentPEXPaymentPPayDetailsSaveResponse> Save([FromBody] PEXLCPPaymentPEXPaymentPPayDetailsSaveRequest data)
        {
            PEXLCPPaymentPEXPaymentPPayDetailsSaveResponse response = new();
            // Class validate
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {

                        // 0 - Select EXLC Master
                        var pExlcMaster = (from row in _context.pExlcs
                                           where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                 row.RECORD_TYPE == "MASTER"
                                           select row).FirstOrDefault();

                        // 1 - Check if Master Exists
                        if (pExlcMaster == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC Master does not exists";
                            return BadRequest(response);
                        }

                        // 2 - Update Master
                        _context.Database.ExecuteSqlRaw($"UPDATE pExlc SET REC_STATUS = 'P' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");


                        var targetEventNo = pExlcMaster.EVENT_NO + 1;

                        // 2 - Insert EVENT
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlc eventRow = data.PEXLC;


                        // 3 - Select Existing Event
                        var pExlcEvent = (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                (row.REC_STATUS == "P" || row.REC_STATUS == "W") &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == targetEventNo
                                          select row).AsNoTracking().FirstOrDefault();


                        eventRow.CenterID = USER_CENTER_ID;
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
                        eventRow.EVENT_NO = targetEventNo;
                        eventRow.EVENT_MODE = "E";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                      //  eventRow.EVENT_DATE = DateTime.Today; // Without Time
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = UpdateDateT; // With Time

                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE = UpdateDateNT; // Without Time

                        eventRow.PurposeCode = data.PEXLC.PurposeCode;

                        eventRow.WithOutFlag = data.PEXLC.WithOutFlag;
                        eventRow.WithOutType = null;
                        eventRow.Wref_Bank_ID = "";

                        if (eventRow.WithOutFlag == "Y")
                        {
                            eventRow.WithOutType = data.PEXLC.WithOutType;
                            eventRow.Wref_Bank_ID = data.PEXLC.Wref_Bank_ID;
                        }

                        eventRow.COMMONTT = data.PEXLC.COMMONTT;
                        eventRow.INT_AMT_THB = data.PEXLC.INT_AMT_THB;
                        eventRow.INVOICE = data.PEXLC.INVOICE;
                        eventRow.REC_STATUS = "P";
                        eventRow.IN_USE = 0;
                        eventRow.AGENT_BANK_ID = data.PEXLC.AGENT_BANK_ID;
                        eventRow.AGENT_BANK_INFO = data.PEXLC.AGENT_BANK_INFO;
                        //eventRow.ValueDate = DateTime.Today;
                        eventRow.PAYMENT_INSTRU = data.PEXLC.PAYMENT_INSTRU;

                        if (eventRow.PAYMENT_INSTRU == "PAID")
                        {
                            eventRow.METHOD = data.PEXLC.METHOD;
                            if (eventRow.RECEIVED_NO == null || eventRow.RECEIVED_NO == "")
                            {
                                eventRow.RECEIVED_NO = ExportLCHelper.GenRefNo(_context, USER_CENTER_ID, USER_ID, "PAYD", UpdateDateT, UpdateDateNT);
                            }


                            // Call Save Payment
                            eventRow.RECEIVED_NO = ExportLCHelper.SavePayment(_context, USER_CENTER_ID, USER_ID, eventRow, data.PPAYMENT, UpdateDateT, UpdateDateNT);

                            // Call Save PaymentDetail
                            //if (eventRow.RECEIVED_NO != "ERROR")
                            //{
                            //    bool savePayDetailResult = ExportLCHelper.SavePaymentDetail(_context, eventRow, data.PPAYDETAILS);
                            //}
                        }
                        else
                        {
                            // UNPAID
                            eventRow.METHOD = "";
                            eventRow.RECEIVED_NO = "";
                            eventRow.VOUCH_ID = "";
                            var existingPaymentRows = (from row in _context.pPayments
                                                       where row.RpReceiptNo == eventRow.RECEIVED_NO
                                                       select row).ToList();
                            foreach (var row in existingPaymentRows)
                            {
                                _context.pPayments.Remove(row);

                            }

                            var existingPPayDetailRows = (from row in _context.pPayDetails
                                                          where row.DpReceiptNo == eventRow.RECEIVED_NO
                                                          select row).ToList();
                            foreach (var row in existingPPayDetailRows)
                            {
                                _context.pPayDetails.Remove(row);
                            }

                        }

                        eventRow.NEGO_COMM = data.PEXLC.NEGO_COMM;
                        eventRow.TELEX_SWIFT = data.PEXLC.TELEX_SWIFT;
                        eventRow.COURIER_POSTAGE = data.PEXLC.COURIER_POSTAGE;
                        eventRow.STAMP_FEE = data.PEXLC.STAMP_FEE;
                        eventRow.BE_STAMP = data.PEXLC.BE_STAMP;
                        eventRow.COMM_OTHER = data.PEXLC.COMM_OTHER;
                        eventRow.HANDING_FEE = data.PEXLC.HANDING_FEE;
                        eventRow.DRAFTCOMM = data.PEXLC.DRAFTCOMM;
                        eventRow.TOTAL_CHARGE = data.PEXLC.TOTAL_CHARGE;
                        eventRow.REFUND_TAX_YN = data.PEXLC.REFUND_TAX_YN;
                        eventRow.REFUND_TAX_AMT = data.PEXLC.REFUND_TAX_AMT;
                        eventRow.TOTAL_AMOUNT = data.PEXLC.TOTAL_AMOUNT;
                        eventRow.PAYMENTTYPE = data.PEXLC.PAYMENTTYPE;
                        eventRow.NARRATIVE = data.PEXLC.NARRATIVE;
                        eventRow.ALLOCATION = data.PEXLC.ALLOCATION;
                        eventRow.DISCOUNT_CCY = data.PEXLC.DISCOUNT_CCY;
                        eventRow.DISCOUNT_RATE = data.PEXLC.DISCOUNT_RATE;
                        eventRow.DISCOUNT_AMT = data.PEXLC.DISCOUNT_AMT;
                        eventRow.CURRENT_INT_RATE = data.PEXLC.CURRENT_INT_RATE;
                        eventRow.FlagBack = data.PEXLC.FlagBack;

                        // TODO: PAYMENT

                        pExPayment pExPaymentRow = data.PEXPAYMENT;


                        // 3 - Select Existing Event
                        var pExPayment = (from row in _context.pExPayments
                                          where row.DOCNUMBER == data.PEXLC.EXPORT_LC_NO &&
                                                (row.REC_STATUS == "P" || row.REC_STATUS == "W") &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == targetEventNo
                                          select row).AsNoTracking().FirstOrDefault();

                        pExPaymentRow.DOCNUMBER = data.PEXLC.EXPORT_LC_NO;
                        pExPaymentRow.EVENT_NO = targetEventNo;
                        pExPaymentRow.EVENT_TYPE = EVENT_TYPE;

                        pExPaymentRow.CenterID = USER_CENTER_ID;
                        pExPaymentRow.REC_STATUS = "P";
                       
                        if (!string.IsNullOrEmpty(data.PEXPAYMENT.fb_ccy))
                        {
                            data.PEXPAYMENT.fb_ccy = data.PEXPAYMENT.fb_ccy;
                        }
                        else
                        {
                            data.PEXPAYMENT.fb_ccy = null;
                        }

                        if (pExPaymentRow.PAYMENT_INSTRU == "UNPAID")
                        {
                            pExPaymentRow.Method = "";
                            eventRow.RECEIVED_NO = "";
                            eventRow.VOUCH_ID = "";
                        }

                        // GL

                        /*
                         If OptPaid.Value Then
                            If optIssueBankPay.Value Then
                                Dim GLEvent As String
                                If ChKWithOut.Value = 1 Then
                                    If OpFund.Value = True Then
                                        GLEvent = ""
                                    ElseIf OpIUFund.Value = True Then
                                        GLEvent = "PAYMENT-PUR-UNISB"
                                    ElseIf OpAUFund.Value = True Then
                                        GLEvent = "PAYMENT-PUR-UNAGB"
                                    End If
                                Else
                                        GLEvent = UCase(eventType)
                                End If
                                StartPEXLC TxtExLcCode.Text, mskEvenDate.Text, eventType, TmpEvent_no, GLEvent, True
                            Else
                                If ChKWithOut.Value = 1 Then
                                    If OpFund.Value = True Then
                                        GLEvent = ""
                                    ElseIf OpIUFund.Value = True Then
                                        GLEvent = "CPAYMENT-PUR-UNISB"
                                    ElseIf OpAUFund.Value = True Then
                                        GLEvent = "CPAYMENT-PUR-UNAGB"
                                    End If
                                Else
                                        GLEvent = "CPAYMENT PURCHASE"
                                End If
                                StartPEXLC TxtExLcCode.Text, mskEvenDate.Text, eventType, TmpEvent_no, GLEvent, True
                            End If
                            cSql = "Update pExlc set VOUCH_ID ='" & ImpVouch & "' " _
                                & "where EXPORT_LC_NO='" & TxtExLcCode.Text & "' and EVENT_TYPE ='" & eventType & "'  " _
                                & "and rec_status IN('P','W')  and event_no = " & TmpEvent_no & "  "
                            cn.Execute cSql
                            LbVouch.Caption = ImpVouch
                            Call PrintPostGL
                        End If
                        */
                      //  eventRow.VOUCH_ID = "MOCK VOUCH_ID";

                        // Commit pExlc
                        if (pExlcEvent == null)
                        {
                            // Insert
                            eventRow.EVENT_NO = targetEventNo;

                            _context.pExlcs.Add(eventRow);
                        }
                        else
                        {
                            // Update
                            _context.pExlcs.Update(eventRow);
                        }

                        // Commit PExPayment
                        if (pExlcEvent == null)
                        {
                            // Insert
                            _context.pExPayments.Add(pExPaymentRow);
                        }
                        else
                        {
                            // Update
                            _context.pExPayments.Update(pExPaymentRow);
                        }

                        // TODO

                        _context.SaveChanges();
                        transaction.Complete();
                        transaction.Dispose();
                        response.Code = Constants.RESPONSE_OK;

                        PEXLCPPaymentPEXPaymentPPayDetailDataContainer responseData = new();
                        responseData.PEXLC = eventRow;
                        responseData.PPAYMENT = data.PPAYMENT;
                       responseData.PEXPAYMENT = data.PEXPAYMENT;

                        response.Data = responseData;

                        bool resGL;
                        bool resPayD;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent = response.Data.PEXLC.EVENT_TYPE;
                        eventDate = response.Data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");
                        if (response.Data.PEXLC.PAYMENT_INSTRU == "PAID")
                        {
                            if (response.Data.PEXPAYMENT.PAY_TYPE ==1)
                            {
                                if (data.PEXLC.WithOutFlag == "Y")
                                {
                                    if (data.PEXLC.WithOutType == "F")
                                    {
                                        GLEvent = "";
                                    }
                                    if (data.PEXLC.WithOutType == "I")
                                    {
                                        GLEvent = "PAYMENT-PUR-UNISB";
                                    }
                                    if (data.PEXLC.WithOutType == "A")
                                    {
                                        GLEvent = "PAYMENT-PUR-UNAGB";
                                    }
                                }
                                else
                                {
                                    GLEvent = response.Data.PEXLC.EVENT_TYPE;
                                }
                            }

                            if (response.Data.PEXPAYMENT.PAY_TYPE == 2)
                            {
                                if (data.PEXLC.WithOutFlag == "Y")
                                {
                                    if (data.PEXLC.WithOutType == "F")
                                    {
                                        GLEvent = "";
                                    }
                                    if (data.PEXLC.WithOutType == "I")
                                    {
                                        GLEvent = "CPAYMENT-PUR-UNISB";
                                    }
                                    if (data.PEXLC.WithOutType == "A")
                                    {
                                        GLEvent = "CPAYMENT-PUR-UNAGB";
                                    }
                                }
                                else
                                {
                                    GLEvent = "CPAYMENT PURCHASE";
                                }
                            }
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(response.Data.PEXLC.EXPORT_LC_NO,
                                eventDate,
                                response.Data.PEXLC.EVENT_TYPE,
                                response.Data.PEXLC.EVENT_NO,
                                GLEvent,true);

                        }
                        else
                        {
                            resVoucherID = "";

                        }
                        if (resVoucherID != "ERROR")
                        {
                            resGL = true;
                            response.Data.PEXLC.VOUCH_ID = resVoucherID;
                        }
                        else
                        {
                            resGL = false;
                        }

                        string resPayDetail;
                        if (response.Data.PPAYMENT != null)
                        {
                            resPayDetail = ISPModule.PayDetailEXLC.PayDetail_PurchasePay(response.Data.PEXLC.EXPORT_LC_NO, response.Data.PEXLC.EVENT_NO, response.Data.PEXLC.RECEIVED_NO);
                            if (resPayDetail != "ERROR")
                            {
                                resPayD = true;
                            }
                            else
                            {
                                resPayD = false;
                            }
                        }
                        else
                        {
                            resPayD = true;
                        }

                        response.Message = "Export L/C Saved";
                        return Ok(response);
                    }
                    catch (Exception e)
                    {
                        if (e.InnerException != null
                            && e.InnerException.Message.Contains("Violation of PRIMARY KEY constraint"))
                        {
                            // Key already exists
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC " + EVENT_TYPE + " Event Already exists / Wrong Event State";
                            return BadRequest(response);
                        }
                        else
                        {
                            // Rollback
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = e.ToString();
                            return BadRequest(response);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                return BadRequest(response);
            }

        }


        [HttpPost("release")]
        public ActionResult<EXLCResultResponse> Release([FromBody] PEXLCSaveRequest data)
        {
            EXLCResultResponse response = new();
            // Class validate
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {

                        // 0 - Select EXLC Master
                        var pExlcMaster = (from row in _context.pExlcs
                                           where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                 row.RECORD_TYPE == "MASTER"
                                           select row).FirstOrDefault();

                        // 1 - Check if Master Exists
                        if (pExlcMaster == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC Master does not exists";
                            return BadRequest(response);
                        }


                        var targetEventNo = pExlcMaster.EVENT_NO + 1;

                        // 2 - Select Existing EVENT
                        var pExlcEvent = (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                row.REC_STATUS == "P" &&
                                                row.BUSINESS_TYPE == BUSINESS_TYPE
                                          select row).AsNoTracking().FirstOrDefault();

                        // 3 - Check Event Exists
                        if (pExlcEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC " + EVENT_TYPE + " Event does not exists";
                            return BadRequest(response);
                        }

                        // 4 - Insert/Update EVENT
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlc eventRow = pExlcEvent;

                        var opEvent = "";
                        if (eventRow.METHOD.Contains("DEBIT"))
                        {
                            opEvent = "DR";
                        }
                        else if (eventRow.METHOD.Contains("CREDIT"))
                        {
                            opEvent = "CR";
                        }
                        if (opEvent != "")
                        {
                            /*
                             Req1PSys = Send1PTxn(txtBeneCode.Text, TxtExLcCode.Text, OPSeqNo, "EXLC", op_event, _
                                txtAcctNo(1).Text, txtAmtDebt(1).Text, _
                                txtAcctNo(2).Text, txtAmtDebt(2).Text, _
                                txtAcctNo(3).Text, txtAmtDebt(3).Text)
                                If Req1PSys = False Then
                                    cSql = "Update pExlc set   REC_STATUS ='W'   where EXPORT_LC_NO='" & TxtExLcCode.Text & "' " _
                                           & "and record_type='EVENT' and Event_No =" & OPSeqNo & ""
                                    cn.Execute cSql
                                    framRelease.Visible = False
                                    CmdDel.Enabled = True
                                    CmdSave.Enabled = False
                                    CmdPrint.Enabled = False
                                     CmdExit.Enabled = True: SSTab1.Enabled = True
                                    TxtExLcCode.Enabled = True: cmdFndLC.Enabled = True
                                    Exit Sub
                                End If
                            */
                    }


                        // 4 - Update Master
                    pExlcMaster.AUTH_CODE = USER_ID;
                     pExlcMaster.AUTH_DATE = UpdateDateT; // With Time
                     pExlcMaster.UPDATE_DATE = UpdateDateT; // With Time

                        var pExPayments = (from row in _context.pExPayments
                                           where row.DOCNUMBER == data.PEXLC.EXPORT_LC_NO &&
                                                 row.EVENT_TYPE == EVENT_TYPE &&
                                                 row.EVENT_NO == targetEventNo
                                           select row).AsNoTracking().FirstOrDefault();
                        double Tot_paid;
                        if (data.PEXLC.PARTIAL_FULL_RATE ==2) //full rate
                        {

                            if (pExPayments.SETTLEMENT_CREDIT==0 || pExPayments.SETTLEMENT_CREDIT == 1)//fcy to thb
                            {
           
                                if (pExlcEvent.TENOR_OF_COLL ==1)
                                {
                                    Tot_paid = pExPayments.SIGHT_PAID_AMT.Value;
                                }
                                else
                                {
                                    Tot_paid = pExPayments.TERM_PAID_AMT.Value;
                                }
                            }
                            else if (pExPayments.SETTLEMENT_CREDIT == 2)
                            {
                                if (pExlcEvent.TENOR_OF_COLL == 1)
                                {
                                    Tot_paid = pExPayments.SIGHT_PAID_THB.Value;
                                }
                                else
                                {
                                    Tot_paid = pExPayments.TERM_PAID_THB.Value;
                                }
                            }
                        }//full rate
                        else
                        {
                            //if (pExPayments.SETTLEMENT_CREDIT == 0 || pExPayments.SETTLEMENT_CREDIT == 1)//fcy to thb
                            //{
                            //    Tot_paid =pExPayments.PARTIAL_AMT1.Value+ pExPayments.PARTIAL_AMT2.Value+
                            //        pExPayments.PARTIAL_AMT3.Value + pExPayments.PARTIAL_AMT4.Value +
                            //        pExPayments.PARTIAL_AMT5.Value + pExPayments.PARTIAL_AMT6.Value 
                            //}
                            //else if (pExPayments.SETTLEMENT_CREDIT == 2)//fcy to thb
                            //{
                            //    Tot_paid = pExPayments.PARTIAL_AMT1_THB.Value + pExPayments.PARTIAL_AMT2_THB.Value +
                            //        pExPayments.PARTIAL_AMT3_THB.Value + pExPayments.PARTIAL_AMT4_THB.Value +
                            //        pExPayments.PARTIAL_AMT5_THB.Value + pExPayments.PARTIAL_AMT6_THB.Value 
                            //}

                        }
                        pExlcMaster.PurposeCode = pExlcEvent.PurposeCode;



//                        !VOUCH_ID = LbVouch.Caption
//                         !user_id = cUserCode
//                         !RELETE_PACK = txtRelaPackNo.Text
//                         !update_date = getDateTime("YMDHMS")
//    'DAT
//    '!EVENT_DATE = nowDate$


//    'PAYMENT
//    !NEGO_AMT = Val(num(totNegoBAl.Text))
//    !LESS_AGENT = Val(num(txtLessAgent.Text))
//    !tot_nego_amount = Val(num(totNegoAmt.Text))

//    !NET_PROCEED_CLAIM = Val(Format(txtNetProcClaim.Text, "#0.00"))
//    !BANK_CHARGE_AMT = Val(Format(txtBankCharge.Text, "#0.00"))
//    !TOT_NEGO_AMT = Val(Format(totNegoAmt.Text, "#0.00"))
//    If optPayType(1).Value Then !PaymentType = "F"
//    If optPayType(0).Value Then !PaymentType = "P"

//    !PURCHASE_AMT = IIf(IsNull(!PURCHASE_AMT), 0, !PURCHASE_AMT) - Tot_paid
//    !TOT_NEGO_AMT = IIf(IsNull(!TOT_NEGO_AMT), 0, !TOT_NEGO_AMT) - Tot_paid
//    !tot_nego_amount = !TOT_NEGO_AMT
//    If!TOT_NEGO_AMT = 0 Or optPayType(1).Value Then
//        !PaymentType = "F"
//        ckPayFull = True
//    Else
//        !PaymentType = "P"
//        ckPayFull = False
//        If optFullRate(1).Value Then
//            !PARTIAL_AMT1 = !PURCHASE_AMT
//            !PARTIAL_AMT2 = 0
//            !PARTIAL_AMT3 = 0
//            !PARTIAL_AMT4 = 0
//            !PARTIAL_AMT5 = 0
//            !PARTIAL_AMT6 = 0

//            !PARTIAL_AMT1_THB = !PURCHASE_AMT * !PARTIAL_RATE1
//            !PARTIAL_AMT2_THB = 0
//            !PARTIAL_AMT3_THB = 0
//            !PARTIAL_AMT4_THB = 0
//            !PARTIAL_AMT5_THB = 0
//            !PARTIAL_AMT6_THB = 0

//            !PARTIAL_RATE2 = 0
//            !PARTIAL_RATE3 = 0
//            !PARTIAL_RATE4 = 0
//            !PARTIAL_RATE5 = 0
//            !PARTIAL_RATE6 = 0

//            !FORWARD_CONRACT_NO1 = ""
//            !FORWARD_CONRACT_NO2 = ""
//            !FORWARD_CONRACT_NO3 = ""
//            !FORWARD_CONRACT_NO4 = ""
//            !FORWARD_CONRACT_NO5 = ""
//            !FORWARD_CONRACT_NO6 = ""
//        End If
//    End If


//    !TOTAL_NEGO_BALANCE = Val(num(TxtNetNegoCcy.Text))
//    !total_nego_bal_thb = Val(num(TxtNetNegoTHB.Text))


//'TAB 2
//    !nego_comm = num(txtCharge(0).Text): !telex_swift = num(txtCharge(1).Text): !courier_postage = num(txtCharge(2).Text)
//    !stamp_fee = num(txtCharge(3).Text): !be_stamp = num(txtCharge(4).Text): !comm_Other = num(txtCharge(5).Text)
//    !handing_fee = num(txtCharge(6).Text): !draftComm = num(txtCharge(7).Text)
//    !total_charge = num(txtTotCharge.Text)
//    !refund_tax_yn = IIf(optRefund(1).Value = True, optRefund(1).Tag, optRefund(2).Tag)
//    !refund_tax_amt = num(txtTax.Text)
//    !TOTAL_AMOUNT = num(txtTotAcc.Text)
//    If OptPaid.Value = True Then 'if not paid not save
//        !payment_instru = "PAID"
//        !method = CmbMethod.Text
//        !RECEIVED_NO = ReceiptNo
//    Else
//        !payment_instru = "UNPAID"
//        !method = ""
//        !RECEIVED_NO = ReceiptNo
//    End If
//    !DISCOUNT_CCY = Val(num(TxtDiscount(1).Text))
//    !discrate = Val(Format(TxtDiscount(0).Text, "#0.00000000"))
//    !DISCOUNT_AMT = Val(num(txtCharge(8).Text))
//    !ValueDate = cvTxt2Date(mskPayDate.Text)


                        _context.SaveChanges();

                        // 5 - Update Master/Event PK to Release
                        _context.Database.ExecuteSqlRaw($"UPDATE pExlc SET REC_STATUS = 'R' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");


                        /*
                         * FRONT OR BACK LOGIC
                         If Duplicate = True Then
                            If ChkReleaseMaster("EXLC", Trim(TxtExLcCode.Text)) = True Then CmdDel.Enabled = False: framRelease.Visible = False: CmdSave.Enabled = False: Exit Sub
                         End If
                         */

                        // 6 - Update GL Flag
                        var gls = (from row in _context.pDailyGLs
                                   where row.VouchID == data.PEXLC.VOUCH_ID &&
                                            row.VouchDate == data.PEXLC.EVENT_DATE.GetValueOrDefault().Date
                                   select row).ToList();

                        foreach (var row in gls)
                        {
                            row.SendFlag = "R";
                        }


                        if (data.PEXLC.WithOutFlag == "N")
                        {
                            var result = ExportLCHelper.UpdateCustomerLiability(_context, data.PEXLC);
                        }
                        else if (data.PEXLC.WithOutFlag == "Y")
                        {
                            var result = ExportLCHelper.UpdateBankLiability(_context, data.PEXLC);
                        }

                        transaction.Complete();




                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export L/C Released";
                        return Ok(response);
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                return BadRequest(response);
            }
        }

        [HttpPost("delete")]
        public async Task<ActionResult<EXLCResultResponse>> Delete([FromBody] PEXLCDeleteRequest data)
        {
            EXLCResultResponse response = new EXLCResultResponse();
            DynamicParameters param = new();

            // Validate
            if (string.IsNullOrEmpty(data.EXPORT_LC_NO) ||
                string.IsNullOrEmpty(data.EVENT_DATE)
                )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_DATE is required";
                return BadRequest(response);
            }


            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // 0 - Select EXLC MASTER
                        var pExlc = (from row in _context.pExlcs
                                     where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                           row.RECORD_TYPE == "MASTER"
                                     select row).FirstOrDefault();

                        if (pExlc == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export L/C does not exist";
                            return BadRequest(response);
                        }



                        // 1 - Delete Daily GL
                        var dailyGL = (from row in _context.pDailyGLs
                                       where row.VouchID == data.VOUCH_ID &&
                                             row.VouchDate == DateTime.Parse(data.EVENT_DATE)
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }


                        // 2 - Update pExlc EVENT
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'T' WHERE EXPORT_LC_NO = '{data.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE = '{EVENT_TYPE}' AND REC_STATUS IN ('P','W')");




                        // 3 - Cancel PExPayment
                        var targetEventNo = pExlc.EVENT_NO + 1;
                        var pExPayments = (from row in _context.pExPayments
                                           where row.DOCNUMBER == data.EXPORT_LC_NO &&
                                                 row.EVENT_TYPE == EVENT_TYPE &&
                                                 row.EVENT_NO == targetEventNo
                                           select row).ToListAsync();

                        foreach (var row in await pExPayments)
                        {
                            _context.pExPayments.Remove(row);
                        }

                        // 4 - Update pExlc Master

                        /* 
                        var pExlcMasters = (from row in _context.pExlcs
                                         where  row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "MASTER"
                                         select row).ToListAsync();

                        foreach (var row in await pExlcMasters)
                        {
                            row.REC_STATUS = "R";
                            //row.EVENT_NO = targetEventNo;
                        }*/

                        // Commit
                        await _context.SaveChangesAsync();

                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', EVENT_NO = {targetEventNo} WHERE EXPORT_LC_NO = '{data.EXPORT_LC_NO}' AND RECORD_TYPE = 'MASTER'");

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
                    response.Message = "Export L/C Deleted";
                    return Ok(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                return BadRequest(response);
            }
        }
    }
}
