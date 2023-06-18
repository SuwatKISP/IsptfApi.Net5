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
using ISPTF.Models.ExportLC.AcceptTermDueWREF;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using System.Reflection;

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCAcceptTermDueWREFController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "4W";
        private const string EVENT_TYPE = "Accept Due WREF";
        public EXLCAcceptTermDueWREFController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCAcceptTermDueWREFListResponse>> List(string? @ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? Page, string? PageSize)
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

                param.Add("@ListType", @ListType);
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
                            storedProcedure: "usp_q_EXLC_AcceptTermDueWREFListPage",
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
                           storedProcedure: "usp_pEXLC_AcceptTermDueWREF_Select",
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


                        // GL MOCK WAIT DLL
                        var glVouchId = "VOUCH ID FROM GL DLL";
                        eventRow.VOUCH_ID = glVouchId;
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
        public async Task<ActionResult<EXLCResultResponse>> Release(string? EXPORT_LC_NO, int? EVENT_NO, string? RECORD_TYPE, string? REC_STATUS)
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

            //from vb (not implimented here)
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
                    /*
                    If op_event <> "" Then
                        Req1PSys = Send1PTxn(txtbene_id.Text, TxtCode.Text, OPSeqNo, "EXLC", op_event, _
                        txtaccount_no1.Text, txtAmt_Debit1.Text, _
                        txtaccount_no2.Text, txtAmt_Debit2.Text, _
                        txtaccount_no3.Text, txtAmt_Debit3.Text)
                        If Req1PSys = False Then
                            cSql = "Update pExlc set   REC_STATUS ='W'   where  " _
                                & "EXPORT_LC_NO='" & TxtCode.Text & "' and EVENT_TYPE ='" & eventType & "'   and rec_status IN('P','W') and record_type='EVENT' "
                            cn.Execute cSql
                            framRelease.Visible = False
                            CmdDel.Enabled = True
                            CmdSave.Enabled = False
                            CmdPrint.Enabled = False
                             CmdExit.Enabled = True: SSTab1.Enabled = True
                            TxtCode.Enabled = True: cmdFndLC.Enabled = True
                            Exit Sub
                        End If
                        If Duplicate = True Then
                            If ChkReleaseMaster("EXLC", Trim(TxtCode.Text)) = True Then CmdDel.Enabled = False: framRelease.Visible = False: CmdSave.Enabled = False: Exit Sub
                        End If
                    End If 
                    */
                }
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // 4 - Update Event
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlcEvent.RECEIVED_NO = pExlcEvent.RECEIVED_NO;
                        pExlcEvent.AUTH_CODE = pExlcEvent.AUTH_CODE;
                        pExlcEvent.AUTH_DATE = pExlcEvent.AUTH_DATE;
                        pExlcEvent.GENACC_FLAG = "Y";
                        pExlcEvent.GENACC_DATE = DateTime.Today;

                        // 5 - Update Master
                        pExlcMaster.AUTH_CODE = pExlcEvent.AUTH_CODE;
                        pExlcMaster.AUTH_DATE = pExlcEvent.AUTH_DATE;
                        pExlcMaster.VOUCH_ID = pExlcEvent.VOUCH_ID;
                        pExlcMaster.GENACC_FLAG = "Y";
                        pExlcMaster.GENACC_DATE = DateTime.Today;
                        pExlcMaster.USER_ID = USER_ID;
                        pExlcMaster.UPDATE_DATE = DateTime.Today;
                        pExlcMaster.BUSINESS_TYPE = BUSINESS_TYPE;
                        pExlcMaster.EVENT_TYPE = EVENT_TYPE;
                        pExlcMaster.SEQ_ACCEPT_DUE = pExlcEvent.SEQ_ACCEPT_DUE;
                        pExlcMaster.CONFIRM_DATE = pExlcEvent.CONFIRM_DATE;
                        pExlcMaster.DISC_DAYS_PLUS_MINUS = pExlcEvent.DISC_DAYS_PLUS_MINUS;
                        pExlcMaster.PLUS_MINUS_DISC = pExlcEvent.PLUS_MINUS_DISC;
                        pExlcMaster.REFUND_DISC_RECEIVE = pExlcEvent.REFUND_DISC_RECEIVE;
                        pExlcMaster.DISC_RECEIVE = pExlcEvent.DISC_RECEIVE;
                        pExlcMaster.RECEIVE_PAY_AMT = pExlcEvent.RECEIVE_PAY_AMT;
                        pExlcMaster.EXCHANGE_RATE = pExlcEvent.EXCHANGE_RATE;
                        pExlcMaster.DISCRATE = pExlcEvent.DISCRATE;
                        pExlcMaster.TOTAL_AMOUNT = pExlcEvent.TOTAL_AMOUNT;
                        pExlcMaster.NARRATIVE = pExlcEvent.NARRATIVE;
                        pExlcMaster.CFRRate = pExlcEvent.CFRRate;
                        pExlcMaster.IntRateCode = pExlcEvent.IntRateCode;
                        pExlcMaster.COLLECT_REFUND = pExlcEvent.COLLECT_REFUND;
                        if (pExlcEvent.TENOR_TYPE == 4)
                        {
                            pExlcMaster.TERM_START_DATE = pExlcEvent.TERM_START_DATE;
                            pExlcMaster.TERM_DUE_DATE = pExlcEvent.TERM_DUE_DATE;
                        }
                        else
                        {
                            if (pExlcEvent.PLUS_MINUS_DISC == "1")
                            {
                                pExlcMaster.TERM_START_DATE = pExlcEvent.TERM_START_DATE;
                                pExlcMaster.TERM_DUE_DATE = pExlcEvent.TERM_DUE_DATE.Value.AddDays((Double)pExlcEvent.DISC_DAYS_PLUS_MINUS);
                                pExlcMaster.DISCOUNT_CCY = pExlcEvent.DISCOUNT_CCY + pExlcEvent.RECEIVE_PAY_AMT;
                                if (pExlcEvent.REFUND_DISC_RECEIVE > 0)
                                {
                                    pExlcMaster.DISCOUNT_AMT = pExlcEvent.DISCOUNT_AMT + pExlcEvent.REFUND_DISC_RECEIVE;
                                }
                                else
                                {
                                    pExlcMaster.DISCOUNT_AMT = pExlcEvent.DISCOUNT_AMT + pExlcEvent.DISC_RECEIVE;
                                }
                            }
                            else if (pExlcEvent.PLUS_MINUS_DISC == "2")
                            {
                                pExlcMaster.TERM_START_DATE = pExlcEvent.TERM_START_DATE;
                                pExlcMaster.TERM_DUE_DATE = pExlcEvent.CONFIRM_DATE;
                                pExlcMaster.DISCOUNT_CCY = pExlcEvent.DISCOUNT_CCY + pExlcEvent.RECEIVE_PAY_AMT;
                                if (pExlcEvent.REFUND_DISC_RECEIVE > 0)
                                {
                                    pExlcMaster.DISCOUNT_AMT = pExlcEvent.DISCOUNT_AMT + pExlcEvent.REFUND_DISC_RECEIVE;
                                }
                                else
                                {
                                    pExlcMaster.DISCOUNT_AMT = pExlcEvent.DISCOUNT_AMT + pExlcEvent.DISC_RECEIVE;
                                }
                            }
                        }
                        pExlcMaster.DISCOUNT_DAY = pExlcEvent.DISCOUNT_DAY;
                        pExlcMaster.CURRENT_DIS_RATE = pExlcEvent.CURRENT_DIS_RATE;
                        if (pExlcEvent.TENOR_TYPE != 4)
                        {
                            var netDiscount = pExlcEvent.DISCOUNT_CCY - pExlcEvent.TOTALACCRUAMT;
                            var netDay = pExlcEvent.DISCOUNT_DAY - pExlcEvent.SUSPAMT;
                            if (netDay + pExlcEvent.DISC_DAYS_PLUS_MINUS != 0)
                            {
                                if (pExlcEvent.PLUS_MINUS_DISC == "1")
                                {
                                    pExlcMaster.ACCRUAMT = (netDiscount + pExlcEvent.RECEIVE_PAY_AMT) / (netDay + pExlcEvent.DISC_DAYS_PLUS_MINUS);
                                }
                                else
                                {
                                    if (netDiscount - pExlcEvent.RECEIVE_PAY_AMT <= 0 || netDay - pExlcEvent.DISC_DAYS_PLUS_MINUS == 0)
                                    {
                                        pExlcMaster.ACCRUAMT = 0;
                                    }
                                    else
                                    {
                                        pExlcMaster.ACCRUAMT = (netDiscount - pExlcEvent.RECEIVE_PAY_AMT) / (netDay - pExlcEvent.DISC_DAYS_PLUS_MINUS);
                                        if (pExlcEvent.ACCRUAMT < 0)
                                        {
                                            pExlcMaster.ACCRUAMT = 0;
                                        }
                                    }
                                }
                            }
                            pExlcMaster.LASTINTDATE = pExlcEvent.LASTINTDATE;
                        }
                        // 6 - Update pPayment
                        if (pExlcEvent.PAYMENT_INSTRU == "PAID")
                        {
                            pExlcMaster.PAYMENT_INSTRU = "PAID";
                            pExlcMaster.METHOD = pExlcEvent.METHOD;
                            pExlcMaster.RECEIVED_NO = pExlcEvent.RECEIVED_NO;
                            var pPayment = (from row in _context.pPayments
                                            where row.RpReceiptNo == pExlcEvent.RECEIVED_NO
                                            select row).AsNoTracking().FirstOrDefault();
                            pPayment.RpRecStatus = "R";
                        }
                        else
                        {
                            pExlcMaster.PAYMENT_INSTRU = "UNPAID";
                            pExlcMaster.METHOD = "";
                            pExlcMaster.RECEIVED_NO = pExlcEvent.RECEIVED_NO;
                        }
                        // 7 - Update pDailyGL
                        if (pExlcEvent.PAYMENT_INSTRU == "PAID")
                        {
                            var dailyGL = (from row in _context.pDailyGLs
                                           where row.VouchID == pExlcEvent.VOUCH_ID &&
                                                 row.VouchDate == pExlcEvent.EVENT_DATE
                                           select row).AsNoTracking().FirstOrDefault();
                            dailyGL.SendFlag = "R";
                        }
                        await _context.SaveChangesAsync();

                        // 8 - Updata Master,Event PK
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
                        var issueCollectExlc = (from row in _context.pExlcs
                                                where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                                      row.RECORD_TYPE == "EVENT" &&
                                                      row.EVENT_TYPE == "Accept Due WREF" &&
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
                                             row.VouchDate == DateTime.Parse(data.EVENT_DATE)
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }


                        // 3 - Update pExlc EVENT
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'T' WHERE EXPORT_LC_NO = '{data.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE = '{EVENT_TYPE}' AND REC_STATUS IN ('P','W')");


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
