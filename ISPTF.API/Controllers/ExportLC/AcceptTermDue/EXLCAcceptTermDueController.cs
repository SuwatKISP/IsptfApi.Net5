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
using System.Reflection;

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCAcceptTermDueController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "4";
        private const string EVENT_TYPE = "Accept Due";

        public EXLCAcceptTermDueController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCAcceptTermDueListResponse>> List(string? @ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? Page, string? PageSize)
        {
            EXLCAcceptTermDueListResponse response = new EXLCAcceptTermDueListResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
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
                            storedProcedure: "usp_q_EXLC_AcceptTermDueListPage",
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
        public async Task<ActionResult<PEXLCPPaymentResponse>> Select(string? EXPORT_LC_NO, string? EVENT_NO, string? LFROM)
        {
            PEXLCPPaymentResponse response = new PEXLCPPaymentResponse();
            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) || string.IsNullOrEmpty(EVENT_NO) || string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXLCPPaymentRsp();
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

                param.Add("@PEXLCPPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<PEXLCPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_AcceptTermDue_Select",
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

        [HttpPost("Release")]
        public async Task<ActionResult<EXLCResultResponse>> Release([FromBody] PEXLCSaveRequest data)
        {
            EXLCResultResponse response = new();

            // Validate

            //from vb (not implimented here)
            try
            {
                bool onePUse = false;
                if (onePUse && data.PEXLC.TOTAL_AMOUNT > 0)
                {
                    string op_event;
                    if (data.PEXLC.METHOD.Contains("DEBIT"))
                    {
                        op_event = "DR";
                    }
                    else if (data.PEXLC.METHOD.Contains("CREDIT"))
                    {
                        op_event = "CR";
                    }
                    else
                    {
                        op_event = "";
                    }
                    // Use Socket
                }
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        //SaveMaster
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

                        // 2 - Select Existing Event
                        var cEventNo = pExlcMaster.EVENT_NO + 1;
                        var pExlcEvent = (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                (row.REC_STATUS == "P" || row.REC_STATUS == "W") &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == cEventNo
                                          select row).AsNoTracking().FirstOrDefault();

                        // 3 - Check if Event Exist
                        if (pExlcEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "PEXLC " + EVENT_TYPE + " Event does not exists";
                            return BadRequest(response);
                        }

                        // 4 - Update Event
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlcEvent.RECEIVED_NO = data.PEXLC.RECEIVED_NO;
                        pExlcEvent.AUTH_CODE = data.PEXLC.AUTH_CODE;
                        pExlcEvent.AUTH_DATE = data.PEXLC.AUTH_DATE;
                        pExlcEvent.GENACC_FLAG = "Y";
                        pExlcEvent.GENACC_DATE = DateTime.Today;

                        // 5 - Update Master
                        pExlcMaster.AUTH_CODE = data.PEXLC.AUTH_CODE;
                        pExlcMaster.AUTH_DATE = data.PEXLC.AUTH_DATE;
                        pExlcMaster.VOUCH_ID = data.PEXLC.VOUCH_ID;
                        pExlcMaster.GENACC_FLAG = "Y";
                        pExlcMaster.GENACC_DATE = DateTime.Today;
                        pExlcMaster.USER_ID = USER_ID;
                        pExlcMaster.UPDATE_DATE = DateTime.Today;
                        pExlcMaster.BUSINESS_TYPE = BUSINESS_TYPE;
                        pExlcMaster.EVENT_TYPE = EVENT_TYPE;
                        pExlcMaster.SEQ_ACCEPT_DUE = data.PEXLC.SEQ_ACCEPT_DUE;
                        pExlcMaster.CONFIRM_DATE = data.PEXLC.CONFIRM_DATE;
                        pExlcMaster.DISC_DAYS_PLUS_MINUS = data.PEXLC.DISC_DAYS_PLUS_MINUS;
                        pExlcMaster.PLUS_MINUS_DISC = data.PEXLC.PLUS_MINUS_DISC;
                        pExlcMaster.REFUND_DISC_RECEIVE = data.PEXLC.REFUND_DISC_RECEIVE;
                        pExlcMaster.DISC_RECEIVE = data.PEXLC.DISC_RECEIVE;
                        pExlcMaster.RECEIVE_PAY_AMT = data.PEXLC.RECEIVE_PAY_AMT;
                        pExlcMaster.EXCHANGE_RATE = data.PEXLC.EXCHANGE_RATE;
                        pExlcMaster.DISCRATE = data.PEXLC.DISCRATE;
                        pExlcMaster.TOTAL_AMOUNT = data.PEXLC.TOTAL_AMOUNT;
                        pExlcMaster.NARRATIVE = data.PEXLC.NARRATIVE;
                        pExlcMaster.CFRRate = data.PEXLC.CFRRate;
                        pExlcMaster.IntRateCode = data.PEXLC.IntRateCode;
                        pExlcMaster.COLLECT_REFUND = data.PEXLC.COLLECT_REFUND;
                        if (data.PEXLC.TENOR_TYPE == 4)
                        {
                            pExlcMaster.TERM_START_DATE = data.PEXLC.TERM_START_DATE;
                            pExlcMaster.TERM_DUE_DATE = data.PEXLC.TERM_DUE_DATE;
                        }
                        else
                        {
                            if (data.PEXLC.PLUS_MINUS_DISC == "1")
                            {
                                pExlcMaster.TERM_START_DATE = data.PEXLC.TERM_START_DATE;
                                pExlcMaster.TERM_DUE_DATE = data.PEXLC.TERM_DUE_DATE.Value.AddDays((Double)data.PEXLC.DISC_DAYS_PLUS_MINUS);
                                pExlcMaster.DISCOUNT_CCY = data.PEXLC.DISCOUNT_CCY + data.PEXLC.RECEIVE_PAY_AMT;
                                if (data.PEXLC.REFUND_DISC_RECEIVE > 0)
                                {
                                    pExlcMaster.DISCOUNT_AMT = data.PEXLC.DISCOUNT_AMT + data.PEXLC.REFUND_DISC_RECEIVE;
                                }
                                else
                                {
                                    pExlcMaster.DISCOUNT_AMT = data.PEXLC.DISCOUNT_AMT + data.PEXLC.DISC_RECEIVE;
                                }
                            }
                            else if (data.PEXLC.PLUS_MINUS_DISC == "2")
                            {
                                pExlcMaster.TERM_START_DATE = data.PEXLC.TERM_START_DATE;
                                pExlcMaster.TERM_DUE_DATE = data.PEXLC.CONFIRM_DATE;
                                pExlcMaster.DISCOUNT_CCY = data.PEXLC.DISCOUNT_CCY + data.PEXLC.RECEIVE_PAY_AMT;
                                if (data.PEXLC.REFUND_DISC_RECEIVE > 0)
                                {
                                    pExlcMaster.DISCOUNT_AMT = data.PEXLC.DISCOUNT_AMT + data.PEXLC.REFUND_DISC_RECEIVE;
                                }
                                else
                                {
                                    pExlcMaster.DISCOUNT_AMT = data.PEXLC.DISCOUNT_AMT + data.PEXLC.DISC_RECEIVE;
                                }
                            }
                        }
                        pExlcMaster.DISCOUNT_DAY = data.PEXLC.DISCOUNT_DAY;
                        pExlcMaster.CURRENT_DIS_RATE = data.PEXLC.CURRENT_DIS_RATE;
                        if(data.PEXLC.TENOR_TYPE != 4)
                        {
                            var netDiscount = data.PEXLC.DISCOUNT_CCY - data.PEXLC.TOTALACCRUAMT;
                            var netDay = data.PEXLC.DISCOUNT_DAY - data.PEXLC.SUSPAMT;
                            if (netDay + data.PEXLC.DISC_DAYS_PLUS_MINUS != 0)
                            {
                                if(data.PEXLC.PLUS_MINUS_DISC == "1")
                                {
                                    pExlcMaster.ACCRUAMT = (netDiscount + data.PEXLC.RECEIVE_PAY_AMT) / (netDay + data.PEXLC.DISC_DAYS_PLUS_MINUS);
                                }
                                else
                                {
                                    if(netDiscount - data.PEXLC.RECEIVE_PAY_AMT <= 0 || netDay - data.PEXLC.DISC_DAYS_PLUS_MINUS == 0 )
                                    {
                                        pExlcMaster.ACCRUAMT = 0;
                                    }
                                    else
                                    {
                                        pExlcMaster.ACCRUAMT = (netDiscount - data.PEXLC.RECEIVE_PAY_AMT) / (netDay - data.PEXLC.DISC_DAYS_PLUS_MINUS);
                                        if (data.PEXLC.ACCRUAMT < 0)
                                        {
                                            pExlcMaster.ACCRUAMT = 0;
                                        }
                                    }
                                }
                            }
                            pExlcMaster.LASTINTDATE = data.PEXLC.LASTINTDATE;
                        }
                        // 6 - Update pPayment
                        if (data.PEXLC.PAYMENT_INSTRU == "PAID")
                        {
                            pExlcMaster.PAYMENT_INSTRU = "PAID";
                            pExlcMaster.METHOD = data.PEXLC.METHOD;
                            pExlcMaster.RECEIVED_NO = data.PEXLC.RECEIVED_NO;
                            var pPayment = (from row in _context.pPayments
                                            where row.RpReceiptNo == data.PEXLC.RECEIVED_NO
                                            select row).AsNoTracking().FirstOrDefault();
                            pPayment.RpRecStatus = "R";
                        }
                        else
                        {
                            pExlcMaster.PAYMENT_INSTRU = "UNPAID";
                            pExlcMaster.METHOD = "";
                            pExlcMaster.RECEIVED_NO = data.PEXLC.RECEIVED_NO;
                        }
                        // 7 - Update pDailyGL
                        if (data.PEXLC.PAYMENT_INSTRU == "PAID")
                        {
                            var dailyGL = (from row in _context.pDailyGLs
                                           where row.VouchID == data.PEXLC.VOUCH_ID &&
                                                 row.VouchDate == data.PEXLC.EVENT_DATE
                                           select row).AsNoTracking().FirstOrDefault();
                            dailyGL.SendFlag = "R";
                        }
                        await _context.SaveChangesAsync();

                        // 8 - Updata Master,Event PK
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', EVENT_NO = {cEventNo} WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE='{EVENT_TYPE}'");
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
                                             row.VouchDate == DateTime.Parse(data.EVENT_DATE)
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }


                        // 3 - Update pExlc EVENT
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'T' WHERE EXPORT_LC_NO = '{data.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE = '{EVENT_TYPE}' AND REC_STATUS IN ('P','W')");


                        // 4 - Update pExlc Master
                        var targetEventNo = pExlc.EVENT_NO + 1;
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
