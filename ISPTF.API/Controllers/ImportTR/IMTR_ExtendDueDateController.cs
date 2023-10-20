using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.Inquiry;
using ISPTF.Models.ImportTR;
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


using ISPTF.Models.ExportLC;
namespace ISPTF.API.Controllers.ImportTR
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IMTR_ExtendDueDateController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public IMTR_ExtendDueDateController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("listpage")]
        public async Task<ActionResult<Q_IMTR_ListPage_Response>> ListPage(string? ListType, string CustCode,string? CustName,string? TRNumber ,string? CenterID, string? Page, string? PageSize)
        {
            Q_IMTR_ListPage_Response response = new Q_IMTR_ListPage_Response();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType,CenterID, Page, PageSize is required";
                response.Data = new List<Q_IMTR_ListPage_rsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_IMTR_ListPage_rsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@TRNumber", TRNumber);
                param.Add("@CenterID", CenterID);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }
                if (TRNumber == null)
                {
                    param.Add("@TRNumber", "");
                }

                var results = await _db.LoadData<Q_IMTR_ListPage_rsp, dynamic>(
                            storedProcedure: "usp_q_IMTR_ExtendDueDateListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IMTR_ListPage_rsp>)results;

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
                response.Data = new List<Q_IMTR_ListPage_rsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("Select")]
        public async Task<ActionResult<Q_IMTR_ExtendDueDateSelect_Response>> Select(string? ListType, string? CustCode, string? RefNumber, string? TRSeqno, string? RecType, string? Event)
        {
            Q_IMTR_ExtendDueDateSelect_Response response = new Q_IMTR_ExtendDueDateSelect_Response();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(CustCode) || string.IsNullOrEmpty(RefNumber) || string.IsNullOrEmpty(TRSeqno) ||
                string.IsNullOrEmpty(RecType) || string.IsNullOrEmpty(Event))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CustCode, RefNumber, TRSeqno, RecType, Event are required";
                response.Data = new Q_IMTR_ExtendDueDateSelect_JSON_rsp();
                return BadRequest(response);
            }
            if (ListType != "NEW" && ListType != "EDIT")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType = NEW or EDIT only";
                response.Data = new Q_IMTR_ExtendDueDateSelect_JSON_rsp();
                return BadRequest(response);
            }
            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CustCode", CustCode);
                param.Add("@RefNumber", RefNumber);
                param.Add("@TRSeqno", TRSeqno);
                param.Add("@RecType", RecType);
                param.Add("@Event", Event);

                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@ExtendedDueDateResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_IMTR_ExtendDueDateSelect_JSON_rsp, dynamic>(
                            storedProcedure: "usp_Q_IMTR_ExtendedDueDateListSelect",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var ExtendedDueDateResp = param.Get<dynamic>("@ExtendedDueDateResp");

                if (Resp == 1)
                {
                    Q_IMTR_ExtendDueDateSelect_JSON_rsp jsonResponse = JsonSerializer.Deserialize<Q_IMTR_ExtendDueDateSelect_JSON_rsp>(ExtendedDueDateResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_IMTR_ExtendDueDateSelect_JSON_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_IMTR_ExtendDueDateSelect_JSON_rsp();
                return BadRequest(response);
            }
        }

        [HttpPost("save")]
        public async Task<ActionResult<IMTR_SaveExtendDueDate_Response>> Save([FromBody] IMTR_SaveExtendDueDate_JSON_req save)
        {
            IMTR_SaveExtendDueDate_Response response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            if (save.ListType.ListType != "NEW" && save.ListType.ListType != "EDIT")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType should be NEW or EDIT";
                response.Data = new IMTR_SaveExtendDueDate_JSON_rsp();
                return BadRequest(response);
            }
            try
            {
                DynamicParameters param = new DynamicParameters();

                //ListType
                param.Add("@ListType", save.ListType.ListType);
                //pIMTR
                param.Add("@CenterID", save.pIMTR.CenterID);
                param.Add("@TRNumber", save.pIMTR.TRNumber);
                param.Add("@RefNumber", save.pIMTR.RefNumber);
                param.Add("@RecType", save.pIMTR.RecType);
                param.Add("@TRSeqno", save.pIMTR.TRSeqno);
                param.Add("@TRStatus", save.pIMTR.TRStatus);
                param.Add("@RecStatus", save.pIMTR.RecStatus);
                param.Add("@EventMode", save.pIMTR.EventMode);
                param.Add("@Event", save.pIMTR.Event);
                param.Add("@EventDate", save.pIMTR.EventDate);
                param.Add("@LOCode", save.pIMTR.LOCode);
                param.Add("@AOCode", save.pIMTR.AOCode);
                param.Add("@ValueDate", save.pIMTR.ValueDate);
                param.Add("@EventFlag", save.pIMTR.EventFlag);
                param.Add("@AutoOverDue", save.pIMTR.AutoOverDue);
                param.Add("@TRDueStatus", save.pIMTR.TRDueStatus);
                param.Add("@OverdueDate", save.pIMTR.OverdueDate);
                param.Add("@PastDueDate", save.pIMTR.PastDueDate);
                param.Add("@TRCCyFlag", save.pIMTR.TRCCyFlag);
                param.Add("@TRRate", save.pIMTR.TRRate);
                param.Add("@LCNumber", save.pIMTR.LCNumber);
                param.Add("@BLNumber", save.pIMTR.BLNumber);
                param.Add("@BLAdvice", save.pIMTR.BLAdvice);
                param.Add("@CustCode", save.pIMTR.CustCode);
                param.Add("@CustAddr", save.pIMTR.CustAddr);
                param.Add("@DocCCy", save.pIMTR.DocCCy);
                param.Add("@BLBalance", save.pIMTR.BLBalance);
                param.Add("@BLDay", save.pIMTR.BLDay);
                param.Add("@TRTermDay", save.pIMTR.TRTermDay);
                param.Add("@BLIntStartDate", save.pIMTR.BLIntStartDate);
                param.Add("@BLIntCode", save.pIMTR.BLIntCode);
                param.Add("@BLIntRate", save.pIMTR.BLIntRate);
                param.Add("@BLBase", save.pIMTR.BLBase);
                param.Add("@BLInterest", save.pIMTR.BLInterest);
                param.Add("@BLExch", save.pIMTR.BLExch);
                param.Add("@BLFwd", save.pIMTR.BLFwd);
                param.Add("@BLIntAmt", save.pIMTR.BLIntAmt);
                param.Add("@BenName", save.pIMTR.BenName);
                param.Add("@BenInfo", save.pIMTR.BenInfo);
                param.Add("@BenCnty", save.pIMTR.BenCnty);
                param.Add("@TenorType", save.pIMTR.TenorType);
                param.Add("@NegoBank", save.pIMTR.NegoBank);
                param.Add("@NegoCnty", save.pIMTR.NegoCnty);
                param.Add("@NegoRefno", save.pIMTR.NegoRefno);
                param.Add("@ChipNego", save.pIMTR.ChipNego);
                param.Add("@TRCcy", save.pIMTR.TRCcy);
                param.Add("@TRAmount", save.pIMTR.TRAmount);
                param.Add("@TRBalance", save.pIMTR.TRBalance);
                param.Add("@TRProfit", save.pIMTR.TRProfit);
                param.Add("@MidRate", save.pIMTR.MidRate);
                param.Add("@TRDay", save.pIMTR.TRDay);
                param.Add("@StartDate", save.pIMTR.StartDate);
                param.Add("@DueDate", save.pIMTR.DueDate);
                param.Add("@PrevDueDate", save.pIMTR.PrevDueDate);
                param.Add("@FBCcy", save.pIMTR.FBCcy);
                param.Add("@FBCharge", save.pIMTR.FBCharge);
                param.Add("@FBInterest", save.pIMTR.FBInterest);
                param.Add("@FBEngage", save.pIMTR.FBEngage);
                param.Add("@PrevFBChrg", save.pIMTR.PrevFBChrg);
                param.Add("@PrevFBInt", save.pIMTR.PrevFBInt);
                param.Add("@PrevFBEng", save.pIMTR.PrevFBEng);
                param.Add("@Invoice", save.pIMTR.Invoice);
                param.Add("@Goods", save.pIMTR.Goods);
                param.Add("@Relation", save.pIMTR.Relation);
                param.Add("@DeductSwift", save.pIMTR.DeductSwift);
                param.Add("@DeductComm", save.pIMTR.DeductComm);
                param.Add("@DeductOther", save.pIMTR.DeductOther);
                param.Add("@SettleFlag", save.pIMTR.SettleFlag);
                param.Add("@SettleDate", save.pIMTR.SettleDate);
                param.Add("@MTNego", save.pIMTR.MTNego);
                param.Add("@MTType", save.pIMTR.MTType);
                param.Add("@ReimBank", save.pIMTR.ReimBank);
                param.Add("@SGNumber", save.pIMTR.SGNumber);
                param.Add("@SGNumber1", save.pIMTR.SGNumber1);
                param.Add("@SGAmount", save.pIMTR.SGAmount);
                param.Add("@DOAmount", save.pIMTR.DOAmount);
                param.Add("@IntermBank", save.pIMTR.IntermBank);
                param.Add("@ChipInterm", save.pIMTR.ChipInterm);
                param.Add("@IntermAddr", save.pIMTR.IntermAddr);
                param.Add("@AcBank", save.pIMTR.AcBank);
                param.Add("@ChipAcBank", save.pIMTR.ChipAcBank);
                param.Add("@AcAddr", save.pIMTR.AcAddr);
                param.Add("@IntBefore", save.pIMTR.IntBefore);
                param.Add("@ExchBefore", save.pIMTR.ExchBefore);
                param.Add("@IntPayType", save.pIMTR.IntPayType);
                param.Add("@IntFixDate", save.pIMTR.IntFixDate);
                param.Add("@IntRateCode", save.pIMTR.IntRateCode);
                param.Add("@IntRate", save.pIMTR.IntRate);
                param.Add("@IntSpread", save.pIMTR.IntSpread);
                param.Add("@IntFlag", save.pIMTR.IntFlag);
                param.Add("@IntBaseDay", save.pIMTR.IntBaseDay);
                param.Add("@CFRRate", save.pIMTR.CFRRate);
                param.Add("@IntStartDate", save.pIMTR.IntStartDate);
                param.Add("@LastIntDate", save.pIMTR.LastIntDate);
                param.Add("@LastIntAmt", save.pIMTR.LastIntAmt);
                param.Add("@IntBalance", save.pIMTR.IntBalance);
                param.Add("@OverDrawComm", save.pIMTR.OverDrawComm);
                param.Add("@ExchRate", save.pIMTR.ExchRate);
                param.Add("@EngageRate", save.pIMTR.EngageRate);
                param.Add("@EngageComm", save.pIMTR.EngageComm);
                param.Add("@CommFCD", save.pIMTR.CommFCD);
                param.Add("@OpenAmt", save.pIMTR.OpenAmt);
                param.Add("@CableAmt", save.pIMTR.CableAmt);
                param.Add("@PostageAmt", save.pIMTR.PostageAmt);
                param.Add("@DutyAmt", save.pIMTR.DutyAmt);
                param.Add("@PayableAmt", save.pIMTR.PayableAmt);
                param.Add("@IBCRate", save.pIMTR.IBCRate);
                param.Add("@IBCComm", save.pIMTR.IBCComm);
                param.Add("@CommLieu", save.pIMTR.CommLieu);
                param.Add("@CommTran", save.pIMTR.CommTran);
                param.Add("@CommExch", save.pIMTR.CommExch);
                param.Add("@CommCertify", save.pIMTR.CommCertify);
                param.Add("@DiscFee", save.pIMTR.DiscFee);
                param.Add("@CommOther", save.pIMTR.CommOther);
                param.Add("@TaxRefund", save.pIMTR.TaxRefund);
                param.Add("@TaxAmt", save.pIMTR.TaxAmt);
                param.Add("@CommDesc", save.pIMTR.CommDesc);
                param.Add("@PayFlag", save.pIMTR.PayFlag);
                param.Add("@PayMethod", save.pIMTR.PayMethod);
                param.Add("@Allocation", save.pIMTR.Allocation);
                param.Add("@DateLastPaid", save.pIMTR.DateLastPaid);
                param.Add("@LastReceiptNo", save.pIMTR.LastReceiptNo);
                param.Add("@AppvNo", save.pIMTR.AppvNo);
                param.Add("@FacNo", save.pIMTR.FacNo);
                param.Add("@FCyPayFlag", save.pIMTR.FCyPayFlag);
                param.Add("@FCyAcNo", save.pIMTR.FCyAcNo);
                param.Add("@FCyReceiptNo", save.pIMTR.FCyReceiptNo);
                param.Add("@PayType", save.pIMTR.PayType);
                param.Add("@PayAmount", save.pIMTR.PayAmount);
                param.Add("@PayInterest", save.pIMTR.PayInterest);
                //param.Add("@UpdateDate", save.pIMTR.UpdateDate);
                param.Add("@UserCode", USER_ID);
                //param.Add("@AuthDate", save.pIMTR.AuthDate);
                //param.Add("@AuthCode", save.pIMTR.AuthCode);
                param.Add("@GenAccFlag", save.pIMTR.GenAccFlag);
                param.Add("@VoucherID", save.pIMTR.VoucherID);
                param.Add("@DateToStop", save.pIMTR.DateToStop);
                param.Add("@DateStartAccru", save.pIMTR.DateStartAccru);
                param.Add("@DateLastAccru", save.pIMTR.DateLastAccru);
                param.Add("@LastAccruCcy", save.pIMTR.LastAccruCcy);
                param.Add("@LastAccruAmt", save.pIMTR.LastAccruAmt);
                param.Add("@NewAccruCcy", save.pIMTR.NewAccruCcy);
                param.Add("@NewAccruAmt", save.pIMTR.NewAccruAmt);
                param.Add("@AccruCCy", save.pIMTR.AccruCCy);
                param.Add("@AccruAmt", save.pIMTR.AccruAmt);
                param.Add("@DAccruAmt", save.pIMTR.DAccruAmt);
                param.Add("@PAccruAmt", save.pIMTR.PAccruAmt);
                param.Add("@AccruPending", save.pIMTR.AccruPending);
                param.Add("@RevAccru", save.pIMTR.RevAccru);
                param.Add("@RevAccruTax", save.pIMTR.RevAccruTax);
                param.Add("@DMS", save.pIMTR.DMS);
                param.Add("@Tx72", save.pIMTR.Tx72);
                param.Add("@Tx23E", save.pIMTR.Tx23E);
                param.Add("@Tx71A", save.pIMTR.Tx71A);
                param.Add("@Tx26", save.pIMTR.Tx26);
                param.Add("@Tx59A", save.pIMTR.Tx59A);
                param.Add("@Tx59D", save.pIMTR.Tx59D);
                param.Add("@Tx59Cnty", save.pIMTR.Tx59Cnty);
                param.Add("@TRCcy1", save.pIMTR.TRCcy1);
                param.Add("@TRExch1", save.pIMTR.TRExch1);
                param.Add("@TRAmt1", save.pIMTR.TRAmt1);
                param.Add("@TRCont1", save.pIMTR.TRCont1);
                param.Add("@TRCcy2", save.pIMTR.TRCcy2);
                param.Add("@TRExch2", save.pIMTR.TRExch2);
                param.Add("@TRAmt2", save.pIMTR.TRAmt2);
                param.Add("@TRCont2", save.pIMTR.TRCont2);
                param.Add("@TRCcy3", save.pIMTR.TRCcy3);
                param.Add("@TRExch3", save.pIMTR.TRExch3);
                param.Add("@TRAmt3", save.pIMTR.TRAmt3);
                param.Add("@TRCont3", save.pIMTR.TRCont3);
                param.Add("@TRCcy4", save.pIMTR.TRCcy4);
                param.Add("@TRExch4", save.pIMTR.TRExch4);
                param.Add("@TRAmt4", save.pIMTR.TRAmt4);
                param.Add("@TRCont4", save.pIMTR.TRCont4);
                param.Add("@TRCcy5", save.pIMTR.TRCcy5);
                param.Add("@TRExch5", save.pIMTR.TRExch5);
                param.Add("@TRAmt5", save.pIMTR.TRAmt5);
                param.Add("@TRCont5", save.pIMTR.TRCont5);
                param.Add("@NostACInfo", save.pIMTR.NostACInfo);
                param.Add("@Nego799", save.pIMTR.Nego799);
                param.Add("@Nego999", save.pIMTR.Nego999);
                param.Add("@NegoTelex", save.pIMTR.NegoTelex);
                param.Add("@CCS_ACCT", save.pIMTR.CCS_ACCT);
                param.Add("@CCS_LmType", save.pIMTR.CCS_LmType);
                param.Add("@CCS_CNUM", save.pIMTR.CCS_CNUM);
                param.Add("@CCS_CIFRef", save.pIMTR.CCS_CIFRef);
                param.Add("@TRFLAG", save.pIMTR.TRFLAG);
                param.Add("@InUse", save.pIMTR.InUse);
                param.Add("@ObjectType", save.pIMTR.ObjectType);
                param.Add("@UnderlyName", save.pIMTR.UnderlyName);
                param.Add("@BPOFlag", save.pIMTR.BPOFlag);
                param.Add("@Campaign_Code", save.pIMTR.Campaign_Code);
                param.Add("@Campaign_EffDate", save.pIMTR.Campaign_EffDate);
                param.Add("@PurposeCode", save.pIMTR.PurposeCode);

                //pPayment
                param.Add("@RpReceiptNo", save.pPayment.RpReceiptNo);
                param.Add("@RpModule", save.pPayment.RpModule);
                param.Add("@RpEvent", save.pPayment.RpEvent);
                param.Add("@RpDocNo", save.pPayment.RpDocNo);
                param.Add("@RpCustCode", save.pPayment.RpCustCode);
                param.Add("@RpPayDate", save.pPayment.RpPayDate);
                param.Add("@RpPayBy", save.pPayment.RpPayBy);
                param.Add("@RpNote", save.pPayment.RpNote);
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
                param.Add("@RpRefer1", save.pPayment.RpRefer1);
                param.Add("@RpRefer2", save.pPayment.RpRefer2);
                param.Add("@RpApplicant", save.pPayment.RpApplicant);
                param.Add("@RpIssBank", save.pPayment.RpIssBank);
                param.Add("@RpStatus", save.pPayment.RpStatus);
                param.Add("@RpRecStatus", save.pPayment.RpRecStatus);
                param.Add("@RpPrint", save.pPayment.RpPrint);
                //param.Add("@UserCode", save.pPayment.UserCode);
                //param.Add("@UpdateDate", save.pPayment.UpdateDate);
                //param.Add("@AuthCode", save.pPayment.AuthCode);
                //param.Add("@AuthDate", save.pPayment.AuthDate);

                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@SaveResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<IMTR_SaveExtendDueDate_Response, dynamic>(
                    storedProcedure: "usp_pIMTR_ExtenedDueDate_Save",
                    param);

                var Resp = param.Get<int>("@Resp");
                var SaveResp = param.Get<dynamic>("@SaveResp");

                //var Resp = param.Get<int>("@Resp");
                if (Resp > 0)
                {
                    IMTR_SaveExtendDueDate_JSON_rsp jsonResponse = JsonSerializer.Deserialize<IMTR_SaveExtendDueDate_JSON_rsp>(SaveResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Extend DueDate Save Error";
                    response.Data = new IMTR_SaveExtendDueDate_JSON_rsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new IMTR_SaveExtendDueDate_JSON_rsp();
                return BadRequest(response);
            }

        }

        [HttpPost("release")]
        public async Task<ActionResult<IMTRResultResponse>> Release([FromBody] IMTR_ReleaseExtendDueDate_req release)
        {
            IMTRResultResponse response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            //if (saveissue.pIMTR.ListType != "NEW" && saveissue.pIMTR.ListType != "EDIT")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be NEW or EDIT";
            //    response.Data = new IMTR_SaveIssue_JSON_rsp();
            //    return BadRequest(response);
            //}

            DynamicParameters param = new DynamicParameters();

            param.Add("@RefNumber", release.RefNumber);
            param.Add("@RecType", release.RecType);
            param.Add("@TRSeqno", release.TRSeqno);
            param.Add("@UserCode", USER_ID);
            param.Add("@DueDate", release.DueDate);
            param.Add("@PayFlag", release.PayFlag);
            param.Add("@PayableAmt", release.PayableAmt);
            param.Add("@CFRRate", release.CFRRate);
            param.Add("@IntRateCode", release.IntRateCode);
            param.Add("@IntRate", release.IntRate);
            param.Add("@IntSpread", release.IntSpread);
            param.Add("@IntBaseDay", release.IntBaseDay);
            param.Add("@IntFlag", release.IntFlag);
            param.Add("@NegoTelex", release.NegoTelex);

            param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            try
            {
                await _db.SaveData(
                    storedProcedure: "usp_pIMTR_ExtenedDueDate_Release", param);

                var Resp = param.Get<int>("@Resp");

                if (Resp > 0)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Extend Duedate Release Complete";
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    try
                    {
                        response.Message = Resp.ToString();
                    }
                    catch (Exception)
                    {
                        response.Message = "Extend Duedate Release Error";
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
        public async Task<ActionResult<IMTRResultResponse>> Delete([FromBody] IMTR_DeleteExtendDueDate_req delete)
        {
            IMTRResultResponse response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            //if (saveissue.pIMTR.ListType != "NEW" && saveissue.pIMTR.ListType != "EDIT")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be NEW or EDIT";
            //    response.Data = new IMTR_SaveIssue_JSON_rsp();
            //    return BadRequest(response);
            //}

            DynamicParameters param = new DynamicParameters();

            param.Add("@RefNumber", delete.RefNumber);
            param.Add("@TRSeqno", delete.TRSeqno);

            param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            try
            {
                await _db.SaveData(
                    storedProcedure: "usp_pIMTR_ExtenedDueDate_Delete", param);

                var Resp = param.Get<int>("@Resp");

                if (Resp > 0)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Extend Duedate Delete Complete";
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    try
                    {
                        response.Message = Resp.ToString();
                    }
                    catch (Exception)
                    {
                        response.Message = "Extend Duedate Delete Error";
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