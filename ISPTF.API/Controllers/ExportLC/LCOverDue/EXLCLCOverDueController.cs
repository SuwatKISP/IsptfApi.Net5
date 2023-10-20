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
using System.Transactions;

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCLCOverDueController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "12";
        private const string EVENT_TYPE = "OverDue";
        public EXLCLCOverDueController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCEditFlagListPageResponse>> List(string? @ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName,string? OverDueType, string? Page, string? PageSize)
        {
            EXLCEditFlagListPageResponse response = new EXLCEditFlagListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) ||
                string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(Page) ||
                string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCEditFlagListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EXLCEditFlagListPageRsp>();
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
                param.Add("@OverDueType", OverDueType);
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
                if (OverDueType == null)
                {
                    param.Add("@OverDueType", "");
                }
                var results = await _db.LoadData<Q_EXLCEditFlagListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_LCOverDueListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCEditFlagListPageRsp>)results;

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
                response.Data = new List<Q_EXLCEditFlagListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("select")]
        public async Task<ActionResult<PEXLCPPaymentSelectResponse>> Select(string? EXPORT_LC_NO, string? EVENT_NO, string? LFROM)
        {
            PEXLCPPaymentSelectResponse response = new PEXLCPPaymentSelectResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) ||
                string.IsNullOrEmpty(EVENT_NO) ||
                string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXLCPPaymentDataContainer();
                return BadRequest(response);
            }

            // 0 - Select EXLC Master
            var pExlcMaster = await (from row in _context.pExlcs
                                     where row.EXPORT_LC_NO == EXPORT_LC_NO &&
                                           row.RECORD_TYPE == "MASTER"
                                     select row).FirstOrDefaultAsync();
            try
            {
                // 1 - Check if Master Exists
                if (pExlcMaster == null)
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "PEXLC Master does not exists";
                    return BadRequest(response);
                }
                var targetEventNo = pExlcMaster.EVENT_NO + 1;

                // 3 - Select Existing EVENT
                PEXLCPPaymentDataContainer pEXLCPPaymentDataContainer = new();

                if (LFROM == "TRUE")
                {
                    var eventRow = await (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                row.REC_STATUS == "R" &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == pExlcMaster.EVENT_NO
                                          select row).FirstOrDefaultAsync();

                    if (eventRow == null)
                    {
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = "PEXLC Event " + EVENT_TYPE + " at Event No: " + targetEventNo.ToString() + " does not exists";
                        return BadRequest(response);
                    }
                    var pPayment = (from row in _context.pPayments
                                    where row.RpReceiptNo == eventRow.RECEIVED_NO
                                    select row).FirstOrDefault();

                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";


                    pEXLCPPaymentDataContainer.PEXLC = eventRow;
                    pEXLCPPaymentDataContainer.PPAYMENT = pPayment;

                    response.Data = pEXLCPPaymentDataContainer;
                    return Ok(response);
                }
                else if (LFROM == "FALSE")
                {
                    var eventRow = await (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                row.REC_STATUS == "P" &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == targetEventNo
                                          select row).FirstOrDefaultAsync();

                    if (eventRow == null)
                    {
                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Success";

                        // Return Master
                        pEXLCPPaymentDataContainer.PEXLC = pExlcMaster;
                        pEXLCPPaymentDataContainer.PPAYMENT = null;

                        response.Data = pEXLCPPaymentDataContainer;
                        return Ok(response);
                    }
                    var pPayment = await (from row in _context.pPayments
                                          where row.RpReceiptNo == eventRow.RECEIVED_NO
                                          select row).FirstOrDefaultAsync();

                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";

                    pEXLCPPaymentDataContainer.PEXLC = eventRow;
                    pEXLCPPaymentDataContainer.PPAYMENT = pPayment;

                    response.Data = pEXLCPPaymentDataContainer;
                    return Ok(response);
                }
            }

            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXLCPPaymentDataContainer();
            }
            return BadRequest(response);
        }

        [HttpPost("save")]
        public async Task<ActionResult<PEXLCSaveResponse>> Save([FromBody] PEXLCSaveRequest data)
        {
            PEXLCSaveResponse response = new();
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
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'P' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");


                        var targetEventNo = pExlcMaster.EVENT_NO + 1;

                        // 3 - Select Existing EVENT
                        var pExlcEvent = (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                row.REC_STATUS == "P" &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == targetEventNo
                                          select row).AsNoTracking().FirstOrDefault();


                        // 3 - Insert/Update EVENT
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlc eventRow = data.PEXLC;

                        eventRow.CenterID = USER_CENTER_ID;
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
                        eventRow.EVENT_NO = targetEventNo;
                        eventRow.REC_STATUS = "P";
                        eventRow.EVENT_MODE = "E";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                      //  eventRow.EVENT_DATE = DateTime.Today; // Without Time
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = UpdateDateT; // With Time

                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE = UpdateDateNT; // Without Time

                        // Event Specific
                        eventRow.IN_USE = 0;
                        //eventRow.WithOutFlag = "N";
                        eventRow.WithOut = null;
                        eventRow.PAYMENT_INSTRU = "UNPAID";
                        eventRow.METHOD = "";
                        eventRow.RECEIVED_NO = "";
                        eventRow.LCOVERDUE = "Y";
                        eventRow.AUTOOVERDUE = "N";

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
                        transaction.Complete();
                        transaction.Dispose();

                        response.Code = Constants.RESPONSE_OK;

                        PEXLCDataContainer responseData = new();
                        responseData.PEXLC = eventRow;

                        response.Data = responseData;
                        response.Message = "Export L/C Saved";

                        bool resGL;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent = response.Data.PEXLC.EVENT_TYPE;
                        eventDate = response.Data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");
                        if (data.PEXLC.WithOutFlag == "Y")
                        {
                            if (data.PEXLC.WithOutType == "F")
                            {
                                GLEvent = "OVERDUE-FUND";
                            }
                            if (data.PEXLC.WithOutType == "I")
                            {
                                GLEvent = "OVERDUE-UNISB";
                            }
                            if (data.PEXLC.WithOutType == "A")
                            {
                                GLEvent = "OVERDUE-UNAGB";
                            }
                        }
                        resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(response.Data.PEXLC.EXPORT_LC_NO,
                        eventDate,
                        response.Data.PEXLC.EVENT_TYPE,
                        response.Data.PEXLC.EVENT_NO,
                        response.Data.PEXLC.EVENT_TYPE, false, "U");
                        if (resVoucherID != "ERROR")
                        {
                            resGL = true;
                            response.Data.PEXLC.VOUCH_ID = resVoucherID;
                        }
                        else
                        {
                            resGL = false;
                        }
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
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

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
                        // 4 - Update Event
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', AUTH_CODE = '{USER_ID}', AUTH_DATE = '{UpdateDateT}' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_NO='{targetEventNo}'");
                        // 5 - Update GL Flag
                        var gls = (from row in _context.pDailyGLs
                                   where row.VouchID == data.PEXLC.VOUCH_ID &&
                                         row.VouchDate == data.PEXLC.EVENT_DATE.GetValueOrDefault().Date
                                   select row).ToListAsync();

                        foreach (var row in await gls)
                        {
                            row.SendFlag = "R";
                        }
                        await _context.SaveChangesAsync();

                        //6 -Update Master
                        pExlcMaster.AUTH_CODE = USER_ID;
                        pExlcMaster.AUTH_DATE = UpdateDateT;
                        pExlcMaster.VOUCH_ID = pExlcEvent.VOUCH_ID;
                        pExlcMaster.USER_ID = USER_ID;
                        pExlcMaster.UPDATE_DATE = UpdateDateT;
                        pExlcMaster.BUSINESS_TYPE = BUSINESS_TYPE;
                        pExlcMaster.EVENT_TYPE = EVENT_TYPE;
                       // pExlcMaster.REC_STATUS = "R";
                     //   pExlcMaster.event_no = cEventNo;
                        pExlcMaster.IntRateCode = pExlcEvent.IntRateCode;
                        pExlcMaster.OINTDAY = pExlcEvent.OINTDAY;
                        pExlcMaster.OINTRATE = pExlcEvent.OINTRATE;
                        pExlcMaster.OINTSPDRATE = pExlcEvent.OINTSPDRATE;
                        pExlcMaster.OINTCURRATE = pExlcEvent.OINTCURRATE;
                        if (pExlcEvent.WithOutFlag == "Y")
                        {
                            pExlcMaster.DRAFT_CCY = pExlcEvent.DRAFT_CCY;
                            pExlcMaster.OINTDAY = pExlcEvent.BASE_DAY;
                            pExlcMaster.INTBALANCE =pExlcEvent.PARTIAL_AMT1;
                            pExlcMaster.PRNBALANCE = pExlcEvent.PARTIAL_AMT2;
                            pExlcMaster.AccruPending = pExlcEvent.PARTIAL_AMT1;
                            pExlcMaster.INT_BASE_RATE = pExlcEvent.OINTRATE;
                            pExlcMaster.CURRENT_INT_RATE = pExlcEvent.OINTCURRATE;
                            pExlcMaster.INT_SPREAD_RATE = pExlcEvent.OINTSPDRATE;
                        }
                        else
                            {
                            pExlcMaster.DRAFT_CCY = "THB";
                            pExlcMaster.OBASEDAY = pExlcEvent.OBASEDAY;
                            pExlcMaster.TOTAL_NEGO_BAL_THB = pExlcEvent.TOTAL_NEGO_BAL_THB;
                            pExlcMaster.INTBALANCE = pExlcEvent.PARTIAL_AMT1_THB;
                            pExlcMaster.PRNBALANCE = pExlcEvent.TOTAL_NEGO_BAL_THB;
                            pExlcMaster.AccruPending = pExlcEvent.PARTIAL_AMT1_THB;
                        }
                        pExlcMaster.LASTINTDATE =  pExlcEvent.VALUE_DATE;
                        pExlcMaster.VALUE_DATE = pExlcEvent.VALUE_DATE;
                        //pExlcMaster.OVESEQNO = pExlcEvent.OVESEQNO;
                        pExlcMaster.LCOVERDUE = "Y";
                        pExlcMaster.AUTOOVERDUE = pExlcEvent.AUTOOVERDUE;
                        pExlcMaster.INTFLAG = pExlcEvent.INTFLAG;
                        pExlcMaster.PAYMENT_INSTRU = "UNPAID";
                        pExlcMaster.METHOD = "";
                        pExlcMaster.RECEIVED_NO = "";
                       //  ------------------------- ACCRU------------------------------
                        pExlcMaster.DateStartAccru = pExlcEvent.VALUE_DATE;
                        DateTime NewStopDate;
                        NewStopDate = pExlcEvent.VALUE_DATE.Value.AddDays(89); // DateAdd("d", 89, Format(Format(MskValue.Text, "dd/mm/yyyy"), "yyyy/mm/dd"))
                        pExlcMaster.DateToStop = NewStopDate;
                        pExlcMaster.PASTDUEDATE = NewStopDate;
                        pExlcMaster.LCPastDue = "O";
                        await _context.SaveChangesAsync();

                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', EVENT_NO = '{targetEventNo}'  WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");

                        var HistoryInt = ExportLCHelper.HistInterestIssueODU(_context, USER_CENTER_ID, USER_ID, data.PEXLC);

                        transaction.Complete();
                        transaction.Dispose();

                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = "Export L/C Released";

                        string eventDate;
                        string resCustLiab;
                        eventDate = data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");
                        resCustLiab = ISPModule.CustLiabEXLC.EXLC_Overdue(eventDate, "ISSUE", "SAVE",
                        data.PEXLC.EXPORT_LC_NO, data.PEXLC.BENE_ID,
                        data.PEXLC.DRAFT_CCY,
                        data.PEXLC.PARTIAL_AMT2.ToString(),
                        data.PEXLC.PARTIAL_RATE2.ToString()
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
        public async Task<ActionResult<EXLCResultResponse>> Delete([FromBody] PEXLCDeleteRequest data)
        {
            EXLCResultResponse response = new EXLCResultResponse();

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
                                       where row.TranDocNo == data.EXPORT_LC_NO &&
                                             row.VouchDate == DateTime.Parse(data.EVENT_DATE)
                                       select row).ToListAsync();

                        foreach (var row in await dailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }

                        // 2 - Delete pExlc EVENT
                        var pExlcs = (from row in _context.pExlcs
                                      where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                            row.EVENT_TYPE == EVENT_TYPE &&
                                            row.REC_STATUS == "P" &&
                                            row.RECORD_TYPE == "EVENT"
                                      select row).ToListAsync();

                        foreach (var row in await pExlcs)
                        {
                            _context.Remove(row);
                        }

                        // 3 - Delete pExInterest

                        var targetEventNo = pExlc.EVENT_NO + 1;

                        var pSWExports = (from row in _context.pEXInterests
                                          where row.DocNo == data.EXPORT_LC_NO &&
                                                row.EventNo == targetEventNo
                                          select row).ToListAsync();

                        foreach (var row in await pSWExports)
                        {
                            _context.pEXInterests.Remove(row);
                        }

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
                }
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Export L/C Deleted";
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
}
