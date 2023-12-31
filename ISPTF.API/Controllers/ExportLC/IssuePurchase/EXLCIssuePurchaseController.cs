using Dapper;
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
using Microsoft.EntityFrameworkCore;
using ISPTF.Models.LoginRegis;
using System.Transactions;
using AutoMapper;
using CSharpTest.Net;
using System.Data.SqlClient;
using ISPTF.Commons;
namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCIssuePurchaseController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "1";
        private const string EVENT_TYPE = "Issue Purchase";

        //private  DateTime GetSysDate = ModDate.GetSystemDateTime();


       
        public EXLCIssuePurchaseController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("newlist")]
        public async Task<ActionResult<EXLCIssuePurchaseNewListResponse>> GetAllNew(string? CenterID, string? RegDocNo, string? BENName, string? Page, string? PageSize)
        {
            EXLCIssuePurchaseNewListResponse response = new EXLCIssuePurchaseNewListResponse();
           
            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCIssueNewPageRsp>();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@CenterID", CenterID);
                param.Add("@RegDocNo", RegDocNo);
                param.Add("@BENName", BENName);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (RegDocNo == null)
                {
                    param.Add("@RegDocNo", "");
                }
                if (BENName == null)
                {
                    param.Add("@BENName", "");
                }
                var results = await _db.LoadData<Q_EXLCIssueNewPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXLC_IssuePurchNewPage",
                        param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCIssueNewPageRsp>)results;

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
                response.Data = new List<Q_EXLCIssueNewPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("editlist")]
        public async Task<ActionResult<EXLCIssuePurchaseEditListResponse>> GetAllEdit(string? CenterID, string? EXPORT_LC_NO, string? BENNAME, string? Page, string? PageSize)
        {
            EXLCIssuePurchaseEditListResponse response = new EXLCIssuePurchaseEditListResponse();

            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@CenterID", CenterID);
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@BENNAME", BENNAME);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_LC_NO == null)
                {
                    param.Add("@EXPORT_LC_NO", "");
                }
                if (BENNAME == null)
                {
                    param.Add("@BENNAME", "");
                }

                var results = await _db.LoadData<Q_EXLCIssueEditPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_IssuePurchEditPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCIssueEditPageRsp>)results;

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
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("releaselist")]
        public async Task<ActionResult<EXLCIssuePurchaseReleaseListResponse>> GetAllrelease(string? CenterID, string? EXPORT_LC_NO, string? BENNAME, string? Page, string? PageSize)
        {
            EXLCIssuePurchaseReleaseListResponse response = new EXLCIssuePurchaseReleaseListResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(USER_ID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, USER_ID, Page, PageSize is required";
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@CenterID", CenterID);
                param.Add("@USER_ID", USER_ID);
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@BENNAME", BENNAME);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (EXPORT_LC_NO == null)
                {
                    param.Add("@EXPORT_LC_NO", "");
                }
                if (BENNAME == null)
                {
                    param.Add("@BENNAME", "");
                }

                var results = await _db.LoadData<Q_EXLCIssueEditPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_IssuePurchReleasePage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCIssueEditPageRsp>)results;

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
                response.Data = new List<Q_EXLCIssueEditPageRsp>();
            }
            return BadRequest(response);
        }

        // Select from pDocRegister
        [HttpGet("newselect")]
        public async Task<ActionResult<EXLCIssuePurchaseNewSelectResponse>> GetNewSelect(string? RegDocNo)
        {
            EXLCIssuePurchaseNewSelectResponse response = new EXLCIssuePurchaseNewSelectResponse();

            // Validate
            if (string.IsNullOrEmpty(RegDocNo))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "RegDocNo is required";
                response.Data = new List<PDocRegister>();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@RegDocNo", RegDocNo);

                var results = await _db.LoadData<PDocRegister, dynamic>(
                            storedProcedure: "usp_pDocRegisterSelect",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<PDocRegister>)results;
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<PDocRegister>();
            }
            return BadRequest(response);
        }

        // editselect new with jaon
        [HttpGet("select")]
        public async Task<ActionResult<PEXLCPPaymentResponse>> Select(string? EXPORT_LC_NO, string? RECORD_TYPE, string? REC_STATUS, string? EVENT_NO)
        {
            PEXLCPPaymentResponse response = new PEXLCPPaymentResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) ||
                string.IsNullOrEmpty(RECORD_TYPE) ||
                string.IsNullOrEmpty(REC_STATUS) ||
                string.IsNullOrEmpty(EVENT_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, RECORD_TYPE, REC_STATUS, EVENT_NO is required";
                response.Data = new PEXLCPPaymentRsp();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@RECORD_TYPE", RECORD_TYPE);
                param.Add("@REC_STATUS", REC_STATUS);
                param.Add("@EVENT_NO", EVENT_NO);
                param.Add("@PExLcRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);
                param.Add("@PEXLCPEXPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<PEXLCPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_IssuePurchase_Select",
                           param);

                var PExLcRsp = param.Get<dynamic>("@PExLcRsp");
                var pexlcpexpaymentrsp = param.Get<dynamic>("@PEXLCPEXPaymentRsp");

                if (PExLcRsp > 0 && !string.IsNullOrEmpty(pexlcpexpaymentrsp))
                {
                    PEXLCPPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXLCPPaymentRsp>(pexlcpexpaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT L/C NO does not exit";
                    response.Data = new PEXLCPPaymentRsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXLCPPaymentRsp();
            }
            return BadRequest(response);
        }


        [HttpPost("save")]
        public ActionResult<PEXLCPPaymentPPayDetailsSaveResponse> Save([FromBody] PEXLCPPaymentPPayDetailsSaveRequest data)
        {
            PEXLCPPaymentPPayDetailsSaveResponse response = new();
            // Class validate
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
            //var Update =
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
                 
                        // 3 - Select PDOCRegister >> find cust approve
                        string appvFac ="";
                        string appvNo = "";
                        var pDocRegister = (from row in _context.pDocRegisters
                                            where row.Reg_Docno == data.PEXLC.EXPORT_LC_NO
                                            select row).FirstOrDefault();
                        if (pDocRegister != null)
                        {
                            var pCustApprove = (from row in _context.pCustAppvs
                                                where row.Appv_No == pDocRegister.Reg_AppvNo
                                                select row).FirstOrDefault();

                            if (pCustApprove != null)
                            {
                                appvNo = pCustApprove.Appv_No;
                                appvFac = pCustApprove.Facility_No;
                            }
                            pDocRegister.Reg_Status = "I";
                            _context.pDocRegisters.Update(pDocRegister);
                            _context.SaveChanges();
                            //    cSql = "UPDATE pDocRegister SET Reg_Status = 'I' WHERE Reg_Login = 'EXLC' AND reg_docno='" & lcNo$ & "' AND REG_STATUS='A'"

                        }
                        else
                        {
                            // PDocRegister Not Found
                        }
                        string NewRec ="NEW";
                        var pExlcMasterDelete = (from row in _context.pExlcs
                                           where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO 
                                           select row).ToList();
                        foreach (var row in pExlcMasterDelete)
                        {
                            NewRec = "EDIT";
                            _context.pExlcs.Remove(row);
                        }
                        _context.SaveChanges();
                        // 0 - Select EXLC Master
                        var pExlcMaster = (from row in _context.pExlcs
                                           where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                 row.RECORD_TYPE == "MASTER"
                                           select row).AsNoTracking().FirstOrDefault();

                        // 1 - Insert Master if not exists
                        pExlc pExlc = data.PEXLC;
                        if (pExlcMaster == null)
                        {
                            pExlc.EXPORT_LC_NO = data.PEXLC.EXPORT_LC_NO;
                            pExlc.EVENT_NO = 1;
                            if (data.PEXLC.REC_STATUS == "N" && data.PEXLC.TENOR_OF_COLL == 1)
                            {
                                pExlc.REC_STATUS = "P";
                            }
                            if (pExlc.FB_AMT == null) pExlc.FB_AMT = 0;
                            if (pExlc.RECEIVE_PAY_AMT == null) pExlc.RECEIVE_PAY_AMT = 0;
                            //    pExlc.REC_STATUS = "P";
                            pExlc.RECORD_TYPE = "MASTER";
                            _context.pExlcs.Add(pExlc);
                            _context.SaveChanges();
                        }
                        else
                        {
                            pExlc.IN_USE = 0;
                            pExlc.EVENT_TYPE = EVENT_TYPE;
                            pExlc.CenterID = USER_CENTER_ID;
                            pExlc.BUSINESS_TYPE = BUSINESS_TYPE;
                            pExlc.EVENT_MODE = "E";
                            pExlc.AUTOOVERDUE = "N";
                            pExlc.LCOVERDUE = "N";
                            if (pExlc.TENOR_OF_COLL == 1)
                            {
                                pExlc.LASTINTDATE = pExlc.SIGHT_START_DATE;
                            }
                            else
                            {
                                pExlc.LASTINTDATE = pExlc.TERM_DUE_DATE;
                            }
                            //ventRow.EVENT_DATE = DateTime.Today; // Without Time
                            //eventRow.VOUCH_ID = "ISSUE-PURC";
                            pExlc.USER_ID = USER_ID;
                            pExlc.UPDATE_DATE = UpdateDateT; // With Time
                            pExlc.FACNO = appvFac;
                            pExlc.APPVNO = appvNo;
                            if (pExlc.FB_AMT == null) pExlc.FB_AMT = 0;
                            if (pExlc.RECEIVE_PAY_AMT == null) pExlc.RECEIVE_PAY_AMT = 0;
                            _context.pExlcs.Update(pExlc);
                            _context.SaveChanges();
                        }
              

                        //pExlcMaster = (from row in _context.pExlcs
                        //               where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                        //                     row.RECORD_TYPE == "MASTER"
                        //               select row).FirstOrDefault();


                        // 2 - Insert EVENT
                        var pExlcEvent = (from row in _context.pExlcs
                                       where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                             row.RECORD_TYPE == "EVENT"
                                       select row).AsNoTracking().FirstOrDefault();

                        pExlc eventRow = data.PEXLC;

                        if (pExlcEvent == null)
                        {
                            eventRow.VOUCH_ID = "";
                            eventRow.RECEIVED_NO = "";
                        }
                        eventRow.CenterID = USER_CENTER_ID;
                        //eventRow.RECORD_TYPE = "EVENT";
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        if (data.PEXLC.REC_STATUS == "N" && data.PEXLC.TENOR_OF_COLL == 1)
                        {
                            eventRow.REC_STATUS = "P";
                        }
                        //      eventRow.REC_STATUS = "P";
                        eventRow.EVENT_NO = 1;
                        eventRow.EVENT_MODE = "E";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                        eventRow.AUTOOVERDUE = "N";
                        eventRow.LCOVERDUE = "N";
                        eventRow.IN_USE = 0;
                        if (eventRow.TENOR_OF_COLL ==1)
                        {
                            eventRow.LASTINTDATE = eventRow.SIGHT_START_DATE;
                        }
                      else
                        {
                            eventRow.LASTINTDATE = eventRow.TERM_DUE_DATE;
                        }
                        //ventRow.EVENT_DATE = DateTime.Today; // Without Time
                        //eventRow.VOUCH_ID = "ISSUE-PURC";
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = UpdateDateT; // With Time
                        eventRow.APPVNO = appvNo;
                        eventRow.FACNO = appvFac;

                        if (eventRow.PAYMENT_INSTRU == "PAID" || eventRow.PAYMENT_INSTRU == "BAHTNET")
                        {
                            eventRow.METHOD = data.PEXLC.METHOD;

                            if (eventRow.RECEIVED_NO ==null || eventRow.RECEIVED_NO =="")
                            {
                                eventRow.RECEIVED_NO = ExportLCHelper.GenRefNo(_context, USER_CENTER_ID, USER_ID, "PAYC", UpdateDateT, UpdateDateNT);
                            }
                            // Call Save Payment
                            eventRow.RECEIVED_NO = ExportLCHelper.SavePayment(_context, USER_CENTER_ID, USER_ID, eventRow, data.PPAYMENT,UpdateDateT,UpdateDateNT);

                            // Call Save PaymentDetail
                                                        
                            //if (eventRow.RECEIVED_NO != "ERROR") 
                            //{  
                                
                            //   bool savePayDetailResult = ExportLCHelper.SavePaymentDetail(_context, eventRow, data.PPAYDETAILS);
                            //}
                        }
                        else
                        {
                            // UNPAID
                            eventRow.METHOD = "";
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
                            eventRow.RECEIVED_NO = "";
                        }
                        eventRow.RECORD_TYPE = "EVENT";
                        if (eventRow.FB_AMT == null) eventRow.FB_AMT = 0;
                        if (eventRow.RECEIVE_PAY_AMT == null) eventRow.RECEIVE_PAY_AMT = 0;
                        // Commit
                        if (pExlcEvent ==null)
                        {
                            eventRow.VOUCH_ID = "";
                            _context.pExlcs.Add(eventRow);
                            _context.SaveChanges();

                        }
                        else
                        {
                            _context.pExlcs.Update(eventRow);
                            _context.SaveChanges();
                        }

                        transaction.Complete();
                        transaction.Dispose();
                        response.Code = Constants.RESPONSE_OK;

                        PEXLCPPaymentPPayDetailDataContainer responseData = new();
                        responseData.PEXLC = eventRow;
                        responseData.PPAYMENT = data.PPAYMENT;
                    //    responseData.PPAYDETAILS = data.PPAYDETAILS;

                        response.Data = responseData;


                        bool resGL;
                        bool resPayD;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent =response.Data.PEXLC.EVENT_TYPE;
                        eventDate = response.Data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");
                        if ( response.Data.PEXLC.PAYMENT_INSTRU == "PAID" || response.Data.PEXLC.PAYMENT_INSTRU == "BAHTNET")
                        {
                            if (data.PEXLC.WithOutFlag == "Y")
                            {
                                if (data.PEXLC.WithOutType == "F")
                                {
                                    GLEvent = "ISSUE-PUR-FUND";
                                }
                                if (data.PEXLC.WithOutType == "I")
                                {
                                    GLEvent = "ISSUE-PUR-UNISB";
                                }
                                if (data.PEXLC.WithOutType == "A")
                                {
                                    GLEvent = "ISSUE-PUR-UNAGB";
                                }
                            }
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(response.Data.PEXLC.EXPORT_LC_NO,
                                eventDate,
                                response.Data.PEXLC.EVENT_TYPE,
                                response.Data.PEXLC.EVENT_NO,
                                GLEvent);
                            

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
                            resPayDetail = ISPModule.PayDetailEXLC.PayDetail_IssPurchase( response.Data.PEXLC.EXPORT_LC_NO, response.Data.PEXLC.EVENT_NO, response.Data.PEXLC.RECEIVED_NO);
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
                        string resQuote = "";
                        if (response.Data.PEXLC.REC_STATUS == "N" && response.Data.PEXLC.TENOR_OF_COLL !=1)
                        {
                            resQuote = ISPModule.RequestQuoteRate.GenQuoteRate("EXLC", response.Data.PEXLC.EXPORT_LC_NO,
                                 response.Data.PEXLC.EVENT_NO, response.Data.PEXLC.EVENT_TYPE, NewRec, response.Data.PEXLC.USER_ID);
                        }
                        if (resQuote == "ERROR")
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Error for Quote Rate";
                            return BadRequest(response);
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
                            response.Message = "PEXLC " + EVENT_TYPE + " Event Already exists";
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
        public async Task<ActionResult<EXLCResultResponse>> Release([FromBody] PEXLCSaveRequest data)
        {
            EXLCResultResponse response = new EXLCResultResponse();
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
            // 0 - Select EXLC Master
            var pExlcMaster = (from row in _context.pExlcs
                               where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                     row.RECORD_TYPE == "MASTER"
                               select row).FirstOrDefault();

            if (pExlcMaster == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "PEXLC " + EVENT_TYPE + " Master does not exists";
                return BadRequest(response);
            }


            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // 1 - Update Master
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        // PAID OR UNPAID
                        if (data.PEXLC.PAYMENT_INSTRU == "PAID" || data.PEXLC.PAYMENT_INSTRU == "UNPAID")
                        {
                            if (data.PEXLC.WithOutFlag == "Y")
                            {

                                if (data.PEXLC.WithOutType == "F") // FUNDED
                                {
                                    pExlcMaster.AcceptFlag = "Y";
                                    pExlcMaster.PAYMENTTYPE = "F";

                                    await _context.SaveChangesAsync();
                                    await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'C', AUTH_CODE = '{USER_ID}', AUTH_DATE = '{UpdateDateT}' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");
                                }
                                else
                                {
                                    pExlcMaster.AcceptFlag = "Y";

                                    await _context.SaveChangesAsync();
                                    await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', AUTH_CODE = '{USER_ID}', AUTH_DATE = '{UpdateDateT}' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");
                                }
                            }
                            else
                            {
                                await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', AUTH_CODE = '{USER_ID}', AUTH_DATE = '{UpdateDateT}' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");
                            }

                            // 2 - Update Event
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', AUTH_CODE = '{USER_ID}', AUTH_DATE = '{UpdateDateT}' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT'");

                            //2.1 Update  Collection to Purchase
                            if (data.PEXLC.CLAIM_TYPE ==1)
                            {

                                await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'C', REFER_LC_NO ='{data.PEXLC.REFER_LC_NO}',AUTH_CODE = '{USER_ID}', AUTH_DATE = '{UpdateDateT}' WHERE EXPORT_LC_NO = '{data.PEXLC.REFER_LC_NO}' AND RECORD_TYPE='MASTER'");
                                await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'C' ,in_use =2  WHERE EXPORT_LC_NO = '{data.PEXLC.REFER_LC_NO}' AND RECORD_TYPE='EVENT'");
                            }


                            // 3 - Update GL Flag
                            var gls = (from row in _context.pDailyGLs
                                       where row.VouchID == data.PEXLC.VOUCH_ID &&
                                             row.VouchDate == data.PEXLC.EVENT_DATE.GetValueOrDefault().Date
                                       select row).ToListAsync();

                            foreach (var row in await gls)
                            {
                                row.SendFlag = "R";
                            }

                            // 4 - Update PPayment
                            var pPayments = (from row in _context.pPayments
                                             where row.RpReceiptNo == data.PEXLC.RECEIVED_NO
                                             select row).ToListAsync();

                            foreach (var row in await pPayments)
                            {
                                row.RpRecStatus = "R";
                            }
                        }
                        

                        // Commit
                        await _context.SaveChangesAsync();
                        transaction.Complete();
                       transaction.Dispose();
                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export L/C Release Complete";

                        string eventDate;
                        string resCustLiab;
                        string bankID ="";
                        if (data.PEXLC.Wref_Bank_ID == null) bankID = "";
                        eventDate = data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");
                        resCustLiab = ISPModule.CustLiabEXLC.EXLC_IssPurchase(eventDate, "ISSUE", "SAVE",
                        data.PEXLC.EXPORT_LC_NO, data.PEXLC.BENE_ID,
                        data.PEXLC.CLAIM_TYPE.ToString(), data.PEXLC.TENOR_TYPE.ToString(),
                        data.PEXLC.DRAFT_CCY,
                        data.PEXLC.DRAFT_AMT.ToString(),
                        data.PEXLC.PURCHASE_AMT.ToString(),
                        bankID
                            );
                        if (resCustLiab != "ERROR")
                        {
                            return Ok(response);
                        }
                        else
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export L/C Error for Update Liability";
                            return BadRequest(response);
                        }

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
        public async Task<ActionResult<EXLCResultResponse>> EXLCIssuePurchaseDelete([FromBody] PEXLCDeleteRequest data)
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
                        var issueCollectExlc = (from row in _context.pExlcs
                                                where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                                      row.RECORD_TYPE == "EVENT" &&
                                                      row.EVENT_TYPE == EVENT_TYPE &&
                                                      row.REC_STATUS == "P" &&
                                                      (row.RECEIVED_NO != null && row.RECEIVED_NO != "")
                                                select row).ToListAsync();

                        foreach (var row in await issueCollectExlc)
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
                                       where row.TranDocNo == data.EXPORT_LC_NO &&
                                             row.VouchDate == DateTime.Parse(data.EVENT_DATE)
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }


                        // 3 - Update PDOCRegister
                        var pDocRegister = (from row in _context.pDocRegisters
                                            where row.Reg_Docno == data.EXPORT_LC_NO &&
                                                  row.Reg_Login == "EXLC"
                                            select row).ToListAsync();

                        foreach (var row in await pDocRegister)
                        {
                            row.Reg_Status = "A";
                            row.Remark = "N";
                        }


                        // 4 - Delete all pExlc
                        var pExlcs = (from row in _context.pExlcs
                                      where row.EXPORT_LC_NO == data.EXPORT_LC_NO
                                      select row).ToListAsync();

                        foreach (var row in await pExlcs)
                        {
                            _context.pExlcs.Remove(row);
                        }

                        // 5 - Delete pInstall
                        var pInstalls = (from row in _context.pInstalls
                                         where row.LC_NO == data.EXPORT_LC_NO
                                         select row).ToListAsync();

                        foreach (var row in await pInstalls)
                        {
                            _context.pInstalls.Remove(row);
                        }

                        // Commit
                        await _context.SaveChangesAsync();
                        transaction.Complete();
                    }
                    catch (Exception e)
                    {
                        if (e is ArgumentException || e is DuplicateKeyException)
                        {
                            // Key already exists
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC " + EVENT_TYPE + " Event Already exists";
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
