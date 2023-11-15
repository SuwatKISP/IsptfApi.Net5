using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.DomesticLC;
using ISPTF.Models.ImportLC;
using ISPTF.Models.PackingCredit;
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

namespace ISPTF.API.Controllers.DomesticLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DMLCFormBEPaymentController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        //private const string BUSINESS_TYPE = "4";
        //private const string EVENT_TYPE = "Accept Due";

        public DMLCFormBEPaymentController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }


        [HttpGet("select")]
        public async Task<ActionResult<Q_DMLC_PaymentDBE_Select_Response>> NewSelect(string? ListType, string? LoadPay, string? BENumber, int? BESeqno, string? RecType, string? Event, string? RecStatus, string? BECcy, string? CustCode, string? UserCode)
        {
            Q_DMLC_PaymentDBE_Select_Response response = new Q_DMLC_PaymentDBE_Select_Response();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(LoadPay))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, LoadPay is required";
                response.Data = new Q_DMLC_PaymentDBE_Select_JSON_rsp();
                return BadRequest(response);
            }
            if (LoadPay != "PAYMENT" && LoadPay != "PAY-OVERDUE")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LoadLC shoud be PAYMENT, PAY-OVERDUE ";
                response.Data = new Q_DMLC_PaymentDBE_Select_JSON_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@LoadPay", LoadPay);
                param.Add("@BENumber", BENumber);
                param.Add("@BESeqno", BESeqno);
                param.Add("@RecType", RecType);
                param.Add("@Event", Event);
                param.Add("@RecStatus", RecStatus);
                param.Add("@BECcy", BECcy);
                param.Add("@CustCode", CustCode);
                param.Add("@UserCode", USER_ID);

                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@PaymentResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_DMLC_PaymentDBE_Select_JSON_rsp, dynamic>(
                            storedProcedure: "[usp_q_DMLC_PaymentBillsSelect]",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var PaymentResp = param.Get<dynamic>("@PaymentResp");

                if (Resp == 1)
                {
                    Q_DMLC_PaymentDBE_Select_JSON_rsp jsonResponse = JsonSerializer.Deserialize<Q_DMLC_PaymentDBE_Select_JSON_rsp>(PaymentResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_DMLC_PaymentDBE_Select_JSON_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_DMLC_PaymentDBE_Select_JSON_rsp();
                return BadRequest(response);
            }
        }


        [HttpHead("Remark1/1.For Select Menu Payment Drawn Bills ")]
        [HttpHead("Remark2/2.For Select Menu Payment OverDue Bills")]
        [HttpHead("Remark3/3.ListType = NEW, EDIT, RELEASE")]
        [HttpHead("Remark4/4.LoadPay for PAYMENT , PAY-OVERDUE ")]
        public async Task<ActionResult<IMLCResultResponse>> Remark([FromBody] IMLC_RemarkAmend_JSON_req save)
        {
            IMLCResultResponse response = new();
            var USER_ID = User.Identity.Name;
            // Class validate

            try
            {
                DynamicParameters param = new DynamicParameters();
                ////ListType
                //await _db.SaveData(
                //  storedProcedure: "usp_pIMLC_Amend_Release", param);
                var resp = param.Get<int>("@Resp");

                if (resp > 0)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                return BadRequest(response);
            }
        }

        [HttpPost("save")]
        public async Task<ActionResult<DMLC_SavePaymentDBE_Response>> Save([FromBody] DMLC_SavePaymentDBE_JSON_req save)
        {
            DMLC_SavePaymentDBE_Response response = new();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
            // Class validate
            if (string.IsNullOrEmpty(save.ListType.ListType) || string.IsNullOrEmpty(save.ListType.LoadPay))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType , LoadPay is required";
                response.Data = new DMLC_SavePaymentDBE_JSON_rsp();
                return BadRequest(response);
            }
            if (save.ListType.LoadPay != "PAYMENT" && save.ListType.LoadPay != "PAY-OVERDUE")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType should be BEISSUE, BEREVERSE";
                response.Data = new DMLC_SavePaymentDBE_JSON_rsp();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new DynamicParameters();

                //ListType
                param.Add("@ListType", save.ListType.ListType);
                param.Add("@LoadPay", save.ListType.LoadPay);
                param.Add("@txTotalPaid", save.ListType.txTotalPaid);
                param.Add("@TxPrinciple", save.ListType.TxPrinciple);
                param.Add("@TxInterest", save.ListType.TxInterest);
                param.Add("@TxAccInt", save.ListType.TxAccInt);
                param.Add("@TxNewInt", save.ListType.TxNewInt);

                //pDOMBE
                param.Add("@BENumber", save.pDOMBE.BENumber);
                param.Add("@RecType", save.pDOMBE.RecType);
                param.Add("@BESeqno", save.pDOMBE.BESeqno);
                param.Add("@BEStatus", save.pDOMBE.BEStatus);
                param.Add("@RecStatus", save.pDOMBE.RecStatus);
                param.Add("@EventMode", save.pDOMBE.EventMode);
                param.Add("@Event", save.pDOMBE.Event);
                param.Add("@EventDate", save.pDOMBE.EventDate);
                param.Add("@EventFlag", save.pDOMBE.EventFlag);
                param.Add("@AutoOverDue", save.pDOMBE.AutoOverDue);
                param.Add("@OverdueDate", save.pDOMBE.OverdueDate);
                param.Add("@BEOverDue", save.pDOMBE.BEOverDue);
                param.Add("@DLCNumber", save.pDOMBE.DLCNumber);
                param.Add("@DocCCy", save.pDOMBE.DocCCy);
                param.Add("@DLCAmt", save.pDOMBE.DLCAmt);
                param.Add("@CustCode", save.pDOMBE.CustCode);
                param.Add("@CustAddr", save.pDOMBE.CustAddr);
                param.Add("@BenInfo", save.pDOMBE.BenInfo);
                param.Add("@BenCnty", save.pDOMBE.BenCnty);
                param.Add("@AdviceDisc", save.pDOMBE.AdviceDisc);
                param.Add("@AdviceResult", save.pDOMBE.AdviceResult);
                param.Add("@ReferBE", save.pDOMBE.ReferBE);
                param.Add("@TenorType", save.pDOMBE.TenorType);
                param.Add("@TenorDay", save.pDOMBE.TenorDay);
                param.Add("@TenorTerm", save.pDOMBE.TenorTerm);
                param.Add("@NegoDate", save.pDOMBE.NegoDate);
                param.Add("@ValueDate", save.pDOMBE.ValueDate);
                param.Add("@BECcy", save.pDOMBE.BECcy);
                param.Add("@BEAmount", save.pDOMBE.BEAmount);
                param.Add("@BEBalance", save.pDOMBE.BEBalance);
                param.Add("@BEOverDrawn", save.pDOMBE.BEOverDrawn);
                param.Add("@StartDate", save.pDOMBE.StartDate);
                param.Add("@DueDate", save.pDOMBE.DueDate);
                param.Add("@PrevDueDate", save.pDOMBE.PrevDueDate);
                param.Add("@IntBefore", save.pDOMBE.IntBefore);
                param.Add("@ExchBefore", save.pDOMBE.ExchBefore);
                param.Add("@IntRateCode", save.pDOMBE.IntRateCode);
                param.Add("@IntRate", save.pDOMBE.IntRate);
                param.Add("@IntSpread", save.pDOMBE.IntSpread);
                param.Add("@IntFlag", save.pDOMBE.IntFlag);
                param.Add("@IntBaseDay", save.pDOMBE.IntBaseDay);
                param.Add("@IntStartDate", save.pDOMBE.IntStartDate);
                param.Add("@LastIntDate", save.pDOMBE.LastIntDate);
                param.Add("@LastIntAmt", save.pDOMBE.LastIntAmt);
                param.Add("@IntBalance", save.pDOMBE.IntBalance);
                param.Add("@ExchRate", save.pDOMBE.ExchRate);
                param.Add("@ChkDeduct", save.pDOMBE.ChkDeduct);
                param.Add("@OverAmt", save.pDOMBE.OverAmt);
                param.Add("@NegoAmt", save.pDOMBE.NegoAmt);
                param.Add("@CableAmt", save.pDOMBE.CableAmt);
                param.Add("@PostageAmt", save.pDOMBE.PostageAmt);
                param.Add("@DutyAmt", save.pDOMBE.DutyAmt);
                param.Add("@PayableAmt", save.pDOMBE.PayableAmt);
                param.Add("@CommOther", save.pDOMBE.CommOther);
                param.Add("@CommTran", save.pDOMBE.CommTran);
                param.Add("@CommCertify", save.pDOMBE.CommCertify);
                param.Add("@CommEngage", save.pDOMBE.CommEngage);
                param.Add("@Discfee", save.pDOMBE.Discfee);
                param.Add("@TaxRefund", save.pDOMBE.TaxRefund);
                param.Add("@TaxAmt", save.pDOMBE.TaxAmt);
                param.Add("@CommDesc", save.pDOMBE.CommDesc);
                param.Add("@PaymentFlag", save.pDOMBE.PaymentFlag);
                param.Add("@PayBalance", save.pDOMBE.PayBalance);
                param.Add("@PayInterest", save.pDOMBE.PayInterest);
                param.Add("@PayFlag", save.pDOMBE.PayFlag);
                param.Add("@PayMethod", save.pDOMBE.PayMethod);
                param.Add("@Allocation", save.pDOMBE.Allocation);
                param.Add("@DateLastPaid", save.pDOMBE.DateLastPaid);
                param.Add("@LastReceiptNo", save.pDOMBE.LastReceiptNo);
                param.Add("@FCYReceiptNo", save.pDOMBE.FCYReceiptNo);
                param.Add("@AppvNo", save.pDOMBE.AppvNo);
                param.Add("@FacNo", save.pDOMBE.FacNo);
                //param.Add("@UpdateDate", save.pDOMBE.UpdateDate);
                param.Add("@UserCode", USER_ID);
                //param.Add("@AuthDate", save.pDOMBE.AuthDate);
                //param.Add("@AuthCode", save.pDOMBE.AuthCode);
                param.Add("@GenAccFlag", save.pDOMBE.GenAccFlag);
                param.Add("@DateGenAc", save.pDOMBE.DateGenAc);
                param.Add("@VoucherID", save.pDOMBE.VoucherID);
                param.Add("@TotalAccruAmt", save.pDOMBE.TotalAccruAmt);
                param.Add("@TotalAccruBht", save.pDOMBE.TotalAccruBht);
                param.Add("@AccruAmt", save.pDOMBE.AccruAmt);
                param.Add("@AccruBht", save.pDOMBE.AccruBht);
                param.Add("@DateLastAccru", save.pDOMBE.DateLastAccru);
                param.Add("@PastDueDate", save.pDOMBE.PastDueDate);
                param.Add("@PastDueFlag", save.pDOMBE.PastDueFlag);
                param.Add("@TotalSuspAmt", save.pDOMBE.TotalSuspAmt);
                param.Add("@TotalSuspBht", save.pDOMBE.TotalSuspBht);
                param.Add("@SuspAmt", save.pDOMBE.SuspAmt);
                param.Add("@SuspBht", save.pDOMBE.SuspBht);
                param.Add("@DateToStop", save.pDOMBE.DateToStop);
                param.Add("@DateStartAccru", save.pDOMBE.DateStartAccru);
                param.Add("@LastAccruCcy", save.pDOMBE.LastAccruCcy);
                param.Add("@LastAccruAmt", save.pDOMBE.LastAccruAmt);
                param.Add("@NewAccruCcy", save.pDOMBE.NewAccruCcy);
                param.Add("@NewAccruAmt", save.pDOMBE.NewAccruAmt);
                param.Add("@AccruCCy", save.pDOMBE.AccruCCy);
                param.Add("@AccruAmt1", save.pDOMBE.AccruAmt1);
                param.Add("@DAccruAmt", save.pDOMBE.DAccruAmt);
                param.Add("@PAccruAmt", save.pDOMBE.PAccruAmt);
                param.Add("@AccruPending", save.pDOMBE.AccruPending);
                param.Add("@DMS", save.pDOMBE.DMS);
                param.Add("@Discrepancy", save.pDOMBE.Discrepancy);
                param.Add("@Instruction", save.pDOMBE.Instruction);
                param.Add("@TRFlag", save.pDOMBE.TRFlag);
                param.Add("@CenterID", USER_CENTER_ID);
                param.Add("@CCS_ACCT", save.pDOMBE.CCS_ACCT);
                param.Add("@CCS_LmType", save.pDOMBE.CCS_LmType);
                param.Add("@CCS_CNUM", save.pDOMBE.CCS_CNUM);
                param.Add("@CCS_CIFRef", save.pDOMBE.CCS_CIFRef);
                param.Add("@SwFlag", save.pDOMBE.SwFlag);
                param.Add("@Pending_Payable", save.pDOMBE.Pending_Payable);
                param.Add("@BPOFlag", save.pDOMBE.BPOFlag);
                param.Add("@Campaign_Code", save.pDOMBE.Campaign_Code);
                param.Add("@Campaign_EffDate", save.pDOMBE.Campaign_EffDate);


                //pPayment
                //param.Add("@RpReceiptNo", save.pPayment.RpReceiptNo);
                //param.Add("@RpModule", save.pPayment.RpModule);
                //param.Add("@RpEvent", save.pPayment.RpEvent);
                //param.Add("@RpDocNo", save.pPayment.RpDocNo);
                //param.Add("@RpCustCode", save.pPayment.RpCustCode);
                //param.Add("@RpPayDate", save.pPayment.RpPayDate);
                //param.Add("@RpPayBy", save.pPayment.RpPayBy);
                //param.Add("@RpNote", save.pPayment.RpNote);
                param.Add("@RpCashAmt", save.pPayment.RpCashAmt);
                param.Add("@RpChqAmt", save.pPayment.RpChqAmt);
                param.Add("@RpChqNo", save.pPayment.RpChqNo);
                param.Add("@RpChqBank", save.pPayment.RpChqBank);
                param.Add("@RpChqBranch", save.pPayment.RpChqBranch);
                param.Add("@RpCustAc1", save.pPayment.RpCustAc1);
                param.Add("@RpCustAmt1", save.pPayment.RpCustAmt1);
                param.Add("@RpCustAc2", save.pPayment.RpCustAc2);
                param.Add("@RpCustAmt2", save.pPayment.RpCustAmt2);
                param.Add("@RpCustAc3", save.pPayment.RpCustAc3);
                param.Add("@RpCustAmt3", save.pPayment.RpCustAmt3);
                //param.Add("@RpRefer1", save.pPayment.RpRefer1);
                //param.Add("@RpRefer2", save.pPayment.RpRefer2);
                //param.Add("@RpApplicant", save.pPayment.RpApplicant);
                //param.Add("@RpIssBank", save.pPayment.RpIssBank);
                //param.Add("@RpStatus", save.pPayment.RpStatus);
                //param.Add("@RpRecStatus", save.pPayment.RpRecStatus);
                //param.Add("@RpPrint", save.pPayment.RpPrint);
                //param.Add("@UserCode", save.pPayment.UserCode);
                //param.Add("@UpdateDate", save.pPayment.UpdateDate);
                //param.Add("@AuthCode", save.pPayment.AuthCode);
                //param.Add("@AuthDate", save.pPayment.AuthDate);

                //pSWImport
                param.Add("@Login", save.pSWImport.Login);
                param.Add("@DocNumber", save.pSWImport.DocNumber);
                param.Add("@Seqno", save.pSWImport.Seqno);
                //param.Add("@RefNumber", save.pSWImport.RefNumber);
                param.Add("@RemitCcy", save.pSWImport.RemitCcy);
                param.Add("@RemitAmt", save.pSWImport.RemitAmt);
                param.Add("@DeductAmt", save.pSWImport.DeductAmt);
                param.Add("@ChargeAmt", save.pSWImport.ChargeAmt);
                param.Add("@Amt71", save.pSWImport.Amt71);
                //param.Add("@ValueDate", save.pSWImport.ValueDate);
                param.Add("@SwiftFile", save.pSWImport.SwiftFile);
                param.Add("@MT103", save.pSWImport.MT103);
                param.Add("@MT202", save.pSWImport.MT202);
                param.Add("@MT734", save.pSWImport.MT734);
                param.Add("@MT752", save.pSWImport.MT752);
                param.Add("@MT754", save.pSWImport.MT754);
                param.Add("@MT756", save.pSWImport.MT756);
                param.Add("@MT799", save.pSWImport.MT799);
                param.Add("@MT999", save.pSWImport.MT999);
                param.Add("@MT412", save.pSWImport.MT412);
                param.Add("@MT499", save.pSWImport.MT499);
                param.Add("@MT202Cov", save.pSWImport.MT202Cov);
                param.Add("@MT400", save.pSWImport.MT400);
                param.Add("@BNet", save.pSWImport.BNet);
                param.Add("@ToNego", save.pSWImport.ToNego);
                param.Add("@ToName", save.pSWImport.ToName);
                param.Add("@ToRefer", save.pSWImport.ToRefer);
                param.Add("@ToBank", save.pSWImport.ToBank);
                param.Add("@ToWhom", save.pSWImport.ToWhom);
                param.Add("@F20", save.pSWImport.F20);
                param.Add("@F20_X", save.pSWImport.F20_X);
                param.Add("@F21", save.pSWImport.F21);
                param.Add("@F21_X", save.pSWImport.F21_X);
                param.Add("@F23", save.pSWImport.F23);
                param.Add("@F23_X", save.pSWImport.F23_X);
                param.Add("@F26", save.pSWImport.F26);
                param.Add("@F30", save.pSWImport.F30);
                param.Add("@F32A", save.pSWImport.F32A);
                param.Add("@F32B", save.pSWImport.F32B);
                param.Add("@F33A", save.pSWImport.F33A);
                param.Add("@F33B", save.pSWImport.F33B);
                param.Add("@F34A", save.pSWImport.F34A);
                param.Add("@F50K", save.pSWImport.F50K);
                param.Add("@F59", save.pSWImport.F59);
                param.Add("@F70", save.pSWImport.F70);
                param.Add("@F71A", save.pSWImport.F71A);
                param.Add("@F71F", save.pSWImport.F71F);
                param.Add("@F52A", save.pSWImport.F52A);
                param.Add("@F52D", save.pSWImport.F52D);
                param.Add("@F53A", save.pSWImport.F53A);
                param.Add("@F53B", save.pSWImport.F53B);
                param.Add("@F53D", save.pSWImport.F53D);
                param.Add("@F53UID", save.pSWImport.F53UID);
                param.Add("@F54A", save.pSWImport.F54A);
                param.Add("@F54D", save.pSWImport.F54D);
                param.Add("@F54UID", save.pSWImport.F54UID);
                param.Add("@F56A", save.pSWImport.F56A);
                param.Add("@F56D", save.pSWImport.F56D);
                param.Add("@F56UID", save.pSWImport.F56UID);
                param.Add("@F57A", save.pSWImport.F57A);
                param.Add("@F57D", save.pSWImport.F57D);
                param.Add("@F57UID", save.pSWImport.F57UID);
                param.Add("@F58A", save.pSWImport.F58A);
                param.Add("@F58D", save.pSWImport.F58D);
                param.Add("@F58UID", save.pSWImport.F58UID);
                param.Add("@F71B", save.pSWImport.F71B);
                param.Add("@F72", save.pSWImport.F72);
                param.Add("@F72_X", save.pSWImport.F72_X);
                param.Add("@F73", save.pSWImport.F73);
                param.Add("@F79", save.pSWImport.F79);
                param.Add("@F79_X", save.pSWImport.F79_X);
                param.Add("@F77A", save.pSWImport.F77A);
                param.Add("@F77B", save.pSWImport.F77B);
                param.Add("@F77J", save.pSWImport.F77J);
                param.Add("@F53A_X", save.pSWImport.F53A_X);
                param.Add("@F53B_X", save.pSWImport.F53B_X);
                param.Add("@F53D_X", save.pSWImport.F53D_X);
                param.Add("@F53UID_X", save.pSWImport.F53UID_X);
                param.Add("@F54A_X", save.pSWImport.F54A_X);
                param.Add("@F54D_X", save.pSWImport.F54D_X);
                param.Add("@F54UID_X", save.pSWImport.F54UID_X);
                param.Add("@F72103", save.pSWImport.F72103);
                param.Add("@Flag32", save.pSWImport.Flag32);
                param.Add("@Detail32", save.pSWImport.Detail32);
                param.Add("@F21_B", save.pSWImport.F21_B);
                param.Add("@F21_C", save.pSWImport.F21_C);
                param.Add("@MT199", save.pSWImport.MT199);
                param.Add("@CF50", save.pSWImport.CF50);
                param.Add("@CF59", save.pSWImport.CF59);
                param.Add("@F79_Z", save.pSWImport.F79_Z);
                param.Add("@SWUuid", save.pSWImport.SWUuid);

                //pIMPayment
                param.Add("@DocNumber", save.pIMPayment.DocNumber);
                param.Add("@DocSeqno", save.pIMPayment.DocSeqno);
                //param.Add("@RecStatus", save.pIMPayment.RecStatus);
                param.Add("@PayMode", save.pIMPayment.PayMode);
                //param.Add("@PayFlag", save.pIMPayment.PayFlag);
                param.Add("@BalanceAmt", save.pIMPayment.BalanceAmt);
                param.Add("@InterestAmt", save.pIMPayment.InterestAmt);
                param.Add("@InterestBL", save.pIMPayment.InterestBL);
                param.Add("@PaymentDate", save.pIMPayment.PaymentDate);
                param.Add("@PayCcyAmt", save.pIMPayment.PayCcyAmt);
                param.Add("@PayCcyInt", save.pIMPayment.PayCcyInt);
                param.Add("@PayFCD", save.pIMPayment.PayFCD);
                param.Add("@PayAmtBht1", save.pIMPayment.PayAmtBht1);
                param.Add("@PayExch1", save.pIMPayment.PayExch1);
                param.Add("@PayBaht1", save.pIMPayment.PayBaht1);
                param.Add("@FwdCont", save.pIMPayment.FwdCont);
                param.Add("@PayAmtBht2", save.pIMPayment.PayAmtBht2);
                param.Add("@PayExch2", save.pIMPayment.PayExch2);
                param.Add("@PayBaht2", save.pIMPayment.PayBaht2);
                param.Add("@FwdCont2", save.pIMPayment.FwdCont2);
                param.Add("@PayAmtBht3", save.pIMPayment.PayAmtBht3);
                param.Add("@PayExch3", save.pIMPayment.PayExch3);
                param.Add("@PayBaht3", save.pIMPayment.PayBaht3);
                param.Add("@FwdCont3", save.pIMPayment.FwdCont3);
                param.Add("@PayAmtBht4", save.pIMPayment.PayAmtBht4);
                param.Add("@PayExch4", save.pIMPayment.PayExch4);
                param.Add("@PayBaht4", save.pIMPayment.PayBaht4);
                param.Add("@FwdCont4", save.pIMPayment.FwdCont4);
                param.Add("@PayAmtBht5", save.pIMPayment.PayAmtBht5);
                param.Add("@PayExch5", save.pIMPayment.PayExch5);
                param.Add("@PayBaht5", save.pIMPayment.PayBaht5);
                param.Add("@FwdCont5", save.pIMPayment.FwdCont5);
                param.Add("@PayAmtBht6", save.pIMPayment.PayAmtBht6);
                param.Add("@PayExch6", save.pIMPayment.PayExch6);
                param.Add("@PayBaht6", save.pIMPayment.PayBaht6);
                param.Add("@FwdCont6", save.pIMPayment.FwdCont6);
                param.Add("@PayIntBht1", save.pIMPayment.PayIntBht1);
                param.Add("@PayIntExch1", save.pIMPayment.PayIntExch1);
                param.Add("@PayIntBaht1", save.pIMPayment.PayIntBaht1);
                param.Add("@FwdContInt1", save.pIMPayment.FwdContInt1);
                param.Add("@PayIntBht2", save.pIMPayment.PayIntBht2);
                param.Add("@PayIntExch2", save.pIMPayment.PayIntExch2);
                param.Add("@PayIntBaht2", save.pIMPayment.PayIntBaht2);
                param.Add("@FwdContInt2", save.pIMPayment.FwdContInt2);
                //param.Add("@CenterID", save.pIMPayment.CenterID);
                //param.Add("@TRDueStatus", save.pIMPayment.TRDueStatus);
                //param.Add("@OverDueDate", save.pIMPayment.OverDueDate);
                //param.Add("@PastdueDate", save.pIMPayment.PastdueDate);
                //param.Add("@DateStartAccru", save.pIMPayment.DateStartAccru);
                //param.Add("@DateLastAccru", save.pIMPayment.DateLastAccru);
                //param.Add("@DateToStop", save.pIMPayment.DateToStop);
                //param.Add("@LastAccruCcy", save.pIMPayment.LastAccruCcy);
                //param.Add("@LastAccruAmt", save.pIMPayment.LastAccruAmt);
                param.Add("@LastAccruBht", save.pIMPayment.LastAccruBht);
                //param.Add("@NewAccruCcy", save.pIMPayment.NewAccruCcy);
                //param.Add("@NewAccruAmt", save.pIMPayment.NewAccruAmt);
                param.Add("@NewAccruBht", save.pIMPayment.NewAccruBht);
                //param.Add("@AccruCCy", save.pIMPayment.AccruCCy);
                //param.Add("@AccruAmt", save.pIMPayment.AccruAmt);
                //param.Add("@AccruBht", save.pIMPayment.AccruBht);
                //param.Add("@DAccruAmt", save.pIMPayment.DAccruAmt);
                //param.Add("@PAccruAmt", save.pIMPayment.PAccruAmt);
                //param.Add("@AccruPending", save.pIMPayment.AccruPending);
                //param.Add("@RevAccru", save.pIMPayment.RevAccru);



                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@SaveResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<DMLC_SavePaymentDBE_JSON_rsp, dynamic>(
                    storedProcedure: "usp_pDOMBE_BEPayment_Save",
                    param);

                var Resp = param.Get<int>("@Resp");
                var SaveResp = param.Get<dynamic>("@SaveResp");

                //var Resp = param.Get<int>("@Resp");
                if (Resp > 0)
                {
                    DMLC_SavePaymentDBE_JSON_rsp jsonResponse = JsonSerializer.Deserialize<DMLC_SavePaymentDBE_JSON_rsp>(SaveResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Save Error";
                    response.Data = new DMLC_SavePaymentDBE_JSON_rsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new DMLC_SavePaymentDBE_JSON_rsp();
                return BadRequest(response);
            }

        }


        [HttpPost("release")]
        public async Task<ActionResult<DMLCResultResponse>> release([FromBody] DMLC_ReleasePaymentDBE_JSON_req release)
        {
            DMLCResultResponse response = new();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
            // Class validate
            //if (string.IsNullOrEmpty(save.ListType.ListType) || string.IsNullOrEmpty(save.ListType.LoadPay))
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType , LoadPay is required";
            //    return BadRequest(response);
            //}
            //if (save.ListType.LoadPay != "PAYMENT" && save.ListType.LoadPay != "PAY-OVERDUE")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be BEISSUE, BEREVERSE";
            //    return BadRequest(response);
            //}

                DynamicParameters param = new DynamicParameters();

                //ListType
                param.Add("@ListType", release.ListType.ListType);
                param.Add("@LoadPay", release.ListType.LoadPay);
                param.Add("@TxNewInt", release.ListType.TxNewInt);
                param.Add("@TxIntAmt", release.ListType.TxIntAmt);
                param.Add("@TxIntPay", release.ListType.TxIntPay);
                param.Add("@TxAccInt", release.ListType.TxAccInt);
                param.Add("@MaskStopDate", release.ListType.TxNewInt);

                //pDOMBE
                param.Add("@BENumber", release.pDOMBE.BENumber);
                param.Add("@RecType", release.pDOMBE.RecType);
                param.Add("@BESeqno", release.pDOMBE.BESeqno);
                param.Add("@BEStatus", release.pDOMBE.BEStatus);
                param.Add("@RecStatus", release.pDOMBE.RecStatus);
                param.Add("@BECcy", release.pDOMBE.BECcy);
                param.Add("@Event", release.pDOMBE.Event);
                param.Add("@EventDate", release.pDOMBE.EventDate);
                param.Add("@ExchBefore", release.pDOMBE.ExchBefore);
                param.Add("@IntStartDate", release.pDOMBE.IntStartDate);
                param.Add("@OverAmt", release.pDOMBE.OverAmt);
                param.Add("@NegoAmt", release.pDOMBE.NegoAmt);
                param.Add("@CableAmt", release.pDOMBE.CableAmt);
                param.Add("@DutyAmt", release.pDOMBE.DutyAmt);
                param.Add("@PayableAmt", release.pDOMBE.PayableAmt);
                param.Add("@CommOther", release.pDOMBE.CommOther);
                param.Add("@CommTran", release.pDOMBE.CommTran);
                param.Add("@CommCertify", release.pDOMBE.CommCertify);
                param.Add("@CommEngage", release.pDOMBE.CommEngage);
                param.Add("@Discfee", release.pDOMBE.Discfee);
                param.Add("@TaxAmt", release.pDOMBE.TaxAmt);
                param.Add("@PayBalance", release.pDOMBE.PayBalance);
                param.Add("@PayInterest", release.pDOMBE.PayInterest);
                param.Add("@PayFlag", release.pDOMBE.PayFlag);
                param.Add("@PayMethod", release.pDOMBE.PayMethod);
                param.Add("@LastReceiptNo", release.pDOMBE.LastReceiptNo);
                param.Add("@UserCode", USER_ID);
                param.Add("@CenterID", USER_CENTER_ID);
                //param.Add("@", release.pDOMBE.);


                //pIMPayment
                param.Add("@PayMode", release.pIMPayment.PayMode);
                param.Add("@PaymentDate", release.pIMPayment.PaymentDate);

                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                try
                {
                    await _db.SaveData(
                      storedProcedure: "usp_pDOMBE_BEPayment_Release", param);
                    var resp = param.Get<int>("@Resp");

                    if (resp > 0)
                    {
                        response.Code = Constants.RESPONSE_OK;
                        response.Message = "Release Complete";
                        return Ok(response);
                    }
                    else
                    {
                        response.Code = Constants.RESPONSE_ERROR;
                        try
                        {
                            response.Message = resp.ToString();
                        }
                        catch (Exception)
                        {
                            response.Message = "Release Error";
                        }
                        return BadRequest(response);
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
        public async Task<ActionResult<DMLCResultResponse>> delete([FromBody] DMLC_DeletePaymentDBE_JSON_req release)
        {
            DMLCResultResponse response = new();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
            // Class validate
            //if (string.IsNullOrEmpty(save.ListType.ListType) || string.IsNullOrEmpty(save.ListType.LoadPay))
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType , LoadPay is required";
            //    return BadRequest(response);
            //}
            //if (save.ListType.LoadPay != "PAYMENT" && save.ListType.LoadPay != "PAY-OVERDUE")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be BEISSUE, BEREVERSE";
            //    return BadRequest(response);
            //}

            DynamicParameters param = new DynamicParameters();

            //ListType
            //param.Add("@ListType", release.ListType.ListType);
            //param.Add("@LoadPay", release.ListType.LoadPay);

            //pDOMBE
            param.Add("@BENumber", release.pDOMBE.BENumber);
            param.Add("@BESeqno", release.pDOMBE.BESeqno);
            param.Add("@UserCode", USER_ID);
            param.Add("@CenterID", USER_CENTER_ID);
            //param.Add("@", release.pDOMBE.);

            param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pDOMBE_BEPayment_Delete", param);
                var resp = param.Get<int>("@Resp");

                if (resp > 0)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Delete Complete";
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    try
                    {
                        response.Message = resp.ToString();
                    }
                    catch (Exception)
                    {
                        response.Message = "Delete Error";
                    }
                    return BadRequest(response);
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
