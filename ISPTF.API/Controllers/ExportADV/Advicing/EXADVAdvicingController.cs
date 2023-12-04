using Dapper;
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
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXADVAdvicingController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public IFormatProvider engDateFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;
        public EXADVAdvicingController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("OriginalLCLoad")]
        public async Task<ActionResult<OriginalLCLoadListPageResponse>> LoadList(string? CenterID, string? LCNo, string? MTType, string? BenName, string? Page, string? PageSize)
        {
            OriginalLCLoadListPageResponse response = new OriginalLCLoadListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CenterID, Page, PageSize is required";
                response.Data = new List<Q_OriginalLCLoadListPageRsp>();
                return BadRequest(response);
            }
            //if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "USER_ID is required";
            //    response.Data = new List<Q_IssuePCNewListPageRsp>();
            //    return BadRequest(response);
            //}

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                //param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@LCNo", LCNo);
                param.Add("@MTType", MTType);
                param.Add("@BenName", BenName);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (LCNo == null)
                {
                    param.Add("@LCNo", "");
                }
                if (MTType == null)
                {
                    param.Add("@MTType", "");
                }
                if (BenName == null)
                {
                    param.Add("@BenName", "");
                }

                var results = await _db.LoadData<Q_OriginalLCLoadListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXAD_AdvisingLCOriginalLoadListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_OriginalLCLoadListPageRsp>)results;

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
                response.Data = new List<Q_OriginalLCLoadListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("list")]
        public async Task<ActionResult<AdvisingListPageResponse>> List(string? TypeLC, string? ListType, string? CenterID, string? EXPORT_ADVICE_NO, string? LC_NO, string? BENEFICIARY_ID, string? BENEFICIARY_INFO, string? Page, string? PageSize)
        {
            AdvisingListPageResponse response = new AdvisingListPageResponse();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(TypeLC) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "TypeLC, ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_AdvisingListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_AdvisingListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@TypeLC", TypeLC);
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

                var results = await _db.LoadData<Q_AdvisingListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXAD_AdvisingLCListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_AdvisingListPageRsp>)results;

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
                response.Data = new List<Q_AdvisingListPageRsp>();
            }
            return BadRequest(response);
        }

        /*
        [HttpGet("test")]
        public async Task<ActionResult<PEXADResponse>> Test()
        {
            PEXADResponse response = new PEXADResponse();
            response.Data = new();
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    // SaveUser("TEST001", 1, "MASTER", "Xxx", "P");

                    //await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET EVENT_NO = 99 WHERE EXPORT_ADVICE_NO = '{exad.EXPORT_ADVICE_NO}' AND RECORD_TYPE='MASTER'");

                    // Commit
                    //await _context.SaveChangesAsync();
                    //transaction.Complete();
                    response.Message = EXHelper.GenSWNo(_context);
                    //response.Data.PEXAD = pexad;
                    return Ok(response);
                }
                catch (Exception e)
                {
                    //transaction.Dispose();
                    response.Message = e.ToString();
                }
                response.Code = Constants.RESPONSE_ERROR;
                response.Data = new();
                return BadRequest(response);
            }
        }
        */

        [HttpGet("select")]
        public async Task<ActionResult<PEXADPPaymentORIResponse>> Select(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO,string ADVICE_TYPE)
        {
            PEXADPPaymentORIResponse response = new();
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
                    response.Data.ADVICE_Type = ADVICE_TYPE;
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

        [HttpGet("GetAmend")]
        public async Task<ActionResult<PEXADPPaymentORIResponse>> GetAmend(string  EXPORT_ADVICE_NO)
        {
            PEXADPPaymentORIResponse response = new();
            response.Data = new();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_ADVICE_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_ADVICE_NO is required";
                return BadRequest(response);
            }

            try
            {
                // pExad
                var exad = await EXADVHelper.GetExadAmend(_context, EXPORT_ADVICE_NO );

                if (exad != null)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Data.PEXAD = exad;
                   // response.Data.ADVICE_Type = ADVICE_TYPE;
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
        public ActionResult<PEXADPPaymentORIResponse> Save([FromBody] PEXADPPaymentRequest pexadppaymentrequest)
        {
            PEXADPPaymentORIResponse response = new();
            response.Data = new();
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
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
            string AdviceType ="";
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // Get Requirement
                        int seq;
                        if (pexadppaymentrequest.pExad.EVENT_TYPE == "Full Advice" || pexadppaymentrequest.pExad.EVENT_TYPE == "Pre Advice")
                        {
                            AdviceType = "ORIGINAL";
                        }
                        else if (pexadppaymentrequest.pExad.EVENT_TYPE == "Amend")
                        {
                            AdviceType = "AMEND";
                        }
                        else
                        {
                            AdviceType = "MAILCONFIRM";
                        }
                        //Get RECEIPT_NO pexadreq.RECEIPT_NO = ?
                        pExad pExadEvent = new pExad();
                        if (pexadppaymentrequest.pExad.EVENT_TYPE == "Full Advice" || pexadppaymentrequest.pExad.EVENT_TYPE == "Pre Advice")
                        {
                            seq = 1;
                            pExadEvent = SaveUser(pexadppaymentrequest.pExad, pexadppaymentrequest.pPayment, seq,"EVENT", pexadppaymentrequest.pExad.EVENT_TYPE,"P", UpdateDateT, UpdateDateNT);
                            if (pExadEvent==null)
                            {
                                response.Code = Constants.RESPONSE_ERROR;
                                response.Message = "Error for Event ";
                                response.Data = new();
                                return BadRequest(response);
                            }
                            SaveDBM(pExadEvent);
                            UpdateExadSWIn(pexadppaymentrequest.pExad, pexadppaymentrequest.pExad.REC_STATUS);
                            KeepDocRegister(pexadppaymentrequest.pExad, "N", "P", "I",UpdateDateT);
                        }
                        else if (pexadppaymentrequest.pExad.EVENT_TYPE == "Amend" || pexadppaymentrequest.pExad.EVENT_TYPE == "Advice Mail")
                        {
                            seq = EXADVHelper.GetSeqNo(_context, pexadppaymentrequest.pExad.EXPORT_ADVICE_NO);
                            pExadEvent = SaveUser(pexadppaymentrequest.pExad, pexadppaymentrequest.pPayment, seq,"EVENT", pexadppaymentrequest.pExad.EVENT_TYPE,"P", UpdateDateT, UpdateDateNT);
                        }

                        // Commit
                        _context.SaveChanges();
                        transaction.Complete();
                        transaction.Dispose();

                        bool resGL;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent = pExadEvent.EVENT_TYPE;
                        eventDate = pExadEvent.EVENT_DATE.Value.ToString("dd/MM/yyyy",engDateFormat);
                        if (pExadEvent.PAYMENT_INSTRU == "1")
                        {
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXAD(pExadEvent.EXPORT_ADVICE_NO,
                                eventDate, GLEvent, pExadEvent.EVENT_NO, "ADVICE");
                        }
                        else
                        {
                            resVoucherID = "";
                        }
                        if (resVoucherID != "ERROR")
                        {
                            resGL = true;
                            pExadEvent.VOUCH_ID = resVoucherID;
                            //if (pExadEvent.EVENT_NO == 1)
                            //{
                            //    _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET VOUCH_ID = '{resVoucherID}' WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE='MASTER' ");
                            //}
                        }
                        else
                        {
                            resGL = false;
                        }
                        if (resGL == false)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Error for G/L";
                            response.Data = new();
                            return BadRequest(response);
                        }
                        var pPaymentEvent = (from row in _context.pPayments
                                             where row.RpReceiptNo == pExadEvent.RECEIPT_NO
                                             select row).AsNoTracking().FirstOrDefault();

                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export Advice Saved";
                        // response.Data.PEXAD = pexadppaymentrequest.pExad;
                        response.Data.PPAYMENT = pexadppaymentrequest.pPayment;
                        response.Data.PEXAD = pExadEvent;
                        response.Data.PPAYMENT = pPaymentEvent;
                        response.Data.ADVICE_Type = AdviceType;
                        return Ok(response);
                    }
                    catch (Exception e)
                    {
                        // Rollback
                        transaction.Dispose();
                        response.Code = Constants.RESPONSE_ERROR;
                        response.Message = e.ToString();
                        return BadRequest(response);
                    }
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
                        var pExadEvent = (from row in _context.pExads
                                          where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                row.RECORD_TYPE == RECORD_TYPE &&
                                                row.EVENT_NO == EVENT_NO &&
                                                row.REC_STATUS == REC_STATUS
                                          select row).AsNoTracking().FirstOrDefault();

                        if(pExadEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export Advice no does not exist.";
                            return BadRequest(response);
                        }

                        var seq = EVENT_NO;
                        // 1 - Update pPayment
                        if(pExadEvent.RECEIPT_NO != "")
                        {
                            var pPayment = (from row in _context.pPayments
                                            where row.RpReceiptNo == pExadEvent.RECEIPT_NO
                                            select row).FirstOrDefault();
                            pPayment.RpStatus = "C";
                        }
                        // 2 - Delete pDailyGL
                        var pDailyGL = (from row in _context.pDailyGLs
                                        where row.VouchID == pExadEvent.VOUCH_ID &&
                                              row.VouchDate == pExadEvent.EVENT_DATE
                                        select row).ToList();
                        foreach (var row in pDailyGL)
                        {
                            _context.pDailyGLs.Remove(row);
                        }

                        if (pExadEvent.EVENT_TYPE == "Full Advice" || pExadEvent.EVENT_TYPE == "Pre Advice")
                        {
                            UpdateExadSWIn(pExadEvent, "");
                            KeepDocRegister(pExadEvent, "N", "P", "D",UpdateDateT);
                            await _context.Database.ExecuteSqlRawAsync($"DELETE pExad WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE IN ('EVENT','MASTER') AND REC_STATUS in('P','W') AND EVENT_NO = {seq}");
                        }
                        else if (pExadEvent.EVENT_TYPE == "Amend" || pExadEvent.EVENT_TYPE == "Advice Mail")
                        {
                            var pExadRelesed = (from row in _context.pExads
                                          where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                row.EVENT_NO == seq &&
                                                row.RECORD_TYPE == "R"
                                          select row).AsNoTracking().FirstOrDefault();
                            if (pExadRelesed==null)
                            {
                                await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'T' WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE ='EVENT' AND REC_STATUS IN ('P','W') AND EVENT_NO = {seq}");
                                await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R' , EVENT_NO = {seq} WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE ='MASTER'");
                            }
                            else
                            {
                                response.Code = Constants.RESPONSE_ERROR;
                                response.Message = "Can not delete MASTER of EVENT record is rec_status = R";
                                return BadRequest(response);
                            }
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
                        var seq = EVENT_NO;
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

                        //Get RECEIPT_NO pexadreq.RECEIPT_NO = ?
                        if (pExadEvent_temp.EVENT_TYPE == "Full Advice" || pExadEvent_temp.EVENT_TYPE == "Pre Advice")
                        {
                            //seq = 1;
                            var pExadEvent = (from row in _context.pExads
                                              where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                    row.RECORD_TYPE == "EVENT" &&
                                                    row.EVENT_NO == 1
                                              select row).AsNoTracking().FirstOrDefault();
                            pExadEvent.AUTH_CODE = USER_ID;
                            pExadEvent.CenterID = CenterID;
                            pExadEvent = SaveSup(pExadEvent,UpdateDateT);
                            _context.pExads.Update(pExadEvent);

                            var pExadMaster = (from row in _context.pExads
                                               where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                     row.RECORD_TYPE == "MASTER" &&
                                                     row.EVENT_NO == 1
                                               select row).AsNoTracking().FirstOrDefault();
                            pExadMaster.AUTH_CODE = USER_ID;
                            pExadMaster.CenterID = CenterID;
                            pExadMaster = SaveSup(pExadMaster,UpdateDateT);
                            _context.pExads.Update(pExadMaster);

                            UpdateExadSWIn(pExadEvent_temp, "I");
                            KeepDocRegister(pExadEvent_temp, "Y", "R", "I",UpdateDateT);
                        }
                        else if (pExadEvent_temp.EVENT_TYPE == "Amend" || pExadEvent_temp.EVENT_TYPE == "Advice Mail")
                        {
                            //seq = await EXADVHelper.GetSeqNo(_context, pExadEvent_temp.EXPORT_ADVICE_NO);

                            var pExadEvent = (from row in _context.pExads
                                              where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                    row.RECORD_TYPE == "EVENT" &&
                                                    row.EVENT_NO == seq
                                              select row).AsNoTracking().FirstOrDefault();
                            pExadEvent.AUTH_CODE = USER_ID;
                            pExadEvent.CenterID = CenterID;
                            pExadEvent = SaveSup(pExadEvent,UpdateDateT);
                            _context.pExads.Update(pExadEvent);

                            var pExadMaster = (from row in _context.pExads
                                               where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                     row.RECORD_TYPE == "MASTER" 
                                               select row).AsNoTracking().FirstOrDefault();
                            pExadMaster.AUTH_CODE = USER_ID;
                            pExadMaster.CenterID = CenterID;
                            pExadMaster = SaveMaster(pExadMaster,pExadEvent,UpdateDateNT);
                            _context.pExads.Update(pExadMaster);
                        }

                        // Commit
                        await _context.SaveChangesAsync();

                        // Update REC_STATUS
                        if (pExadEvent_temp.EVENT_TYPE == "Full Advice" || pExadEvent_temp.EVENT_TYPE == "Pre Advice")
                        {

                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R' WHERE EXPORT_ADVICE_NO = '{pExadEvent_temp.EXPORT_ADVICE_NO}' AND RECORD_TYPE='EVENT' AND EVENT_NO = {seq}");
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R' WHERE EXPORT_ADVICE_NO = '{pExadEvent_temp.EXPORT_ADVICE_NO}' AND RECORD_TYPE='MASTER' AND EVENT_NO = {seq}");
                        }
                        else
                        {
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R' WHERE EXPORT_ADVICE_NO = '{pExadEvent_temp.EXPORT_ADVICE_NO}' AND RECORD_TYPE='EVENT' AND EVENT_NO = {seq}");
                            await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R', EVENT_NO={seq} WHERE EXPORT_ADVICE_NO = '{pExadEvent_temp.EXPORT_ADVICE_NO}' AND RECORD_TYPE='MASTER' ");

                        }

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

        private pExad SaveUser(pExad pExad, pPayment pPayment, int seqNo, string RECORD_TYPE, string EVENT_TYPE, string REC_STATUS, DateTime UpdateDateT, DateTime UpdateDateNT)
        {
            string ExadRef = "";
            var pExadEvent = (from row in _context.pExads
                              where
                                    row.EXPORT_ADVICE_NO == pExad.EXPORT_ADVICE_NO &&
                                    row.RECORD_TYPE == RECORD_TYPE &&
                                    row.REC_STATUS == REC_STATUS &&
                                    row.EVENT_NO == seqNo
                              select row).AsNoTracking().FirstOrDefault();
            string AddNEW = "";
            if (pExadEvent == null)
            {
                AddNEW = "Y";
                if (seqNo==1)
                {
                    ExadRef = EXADVHelper.genRefExad(_context, "EXAD", pExad.CenterID, pExad.USER_ID, UpdateDateT);

                }
                else
                {
                    ExadRef = pExad.EXPORT_ADVICE_NO;
                }
                if (ExadRef=="error")
                {
                    return null;
                }
            }
            else
            {
                AddNEW = "N";
                ExadRef = pExad.EXPORT_ADVICE_NO;
            }
            pExadEvent = pExad;

            pExadEvent.EXPORT_ADVICE_NO = ExadRef;
            pExadEvent.RECORD_TYPE = RECORD_TYPE;
            pExadEvent.EVENT_TYPE = EVENT_TYPE;
            pExadEvent.REC_STATUS = REC_STATUS;
            pExadEvent.EVENT_NO = seqNo;
            pExadEvent.EVENT_MODE = "E";
            if (EVENT_TYPE == "Full Advice")
            {
                pExadEvent.BUSINESS_TYPE = "1";
                pExadEvent.TRANSACTION_TYPE = "1";
            }
                else if (EVENT_TYPE== "Amend")
            {
                pExadEvent.BUSINESS_TYPE = "3";
                pExadEvent.TRANSACTION_TYPE = "2";
            }
            else
            {
                pExadEvent.BUSINESS_TYPE = "4";
                pExadEvent.TRANSACTION_TYPE = "3";
            }
            if (pExadEvent.INCREASE_AMT>0 || pExadEvent.DECREASE_AMT >0)
            {
                pExadEvent.FLAG_TRANSFER = "Y";
            }
            else
            {
                pExadEvent.FLAG_TRANSFER = "N";
            }

            pExadEvent.AUTH_CODE = "";
            pExadEvent.GENACC_FLAG = "Y";
            pExadEvent.GENACC_DATE = UpdateDateNT;
            pExadEvent.UPDATE_DATE = UpdateDateT;
            pExadEvent.IN_USE = "0";
            string FileSWName = "";
            if (pExadEvent.SwiftMT!="N")
            {
                FileSWName = "TFF" + pExadEvent.EXPORT_ADVICE_NO + seqNo + "-" + pExadEvent.EVENT_DATE.Value.ToString("MMdd") + DateTime.Now.ToString("hhmm");
            }
            pExadEvent.SwifInID = FileSWName;
            if (pExadEvent.PAYMENT_INSTRU == "1")
            {
                if (pExadEvent.RECEIPT_NO == null)
                {
                    pExadEvent.RECEIPT_NO = ExportLCHelper.GenRefNo(_context, pExadEvent.CenterID, pExadEvent.USER_ID, "PAYD", UpdateDateT, UpdateDateNT);

                }
                PaymentSave(pExad, pPayment, UpdateDateT, UpdateDateNT);

            }
            else
            {
                pExadEvent.VOUCH_ID = "";
                pExadEvent.RECEIPT_NO = "";
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

            }
            if (pExadEvent.SENDING_BANK_REF == null) pExadEvent.SENDING_BANK_REF = "";
            if (pExadEvent.ADVISE_THRU_THRU_BK_ID == null) pExadEvent.ADVISE_THRU_THRU_BK_ID = "";
            if (AddNEW == "Y")
            {
                _context.Add(pExadEvent);
                _context.SaveChanges();
            }
            else
            {
                _context.Update(pExadEvent);
                _context.SaveChanges();
            }


            // if (pExadEvent.PAYMENT_INSTRU == "1")
            //{
            //    PaymentSave(pExad,pPayment,UpdateDateT,UpdateDateNT);
            //}
            //else
            //{
            //    // Delete pPayment
            //    var pPaymentDel = (from row in _context.pPayments
            //                       where row.RpReceiptNo == pExadEvent.RECEIPT_NO
            //                       select row).ToList();
            //    foreach (var row in pPaymentDel)
            //    {
            //        _context.pPayments.Remove(row);
            //    }
            //    // Delete pPayDetail
            //    var pPayDetailDel = (from row in _context.pPayDetails
            //                       where row.DpReceiptNo == pExadEvent.RECEIPT_NO
            //                       select row).ToList();
            //    foreach (var row in pPayDetailDel)
            //    {
            //        _context.pPayDetails.Remove(row);
            //    }
            //    // Delete pDailyGL
            //    var pDailyGLDel = (from row in _context.pDailyGLs
            //                       where row.VouchID == pExadEvent.VOUCH_ID &&
            //                             row.VouchDate == pExadEvent.EVENT_DATE
            //                       select row).ToList();
            //    foreach (var row in pDailyGLDel)
            //    {
            //        _context.pDailyGLs.Remove(row);
            //    }

            //} // checkpaid

            // Save SWIFT
            if (pExadEvent.SwiftMT != "N")
            {
                var pSWExportEvent = (from row in _context.pSWExports
                                      where row.DocNo == pExadEvent.EXPORT_ADVICE_NO &&
                                            row.Event_No == pExadEvent.EVENT_NO
                                      select row).AsNoTracking().FirstOrDefault();
                if (pSWExportEvent == null)
                {
                    pSWExportEvent = new();
                    pSWExportEvent.AutoNum = EXHelper.GenSWNo(_context);
                    pSWExportEvent.DocNo = pExadEvent.EXPORT_ADVICE_NO;
                    pSWExportEvent.Event_No = pExadEvent.EVENT_NO;
                    pSWExportEvent.Event = pExadEvent.EVENT_TYPE;
                    pSWExportEvent.SwiftFile = FileSWName;
                    pSWExportEvent.RemitCcy = pExadEvent.LC_CURRENCY;
                    pSWExportEvent.RemitAmt = pExadEvent.LC_AMOUNT;
                    pSWExportEvent.ValueDate = pExadEvent.ADVISING_DATE;
                    pSWExportEvent.F20 = pExadEvent.EXPORT_ADVICE_NO;
                    pSWExportEvent.F21 = pExadEvent.EXPORT_ADVICE_NO;
                    pSWExportEvent.BankID = pExadEvent.ISSUE_BANK_ID;
                    pSWExportEvent.BankInFo = pExadEvent.ISSUE_BANK_NAME;
                    pSWExportEvent.F31 = pExadEvent.EVENT_DATE.Value.ToString("yyMMdd");
                    _context.pSWExports.Add(pSWExportEvent);
                }
                else
                {
                    pSWExportEvent.RemitCcy = pExadEvent.LC_CURRENCY;
                    pSWExportEvent.RemitAmt = pExadEvent.LC_AMOUNT;
                    pSWExportEvent.ValueDate = pExadEvent.ADVISING_DATE;
                    pSWExportEvent.F20 = pExadEvent.EXPORT_ADVICE_NO;
                    pSWExportEvent.F21 = pExadEvent.EXPORT_ADVICE_NO;
                    pSWExportEvent.BankID = pExadEvent.ISSUE_BANK_ID;
                    pSWExportEvent.BankInFo = pExadEvent.ISSUE_BANK_NAME;
                    pSWExportEvent.F31 = pExadEvent.EVENT_DATE.Value.ToString("yyMMdd");
                    _context.pSWExports.Update(pSWExportEvent);
                }
            }

            // Update Master
            _context.Database.ExecuteSqlRaw($"UPDATE pExad SET REC_STATUS = 'P' WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE='MASTER'");
            return pExadEvent;
        }

        private void SaveDBM(pExad pExadEvent)
        {
            _context.Database.ExecuteSqlRaw($"DELETE FROM pExad WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE='MASTER'");
            pExad pExadMaster = pExadEvent;
            pExadMaster.RECORD_TYPE = "MASTER";
            _context.pExads.Add(pExadMaster);
        }

        private pExad SaveSup(pExad pExadEvent, DateTime UpdateDateT)
        {
            if (pExadEvent.INCREASE_AMT > 0 || pExadEvent.DECREASE_AMT > 0)
            {
                pExadEvent.FLAG_TRANSFER = "Y";
            }
            else
            {
                pExadEvent.FLAG_TRANSFER = "N";
            }
            if (pExadEvent.RECORD_TYPE == "MASTER")
            {
                pExadEvent.SwiftMT = "N";
                if(pExadEvent.PAYMENT_INSTRU == "2")
                {
                    pExadEvent.UNADVICE_COM = pExadEvent.UNADVICE_COM + pExadEvent.ADVICE_COM;
                    pExadEvent.UNAMEND_COM = pExadEvent.UNAMEND_COM + pExadEvent.AMEND_COM;
                    pExadEvent.UNTRANSFER_COM = pExadEvent.UNTRANSFER_COM + pExadEvent.TRANSFER_COM;
                    pExadEvent.UNCABLE_COM = pExadEvent.UNCABLE_COM + pExadEvent.CABLE_COM;
                    pExadEvent.UNCONFIRM_COM = pExadEvent.UNCONFIRM_COM + pExadEvent.CONFIRM_COM;
                    pExadEvent.UNOTHER_CHARGE = pExadEvent.UNOTHER_CHARGE + pExadEvent.OTHER_CHARGE;
                }
            }
            pExadEvent.AUTH_DATE = UpdateDateT;

            // Update pPayment
            var pPayment = (from row in _context.pPayments
                            where row.RpReceiptNo == pExadEvent.RECEIPT_NO
                            select row).FirstOrDefault();
            if(pPayment!=null)
            {
                pPayment.RpRecStatus = "R";
                pPayment.AuthDate = UpdateDateT;
                pPayment.AuthCode = pExadEvent.USER_ID;
            }

            // Update pDailyGL
            var pDailyGL = (from row in _context.pDailyGLs
                            where row.TranDocNo == pExadEvent.EXPORT_ADVICE_NO &&
                                  row.TranEvent == "ADVICE" &&
                                  row.VouchDate == pExadEvent.EVENT_DATE
                            select row).ToList();
            foreach(var row in pDailyGL)
            {
                row.SendFlag = "R";
            }
            return pExadEvent;
        }

        private pExad SaveMaster(pExad pExadMaster, pExad pExadTemp, DateTime UpdateDateNT)
        {
            var vch = pExadTemp.VOUCH_ID; // ???????
            pExadMaster.LC_TYPE = "1";
            pExadMaster.GENACC_FLAG = "Y";
            pExadMaster.GENACC_DATE = UpdateDateNT;
            pExadMaster.EVENT_MODE = "E";
            pExadMaster.VOUCH_ID = vch;

            if (pExadTemp.EVENT_TYPE == "Amend")
            {
                pExadMaster.BUSINESS_TYPE = "3";
                pExadMaster.AMEND_DATE = pExadTemp.AMEND_DATE;
                pExadMaster.AMEND_NO = pExadTemp.AMEND_NO;
                pExadMaster.INCREASE_AMT = pExadTemp.INCREASE_AMT;
                pExadMaster.DECREASE_AMT = pExadTemp.DECREASE_AMT;
                pExadMaster.LC_AMOUNT = pExadTemp.LC_AMOUNT;
            }
            if(pExadTemp.EVENT_TYPE == "Advice Mail")
            {
                pExadMaster.BUSINESS_TYPE = "4";
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
            }
            if (pExadTemp.PAYMENT_INSTRU == "1")
            {
                pExadMaster.RECEIPT_NO = pExadTemp.RECEIPT_NO;
                pExadMaster.PAYMENT_INSTRU = "1";
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

        private void UpdateExadSWIn(pExad pExad, string RecStatus)
        {
            var exadswin = (from row in _context.pExadSWIns
                            where row.SwifInID == pExad.SwifInID
                            select row).FirstOrDefault();
            if (exadswin!=null)
            {
                exadswin.RecStatus = RecStatus;
            }
        }

        private void KeepDocRegister(pExad pExad, string Reg_Appv, string Reg_RecStat, string Reg_Status,DateTime UpdateDateT)
        {
            var FindCode = "EXAD";
            var Reg_BhtAmt = pExad.LC_AMOUNT * EXHelper.GetRateExChange(_context,pExad.LC_CURRENCY);
            var pDocReg = (from row in _context.pDocRegisters
                                where row.Reg_Login == FindCode &&
                                      row.Reg_Funct == FindCode &&
                                      row.Reg_Docno == pExad.EXPORT_ADVICE_NO
                                select row).FirstOrDefault();
            if (pDocReg == null)
            {
                pDocReg = new();
                pDocReg.Reg_Login = FindCode;
                pDocReg.Reg_Funct = FindCode;
                pDocReg.Reg_Docno = pExad.EXPORT_ADVICE_NO;
                pDocReg.Reg_Date = pExad.EVENT_DATE;
                pDocReg.Reg_Time = UpdateDateT.ToString("HH:mm");
                pDocReg.Reg_Appv = Reg_Appv;
                pDocReg.Reg_RecStat = Reg_RecStat;
                pDocReg.Reg_seq = 1;
                pDocReg.Reg_RefNo = pExad.EXPORT_ADVICE_NO;
                pDocReg.Reg_RefNo2 = pExad.EXPORT_ADVICE_NO;
                pDocReg.Reg_RefNo3 = pExad.EXPORT_ADVICE_NO;
                pDocReg.Reg_CustCode = pExad.BENEFICIARY_ID;
                pDocReg.Reg_Ccy = pExad.LC_CURRENCY;
                pDocReg.Reg_CcyAmt = pExad.LC_AMOUNT;
                pDocReg.Reg_ExchRate = pExad.EXCH_RATE;
                pDocReg.Reg_BhtAmt = Math.Round(Reg_BhtAmt.Value, 2);
                pDocReg.Reg_CcyBal = pExad.LC_AMOUNT;
                pDocReg.Reg_Status = Reg_Status;
                pDocReg.Reg_Tenor = pExad.TENOR_TYPE;
                pDocReg.TenorDay = pExad.TENOR_DAY;
                pDocReg.UpdateDate = UpdateDateT;
                pDocReg.UserCode = pExad.USER_ID;
                pDocReg.CenterID = pExad.CenterID;
                pDocReg.Remark = "N";
                _context.pDocRegisters.Add(pDocReg);
            }
            else
            {
                pDocReg.Reg_Date = pExad.EVENT_DATE;
                pDocReg.Reg_Time = UpdateDateT.ToString("HH:mm");
                pDocReg.Reg_Appv = Reg_Appv;
                pDocReg.Reg_RecStat = Reg_RecStat;
                pDocReg.Reg_seq = 1;
                pDocReg.Reg_RefNo = pExad.EXPORT_ADVICE_NO;
                pDocReg.Reg_RefNo2 = pExad.EXPORT_ADVICE_NO;
                pDocReg.Reg_RefNo3 = pExad.EXPORT_ADVICE_NO;
                pDocReg.Reg_CustCode = pExad.BENEFICIARY_ID;
                pDocReg.Reg_Ccy = pExad.LC_CURRENCY;
                pDocReg.Reg_CcyAmt = pExad.LC_AMOUNT;
                pDocReg.Reg_ExchRate = pExad.EXCH_RATE;
                pDocReg.Reg_BhtAmt = Math.Round(Reg_BhtAmt.Value, 2);
                pDocReg.Reg_CcyBal = pExad.LC_AMOUNT;
                pDocReg.Reg_Status = Reg_Status;
                pDocReg.Reg_Tenor = pExad.TENOR_TYPE;
                pDocReg.TenorDay = pExad.TENOR_DAY;
                pDocReg.UpdateDate = UpdateDateT;
                pDocReg.UserCode = pExad.USER_ID;
                pDocReg.CenterID = pExad.CenterID;
                pDocReg.Remark = "N";
                _context.pDocRegisters.Update(pDocReg);
            }
        }

        private void PaymentSave(pExad exad, pPayment pPaymentReq, DateTime UpdateDateT, DateTime UpdateDateNT)
        {

            var pPaymentEvent = (from row in _context.pPayments
                                 where row.RpReceiptNo == exad.RECEIPT_NO
                                 select row).AsNoTracking().FirstOrDefault();
            if(pPaymentEvent == null)
            {
                pPaymentEvent = new();
                pPaymentEvent = pPaymentReq;
                pPaymentEvent.RpReceiptNo = exad.RECEIPT_NO;
                pPaymentEvent.RpModule = "EXAD";
                pPaymentEvent.RpEvent = "1";
                pPaymentEvent.RpPayDate = exad.EVENT_DATE;
                pPaymentEvent.RpStatus = "A";
                pPaymentEvent.RpRecStatus = "P";
                pPaymentEvent.UserCode = exad.USER_ID;
                pPaymentEvent.UpdateDate = UpdateDateT;
                pPaymentEvent.AuthCode = "";
                pPaymentEvent.AuthDate = null;
                pPaymentEvent.RpNote = "";
                if (pPaymentEvent.RpCustAc1 == null) pPaymentEvent.RpCustAc1 = "";
                if (pPaymentEvent.RpCustAc2 == null) pPaymentEvent.RpCustAc2 = "";
                if (pPaymentEvent.RpCustAc3 == null) pPaymentEvent.RpCustAc3 = "";
                if (pPaymentEvent.RpChqNo == null) pPaymentEvent.RpChqNo = "";
                if (pPaymentEvent.RpChqBank == null) pPaymentEvent.RpChqBank = "";
                if (pPaymentEvent.RpChqBranch == null) pPaymentEvent.RpChqBranch = "";
                _context.pPayments.Add(pPaymentEvent);
            }
            else
            {
                pPaymentReq.RpModule = "EXAD";
                pPaymentReq.RpEvent = "1";
                pPaymentReq.RpPayDate = exad.EVENT_DATE;
                pPaymentReq.RpStatus = "A";
                pPaymentEvent.RpRecStatus = "P";
                pPaymentReq.UserCode = exad.USER_ID;
                pPaymentReq.UpdateDate = UpdateDateT;
                pPaymentReq.AuthCode = "";
                pPaymentReq.AuthDate = null;
                pPaymentEvent.RpNote = "";
                if (pPaymentEvent.RpCustAc1 == null) pPaymentEvent.RpCustAc1 = "";
                if (pPaymentEvent.RpCustAc2 == null) pPaymentEvent.RpCustAc2 = "";
                if (pPaymentEvent.RpCustAc3 == null) pPaymentEvent.RpCustAc3 = "";
                if (pPaymentEvent.RpChqNo == null) pPaymentEvent.RpChqNo = "";
                if (pPaymentEvent.RpChqBank == null) pPaymentEvent.RpChqBank = "";
                if (pPaymentEvent.RpChqBranch == null) pPaymentEvent.RpChqBranch = "";
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
    }
}