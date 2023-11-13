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
    public class EXADVConfirmController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public IFormatProvider engDateFormat = new System.Globalization.CultureInfo("en-US").DateTimeFormat;
        public EXADVConfirmController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<ConfirmLCListPageResponse>> List(string? ListType, string? CenterID, string? EXPORT_ADVICE_NO, string? LC_NO, string? BENEFICIARY_ID, string? BENEFICIARY_INFO, string? Page, string? PageSize)
        {
            ConfirmLCListPageResponse response = new ConfirmLCListPageResponse();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_ConfirmLCListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_ConfirmLCListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
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

                var results = await _db.LoadData<Q_ConfirmLCListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXAD_ConfirmLCListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_ConfirmLCListPageRsp>)results;

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
                response.Data = new List<Q_ConfirmLCListPageRsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("select")]
        public async Task<ActionResult<PEXADPPaymentResponse>> Select(string? EXPORT_ADVICE_NO, string? RECORD_TYPE, string? REC_STATUS, int? EVENT_NO)
        {
            PEXADPPaymentResponse response = new();
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
                    if (exad.PAYMENT_INSTRU == "1")
                    {
                        response.Data.PPAYMENT = await EXHelper.GetPPayment(_context, exad.RECEIPT_NO);
                    }
                    response.Code = Constants.RESPONSE_OK;
                    response.Data.PEXAD = exad;
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
        public ActionResult<PEXADPPaymentResponse> Save([FromBody] PEXADPPaymentRequest pexadppaymentrequest)
        {
            PEXADPPaymentResponse response = new();
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

            try
            {
                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        // Get Requirement
                        var seq = EXADVHelper.GetSeqNo(_context, pexadppaymentrequest.pExad.EXPORT_ADVICE_NO);
                        var pExadEvent = SaveUser(pexadppaymentrequest.pExad, pexadppaymentrequest.pPayment, seq, "EVENT", "Confirm L/C", "P", UpdateDateT, UpdateDateNT);

                        // Commit
                        _context.SaveChanges();
                        transaction.Complete();
                        transaction.Dispose();

                        bool resGL;
                        bool resPayD;
                        string eventDate;
                        string resVoucherID;
                        string GLEvent = pExadEvent.EVENT_TYPE;
                        eventDate = pExadEvent.EVENT_DATE.Value.ToString("dd/MM/yyyy",engDateFormat);
                        if (pExadEvent.PAYMENT_INSTRU == "1")
                        {

                            resVoucherID = ISPModule.GeneratrEXP.StartPEXAD(pExadEvent.EXPORT_ADVICE_NO,
                                eventDate, GLEvent, pExadEvent.EVENT_NO, "CONFIRM LC");
                        }
                        else
                        {
                            resVoucherID = "";
                        }
                        if (resVoucherID != "ERROR")
                        {
                            resGL = true;
                            pExadEvent.VOUCH_ID = resVoucherID;
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
                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export Advice Saved";
                        response.Data.PEXAD = pExadEvent; //pexadppaymentrequest.pExad;
                        var pPaymentEvent = (from row in _context.pPayments
                                             where row.RpReceiptNo == pExadEvent.RECEIPT_NO
                                             select row).AsNoTracking().FirstOrDefault();
                        response.Data.PPAYMENT = pPaymentEvent;// pexadppaymentrequest.pPayment;

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

                        if (pExadEvent == null)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Export Advice no does not exist.";
                            return BadRequest(response);
                        }

                        var seq = EVENT_NO;
                        // 1 - Update pPayment
                        if (pExadEvent.RECEIPT_NO != "")
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

                        
                        var pExadRelesed = (from row in _context.pExads
                                            where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                    row.EVENT_NO == seq &&
                                                    row.RECORD_TYPE == "R"
                                            select row).AsNoTracking().FirstOrDefault();
                        if (pExadRelesed == null)
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

            // Validate
            // Validate
            var UpdateDateNT = ExportLCHelper.GetSysDateNT(_context);
            var UpdateDateT = ExportLCHelper.GetSysDate(_context);
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

                        // var seq = EVENT_NO;
                        var seq =  EXADVHelper.GetSeqNo(_context, pExadEvent_temp.EXPORT_ADVICE_NO);

                        var pExadEvent = (from row in _context.pExads
                                          where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                              row.RECORD_TYPE == "EVENT" &&
                                              row.EVENT_NO == seq
                                          select row).AsNoTracking().FirstOrDefault();
                        if(pExadEvent!=null)
                        {
                            pExadEvent.USER_ID = USER_ID;
                            pExadEvent.CenterID = CenterID;
                            pExadEvent = SaveSup(pExadEvent, UpdateDateT);
                            _context.pExads.Update(pExadEvent);
                        }

                        var pExadMaster = (from row in _context.pExads
                                           where row.EXPORT_ADVICE_NO == EXPORT_ADVICE_NO &&
                                                   row.RECORD_TYPE == "MASTER" 
                                           select row).AsNoTracking().FirstOrDefault();
                        if(pExadMaster!=null)
                        {
                            pExadMaster.USER_ID = USER_ID;
                            pExadMaster.CenterID = CenterID;
                            pExadMaster = SaveMaster(pExadMaster, pExadEvent, "Confirm L/C",UpdateDateT);
                            _context.pExads.Update(pExadMaster);
                        }

                        // CommitS
                        await _context.SaveChangesAsync();

                        // Update REC_STATUS
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R' WHERE EXPORT_ADVICE_NO = '{pExadEvent_temp.EXPORT_ADVICE_NO}' AND RECORD_TYPE='EVENT' AND EVENT_NO = {seq}");
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExad SET REC_STATUS = 'R', EVENT_NO={seq} WHERE EXPORT_ADVICE_NO = '{pExadEvent_temp.EXPORT_ADVICE_NO}' AND RECORD_TYPE='MASTER' ");

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
            var pExadEvent = (from row in _context.pExads
                              where
                                    row.EXPORT_ADVICE_NO == pExad.EXPORT_ADVICE_NO &&
                                    row.RECORD_TYPE == RECORD_TYPE &&
                                    row.REC_STATUS == REC_STATUS &&
                                    row.EVENT_NO == seqNo
                              select row).AsNoTracking().FirstOrDefault();

            bool AddNew=false;
            if (pExadEvent == null)
            {
                AddNew = true;
            }
            //if (pExadEvent == null)
            //{
            //    pExadEvent = pExad;
            //    pExadEvent.RECORD_TYPE = RECORD_TYPE;
            //    pExadEvent.EVENT_TYPE = EVENT_TYPE;
            //    pExadEvent.REC_STATUS = REC_STATUS;
            //    pExadEvent.EVENT_NO = seqNo;
            //    pExadEvent.EVENT_MODE = "E";
            //    _context.Add(pExadEvent);
            //}
            //else
            //{
            //    pExadEvent = pExad;
            //    pExadEvent.EVENT_MODE = "E";
            //    _context.Update(pExadEvent);
            //    _context.SaveChanges();
            //}
            pExadEvent = pExad;
            pExadEvent.RECORD_TYPE = RECORD_TYPE;
            pExadEvent.EVENT_TYPE = EVENT_TYPE;
            pExadEvent.REC_STATUS = REC_STATUS;
            pExadEvent.EVENT_NO = seqNo;
            pExadEvent.EVENT_MODE = "E";
            pExadEvent.AUTH_CODE = "";
            pExadEvent.GENACC_FLAG = "Y";
            pExadEvent.GENACC_DATE = UpdateDateNT;
            pExadEvent.UPDATE_DATE = UpdateDateT;
            if (AddNew == true)
            {
                pExadEvent.VOUCH_ID = "";
                pExadEvent.RECEIPT_NO = "";
            }

            if (pExadEvent.PAYMENT_INSTRU == "1")
            {
                PaymentSave(pExad, pPayment, UpdateDateT, UpdateDateNT);
            }
            else
            {
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
                pExadEvent.VOUCH_ID = "";
                pExadEvent.RECEIPT_NO = "";
            }

            if (AddNew == true)
            {
                _context.Add(pExadEvent);
            }
            else
            {
                _context.Update(pExadEvent);
                //_context.SaveChanges();
            }
            // Update Master
            _context.Database.ExecuteSqlRaw($"UPDATE pExad SET REC_STATUS = 'P' WHERE EXPORT_ADVICE_NO = '{pExadEvent.EXPORT_ADVICE_NO}' AND RECORD_TYPE='MASTER'");
            return pExadEvent;
        }

        private void PaymentSave(pExad exad, pPayment pPaymentReq, DateTime UpdateDateT, DateTime UpdateDateNT)
        {
            if (exad.RECEIPT_NO == null|| exad.RECEIPT_NO =="")
            {
                exad.RECEIPT_NO = ExportLCHelper.GenRefNo(_context, exad.CenterID, exad.USER_ID, "PAYD", UpdateDateT, UpdateDateNT);
            }

            var pPaymentEvent = (from row in _context.pPayments
                                 where row.RpReceiptNo == exad.RECEIPT_NO
                                 select row).AsNoTracking().FirstOrDefault();
            if (pPaymentEvent == null)
            {
                pPaymentEvent = new();
                pPaymentEvent = pPaymentReq;
                pPaymentEvent.RpReceiptNo = exad.RECEIPT_NO;
                pPaymentEvent.RpModule = "EXAD";
                pPaymentEvent.RpEvent = "1";
                pPaymentEvent.RpPayDate = exad.EVENT_DATE;
                pPaymentEvent.RpStatus = "A";
                pPaymentEvent.UserCode = exad.USER_ID;
                pPaymentEvent.UpdateDate = UpdateDateT;
                _context.pPayments.Add(pPaymentEvent);
            }
            else
            {
                pPaymentReq.RpModule = "EXAD";
                pPaymentReq.RpEvent = "1";
                pPaymentReq.RpPayDate = exad.EVENT_DATE;
                pPaymentReq.RpStatus = "A";
                pPaymentReq.UserCode = exad.USER_ID;
                pPaymentReq.UpdateDate = UpdateDateT;
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
                paydetail.DpPayAmt = exad.AMEND_COM;
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
                paydetail.DpPayName = "CONFIRM_COM L/C COMM";
                paydetail.DpPayAmt = exad.ADVICE_COM;
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
                paydetail.DpPayAmt = exad.REFUND_TAX*-1;
                _context.pPayDetails.Add(paydetail);
            }
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
                if (pExadEvent.PAYMENT_INSTRU == "2")
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
            foreach (var row in pDailyGL)
            {
                row.SendFlag = "R";
            }
            return pExadEvent;
        }

        private pExad SaveMaster(pExad pExadMaster, pExad pExadTemp, string EVENT_TYPE, DateTime UpdateDateNT)
        {
            var vch = pExadTemp.VOUCH_ID; // ???????
            pExadMaster.AUTH_CODE = pExadTemp.AUTH_CODE;
            pExadMaster.EVENT_TYPE = EVENT_TYPE;
            pExadMaster.LC_TYPE = "1";
            pExadMaster.GENACC_FLAG = "Y";
            pExadMaster.GENACC_DATE = UpdateDateNT;
            pExadMaster.EVENT_MODE = "E";
            pExadMaster.VOUCH_ID = vch;

            if (pExadTemp.EVENT_TYPE == "Amend")
            {
                pExadMaster.BUSINESS_TYPE = pExadTemp.BUSINESS_TYPE;
                pExadMaster.AMEND_DATE = pExadTemp.AMEND_DATE;
                pExadMaster.AMEND_NO = pExadTemp.AMEND_NO;
                pExadMaster.INCREASE_AMT = pExadTemp.INCREASE_AMT;
                pExadMaster.DECREASE_AMT = pExadTemp.DECREASE_AMT;
                pExadMaster.LC_AMOUNT = pExadTemp.LC_AMOUNT;
            }
            
            pExadMaster.BUSINESS_TYPE = pExadTemp.BUSINESS_TYPE;
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
    }
}