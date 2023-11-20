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
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCCollectionPaymentController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "9";
        private const string EVENT_TYPE = "Payment Collect";

        public EXLCCollectionPaymentController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCCollectionPaymentListResponse>> GetAllList(string? @ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? Page, string? PageSize)
        {
            EXLCCollectionPaymentListResponse response = new EXLCCollectionPaymentListResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCCollectionPaymentListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EXLCCollectionPaymentListPageRsp>();
                return BadRequest(response);
            }

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

                var results = await _db.LoadData<Q_EXLCCollectionPaymentListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_CollectionPaymentListPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCCollectionPaymentListPageRsp>)results;

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
                response.Data = new List<Q_EXLCCollectionPaymentListPageRsp>();
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
        public async Task<ActionResult<PEXLCPEXPaymentPPaymentResponse>> GetAllSelect(string? EXPORT_LC_NO, string? EVENT_NO, string? LFROM)
        {
            PEXLCPEXPaymentPPaymentResponse response = new PEXLCPEXPaymentPPaymentResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_LC_NO) || string.IsNullOrEmpty(EVENT_NO) || string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_LC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXLCPEXPaymentPPaymentRsp();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new();
                param.Add("@EXPORT_LC_NO", EXPORT_LC_NO);
                param.Add("@EVENT_NO", EVENT_NO);
                param.Add("@LFROM", LFROM);
                param.Add("@PEXLCRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);
                param.Add("@PEXLCPEXPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<PEXLCPEXPaymentPPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_CollectionPayment_Select",
                           param);
                var PEXLCRsp = param.Get<dynamic>("@PEXLCRsp");
                var pexlcpexpaymentrsp = param.Get<dynamic>("@PEXLCPEXPaymentRsp");

                if (PEXLCRsp > 0 && !string.IsNullOrEmpty(pexlcpexpaymentrsp))
                {
                    PEXLCPEXPaymentPPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXLCPEXPaymentPPaymentRsp>(pexlcpexpaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT L/C NO does not exit";
                    response.Data = new PEXLCPEXPaymentPPaymentRsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXLCPEXPaymentPPaymentRsp();
            }
            return BadRequest(response);
        }

        [HttpGet("query")]
        public async Task<IEnumerable<Q_EXLCCollectionPaymentQueryPageRsp>> GetAllQuery(string? CenterID, string? EXPORT_LC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        {
            DynamicParameters param = new();

            //param.Add("@ListType", @ListType);
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

            var results = await _db.LoadData<Q_EXLCCollectionPaymentQueryPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXLC_CollectionPaymentQueryPage",
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

                        // 3 - Insert EVENT
                        var USER_ID = User.Identity.Name;
                        var claimsPrincipal = HttpContext.User;
                        var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

                        pExlc eventRow = data.PEXLC;


                        // 4 - Select Existing Event
                        var pExlcEvent = (from row in _context.pExlcs
                                          where row.EXPORT_LC_NO == data.PEXLC.EXPORT_LC_NO &&
                                                row.RECORD_TYPE == "EVENT" &&
                                                (row.REC_STATUS == "P" || row.REC_STATUS == "W") &&
                                                row.EVENT_TYPE == EVENT_TYPE &&
                                                row.EVENT_NO == targetEventNo
                                          select row).AsNoTracking().FirstOrDefault();

                        var recNew = false;
                        if (pExlcEvent == null)
                        {
                            recNew = true;
                            eventRow.VOUCH_ID = "";
                            eventRow.RECEIVED_NO = "";
                        }
                        eventRow.CenterID = USER_CENTER_ID;
                        eventRow.BUSINESS_TYPE = BUSINESS_TYPE;
                        eventRow.RECORD_TYPE = "EVENT";
                        eventRow.EVENT_NO = targetEventNo;
                        eventRow.EVENT_MODE = "E";
                        eventRow.REC_STATUS = "P";
                        eventRow.EVENT_TYPE = EVENT_TYPE;
                        //eventRow.EVENT_DATE = DateTime.Today; // Without Time
                        eventRow.USER_ID = USER_ID;
                        eventRow.UPDATE_DATE = UpdateDateT; // With Time
                        eventRow.IN_USE = 0;
                        eventRow.GENACC_FLAG = "Y";
                        eventRow.GENACC_DATE = UpdateDateNT; // Without Time
                        if (eventRow.FB_AMT == null) eventRow.FB_AMT = 0;
                        if (eventRow.RECEIVE_PAY_AMT == null) eventRow.RECEIVE_PAY_AMT = 0;

                        if (eventRow.PAYMENT_INSTRU == "PAID" ||
                            eventRow.PAYMENT_INSTRU == "BAHTNET" ||
                            eventRow.PAYMENT_INSTRU == "FCD" ||
                            eventRow.PAYMENT_INSTRU == "MT202")
                        {
                            eventRow.METHOD = data.PEXLC.METHOD;

                            // RECEIVED_NO DCR
                            if ( eventRow.RECEIVED_NO !=null && eventRow.RECEIVED_NO != "" )
                            { 

                                if (data.PEXPAYMENT.Debit_credit_flag == "C")
                                {
                                    if (!eventRow.RECEIVED_NO.Contains("DCR"))
                                    {
                                        eventRow.RECEIVED_NO = "";
                                    }
                                 }
                                else
                                {
                                    if (!eventRow.RECEIVED_NO.Contains("DDR"))
                                    {
                                        eventRow.RECEIVED_NO = "";
                                    }
                                }
                            }
                            string PayFlag;
                            //    var receiptNo = "[MOCK]" + ExportLCHelper.GenerateRandomReceiptNo(5);
                            string receiptNo;
                            if (eventRow.RECEIVED_NO == "" || recNew == true || eventRow.RECEIVED_NO == null)
                            {
                                if (data.PEXPAYMENT.Debit_credit_flag == "C")
                                {
                                    if (data.PEXPAYMENT.PAYMENT_INSTRU == "FCD" || data.PEXPAYMENT.PAYMENT_INSTRU == "MT202")
                                    {
                                        receiptNo = ExportLCHelper.GetReceiptFCD(_context, USER_CENTER_ID, USER_ID, "FPAIDC",UpdateDateT, UpdateDateNT);
                                    }
                                    else
                                    {
                                        receiptNo = ExportLCHelper.GenRefNo(_context, USER_CENTER_ID, USER_ID, "PAYC", UpdateDateT,UpdateDateNT);
                                    }
                                }
                                else
                                {
                                    if (data.PEXPAYMENT.PAYMENT_INSTRU == "FCD" || data.PEXPAYMENT.PAYMENT_INSTRU == "MT202")
                                    {
                                        receiptNo = ExportLCHelper.GetReceiptFCD(_context, USER_CENTER_ID, USER_ID, "FPAIDD",UpdateDateT,UpdateDateNT);
                                    }
                                    else
                                    {
                                        receiptNo = ExportLCHelper.GenRefNo(_context, USER_CENTER_ID, USER_ID, "PAYD", UpdateDateT,UpdateDateNT);
                                    }
                                }
                                // Check Duplicate Receipt
                                eventRow.RECEIVED_NO = receiptNo;
                               var duplicateReceipt = (from row in _context.pPayments
                                                        where row.RpReceiptNo == receiptNo &&
                                                              row.RpDocNo == data.PEXLC.EXPORT_LC_NO
                                                        select row).FirstOrDefault();

                                if (duplicateReceipt != null)
                                {
                                    response.Code = Constants.RESPONSE_ERROR;
                                    response.Message = "Duplicate Receipt, Please save again";
                                    return BadRequest(response);
                                }
                            }

                            // Call Save Payment
                            eventRow.RECEIVED_NO = ExportLCHelper.SavePayment(_context, USER_CENTER_ID, USER_ID, eventRow, data.PPAYMENT,UpdateDateT, UpdateDateNT);

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


                        // GL MOCK WAIT DLL
                        //var glVouchId = "VOUCH ID FROM GL DLL";
                        //eventRow.VOUCH_ID = glVouchId;
                        _context.SaveChanges();

                        transaction.Complete();
                        transaction.Dispose();
                        response.Code = Constants.RESPONSE_OK;

                        PEXLCPPaymentPEXPaymentPPayDetailDataContainer responseData = new();
                        responseData.PEXLC = eventRow;
                        responseData.PPAYMENT = data.PPAYMENT;
                        responseData.PEXPAYMENT = data.PEXPAYMENT;
                        //  responseData.PPAYDETAILS = data.PPAYDETAILS;

                        response.Data = responseData;
                        response.Message = "Export L/C Saved";

                        bool resGL;
                        bool resPayD;
                        string eventDate;
                        string resVoucherID ="";
                        string GLEvent = response.Data.PEXLC.EVENT_TYPE;
                        eventDate = response.Data.PEXLC.EVENT_DATE.Value.ToString("dd/MM/yyyy");


                        int resSeqNo = targetEventNo;
                        if (response.Data.PEXLC.PAYMENT_INSTRU == "PAID")
                        {
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(response.Data.PEXLC.EXPORT_LC_NO, eventDate, "Payment Collect", resSeqNo, "Payment Collect", true);

                        }
                        else if (response.Data.PEXLC.PAYMENT_INSTRU == "BAHTNET")
                        {
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(response.Data.PEXLC.EXPORT_LC_NO, eventDate, "Payment Collect", resSeqNo, "Payment Collect", true);

                        }
                        else if (response.Data.PEXLC.PAYMENT_INSTRU == "FCD")
                        {
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(response.Data.PEXLC.EXPORT_LC_NO, eventDate,EVENT_TYPE, resSeqNo, "PAYMENT COLL-FCD", true);

                        }
                        else if (response.Data.PEXLC.PAYMENT_INSTRU == "MT202")
                        {
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(response.Data.PEXLC.EXPORT_LC_NO, eventDate, EVENT_TYPE, resSeqNo, "PAYMENT MT202", true);

                        }
                        else if (response.Data.PEXLC.PAYMENT_INSTRU == "UNPAID")
                        {
                            if (response.Data.PEXPAYMENT.Debit_credit_flag == "R")
                            {
                                resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(response.Data.PEXLC.EXPORT_LC_NO, eventDate, EVENT_TYPE, resSeqNo, "PAYMENT-REVCOLL", true);

                            }
                            else
                            {
                                resVoucherID = ISPModule.GeneratrEXP.StartPEXLC(response.Data.PEXLC.EXPORT_LC_NO, eventDate, EVENT_TYPE, resSeqNo, EVENT_TYPE, false, "U");

                            }

                        }
                        else
                        {
                            resVoucherID = "";

                        }
                        response.Data.PEXLC.VOUCH_ID = resVoucherID;
                        if (resVoucherID != "ERROR")
                        {
                            resGL = true;
                        }
                        else
                        {
                            resGL = false;
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Error for G/L ";
                            return BadRequest(response);
                        }

                        string resPayDetail;
                        if (response.Data.PPAYMENT!= null)
                        {
                            resPayDetail = ISPModule.PayDetailEXLC.PayDetail_CollectPay(response.Data.PEXLC.EXPORT_LC_NO, targetEventNo, response.Data.PEXLC.RECEIVED_NO);
                            if (resPayDetail != "ERROR")
                            {
                                resPayD = true;
                            }
                            else
                            {
                                resPayD = false;
                                response.Code = Constants.RESPONSE_ERROR;
                                response.Message = "Error for  Pay Detail";
                                return BadRequest(response);
                            }
                        }
                        else
                        {
                            resPayD = true;
                        }
                        if (resPayD==false || resGL==false)
                        {
                            response.Code = Constants.RESPONSE_ERROR;
                            response.Message = "Error for G/L or Pay Detail";
                            return BadRequest(response);
                        }
                        else
                        {
                            return Ok(response);
                        }

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

                        pExlc eventRow = pExlcEvent;



                        // 4 - Update Master
                        pExlcMaster.AUTH_CODE = USER_ID;
                        pExlcMaster.AUTH_DATE = UpdateDateT; // With Time
                        pExlcMaster.UPDATE_DATE = UpdateDateT; // With Time

                        var pExPayments = (from row in _context.pExPayments
                                           where row.DOCNUMBER == data.PEXLC.EXPORT_LC_NO &&
                                                 row.EVENT_TYPE == EVENT_TYPE &&
                                                 row.EVENT_NO == targetEventNo
                                           select row).AsNoTracking().FirstOrDefault();
                        double Tot_paid = 0;
                        if (pExlcEvent.PARTIAL_FULL_RATE == 2) //full rate
                        {
                            if (pExPayments.SETTLEMENT_CREDIT == 0 || pExPayments.SETTLEMENT_CREDIT == 1)//fcy to thb
                            {

                                if (pExlcEvent.TENOR_OF_COLL == 1)
                                {
                                    Tot_paid = pExPayments.SIGHT_PAID_AMT.Value;
                                }
                                else
                                {
                                    Tot_paid = pExPayments.TERM_PAID_AMT.Value;
                                }
                            }
                            else if (pExPayments.SETTLEMENT_CREDIT == 2)
                            {
                                if (pExlcEvent.TENOR_OF_COLL == 1)
                                {
                                    Tot_paid = pExPayments.SIGHT_PAID_THB.Value;
                                }
                                else
                                {
                                    Tot_paid = pExPayments.TERM_PAID_THB.Value;
                                }
                            }

                        }
                        else //full rate
                        {
                            double cAmt1 = 0;
                            double cAmt2 = 0;
                            double cAmt3 = 0;
                            double cAmt4 = 0;
                            double cAmt5 = 0;
                            double cAmt6 = 0;
                            double tAmt1 = 0;
                            double tAmt2 = 0;
                            double tAmt3 = 0;
                            double tAmt4 = 0;
                            double tAmt5 = 0;
                            double tAmt6 = 0;
                            if (pExPayments.PARTIAL_AMT1 != null)
                            {
                                cAmt1 = pExPayments.PARTIAL_AMT1.Value;
                            }
                            if (pExPayments.PARTIAL_AMT2 != null)
                            {
                                cAmt2 = pExPayments.PARTIAL_AMT2.Value;
                            }
                            if (pExPayments.PARTIAL_AMT3 != null)
                            {
                                cAmt3 = pExPayments.PARTIAL_AMT3.Value;
                            }
                            if (pExPayments.PARTIAL_AMT4 != null)
                            {
                                cAmt4 = pExPayments.PARTIAL_AMT4.Value;
                            }
                            if (pExPayments.PARTIAL_AMT5 != null)
                            {
                                cAmt5 = pExPayments.PARTIAL_AMT5.Value;
                            }
                            if (pExPayments.PARTIAL_AMT6 != null)
                            {
                                cAmt6 = pExPayments.PARTIAL_AMT6.Value;
                            }

                            if (pExPayments.PARTIAL_AMT1_THB != null)
                            {
                                tAmt1 = pExPayments.PARTIAL_AMT1_THB.Value;
                            }
                            if (pExPayments.PARTIAL_AMT2_THB != null)
                            {
                                tAmt2 = pExPayments.PARTIAL_AMT2_THB.Value;
                            }
                            if (pExPayments.PARTIAL_AMT3_THB != null)
                            {
                                tAmt3 = pExPayments.PARTIAL_AMT3_THB.Value;
                            }
                            if (pExPayments.PARTIAL_AMT4_THB != null)
                            {
                                tAmt4 = pExPayments.PARTIAL_AMT4_THB.Value;
                            }
                            if (pExPayments.PARTIAL_AMT5_THB != null)
                            {
                                tAmt5 = pExPayments.PARTIAL_AMT5_THB.Value;
                            }
                            if (pExPayments.PARTIAL_AMT6_THB != null)
                            {
                                tAmt6 = pExPayments.PARTIAL_AMT6_THB.Value;
                            }
                            if (pExPayments.SETTLEMENT_CREDIT == 0 || pExPayments.SETTLEMENT_CREDIT == 1)//fcy to thb
                            {
                                Tot_paid = cAmt1 + cAmt2 + cAmt3 + cAmt4 + cAmt5 + cAmt6;

                            }
                            else if (pExPayments.SETTLEMENT_CREDIT == 2)//fcy to thb
                            {
                                Tot_paid = tAmt1 + tAmt2 + tAmt3 + tAmt4 + tAmt5 + tAmt6;
                            }

                        }

                        pExlcMaster.PurposeCode = pExlcEvent.PurposeCode;
                        pExlcMaster.INVOICE = pExlcEvent.INVOICE;
                        pExlcMaster.GENACC_FLAG = "Y";
                        pExlcMaster.GENACC_DATE = UpdateDateNT;
                        pExlcMaster.BUSINESS_TYPE = BUSINESS_TYPE;
                        pExlcMaster.EVENT_MODE = "E";

                        pExlcMaster.VOUCH_ID = pExlcEvent.VOUCH_ID;
                        pExlcMaster.USER_ID = USER_ID;
                        pExlcMaster.UPDATE_DATE = UpdateDateT;
                        pExlcMaster.RELETE_PACK = pExlcEvent.RELETE_PACK;
                        pExlcMaster.PAYMENTTYPE = pExlcEvent.PAYMENTTYPE;
                        pExlcMaster.TOT_NEGO_AMT = pExlcMaster.TOT_NEGO_AMT - Tot_paid;
                        pExlcMaster.TOT_NEGO_AMOUNT = pExlcMaster.TOT_NEGO_AMT;
                        if (pExlcMaster.TOT_NEGO_AMT==0)
                        {
                            pExlcMaster.PAYMENTTYPE = "F";
                        }
                        else
                        {
                            pExlcMaster.PAYMENTTYPE = "P";
                        }

                        pExlcMaster.TOTAL_NEGO_BALANCE = pExlcEvent.TOTAL_NEGO_BALANCE;
                        pExlcMaster.TOTAL_NEGO_BAL_THB = pExlcEvent.TOTAL_NEGO_BAL_THB;
                        if (pExPayments.Debit_credit_flag =="R")
                        {
                            pExlcMaster.TOT_NEGO_AMT = 0;
                            pExlcMaster.TOT_NEGO_AMOUNT = 0;
                            pExlcMaster.PAYMENTTYPE = "F";
                        }

                        // 'PAYMENT
                
                        //   'TAB 2
                        pExlcMaster.NEGO_COMM = pExlcEvent.NEGO_COMM;
                        pExlcMaster.TELEX_SWIFT = pExlcEvent.TELEX_SWIFT;
                        pExlcMaster.COURIER_POSTAGE = pExlcEvent.COURIER_POSTAGE;
                        pExlcMaster.STAMP_FEE = pExlcEvent.STAMP_FEE;
                        pExlcMaster.BE_STAMP = pExlcEvent.BE_STAMP;
                        pExlcMaster.COMM_OTHER = pExlcEvent.COMM_OTHER;
                        pExlcMaster.HANDING_FEE = pExlcEvent.HANDING_FEE;
                        pExlcMaster.DRAFTCOMM = pExlcEvent.DRAFTCOMM;
                        pExlcMaster.TOTAL_CHARGE = pExlcEvent.TOTAL_CHARGE;
                        pExlcMaster.REFUND_TAX_YN = pExlcEvent.REFUND_TAX_YN;
                        pExlcMaster.REFUND_TAX_AMT = pExlcEvent.REFUND_TAX_AMT;
                        pExlcMaster.TOTAL_AMOUNT = pExlcEvent.TOTAL_AMOUNT;

                        _context.SaveChanges();



                        var pPayments = (from row in _context.pPayments
                                         where row.RpReceiptNo == pExlcEvent.RECEIVED_NO
                                         select row).ToList();

                        foreach (var row in  pPayments)
                        {
                            row.RpRecStatus = "R";
                        }
                       _context.SaveChanges();

                        // 8 - Update PPayment
                        var pEXPayments = (from row in _context.pExPayments
                                           where row.DOCNUMBER == data.PEXLC.EXPORT_LC_NO &&
                                           row.EVENT_TYPE == EVENT_TYPE && row.EVENT_NO == pExlcEvent.EVENT_NO
                                           select row).ToList();

                        foreach (var row in pEXPayments)
                        {
                            row.REC_STATUS = "R";
                        }
                    //    pExPayments.REC_STATUS = "R";
                        _context.SaveChanges();

                        // 6 - Update GL Flag
                        var gls = (from row in _context.pDailyGLs
                                   where row.VouchID == pExlcEvent.VOUCH_ID &&
                                            row.VouchDate == pExlcEvent.EVENT_DATE.GetValueOrDefault().Date
                                   select row).ToList();

                        foreach (var row in gls)
                        {
                            row.SendFlag = "R";
                        }


                        // var result = ExportLCHelper.UpdateCustomerLiability(_context, data.PEXLC);
                        _context.SaveChanges();

                        // 5 - Update Master/Event PK to Release
                        _context.Database.ExecuteSqlRaw($"UPDATE pExlc SET REC_STATUS = 'R',EVENT_NO ='{targetEventNo}',EVENT_TYPE ='{EVENT_TYPE}'   WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");
                        _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R', AUTH_CODE = '{USER_ID}', AUTH_DATE = '{UpdateDateT}' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='EVENT' AND EVENT_TYPE ='{EVENT_TYPE}' AND EVENT_NO ='{pExlcEvent.EVENT_NO}'");
                        _context.SaveChanges();
                        transaction.Complete();


                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export L/C Released";
                        string eventDate;
                        string resCustLiab;
                        eventDate = pExlcEvent.EVENT_DATE.Value.ToString("dd/MM/yyyy");
                        resCustLiab = ISPModule.CustLiabEXLC.EXLC_CollectPay(eventDate, "ISSUE", pExPayments.Debit_credit_flag,
                        pExlcEvent.EXPORT_LC_NO, pExlcEvent.BENE_ID,
                        pExlcEvent.DRAFT_CCY,
                        pExlcEvent.DRAFT_AMT.ToString(),
                        pExlcEvent.EVENT_NO.ToString());
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
                        var pExlcEvents = (from row in _context.pExlcs
                                                where row.EXPORT_LC_NO == data.EXPORT_LC_NO &&
                                                      row.RECORD_TYPE == "EVENT" &&
                                                      row.EVENT_TYPE == EVENT_TYPE &&
                                                      row.REC_STATUS == "P" &&
                                                      (row.RECEIVED_NO != null && row.RECEIVED_NO != "")
                                                select row).ToListAsync();

                        foreach (var row in await pExlcEvents)
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
                        
                        // 4 - Delete PExInterest
                        var targetEventNo = pExlc.EVENT_NO + 1;
                        var pExInterests = (from row in _context.pEXInterests
                                           where row.DocNo == data.EXPORT_LC_NO &&
                                                 row.Event == EVENT_TYPE &&
                                                 row.EventNo == targetEventNo
                                           select row).ToListAsync();

                        foreach (var row in await pExInterests)
                        {
                            _context.pEXInterests.Remove(row);
                        }

                        // 5 - Delete PExPayment
                        var pExPayments = (from row in _context.pExPayments
                                           where row.DOCNUMBER == data.EXPORT_LC_NO &&
                                                 row.EVENT_TYPE == EVENT_TYPE &&
                                                 row.EVENT_NO == targetEventNo
                                           select row).AsNoTracking().ToListAsync();

                        foreach (var row in await pExPayments)
                        {
                            _context.pExPayments.Remove(row);
                        }
                        // 6 - Update pExlc Master

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
