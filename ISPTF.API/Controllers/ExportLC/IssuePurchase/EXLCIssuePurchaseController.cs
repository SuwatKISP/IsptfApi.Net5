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
        public async Task<ActionResult<PEXLCPPaymentPPayDetailsSaveResponse>> Save([FromBody] PEXLCPPaymentPPayDetailsSaveRequest data)
        {
            PEXLCPPaymentPPayDetailsSaveResponse response = new();
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

                        // 1 - Insert Master if not exists
                        if (pExlcMaster == null)
                        {
                            pExlc pExlc = data.PEXLC;
                            pExlc.EXPORT_LC_NO = data.PEXLC.EXPORT_LC_NO;
                            pExlc.EVENT_NO = 1;
                            pExlc.RECORD_TYPE = "MASTER";
                            pExlc.EVENT_TYPE = EVENT_TYPE;

                            _context.pExlcs.Add(pExlc);
                            _context.SaveChanges();

                            pExlcMaster = (from row in _context.pExlcs
                                           where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                 row.RECORD_TYPE == "MASTER"
                                           select row).FirstOrDefault();
                        }

                        // 2 - Insert EVENT
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlc eventRow = data.PEXLC;


                        // 3 - Select PDOCRegister >> find cust approve
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
                                eventRow.FACNO = pCustApprove.Appv_No;
                            }
                        }
                        else
                        {
                            // PDocRegister Not Found
                        }

                        eventRow.CenterID = USER_CENTER_ID;
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
                        eventRow.EVENT_MODE = "E";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                        eventRow.EVENT_DATE = DateTime.Today; // Without Time
                        eventRow.VOUCH_ID = "ISSUE-PURC";
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = DateTime.Now; // With Time


                        if (eventRow.PAYMENT_INSTRU == "PAID")
                        {
                            eventRow.METHOD = data.PEXLC.METHOD;
                            // Call Save Payment
                            eventRow.RECEIVED_NO = await ExportLCHelper.SavePayment(_context, eventRow, data.PPAYMENT);
                            // Call Save PaymentDetail
                            if (eventRow.RECEIVED_NO != "ERROR") {
                                bool savePayDetailResult = await ExportLCHelper.SavePaymentDetail(_context, eventRow, data.PPAYDETAILS);
                            }
                            
                        }
                        else
                        {
                            // UNPAID
                            eventRow.METHOD = "";

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
                        }

                        // Commit
                        _context.pExlcs.Add(eventRow);
                        await _context.SaveChangesAsync();
                        transaction.Complete();

                        response.Code = Constants.RESPONSE_OK;

                        PEXLCPPaymentPPayDetailDataContainer responseData = new();
                        responseData.PEXLC = eventRow;
                        responseData.PPAYMENT = data.PPAYMENT;
                        responseData.PPAYDETAILS = data.PPAYDETAILS;

                        response.Data = responseData;
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
                                    await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'C', AUTH_CODE = '{USER_ID}', AUTH_DATE = GETDATE() WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");
                                }
                                else
                                {
                                    pExlcMaster.AcceptFlag = "Y";

                                    await _context.SaveChangesAsync();
                                    await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', AUTH_CODE = '{USER_ID}', AUTH_DATE = GETDATE() WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");
                                }
                            }
                            else
                            {
                                await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', AUTH_CODE = '{USER_ID}', AUTH_DATE = GETDATE() WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");
                            }

                            // 2 - Update Event
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', AUTH_CODE = '{USER_ID}', AUTH_DATE = GETDATE() WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT'");


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

                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export L/C Release Complete";
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
