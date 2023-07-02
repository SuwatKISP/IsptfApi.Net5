using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
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
    public class EXLCAcceptTermBillController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "ACB";
        private const string EVENT_TYPE = "Accept Bill";
        public EXLCAcceptTermBillController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCAcceptTermDueListResponse>> List(string? ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? Page, string? PageSize)
        {
            EXLCAcceptTermDueListResponse response = new EXLCAcceptTermDueListResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) ||
                string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(Page) ||
                string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCAcceptTermDueListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EXLCAcceptTermDueListPageRsp>();
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

                var results = await _db.LoadData<Q_EXLCAcceptTermDueListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_AcceptTermBillListPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCAcceptTermDueListPageRsp>)results;

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
                response.Data = new List<Q_EXLCAcceptTermDueListPageRsp>();
            }
            return BadRequest(response);
        }

        //[HttpGet("query")]
        //public async Task<IEnumerable<Q_EXBCCoveringLetterQueryPageRsp>> GetAllQuery(string? @ListType, string? CenterID, string? EXPORT_BC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@ListType", @ListType);
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

        //    var results = await _db.LoadData<Q_EXBCCoveringLetterQueryPageRsp, dynamic>(
        //                storedProcedure: "usp_q_EXLC_CoveringLetterQueryPage",
        //                param);
        //    return results;
        //}


        [HttpGet("select")]
        public async Task<ActionResult<PEXLCPPaymentResponse>> Select(string? EXPORT_LC_NO, int? EVENT_NO, string? RECORD_TYPE, string? REC_STATUS, string? LFROM)
        {
            PEXLCPPaymentResponse response = new PEXLCPPaymentResponse();
            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) ||
                EVENT_NO == null ||
                string.IsNullOrEmpty(RECORD_TYPE) ||
                string.IsNullOrEmpty(REC_STATUS) ||
                string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, RECORD_TYPE, REC_STATUS, LFROM is required";
                response.Data = new PEXLCPPaymentRsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();

                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@EVENT_NO", EVENT_NO);
                param.Add("@RECORD_TYPE", RECORD_TYPE);
                param.Add("@REC_STATUS", REC_STATUS);
                param.Add("@LFROM", LFROM);

                param.Add("@PExLcRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@PEXLCPPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<PEXLCPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_AcceptTermBill_Select",
                           param);

                var PExLcRsp = param.Get<dynamic>("@PExLcRsp");
                var pexlcppaymentrsp = param.Get<dynamic>("@PEXLCPPaymentRsp");

                if (PExLcRsp > 0 && !string.IsNullOrEmpty(pexlcppaymentrsp))
                {
                    PEXLCPPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXLCPPaymentRsp>(pexlcppaymentrsp);
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

                        // 1 - Check if Master Exists
                        if (pExlcMaster == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC Master does not exists";
                            return BadRequest(response);
                        }

                        // 2 - Update Master
                        var checkNew = false;
                        if (pExlcMaster.REC_STATUS == "R")
                        {
                            checkNew = true;
                        }
                        if (data.PEXLC.WithOutFlag == "Y")
                        {
                            // Call Save Back Liability with checkNew param
                        }

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


                        eventRow.CenterID = USER_CENTER_ID;
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
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
                            // Call Save Payment
                            eventRow.RECEIVED_NO = await ExportLCHelper.SavePayment(_context, USER_CENTER_ID, USER_ID, eventRow, data.PPAYMENT);

                            // Call Save PaymentDetail
                            if (eventRow.RECEIVED_NO != "ERROR")
                            {
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
                        if (pExlcEvent == null)
                        {
                            // Insert
                            _context.pExlcs.Add(eventRow);
                        }
                        else
                        {
                            // Update
                            _context.pExlcs.Update(eventRow);

                        }

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
                        if (e.InnerException != null &&
                            e.InnerException.Message.Contains("Violation of PRIMARY KEY constraint / Wrong Event State"))
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
        public async Task<ActionResult<EXLCResultResponse>> Release(string? EXPORT_LC_NO,
                                                            int? EVENT_NO,
                                                            string? RECORD_TYPE,
                                                            string? REC_STATUS)
        {
            EXLCResultResponse response = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) ||
                EVENT_NO == null ||
                string.IsNullOrEmpty(RECORD_TYPE) ||
                string.IsNullOrEmpty(REC_STATUS))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, RECORD_TYPE, REC_STATUS is required";
                return BadRequest(response);
            }

            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

            //from vb (not implimented here)
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        //SaveMaster
                        // 0 - Select EXLC Master
                        var pExlcMaster = (from row in _context.pExlcs
                                           where row.EXPORT_LC_NO == EXPORT_LC_NO &&
                                                 row.RECORD_TYPE == "MASTER"
                                           select row).FirstOrDefault();

                        // 1 - Check if Master Exists
                        if (pExlcMaster == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC Master does not exists";
                            return BadRequest(response);
                        }

                        // 2 - Select Existing Event
                        var pExlcEvent = (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == EXPORT_LC_NO &&
                                                row.RECORD_TYPE == RECORD_TYPE &&
                                                (row.REC_STATUS == REC_STATUS) &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == EVENT_NO
                                          select row).AsNoTracking().FirstOrDefault();

                        // 3 - Check if Event Exist
                        if (pExlcEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC " + EVENT_TYPE + " Event does not exists";
                            return BadRequest(response);
                        }

                        // 4 - Socket
                        bool onePUse = false;
                        if (onePUse && pExlcEvent.TOTAL_AMOUNT > 0)
                        {
                            string op_event;
                            if (pExlcEvent.METHOD.Contains("DEBIT"))
                            {
                                op_event = "DR";
                            }
                            else if (pExlcEvent.METHOD.Contains("CREDIT"))
                            {
                                op_event = "CR";
                            }
                            else
                            {
                                op_event = "";
                            }
                            // Use Socket
                        }

                        // 5 - Update Event
                        pExlcEvent.RECEIVED_NO = pExlcEvent.RECEIVED_NO;
                        pExlcEvent.AUTH_CODE = USER_ID;
                        pExlcEvent.AUTH_DATE = DateTime.Today;
                        pExlcEvent.GENACC_FLAG = "Y";
                        pExlcEvent.GENACC_DATE = DateTime.Today;

                        // 6 - Update Master
                        pExlcMaster.AcceptFlag = "Y";
                        pExlcMaster.AUTH_CODE = USER_ID;
                        pExlcMaster.AUTH_DATE = DateTime.Today;
                        pExlcMaster.VOUCH_ID = pExlcEvent.VOUCH_ID;
                        pExlcMaster.GENACC_FLAG = "Y";
                        pExlcMaster.GENACC_DATE = DateTime.Today;
                        pExlcMaster.USER_ID = USER_ID;
                        pExlcMaster.UPDATE_DATE = DateTime.Today;
                        pExlcMaster.BUSINESS_TYPE = BUSINESS_TYPE;
                        pExlcMaster.EVENT_TYPE = EVENT_TYPE;
                        pExlcMaster.AcceptDate = pExlcEvent.CONFIRM_DATE;
                        pExlcMaster.REFUND_DISC_RECEIVE = pExlcEvent.REFUND_DISC_RECEIVE;
                        pExlcMaster.DISC_RECEIVE = pExlcEvent.DISC_RECEIVE;
                        pExlcMaster.TOTAL_AMOUNT = pExlcEvent.TOTAL_AMOUNT;
                        pExlcMaster.NARRATIVE = pExlcEvent.NARRATIVE;
                        pExlcMaster.CFRRate = pExlcEvent.CFRRate;
                        pExlcMaster.IntRateCode = pExlcEvent.IntRateCode;
                        pExlcMaster.DISCOUNT_DAY = pExlcEvent.DISCOUNT_DAY;
                        pExlcMaster.CURRENT_DIS_RATE = pExlcEvent.CURRENT_DIS_RATE;
                        if (pExlcEvent.WithOutFlag == "N")
                        {
                            pExlcMaster.WithOutType = "";
                            pExlcMaster.Wref_Bank_ID = "";
                            pExlcMaster.ADJUST_LC_REF = pExlcEvent.ADJUST_LC_REF;
                        }
                        else if (pExlcEvent.WithOutFlag == "Y")
                        {
                            pExlcMaster.WithOutType = pExlcEvent.WithOutType;
                            pExlcMaster.Wref_Bank_ID = pExlcEvent.Wref_Bank_ID;
                            pExlcMaster.DISCOUNT_DAY = pExlcEvent.DISCOUNT_DAY;
                            pExlcMaster.INT_BASE_RATE = pExlcEvent.INT_BASE_RATE;
                            pExlcMaster.DISCOUNT_RATE = pExlcEvent.DISCOUNT_RATE;
                            pExlcMaster.DISC_BASE_DAY = pExlcEvent.DISC_BASE_DAY;
                            pExlcMaster.BASE_DAY = pExlcEvent.BASE_DAY;
                            pExlcMaster.INT_SPREAD_RATE = pExlcEvent.INT_SPREAD_RATE;
                            pExlcMaster.CURRENT_DIS_RATE = pExlcEvent.CURRENT_DIS_RATE;
                            pExlcMaster.CURRENT_INT_RATE = pExlcEvent.CURRENT_INT_RATE;
                            pExlcMaster.CFRRate = pExlcEvent.CFRRate;
                            pExlcMaster.IntRateCode = pExlcEvent.IntRateCode;
                            pExlcMaster.DISCOUNT_CCY = pExlcEvent.DISCOUNT_CCY;
                            pExlcMaster.DISCRATE = pExlcEvent.DISCRATE;
                            pExlcMaster.DISCOUNT_AMT = pExlcEvent.DISCOUNT_AMT;
                            pExlcMaster.FACNO = pExlcEvent.FACNO;
                            pExlcMaster.PURCH_DISC_DATE = pExlcEvent.PURCH_DISC_DATE;
                            pExlcMaster.ACCRUAMT = pExlcEvent.ACCRUAMT;
                            pExlcMaster.ACCRUBHT = pExlcEvent.ACCRUBHT;
                            pExlcMaster.TOTALACCRUAMT = pExlcEvent.TOTALACCRUAMT;
                            pExlcMaster.TOTALACCRUBHT = pExlcEvent.TOTALACCRUBHT;
                            pExlcMaster.SUSPAMT = pExlcEvent.SUSPAMT;
                            // 6.1 - Update pMonAccrued
                            var pMonAccrued = (from row in _context.pMonAccrueds
                                               where row.DocNo == EXPORT_LC_NO &&
                                                     row.DocMode == "AMORT"
                                               select row).FirstOrDefault();
                            if (pMonAccrued == null)
                            {
                                response.Code = Constants.RESPONSE_ERROR;
                                response.Message = "pMonAccrued DocNo " + EXPORT_LC_NO + " does not exists";
                                return BadRequest(response);
                            }
                            pMonAccrued.GenAccFlag = "T";
                            // 6.2 - Update pCustAppv
                            var pCusAppv = (from row in _context.pCustAppvs
                                            where row.Appv_No == pExlcEvent.ADJUST_LC_REF
                                            select row).FirstOrDefault();
                            if (pCusAppv == null)
                            {
                                response.Code = Constants.RESPONSE_ERROR;
                                response.Message = "pCustAppv Appv_No " + pExlcEvent.ADJUST_LC_REF + " does not exists";
                                return BadRequest(response);
                            }
                            pCusAppv.RecStatus = "R";
                            pCusAppv.Appv_Status = "A";
                            // 6.3 - UpdateBankLiab
                            var pBankLiab = (from row in _context.pBankLiabs
                                             where row.Bank_Code == pExlcEvent.Wref_Bank_ID &&
                                                   row.Facility_No == pExlcEvent.FACNO &&
                                                   row.Currency == pExlcEvent.DRAFT_CCY
                                             select row).FirstOrDefault();
                            pBankLiab.XLCP_Book = pBankLiab.XLCP_Book - pExlcEvent.DRAFT_AMT;
                            pBankLiab.XLCP_Amt = pBankLiab.XLCP_Amt + pExlcEvent.DRAFT_AMT;
                            pBankLiab.UpdateDate = DateTime.Today;
                            // 6.4 - RevalueBankLiab
                            // Nothing in (VB)ModEXQuery
                        }

                        // 7 - Update pPayment
                        if (pExlcEvent.PAYMENT_INSTRU == "PAID")
                        {
                            pExlcMaster.PAYMENT_INSTRU = "PAID";
                            pExlcMaster.METHOD = pExlcEvent.METHOD;
                            pExlcMaster.RECEIVED_NO = pExlcEvent.RECEIVED_NO;
                            var pPayment = (from row in _context.pPayments
                                            where row.RpReceiptNo == pExlcEvent.RECEIVED_NO
                                            select row).FirstOrDefault();
                            pPayment.RpRecStatus = "R";
                        }
                        else
                        {
                            pExlcMaster.PAYMENT_INSTRU = "UNPAID";
                            pExlcMaster.METHOD = "";
                            pExlcMaster.RECEIVED_NO = pExlcEvent.RECEIVED_NO;
                        }
                        // 8 - Update pDailyGL
                        if (pExlcEvent.PAYMENT_INSTRU == "PAID")
                        {
                            var dailyGL = (from row in _context.pDailyGLs
                                           where row.VouchID == pExlcEvent.VOUCH_ID &&
                                                 row.VouchDate == pExlcEvent.EVENT_DATE
                                           select row).FirstOrDefault();
                            dailyGL.SendFlag = "R";
                        }
                        await _context.SaveChangesAsync();

                        // 9 - Updata Master,Event PK
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', EVENT_NO = {EVENT_NO} WHERE EXPORT_LC_NO = '{pExlcEvent.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R' WHERE EXPORT_LC_NO = '{pExlcEvent.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE='{EVENT_TYPE}'");
                        transaction.Complete();

                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export L/C Released";
                        return Ok(response);
                    }
                    catch (Exception e)
                    {
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
        public async Task<ActionResult<EXLCResultResponse>> Delete(string? EXPORT_LC_NO, int? EVENT_NO, string? RECORD_TYPE, string? REC_STATUS) //([FromBody] PEXLCAcceptTermBillDeleteRequest data)
        {
            EXLCResultResponse response = new EXLCResultResponse();
            DynamicParameters param = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) ||
                EVENT_NO == null ||
                string.IsNullOrEmpty(RECORD_TYPE) ||
                string.IsNullOrEmpty(REC_STATUS))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, RECORD_TYPE, REC_STATUS is required";
                return BadRequest(response);
            }

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {

                        // -1 - Select Target Exlc
                        var data = (from row in _context.pExlcs
                                    where row.EXPORT_LC_NO == EXPORT_LC_NO &&
                                          row.EVENT_NO == EVENT_NO &&
                                          row.RECORD_TYPE == RECORD_TYPE &&
                                          row.REC_STATUS == REC_STATUS
                                    select row).AsNoTracking().FirstOrDefault();

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
                                       where row.VouchID == data.VOUCH_ID &&
                                             row.VouchDate == data.EVENT_DATE
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }


                        // 3 - Update pExlc EVENT

                        var pExlcs = (from row in _context.pExlcs
                                      where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                            row.EVENT_TYPE == EVENT_TYPE &&
                                            (row.REC_STATUS == "P" || row.REC_STATUS == "W") &&
                                            row.RECORD_TYPE == "EVENT"
                                      select row).ToListAsync();

                        foreach (var row in await pExlcs)
                        {
                            row.REC_STATUS = "T";
                        }

                        // 4 - Without recourse

                        if (data.WithOutFlag == "Y")
                        {
                            var pCustApprvs = (from row in _context.pCustAppvs
                                               where row.Appv_No == data.ADJUST_LC_REF
                                               select row).ToListAsync();
                            foreach (var row in await pCustApprvs)
                            {
                                row.RecStatus = "R";
                                row.Appv_Status = "N";
                                row.Appv_Cancel = "V";
                            }

                            var pBankLiabs = (from row in _context.pBankLiabs
                                              where row.Bank_Code == data.Wref_Bank_ID &&
                                                    row.Facility_No == data.FACNO &&
                                                    row.Currency == data.DRAFT_CCY
                                              select row).ToListAsync();
                            foreach (var row in await pBankLiabs)
                            {
                                double XLCP_Book = 0;
                                if (row.XLCP_Book != null)
                                {
                                    XLCP_Book = (double)row.XLCP_Book;
                                }
                                row.XLCP_Book = XLCP_Book - data.DRAFT_AMT;
                                row.UpdateDate = DateTime.Now;
                            }
                        }


                        // 5 - Update pExlc Master
                        var targetEventNo = pExlc.EVENT_NO + 1;


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
