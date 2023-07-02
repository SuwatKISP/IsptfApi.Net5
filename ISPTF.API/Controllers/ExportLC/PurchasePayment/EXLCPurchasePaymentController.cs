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

namespace ISPTF.API.Controllers.ExportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXLCPurchasePaymentController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        private const string BUSINESS_TYPE = "8";
        private const string EVENT_TYPE = "Payment Purchase";
        public EXLCPurchasePaymentController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXLCPurchasePaymentListResponse>> List(string? ListType, string? CenterID, string? EXPORT_LC_NO, string? BENName, string? Page, string? PageSize)
        {
            EXLCPurchasePaymentListResponse response = new EXLCPurchasePaymentListResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(@ListType) ||
                string.IsNullOrEmpty(CenterID) ||
                string.IsNullOrEmpty(Page) ||
                string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXLCPurchasePaymentListPageRsp>();
                return BadRequest(response);
            }

            if (@ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required for RELEASE";
                response.Data = new List<Q_EXLCPurchasePaymentListPageRsp>();
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

                var results = await _db.LoadData<Q_EXLCPurchasePaymentListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXLC_PurchasePaymentListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXLCPurchasePaymentListPageRsp>)results;

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
                response.Data = new List<Q_EXLCPurchasePaymentListPageRsp>();
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
        public async Task<ActionResult<EXLCPurchasePaymentSelectResponse>> Select(string? EXPORT_LC_NO, string? EVENT_NO, string? LFROM)
        {
            EXLCPurchasePaymentSelectResponse response = new EXLCPurchasePaymentSelectResponse();

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
                param.Add("@LFROM", LFROM);

                param.Add("@PExLcRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@PEXLCPEXPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<PEXLCPEXPaymentRsp, dynamic>(
                           storedProcedure: "usp_pEXLC_PurchasePayment_Select",
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
                    response.Message = "Error selecting Purchase Payment";
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

        [HttpPost("save")]
        public async Task<ActionResult<PEXLCPPaymentPPayDetailsSaveResponse>> Save([FromBody] PEXLCPPaymentPEXPaymentPPayDetailsSaveRequest data)
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

                        eventRow.PurposeCode = data.PEXLC.PurposeCode;

                        eventRow.WithOutFlag = data.PEXLC.WithOutType;
                        eventRow.WithOutType = null;
                        eventRow.Wref_Bank_ID = "";

                        if (eventRow.WithOutFlag == "Y")
                        {
                            eventRow.WithOutType = data.PEXLC.WithOutType;
                            eventRow.Wref_Bank_ID = data.PEXLC.Wref_Bank_ID;
                        }

                        eventRow.COMMONTT = data.PEXLC.COMMONTT;
                        eventRow.INT_AMT_THB = data.PEXLC.INT_AMT_THB;
                        eventRow.INVOICE = data.PEXLC.INVOICE;
                        eventRow.REC_STATUS = "P";
                        eventRow.IN_USE = 1;
                        eventRow.AGENT_BANK_ID = data.PEXLC.AGENT_BANK_ID;
                        eventRow.AGENT_BANK_INFO = data.PEXLC.AGENT_BANK_INFO;
                        eventRow.ValueDate = DateTime.Today;
                        eventRow.PAYMENT_INSTRU = data.PEXLC.PAYMENT_INSTRU;

                        if (eventRow.PAYMENT_INSTRU == "PAID")
                        {
                            eventRow.METHOD = data.PEXLC.METHOD;
                            // Call Save Payment
                            eventRow.RECEIVED_NO = "RECEIVE_NO FROM DLL";

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

                        eventRow.NEGO_COMM = data.PEXLC.NEGO_COMM;
                        eventRow.TELEX_SWIFT = data.PEXLC.TELEX_SWIFT;
                        eventRow.COURIER_POSTAGE = data.PEXLC.COURIER_POSTAGE;
                        eventRow.STAMP_FEE = data.PEXLC.STAMP_FEE;
                        eventRow.BE_STAMP = data.PEXLC.BE_STAMP;
                        eventRow.COMM_OTHER = data.PEXLC.COMM_OTHER;
                        eventRow.HANDING_FEE = data.PEXLC.HANDING_FEE;
                        eventRow.DRAFTCOMM = data.PEXLC.DRAFTCOMM;
                        eventRow.TOTAL_CHARGE = data.PEXLC.TOTAL_CHARGE;
                        eventRow.REFUND_TAX_YN = data.PEXLC.REFUND_TAX_YN;
                        eventRow.REFUND_TAX_AMT = data.PEXLC.REFUND_TAX_AMT;
                        eventRow.TOTAL_AMOUNT = data.PEXLC.TOTAL_AMOUNT;
                        eventRow.PAYMENTTYPE = data.PEXLC.PAYMENTTYPE;
                        eventRow.NARRATIVE = data.PEXLC.NARRATIVE;
                        eventRow.ALLOCATION = data.PEXLC.ALLOCATION;
                        eventRow.DISCOUNT_CCY = data.PEXLC.DISCOUNT_CCY;
                        eventRow.DISCOUNT_RATE = data.PEXLC.DISCOUNT_RATE;
                        eventRow.DISCOUNT_AMT = data.PEXLC.DISCOUNT_AMT;
                        eventRow.CURRENT_INT_RATE = data.PEXLC.CURRENT_INT_RATE;
                        eventRow.FlagBack = data.PEXLC.FlagBack;

                        // TODO: PAYMENT

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
                        pExPaymentRow.PAYMENT_DATE = data.PEXPAYMENT.PAYMENT_DATE;
                        pExPaymentRow.EVENT_DATE = data.PEXPAYMENT.EVENT_DATE;
                        pExPaymentRow.NEGO_AMT = data.PEXPAYMENT.NEGO_AMT;
                        pExPaymentRow.LESS_AGENT = data.PEXPAYMENT.LESS_AGENT;
                        pExPaymentRow.TOT_NEGO_AMOUNT = data.PEXPAYMENT.NEGO_AMT;
                        pExPaymentRow.BANK_CHARGE_AMT = data.PEXPAYMENT.BANK_CHARGE_AMT;
                        pExPaymentRow.NET_PROCEED_CLAIM = data.PEXPAYMENT.NET_PROCEED_CLAIM;
                        pExPaymentRow.BASE_DAY = data.PEXPAYMENT.BASE_DAY;
                        pExPaymentRow.CURRENT_DIS_RATE = data.PEXPAYMENT.CURRENT_DIS_RATE;
                        pExPaymentRow.CURRENT_INT_RATE = data.PEXPAYMENT.CURRENT_INT_RATE;
                        pExPaymentRow.PaymentType = data.PEXPAYMENT.PaymentType; // F, P

                        pExPaymentRow.PAY_BY = data.PEXPAYMENT.PAY_BY;
                        pExPaymentRow.AGENT_PAY_BY = data.PEXPAYMENT.AGENT_PAY_BY;
                        pExPaymentRow.SETTLEMENT_CREDIT = data.PEXPAYMENT.SETTLEMENT_CREDIT;

                        pExPaymentRow.PARTIAL_FULL_RATE = data.PEXPAYMENT.PARTIAL_FULL_RATE;
                        pExPaymentRow.RECEIVE_PAY_AMT = data.PEXPAYMENT.RECEIVE_PAY_AMT;

                        pExPaymentRow.SIGHT_PAID_AMT = data.PEXPAYMENT.SIGHT_PAID_AMT;
                        pExPaymentRow.SIGHT_PAID_RATE = data.PEXPAYMENT.SIGHT_PAID_RATE;
                        pExPaymentRow.SIGHT_PAID_THB = data.PEXPAYMENT.SIGHT_PAID_THB;
                        pExPaymentRow.SIGHT_FORWARD = data.PEXPAYMENT.SIGHT_FORWARD;

                        pExPaymentRow.TERM_PAID_AMT = data.PEXPAYMENT.TERM_PAID_AMT;
                        pExPaymentRow.TERM_PAID_RATE = data.PEXPAYMENT.TERM_PAID_RATE;
                        pExPaymentRow.TERM_PAID_THB = data.PEXPAYMENT.TERM_PAID_THB;
                        pExPaymentRow.TERM_FORWARD = data.PEXPAYMENT.TERM_FORWARD;

                        pExPaymentRow.ParTnor_Type1 = data.PEXPAYMENT.ParTnor_Type1;
                        pExPaymentRow.ParTnor_Type2 = data.PEXPAYMENT.ParTnor_Type2;
                        pExPaymentRow.ParTnor_Type3 = data.PEXPAYMENT.ParTnor_Type3;
                        pExPaymentRow.ParTnor_Type4 = data.PEXPAYMENT.ParTnor_Type4;
                        pExPaymentRow.ParTnor_Type5 = data.PEXPAYMENT.ParTnor_Type5;
                        pExPaymentRow.ParTnor_Type6 = data.PEXPAYMENT.ParTnor_Type6;

                        pExPaymentRow.PARTIAL_AMT1 = data.PEXPAYMENT.PARTIAL_AMT1;
                        pExPaymentRow.PARTIAL_AMT2 = data.PEXPAYMENT.PARTIAL_AMT2;
                        pExPaymentRow.PARTIAL_AMT3 = data.PEXPAYMENT.PARTIAL_AMT3;
                        pExPaymentRow.PARTIAL_AMT4 = data.PEXPAYMENT.PARTIAL_AMT4;
                        pExPaymentRow.PARTIAL_AMT5 = data.PEXPAYMENT.PARTIAL_AMT5;
                        pExPaymentRow.PARTIAL_AMT6 = data.PEXPAYMENT.PARTIAL_AMT6;

                        pExPaymentRow.PARTIAL_RATE1 = data.PEXPAYMENT.PARTIAL_RATE1;
                        pExPaymentRow.PARTIAL_RATE2 = data.PEXPAYMENT.PARTIAL_RATE2;
                        pExPaymentRow.PARTIAL_RATE3 = data.PEXPAYMENT.PARTIAL_RATE3;
                        pExPaymentRow.PARTIAL_RATE4 = data.PEXPAYMENT.PARTIAL_RATE4;
                        pExPaymentRow.PARTIAL_RATE5 = data.PEXPAYMENT.PARTIAL_RATE5;
                        pExPaymentRow.PARTIAL_RATE6 = data.PEXPAYMENT.PARTIAL_RATE6;

                        pExPaymentRow.FORWARD_CONRACT_NO1 = data.PEXPAYMENT.FORWARD_CONRACT_NO1;
                        pExPaymentRow.FORWARD_CONRACT_NO2 = data.PEXPAYMENT.FORWARD_CONRACT_NO2;
                        pExPaymentRow.FORWARD_CONRACT_NO3 = data.PEXPAYMENT.FORWARD_CONRACT_NO3;
                        pExPaymentRow.FORWARD_CONRACT_NO4 = data.PEXPAYMENT.FORWARD_CONRACT_NO4;
                        pExPaymentRow.FORWARD_CONRACT_NO5 = data.PEXPAYMENT.FORWARD_CONRACT_NO5;
                        pExPaymentRow.FORWARD_CONRACT_NO6 = data.PEXPAYMENT.FORWARD_CONRACT_NO6;

                        pExPaymentRow.fb_rate = data.PEXPAYMENT.fb_rate;
                        pExPaymentRow.fb_amt = data.PEXPAYMENT.fb_amt;
                        pExPaymentRow.fb_amt_thb = data.PEXPAYMENT.fb_amt_thb;

                        if (!string.IsNullOrEmpty(data.PEXPAYMENT.fb_ccy))
                        {
                            data.PEXPAYMENT.fb_ccy = data.PEXPAYMENT.fb_ccy;
                        }

                        pExPaymentRow.int_paid_amt = data.PEXPAYMENT.int_paid_amt;
                        pExPaymentRow.int_day = data.PEXPAYMENT.int_day;
                        pExPaymentRow.int_paid_rate = data.PEXPAYMENT.int_paid_rate;
                        pExPaymentRow.int_exch_rate = data.PEXPAYMENT.int_exch_rate;
                        pExPaymentRow.int_paid_thb = data.PEXPAYMENT.int_paid_thb;

                        pExPaymentRow.Agent_amt = data.PEXPAYMENT.Agent_amt;
                        pExPaymentRow.Agent_rate = data.PEXPAYMENT.Agent_rate;
                        pExPaymentRow.Agent_thb = data.PEXPAYMENT.Agent_thb;

                        pExPaymentRow.over_paid_amt = data.PEXPAYMENT.over_paid_amt;
                        pExPaymentRow.over_paid_rate = data.PEXPAYMENT.over_paid_rate;
                        pExPaymentRow.over_paid_thb = data.PEXPAYMENT.over_paid_thb;

                        pExPaymentRow.TOTAL_NEGO_BALANCE = data.PEXPAYMENT.TOTAL_NEGO_BALANCE;
                        pExPaymentRow.TOTAL_NEGO_BAL_THB = data.PEXPAYMENT.TOTAL_NEGO_BAL_THB;

                        // TAB2

                        pExPaymentRow.Total_Charge = data.PEXPAYMENT.Total_Charge;
                        pExPaymentRow.TOTAL_DUE_TO_CUS = data.PEXPAYMENT.TOTAL_DUE_TO_CUS;
                        pExPaymentRow.TOTAL_AMOUNT = data.PEXPAYMENT.TOTAL_AMOUNT;

                        pExPaymentRow.PAYMENT_INSTRU = data.PEXPAYMENT.PAYMENT_INSTRU;
                        pExPaymentRow.Method = data.PEXPAYMENT.Method;

                        if (pExPaymentRow.PAYMENT_INSTRU == "UNPAID")
                        {
                            pExPaymentRow.Method = "";
                        }


                        pExPaymentRow.AMT_DEBIT_AC1 = data.PEXPAYMENT.AMT_DEBIT_AC1;
                        pExPaymentRow.AMT_DEBIT_AC2 = data.PEXPAYMENT.AMT_DEBIT_AC2;
                        pExPaymentRow.AMT_DEBIT_AC3 = data.PEXPAYMENT.AMT_DEBIT_AC3;

                        pExPaymentRow.AMT_CREDIT_AC1 = data.PEXPAYMENT.AMT_CREDIT_AC1;
                        pExPaymentRow.AMT_CREDIT_AC2 = data.PEXPAYMENT.AMT_CREDIT_AC2;
                        pExPaymentRow.AMT_CREDIT_AC3 = data.PEXPAYMENT.AMT_CREDIT_AC3;

                        pExPaymentRow.ACCOUNT_NO1 = data.PEXPAYMENT.ACCOUNT_NO1;
                        pExPaymentRow.ACCOUNT_NO2 = data.PEXPAYMENT.ACCOUNT_NO2;
                        pExPaymentRow.ACCOUNT_NO3 = data.PEXPAYMENT.ACCOUNT_NO3;

                        pExPaymentRow.CASH = data.PEXPAYMENT.CASH;
                        pExPaymentRow.CHEQUE_AMT = data.PEXPAYMENT.CHEQUE_AMT;
                        pExPaymentRow.CHEQUE_NO = data.PEXPAYMENT.CHEQUE_NO;
                        pExPaymentRow.CHEQUE_BK_BRN = data.PEXPAYMENT.CHEQUE_BK_BRN;

                        pExPaymentRow.PAY_TYPE = data.PEXPAYMENT.PAY_TYPE;

                        // GL

                        /*
                         If OptPaid.Value Then
                            If optIssueBankPay.Value Then
                                Dim GLEvent As String
                                If ChKWithOut.Value = 1 Then
                                    If OpFund.Value = True Then
                                        GLEvent = ""
                                    ElseIf OpIUFund.Value = True Then
                                        GLEvent = "PAYMENT-PUR-UNISB"
                                    ElseIf OpAUFund.Value = True Then
                                        GLEvent = "PAYMENT-PUR-UNAGB"
                                    End If
                                Else
                                        GLEvent = UCase(eventType)
                                End If
                                StartPEXLC TxtExLcCode.Text, mskEvenDate.Text, eventType, TmpEvent_no, GLEvent, True
                            Else
                                If ChKWithOut.Value = 1 Then
                                    If OpFund.Value = True Then
                                        GLEvent = ""
                                    ElseIf OpIUFund.Value = True Then
                                        GLEvent = "CPAYMENT-PUR-UNISB"
                                    ElseIf OpAUFund.Value = True Then
                                        GLEvent = "CPAYMENT-PUR-UNAGB"
                                    End If
                                Else
                                        GLEvent = "CPAYMENT PURCHASE"
                                End If
                                StartPEXLC TxtExLcCode.Text, mskEvenDate.Text, eventType, TmpEvent_no, GLEvent, True
                            End If
                            cSql = "Update pExlc set VOUCH_ID ='" & ImpVouch & "' " _
                                & "where EXPORT_LC_NO='" & TxtExLcCode.Text & "' and EVENT_TYPE ='" & eventType & "'  " _
                                & "and rec_status IN('P','W')  and event_no = " & TmpEvent_no & "  "
                            cn.Execute cSql
                            LbVouch.Caption = ImpVouch
                            Call PrintPostGL
                        End If
                        */
                        eventRow.VOUCH_ID = "MOCK VOUCH_ID";

                        // Commit pExlc
                        if (pExlcEvent == null)
                        {
                            // Insert
                            eventRow.EVENT_NO = targetEventNo;

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

                        // TODO

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

                        var opEvent = "";
                        if (eventRow.METHOD.Contains("DEBIT"))
                        {
                            opEvent = "DR";
                        }
                        else if (eventRow.METHOD.Contains("CREDIT"))
                        {
                            opEvent = "CR";
                        }
                        if (opEvent != "")
                        {
                            /*
                             Req1PSys = Send1PTxn(txtBeneCode.Text, TxtExLcCode.Text, OPSeqNo, "EXLC", op_event, _
                                txtAcctNo(1).Text, txtAmtDebt(1).Text, _
                                txtAcctNo(2).Text, txtAmtDebt(2).Text, _
                                txtAcctNo(3).Text, txtAmtDebt(3).Text)
                                If Req1PSys = False Then
                                    cSql = "Update pExlc set   REC_STATUS ='W'   where EXPORT_LC_NO='" & TxtExLcCode.Text & "' " _
                                           & "and record_type='EVENT' and Event_No =" & OPSeqNo & ""
                                    cn.Execute cSql
                                    framRelease.Visible = False
                                    CmdDel.Enabled = True
                                    CmdSave.Enabled = False
                                    CmdPrint.Enabled = False
                                     CmdExit.Enabled = True: SSTab1.Enabled = True
                                    TxtExLcCode.Enabled = True: cmdFndLC.Enabled = True
                                    Exit Sub
                                End If
                            */
                    }


                        // 4 - Update Master
                    pExlcMaster.AUTH_CODE = USER_ID;
                        pExlcMaster.AUTH_DATE = DateTime.Now; // With Time
                        pExlcMaster.UPDATE_DATE = DateTime.Now; // With Time



                        await _context.SaveChangesAsync();

                        // 5 - Update Master/Event PK to Release
                        await _context.Database.ExecuteSqlRawAsync($"UPDATE pExlc SET REC_STATUS = 'R' WHERE EXPORT_LC_NO = '{data.PEXLC.EXPORT_LC_NO}' AND RECORD_TYPE='MASTER'");


                        /*
                         * FRONT OR BACK LOGIC
                         If Duplicate = True Then
                            If ChkReleaseMaster("EXLC", Trim(TxtExLcCode.Text)) = True Then CmdDel.Enabled = False: framRelease.Visible = False: CmdSave.Enabled = False: Exit Sub
                         End If
                         */

                        // 6 - Update GL Flag
                        var gls = (from row in _context.pDailyGLs
                                   where row.VouchID == data.PEXLC.VOUCH_ID &&
                                            row.VouchDate == data.PEXLC.EVENT_DATE.GetValueOrDefault().Date
                                   select row).ToListAsync();

                        foreach (var row in await gls)
                        {
                            row.SendFlag = "R";
                        }


                        if (data.PEXLC.WithOutFlag == "N")
                        {
                            var result = await ExportLCHelper.UpdateCustomerLiability(_context, data.PEXLC);
                        }
                        else if (data.PEXLC.WithOutFlag == "Y")
                        {
                            var result = await ExportLCHelper.UpdateBankLiability(_context, data.PEXLC);
                        }

                        transaction.Complete();




                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Export L/C Released";
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




                        // 3 - Cancel PExPayment
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
