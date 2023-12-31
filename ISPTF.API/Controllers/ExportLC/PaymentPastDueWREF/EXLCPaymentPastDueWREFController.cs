﻿using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.ExportLC;
using ISPTF.Models.PEXPayment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models.ExportLC.PaymentOverDueWREF;
using System.Text.Json;
using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCPaymentPastDueWREFController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "PAYD";
        private const string EVENT_TYPE = "PAYMENT PAST DUE";
        public EXLCPaymentPastDueWREFController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCPaymentPastDueWREFListResponse>> List(string? ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? Page, string? PageSize)
        {
            EXLCPaymentPastDueWREFListResponse response = new EXLCPaymentPastDueWREFListResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || 
                string.IsNullOrEmpty(CenterID) || 
                string.IsNullOrEmpty(Page) || 
                string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCPaymentPastDueWREFListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EXLCPaymentPastDueWREFListPageRsp>();
                return BadRequest(response);
            }

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

                var results = await _db.LoadData<Q_EXLCPaymentPastDueWREFListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_PaymentPastDueWREFListPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCPaymentPastDueWREFListPageRsp>)results;

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
                response.Data = new List<Q_EXLCPaymentPastDueWREFListPageRsp>();
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
//        public async Task<IEnumerable<PEXBCPEXPaymentRsp>> GetAllSelect(string? EXPORT_BC_NO , string? EVENT_NO, string? LFROM)
        public async Task<ActionResult<PEXLCPEXPaymentResponse>> GetAllSelect(string? EXPORT_LC_NO, string? EVENT_NO, string? LFROM)
        {
            PEXLCPEXPaymentResponse response = new PEXLCPEXPaymentResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) || 
                string.IsNullOrEmpty(EVENT_NO) || 
                string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXLCPEXPaymentRsp();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@EVENT_NO", EVENT_NO);
                //param.Add("@RECORD_TYPE", RECORD_TYPE);
                //param.Add("@REC_STATUS", REC_STATUS);
                param.Add("@LFROM", LFROM);
                param.Add("@PExLcRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);
                param.Add("@PEXLCPEXPaymentRsp", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);

                var results = await _db.LoadData<PEXLCPEXPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_PaymentPastDueWREF_Select",
                           param);
                var PEXLCRsp = param.Get<dynamic>("@PExLcRsp");
                var pexlcpexpaymentrsp = param.Get<dynamic>("@PEXLCPEXPaymentRsp");

                if (PEXLCRsp > 0 && !string.IsNullOrEmpty(pexlcpexpaymentrsp))
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
                    response.Message = "EXPORT L/C NO does not exit";
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
        public async Task<ActionResult<PEXLCPPaymentPEXPaymentPPayDetailsSaveResponse>> Save([FromBody] PEXLCPPaymentPEXPaymentPPayDetailsSaveRequest data)
        {
            PEXLCPPaymentPEXPaymentPPayDetailsSaveResponse response = new();
            // Class validate

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
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'P' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");

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

                        if (pExlcEvent == null)
                        {
                            eventRow.VOUCH_ID = "";
                            eventRow.RECEIVED_NO = "";
                        }
                        eventRow.CenterID = USER_CENTER_ID;
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
                        eventRow.EVENT_NO = targetEventNo;
                        eventRow.EVENT_MODE = "E";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                        eventRow.EVENT_DATE = DateTime.Today; // Without Time
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = DateTime.Now; // With Time

                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE = DateTime.Today; // Without Time


                        if (eventRow.PAYMENT_INSTRU == "PAID")
                        {
                            eventRow.METHOD = data.PEXLC.METHOD;
                            // Call Save PaymentDetail
                        }
                        else
                        {
                            // UNPAID
                            eventRow.METHOD = "";
                            eventRow.VOUCH_ID = "";
                            var existingPaymentRows = (from row in _context.pPayments
                                                       where row.RpReceiptNo == eventRow.RECEIVED_NO
                                                       select row).ToListAsync();
                            foreach (var row in await existingPaymentRows)
                            {
                                _context.pPayments.Remove(row);
                            }

                            var existingPPayDetailRows = (from row in _context.pPayDetails
                                                          where row.DpReceiptNo == eventRow.RECEIVED_NO
                                                          select row).ToListAsync();
                            foreach (var row in await existingPPayDetailRows)
                            {
                                _context.pPayDetails.Remove(row);
                            }
                            eventRow.RECEIVED_NO = "";

                        }

                        // Commit
                        if (pExlcEvent == null)
                        {
                            // Insert
                            eventRow.VOUCH_ID = "";
                            _context.pExlcs.Add(eventRow);
                        }
                        else
                        {
                            // Update
                            _context.pExlcs.Update(eventRow);
                        }

                        await _context.SaveChangesAsync();


                        pExPayment exPaymentRow = data.PEXPAYMENT;
                        exPaymentRow.DOCNUMBER = data.PEXLC.EXPORT_LC_NO;
                        exPaymentRow.EVENT_NO = targetEventNo;
                        exPaymentRow.EVENT_TYPE = EVENT_TYPE;
                        exPaymentRow.REC_STATUS = "P";
                        exPaymentRow.CenterID = USER_CENTER_ID;

                        if (exPaymentRow.PAYMENT_INSTRU == "UNPAID")
                        {
                            exPaymentRow.Method = "";
                            eventRow.RECEIVED_NO = "";
                            eventRow.VOUCH_ID = "";
                        }
                        // 3 - Select Existing Event
                        var pExPayment = (from row in _context.pExPayments
                                          where row.DOCNUMBER == data.PEXLC.EXPORT_LC_NO &&
                                                (row.REC_STATUS == "P" || row.REC_STATUS == "W") &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == targetEventNo
                                          select row).AsNoTracking().FirstOrDefault();

                        // Commit
                        if (pExPayment == null)
                        {
                            // Insert
                            _context.pExPayments.Add(exPaymentRow);
                        }
                        else
                        {
                            // Update
                            _context.pExPayments.Update(exPaymentRow);
                        }

                        await _context.SaveChangesAsync();

                        // 4 - GL MOCK WAIT DLL

                        var glEvent = "CPAYMENT PURCHASE";
                        if (eventRow.WithOutFlag == "Y")
                        {
                            if (eventRow.WithOutType == "U")
                            {
                                glEvent = "PAYMENT-PDU-UNISB";
                            }
                            else if (eventRow.WithOutType == "A")
                            {
                                glEvent = "PAYMENT-PDU-UNAGB";
                            }
                        }

                        // CALL DLL
                        var glVouchId = "VOUCH ID FROM GL DLL" + " " + glEvent;
                        eventRow.VOUCH_ID = glVouchId;
                        await _context.SaveChangesAsync();

                        transaction.Complete();

                        response.Code = Constants.RESPONSE_OK;

                        PEXLCPPaymentPEXPaymentPPayDetailDataContainer responseData = new();
                        responseData.PEXLC = eventRow;
                        responseData.PPAYMENT = data.PPAYMENT;
                        responseData.PEXPAYMENT = data.PEXPAYMENT;
                      //  responseData.PPAYDETAILS = data.PPAYDETAILS;

                        response.Data = responseData;
                        response.Message = "Export L/C Saved";
                        return Ok(response);
                    }
                    catch (Exception e)
                    {
                        if (e.InnerException != null &&
                            e.InnerException.Message.Contains("Violation of PRIMARY KEY constraint"))
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
                        pExlcMaster.AUTH_DATE = DateTime.Now; // With Time
                        pExlcMaster.UPDATE_DATE = DateTime.Now; // With Time



                        _context.SaveChanges();

                        // 5 - Update Master/Event PK to Release
                        _context.Database.ExecuteSqlRaw($"UPDATE pExlc SET REC_STATUS = 'R' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");


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
                            //Call UpdateBankLiab
                            //var result = await ExportLCHelper.UpdateBankLiability(_context, data.PEXLC);
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

                        // 1 - Cancel PPayment
                        var paymentPastdueExlcs = (from row in _context.pExlcs
                                                where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                                      row.RECORD_TYPE == "EVENT" &&
                                                      row.EVENT_TYPE == "PAYMENT PAST DUE" &&
                                                      row.REC_STATUS == "P" &&
                                                      (row.RECEIVED_NO != null && row.RECEIVED_NO != "")
                                                select row).ToListAsync();

                        foreach (var row in await paymentPastdueExlcs)
                        {
                            var pPayment = (from row2 in _context.pPayments
                                            where row2.RpReceiptNo == row.RECEIVED_NO
                                            select row2).ToListAsync();
                            foreach (var rowPayment in await pPayment)
                            {
                                rowPayment.RpStatus = "C";
                            }
                        }


                        // 2 - Delete Daily GL
                        var dailyGL = (from row in _context.pDailyGLs
                                       where row.VouchID == data.VOUCH_ID &&
                                             row.VouchDate == DateTime.Parse(data.EVENT_DATE)
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }


                        // 3 - Update pExPastDue1
                        var targetEventNo = pExlc.EVENT_NO + 1;
                        var pExPastDues1 = (from row in _context.pExPastDues
                                      where row.DocNumber == data.EXPORT_LC_NO &&
                                            row.EventNo == targetEventNo &&
                                            row.RecType == "E"
                                      select row).ToListAsync();

                        foreach (var row in await pExPastDues1)
                        {
                            row.Status = "T";
                            row.RecStatus = "T";
                        }


                        // 4 - Update pExPastDue2
                        var pExPastDues2 = (from row in _context.pExPastDues
                                           where row.DocNumber == data.EXPORT_LC_NO &&
                                                 row.RecType == "M"
                                           select row).ToListAsync();

                        foreach (var row in await pExPastDues2)
                        {
                            row.RecStatus = "R";
                        }

                        // Commit
                        await _context.SaveChangesAsync();

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
