using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.ExportLC;
using ISPTF.Models.PurchasePayment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models.ExportLC.PaymentOverDue;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCPaymentOverDueController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "20";
        private const string EVENT_TYPE = "Payment OverDue";
        public EXLCPaymentOverDueController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCPaymentOverDueListResponse>> List(string? ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? Page, string? PageSize)
        {
            EXLCPaymentOverDueListResponse response = new EXLCPaymentOverDueListResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || 
                string.IsNullOrEmpty(CenterID) || 
                string.IsNullOrEmpty(Page) || 
                string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCPaymentOverDueListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EXLCPaymentOverDueListPageRsp>();
                return BadRequest(response);
            }

            // Call Procedure

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

                var results = await _db.LoadData<Q_EXLCPaymentOverDueListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_PaymentOverDueListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCPaymentOverDueListPageRsp>)results;

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
                response.Data = new List<Q_EXLCPaymentOverDueListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("select")]
        public async Task<ActionResult<EXLCPaymentOverDueSelectResponse>> Select(string? EXPORT_LC_NO, int? EVENT_NO, string? LFROM)
        {
            EXLCPaymentOverDueSelectResponse response = new EXLCPaymentOverDueSelectResponse();

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
                           storedProcedure: "usp_pEXLC_PaymentOverDue_Select",
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

        [HttpGet("GetOverDue")]
        public async Task<IEnumerable<Q_EXLCGetOverDueRsp>> GetOverDue(string? EXPORT_LC_NO)
        {
            DynamicParameters param = new();
            param.Add("EXPORT_LC_NO", EXPORT_LC_NO);
            var results = await _db.LoadData<Q_EXLCGetOverDueRsp, dynamic>(
                        storedProcedure: "usp_pEXLC_GetOverDue",
                        param);
            return results;
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
                        eventRow.REC_STATUS = "P";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                       // eventRow.EVENT_DATE = DateTime.Today; // Without Time
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = UpdateDateT; // With Time

                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE = UpdateDateNT; // Without Time

                        eventRow.AUTOOVERDUE = "N";
                        eventRow.LCOVERDUE = "Y";
                        eventRow.LCPastDue = "O";
                        eventRow.IN_USE = 0;


                        if (eventRow.PAYMENT_INSTRU == "PAID")
                        {
                            eventRow.METHOD = data.PEXLC.METHOD;

                            // RECEIVED_NO DCR

                                //if (!eventRow.RECEIVED_NO.Contains("DCR"))
                                //{
                                //    eventRow.RECEIVED_NO = "";
                                //}
                                //else if (!eventRow.RECEIVED_NO.Contains("DDR"))
                                //{
                                //    eventRow.RECEIVED_NO = "";
                                //}
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
                        else if (eventRow.PAYMENT_INSTRU == "UNPAID")
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

                        // 3 - PEXPAYMENT

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
                        _context.SaveChanges();

                       // var result = ExportLCHelper.UpdateCustomerLiability(_context, data.PEXLC);

                        transaction.Complete();
                        transaction.Dispose();

                        response.Code = Constants.RESPONSE_OK;

                        PEXLCPPaymentPEXPaymentPPayDetailDataContainer responseData = new();
                        responseData.PEXLC = eventRow;
                        responseData.PPAYMENT = data.PPAYMENT;
                        responseData.PEXPAYMENT = data.PEXPAYMENT;
                        //responseData.PPAYDETAILS = data.PPAYDETAILS;

                        response.Data = responseData;
                        response.Message = "Export L/C Saved";


                        bool resGL;
                        string eventDate;
                        string resVoucherID="";
                        string GLEvent = response.Data.PEXLC.EVENT_TYPE;
                        eventDate = response.Data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");

                        if (response.Data.PEXLC.PAYMENT_INSTRU == "PAID")
                        {

                            resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(response.Data.PEXLC.EXPORT_LC_NO,
                            eventDate, EVENT_TYPE, response.Data.PEXLC.EVENT_NO,
                            EVENT_TYPE, true);

                            if (resVoucherID != "ERROR")
                            {
                                resGL = true;
                                response.Data.PEXLC.VOUCH_ID = resVoucherID;
                            }
                            else
                            {
                                resGL = false;
                            }
                        }
                        bool resPayD;
                        string resPayDetail;
                        if (eventRow.PAYMENT_INSTRU == "PAID")
                        {
                            resPayDetail = ISPModule.PayDetailEXLC.PayDetail_PayOverdue(response.Data.PEXLC.EXPORT_LC_NO, response.Data.PEXLC.EVENT_NO, response.Data.PEXLC.RECEIVED_NO);
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


                        // 3 - Delete PExPayment
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

        [HttpPost("release")]
        //public ActionResult<EXLCResultResponse> Release([FromBody] PEXLCSaveRequest data)
        public async Task<ActionResult<EXLCResultResponse>> Release([FromBody] PEXLCSaveRequest data)
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

                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', AUTH_CODE = '{USER_ID}', AUTH_DATE = '{UpdateDateT}' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE ='{EVENT_TYPE}' AND EVENT_NO ='{data.PEXLC.EVENT_NO}'");

                        // 4 - Update Master
                        var pExPayments = (from row in _context.pExPayments
                                           where row.DOCNUMBER == data.PEXLC.EXPORT_LC_NO &&
                                                 row.EVENT_TYPE == EVENT_TYPE &&
                                                 row.EVENT_NO == targetEventNo
                                           select row).AsNoTracking().FirstOrDefault();

                        pExlcMaster.AUTH_CODE = USER_ID;
                        pExlcMaster.AUTH_DATE = UpdateDateT;
                        pExlcMaster.VOUCH_ID = data.PEXLC.VOUCH_ID;
                        pExlcMaster.GENACC_FLAG = "Y";
                        pExlcMaster.GENACC_DATE = UpdateDateNT;
                        pExlcMaster.USER_ID = USER_ID;
                        pExlcMaster.UPDATE_DATE = UpdateDateT;
                        pExlcMaster.BUSINESS_TYPE = BUSINESS_TYPE;
                        pExlcMaster.DRAFT_CCY = "THB";
                        pExlcMaster.OVESEQNO = data.PEXLC.OVESEQNO;
                        pExlcMaster.LASTINTDATE = data.PEXLC.ValueDate;
                        pExlcMaster.DateStartAccru = data.PEXLC.ValueDate;
                        pExlcMaster.NEGO_AMT = data.PEXLC.NEGO_AMT;
                        pExlcMaster.TELEX_SWIFT = data.PEXLC.TELEX_SWIFT;
                        pExlcMaster.COURIER_POSTAGE = data.PEXLC.COURIER_POSTAGE;
                        pExlcMaster.STAMP_FEE = data.PEXLC.STAMP_FEE;
                        pExlcMaster.BE_STAMP = data.PEXLC.BE_STAMP;
                        pExlcMaster.COMM_OTHER = data.PEXLC.COMM_OTHER;
                        pExlcMaster.HANDING_FEE = data.PEXLC.HANDING_FEE;
                        pExlcMaster.DRAFTCOMM = data.PEXLC.DRAFTCOMM;
                        pExlcMaster.TOTAL_CHARGE = data.PEXLC.TOTAL_CHARGE;
                        pExlcMaster.REFUND_TAX_YN = data.PEXLC.REFUND_TAX_YN;
                        pExlcMaster.REFUND_TAX_AMT = data.PEXLC.REFUND_TAX_AMT;
                        pExlcMaster.TOTAL_AMOUNT = data.PEXLC.TOTAL_AMOUNT;
                        pExlcMaster.PAYMENTTYPE = data.PEXLC.PAYMENTTYPE;
                        pExlcMaster.NARRATIVE = data.PEXLC.NARRATIVE;
                        pExlcMaster.ALLOCATION = data.PEXLC.ALLOCATION;
                        pExlcMaster.AUTOOVERDUE = "N";
                        pExlcMaster.LCOVERDUE = "Y";
                        if (data.PEXLC.PAYMENT_INSTRU == "PAID")
                        {
                            pExlcMaster.PAYMENT_INSTRU = "PAID";
                            pExlcMaster.METHOD = data.PEXLC.METHOD;
                            pExlcMaster.RECEIVED_NO = data.PEXLC.RECEIVED_NO;
                        }
                        else
                        {
                            pExlcMaster.PAYMENT_INSTRU = "UNPAID";
                            pExlcMaster.METHOD = "";
                            pExlcMaster.RECEIVED_NO = data.PEXLC.RECEIVED_NO;
                        }
                        pExlcMaster.OBASEDAY = data.PEXLC.OBASEDAY;
                        pExlcMaster.INTCODE = data.PEXLC.INTCODE;
                        pExlcMaster.OINTDAY = data.PEXLC.OINTDAY;
                        pExlcMaster.OINTRATE = data.PEXLC.OINTRATE;
                        pExlcMaster.OINTSPDRATE = data.PEXLC.OINTSPDRATE;
                        pExlcMaster.OINTCURRATE = data.PEXLC.OINTCURRATE;
                        pExlcMaster.INTBALANCE = (data.PEXLC.INTBALANCE + data.PEXLC.LASTINTAMT) - pExPayments.int_paid_amt;
                        pExlcMaster.PRNBALANCE = data.PEXLC.PRNBALANCE - pExPayments.prn_paid_thb;
                        pExlcMaster.LASTINTAMT = data.PEXLC.LASTINTAMT;
                        pExlcMaster.TOTAL_NEGO_BALANCE =  data.PEXLC.TOTAL_NEGO_BALANCE;
                        pExlcMaster.VALUE_DATE = data.PEXLC.VALUE_DATE;

                        if (data.PEXLC.PAYMENTTYPE=="F")
                        {

                        }
                        else
                        {
                            if (pExlcMaster.PRNBALANCE==0 && pExlcMaster.INTBALANCE==0)
                            {
                                pExlcMaster.PAYMENTTYPE = "F";
                                pExlcMaster.LCOVERDUE = "Y";
                            }
                            else
                            {
                                pExlcMaster.PAYMENTTYPE = "P";
                                pExlcMaster.LCOVERDUE = "Y";
                            }
                        }
    
                        // '-------CAL PASTDUE DATE ----------------------
                        DateTime LastStopDate;
                        if (pExlcMaster.DateToStop==null)
                        {
                            LastStopDate = pExlcMaster.VALUE_DATE.Value;
                        }
                        else
                        {
                            LastStopDate = pExlcMaster.DateToStop.Value;
                        }
                        DateTime NewStopDate;
                        if (pExPayments.int_paid_thb>0)
                        {

                            NewStopDate = data.PEXLC.ValueDate.Value.AddDays(89);
                            pExlcMaster.DateToStop = NewStopDate;
                            pExlcMaster.PASTDUEDATE = NewStopDate;
                        }
                        _context.SaveChanges();

                        // 5 - Update Master/Event PK to Release
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R',EVENT_NO ='{data.PEXLC.EVENT_NO}',EVENT_TYPE ='{EVENT_TYPE}'  WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");

                        // 6 - Update GL Flag
                        var gls = (from row in _context.pDailyGLs
                                   where row.VouchID == data.PEXLC.VOUCH_ID &&
                                            row.VouchDate == data.PEXLC.EVENT_DATE.GetValueOrDefault().Date
                                   select row).ToList();

                        foreach (var row in gls)
                        {
                            row.SendFlag = "R";
                        }

                        // 7 - Update PPayment
                        var pPayments = (from row in _context.pPayments
                                         where row.RpReceiptNo == data.PEXLC.RECEIVED_NO
                                         select row).ToListAsync();

                        foreach (var row in await pPayments)
                        {
                            row.RpRecStatus = "R";
                        }
                        await _context.SaveChangesAsync();

                        // 8 - Update PPayment
                        var pEXPayments = (from row in _context.pExPayments
                                           where row.DOCNUMBER == data.PEXLC.EXPORT_LC_NO &&
                                           row.EVENT_TYPE == EVENT_TYPE && row.EVENT_NO == data.PEXLC.EVENT_NO
                                           select row).ToListAsync();

                        foreach (var row in await pEXPayments)
                        {
                            row.REC_STATUS = "R";
                        }
                        await _context.SaveChangesAsync();

                        //HistInterestODU
                        if (data.PEXLC.OINTDAY > 0)
                        {
                            var HistoryInt = ExportLCHelper.HistInterestODU(_context, USER_CENTER_ID, USER_ID, data.PEXLC, pExPayments);
                        }

                        //if (data.PEXLC.WithOutFlag == "N")
                        //{
                        //    var result = ExportLCHelper.UpdateCustomerLiability(_context, data.PEXLC);
                        //}
                        //else if (data.PEXLC.WithOutFlag == "Y")
                        //{
                        //    var result = ExportLCHelper.UpdateBankLiability(_context, data.PEXLC);
                        //}

                        transaction.Complete();
                        transaction.Dispose();
                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export L/C Released";
                        //return Ok(response);
                        string eventDate;
                        string resCustLiab;
                        eventDate = data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");
                        resCustLiab = ISPModule.CustLiabEXLC.EXLC_PayOverdue(eventDate, "ISSUE", "SAVE",
                        data.PEXLC.EXPORT_LC_NO, data.PEXLC.BENE_ID,
                        data.PEXLC.DRAFT_CCY,
                        pExPayments.prn_paid_thb.ToString()
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

    }


}
