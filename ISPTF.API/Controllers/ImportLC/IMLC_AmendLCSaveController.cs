using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.Inquiry;
using ISPTF.Models.ImportTR;
using ISPTF.Models.ImportLC;
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
namespace ISPTF.API.Controllers.ImportLC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class IMLC_AmendLCSaveController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public IMLC_AmendLCSaveController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }


        //[HttpGet("Remark1/1.Remark for Save,Release,Delete Menu Amend L/C Amount , Amend L/C Other")]
        //[HttpGet("Remark2/2.LoadLC = 'AMEND-AMT' or @LoadLC = 'AMEND-OTH'")]

        [HttpPost("save")]
        public async Task<ActionResult<IMLC_SaveAmend_Response>> Save([FromBody] IMLC_SaveAmend_JSON_req save)
        {
            IMLC_SaveAmend_Response response = new();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
            // Class validate
            if (save.ListType.ListType != "NEW" && save.ListType.ListType != "EDIT")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType should be NEW or EDIT";
                response.Data = new IMLC_SaveAmend_JSON_rsp();
                return BadRequest(response);
            }
            if (save.ListType.LoadLC != "AMEND-AMT" && save.ListType.LoadLC != "AMEND-OTH")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LoadLC should be AMEND-AMT or AMEND-OTH";
                response.Data = new IMLC_SaveAmend_JSON_rsp();
                return BadRequest(response);
            }
            try
            {
                DynamicParameters param = new DynamicParameters();

                //ListType
                param.Add("@ListType", save.ListType.ListType);
                param.Add("@LoadLC", save.ListType.LoadLC);
                param.Add("@TxAmendSeq", save.ListType.TxAmendSeq);
                param.Add("@LbAmdType", save.ListType.LbAmdType);
                param.Add("@LbPeriod", save.ListType.LbPeriod);

                //pIMTR
                param.Add("@LCNumber", save.pIMLC.LCNumber);
                param.Add("@RecType", save.pIMLC.RecType);
                param.Add("@LCSeqno", save.pIMLC.LCSeqno);
                param.Add("@CenterID", USER_CENTER_ID);
                param.Add("@Event", save.pIMLC.Event);
                param.Add("@EventDate", save.pIMLC.EventDate);
                param.Add("@EventFlag", save.pIMLC.EventFlag);
                param.Add("@LCStatus", save.pIMLC.LCStatus);
                param.Add("@RecStatus", save.pIMLC.RecStatus);
                param.Add("@LOCode", save.pIMLC.LOCode);
                param.Add("@AOCode", save.pIMLC.AOCode);
                param.Add("@AmendSeq", save.pIMLC.AmendSeq);
                param.Add("@AmendNo", save.pIMLC.AmendNo);
                param.Add("@LCReferNo", save.pIMLC.LCReferNo);
                param.Add("@RequestCancel", save.pIMLC.RequestCancel);
                param.Add("@ConfirmRequest", save.pIMLC.ConfirmRequest);
                param.Add("@AmendStatus", save.pIMLC.AmendStatus);
                param.Add("@DateIssue", save.pIMLC.DateIssue);
                param.Add("@LCRevolve", save.pIMLC.LCRevolve);
                param.Add("@LCVary", save.pIMLC.LCVary);
                param.Add("@LCSentBy", save.pIMLC.LCSentBy);
                param.Add("@LCForm", save.pIMLC.LCForm);
                param.Add("@LCCcy", save.pIMLC.LCCcy);
                param.Add("@LCAmt", save.pIMLC.LCAmt);
                param.Add("@LCNet", save.pIMLC.LCNet);
                param.Add("@LCBal", save.pIMLC.LCBal);
                param.Add("@LCAvalBal", save.pIMLC.LCAvalBal);
                param.Add("@LCPostAmt", save.pIMLC.LCPostAmt);
                param.Add("@MarDeposit", save.pIMLC.MarDeposit);
                param.Add("@BillAmount", save.pIMLC.BillAmount);
                param.Add("@ExchRate", save.pIMLC.ExchRate);
                param.Add("@AllowPlus", save.pIMLC.AllowPlus);
                param.Add("@AllowMinus", save.pIMLC.AllowMinus);
                param.Add("@AmendFlag", save.pIMLC.AmendFlag);
                param.Add("@DePlus_Flag", save.pIMLC.DePlus_Flag);
                param.Add("@AmendAmt", save.pIMLC.AmendAmt);
                param.Add("@AmendAmtInc", save.pIMLC.AmendAmtInc);
                param.Add("@AmendAmtDec", save.pIMLC.AmendAmtDec);
                param.Add("@AmendPlus", save.pIMLC.AmendPlus);
                param.Add("@AmendMinus", save.pIMLC.AmendMinus);
                param.Add("@PrevPlus", save.pIMLC.PrevPlus);
                param.Add("@PrevMunus", save.pIMLC.PrevMunus);
                param.Add("@PrevAmt", save.pIMLC.PrevAmt);
                param.Add("@PrevNet", save.pIMLC.PrevNet);
                param.Add("@PrevLCBal", save.pIMLC.PrevLCBal);
                param.Add("@PrevLCAvalBal", save.pIMLC.PrevLCAvalBal);
                param.Add("@PrevDateExpiry", save.pIMLC.PrevDateExpiry);
                param.Add("@DateExpiry", save.pIMLC.DateExpiry);
                param.Add("@PrevDateExpMax", save.pIMLC.PrevDateExpMax);
                param.Add("@PlaceExpiry", save.pIMLC.PlaceExpiry);
                param.Add("@DateExpiryMax", save.pIMLC.DateExpiryMax);
                param.Add("@LCDays", save.pIMLC.LCDays);
                param.Add("@PrevLCDays", save.pIMLC.PrevLCDays);
                param.Add("@TenorType", save.pIMLC.TenorType);
                param.Add("@TenorDay", save.pIMLC.TenorDay);
                param.Add("@TenorTerm", save.pIMLC.TenorTerm);
                param.Add("@DraftAt", save.pIMLC.DraftAt);
                param.Add("@MixPayment", save.pIMLC.MixPayment);
                param.Add("@Confirmation", save.pIMLC.Confirmation);
                param.Add("@Restricted", save.pIMLC.Restricted);
                param.Add("@AvailWith", save.pIMLC.AvailWith);
                param.Add("@AvailBy", save.pIMLC.AvailBy);
                param.Add("@AvailCnty", save.pIMLC.AvailCnty);
                param.Add("@Drawee", save.pIMLC.Drawee);
                param.Add("@CustCode", save.pIMLC.CustCode);
                param.Add("@CustAddr", save.pIMLC.CustAddr);
                param.Add("@AdBankCode", save.pIMLC.AdBankCode);
                param.Add("@ConfBankCode", save.pIMLC.ConfBankCode);
                param.Add("@BenInfo1", save.pIMLC.BenInfo1);
                param.Add("@BenInfo2", save.pIMLC.BenInfo2);
                param.Add("@BenInfo3", save.pIMLC.BenInfo3);
                param.Add("@BenInfo4", save.pIMLC.BenInfo4);
                param.Add("@BenCity", save.pIMLC.BenCity);
                param.Add("@BenCnty", save.pIMLC.BenCnty);
                param.Add("@PrevBenInfo", save.pIMLC.PrevBenInfo);
                param.Add("@AdThruBank", save.pIMLC.AdThruBank);
                param.Add("@AdThruInfo1", save.pIMLC.AdThruInfo1);
                param.Add("@AdThruCity", save.pIMLC.AdThruCity);
                param.Add("@AdThruCnty", save.pIMLC.AdThruCnty);
                param.Add("@OutsideCharge", save.pIMLC.OutsideCharge);
                param.Add("@ConfirmComm", save.pIMLC.ConfirmComm);
                param.Add("@Incoterms", save.pIMLC.Incoterms);
                param.Add("@ShipmentFrom", save.pIMLC.ShipmentFrom);
                param.Add("@TransportTo", save.pIMLC.TransportTo);
                param.Add("@DateLateShip", save.pIMLC.DateLateShip);
                param.Add("@PresentDay", save.pIMLC.PresentDay);
                param.Add("@PresentPeriod", save.pIMLC.PresentPeriod);
                param.Add("@PartialShipment", save.pIMLC.PartialShipment);
                param.Add("@Transhipment", save.pIMLC.Transhipment);
                param.Add("@TransportType", save.pIMLC.TransportType);
                param.Add("@ShipPlace", save.pIMLC.ShipPlace);
                param.Add("@GoodsCode", save.pIMLC.GoodsCode);
                param.Add("@PurposeCode", save.pIMLC.PurposeCode);
                param.Add("@ReimPay", save.pIMLC.ReimPay);
                param.Add("@ReimBank", save.pIMLC.ReimBank);
                param.Add("@ReimAddr", save.pIMLC.ReimAddr);
                param.Add("@ReimMT740", save.pIMLC.ReimMT740);
                param.Add("@DateMT740", save.pIMLC.DateMT740);
                param.Add("@ReimCharge", save.pIMLC.ReimCharge);
                param.Add("@ReimNote", save.pIMLC.ReimNote);
                param.Add("@Charge740", save.pIMLC.Charge740);
                param.Add("@Bank740", save.pIMLC.Bank740);
                param.Add("@MT747_Flag", save.pIMLC.MT747_Flag);
                param.Add("@Charge71B", save.pIMLC.Charge71B);
                param.Add("@BanktoBank72", save.pIMLC.BanktoBank72);
                param.Add("@CommType", save.pIMLC.CommType);
                param.Add("@CommLCRate", save.pIMLC.CommLCRate);
                param.Add("@PeriodComm", save.pIMLC.PeriodComm);
                param.Add("@PeriodCommExt", save.pIMLC.PeriodCommExt);
                param.Add("@TaxRefund", save.pIMLC.TaxRefund);
                param.Add("@CommBenCCy", save.pIMLC.CommBenCCy);
                param.Add("@CommAmt", save.pIMLC.CommAmt);
                param.Add("@CableAmt", save.pIMLC.CableAmt);
                param.Add("@PostageAmt", save.pIMLC.PostageAmt);
                param.Add("@DutyAmt", save.pIMLC.DutyAmt);
                param.Add("@PayableAmt", save.pIMLC.PayableAmt);
                param.Add("@OtherAmt", save.pIMLC.OtherAmt);
                param.Add("@MarginAmt", save.pIMLC.MarginAmt);
                param.Add("@TaxAmt", save.pIMLC.TaxAmt);
                param.Add("@CollectRefund", save.pIMLC.CollectRefund);
                param.Add("@PayFlag", save.pIMLC.PayFlag);
                param.Add("@PayMethod", save.pIMLC.PayMethod);
                param.Add("@PayRemark", save.pIMLC.PayRemark);
                param.Add("@Allocation", save.pIMLC.Allocation);
                param.Add("@DateLastPaid", save.pIMLC.DateLastPaid);
                param.Add("@LastReceiptNo", save.pIMLC.LastReceiptNo);
                param.Add("@AppvNo", save.pIMLC.AppvNo);
                param.Add("@FacNo", save.pIMLC.FacNo);
                //param.Add("@UpdateDate", save.pIMLC.UpdateDate);
                param.Add("@UserCode", USER_ID);
                //param.Add("@AuthDate", save.pIMLC.AuthDate);
                //param.Add("@AuthCode", save.pIMLC.AuthCode);
                param.Add("@GenAccFlag", save.pIMLC.GenAccFlag);
                param.Add("@VoucherID", save.pIMLC.VoucherID);
                param.Add("@CCS_ACCT", save.pIMLC.CCS_ACCT);
                param.Add("@CCS_LmType", save.pIMLC.CCS_LmType);
                param.Add("@CCS_CNUM", save.pIMLC.CCS_CNUM);
                param.Add("@CCS_CIFRef", save.pIMLC.CCS_CIFRef);
                param.Add("@InUse", save.pIMLC.InUse);
                param.Add("@ObjectType", save.pIMLC.ObjectType);
                param.Add("@UnderlyName", save.pIMLC.UnderlyName);
                param.Add("@BPOFlag", save.pIMLC.BPOFlag);
                param.Add("@Campaign_Code", save.pIMLC.Campaign_Code);
                param.Add("@Campaign_EffDate", save.pIMLC.Campaign_EffDate);

                //pIMLCGoods
                param.Add("@GoodsDesc", save.pIMLCGoods.GoodsDesc);

                //pIMLCCond
                param.Add("@AddCondition", save.pIMLCCond.AddCondition);

                //pIMLCDocs
                param.Add("@DocRequire", save.pIMLCDocs.DocRequire);

                //pSWIMLC
                param.Add("@SwiftFile", save.pSWIMLC.SwiftFile);
                param.Add("@Flag701", save.pSWIMLC.Flag701);
                //param.Add("@F40E", save.pSWIMLC.F40E);
                param.Add("@F40F", save.pSWIMLC.F40F);
                //param.Add("@F42M", save.pSWIMLC.F42M);
                //param.Add("@F44D", save.pSWIMLC.F44D);
                param.Add("@F44E", save.pSWIMLC.F44E);
                param.Add("@F44F", save.pSWIMLC.F44F);
                //param.Add("@", save.pSWIMLC.);


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

                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@SaveResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<IMLC_SaveAmend_JSON_rsp, dynamic>(
                    storedProcedure: "usp_pIMLC_Amend_Save",
                    param);

                var Resp = param.Get<int>("@Resp");
                var SaveResp = param.Get<dynamic>("@SaveResp");

                //var Resp = param.Get<int>("@Resp");
                if (Resp > 0)
                {
                    IMLC_SaveAmend_JSON_rsp jsonResponse = JsonSerializer.Deserialize<IMLC_SaveAmend_JSON_rsp>(SaveResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Save Error";
                    response.Data = new IMLC_SaveAmend_JSON_rsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new IMLC_SaveAmend_JSON_rsp();
                return BadRequest(response);
            }

        }

        [HttpPost("release")]
        public async Task<ActionResult<IMLCResultResponse>> Release([FromBody] IMLC_ReleaseAmend_JSON_req save)
        {
            IMLCResultResponse response = new();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
            // Class validate
            //if (save.ListType.ListType != "NEW" && save.ListType.ListType != "EDIT")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be NEW or EDIT";
            //    response.Data = new IMLC_SaveAmend_JSON_rsp();
            //    return BadRequest(response);
            //}

            try
            {
                DynamicParameters param = new DynamicParameters();

                //ListType
                param.Add("@LoadLC", save.ListType.LoadLC);

                //pIMTR
                param.Add("@LCNumber", save.pIMLC.LCNumber);
                param.Add("@RecType", save.pIMLC.RecType);
                param.Add("@LCSeqno", save.pIMLC.LCSeqno);
                param.Add("@CenterID", USER_CENTER_ID);
                param.Add("@EventDate", save.pIMLC.EventDate);
                param.Add("@AmendSeq", save.pIMLC.AmendSeq);
                param.Add("@LCRevolve", save.pIMLC.LCRevolve);
                param.Add("@LCSentBy", save.pIMLC.LCSentBy);
                param.Add("@LCForm", save.pIMLC.LCForm);
                param.Add("@LCBal", save.pIMLC.LCBal);
                param.Add("@LCAvalBal", save.pIMLC.LCAvalBal);
                param.Add("@LCPostAmt", save.pIMLC.LCPostAmt);
                param.Add("@AmendFlag", save.pIMLC.AmendFlag);
                param.Add("@DePlus_Flag", save.pIMLC.DePlus_Flag);
                param.Add("@AmendAmt", save.pIMLC.AmendAmt);
                param.Add("@AmendAmtInc", save.pIMLC.AmendAmtInc);
                param.Add("@AmendAmtDec", save.pIMLC.AmendAmtDec);
                param.Add("@AmendPlus", save.pIMLC.AmendPlus);
                param.Add("@AmendMinus", save.pIMLC.AmendMinus);
                param.Add("@PrevAmt", save.pIMLC.PrevAmt);
                param.Add("@PrevNet", save.pIMLC.PrevNet);
                param.Add("@PrevLCBal", save.pIMLC.PrevLCBal);
                param.Add("@PrevLCAvalBal", save.pIMLC.PrevLCAvalBal);
                param.Add("@PrevDateExpiry", save.pIMLC.PrevDateExpiry);
                param.Add("@DateExpiry", save.pIMLC.DateExpiry);
                param.Add("@PlaceExpiry", save.pIMLC.PlaceExpiry);
                param.Add("@DateExpiryMax", save.pIMLC.DateExpiryMax);
                param.Add("@TenorType", save.pIMLC.TenorType);
                param.Add("@TenorDay", save.pIMLC.TenorDay);
                param.Add("@TenorTerm", save.pIMLC.TenorTerm);
                param.Add("@MixPayment", save.pIMLC.MixPayment);
                param.Add("@Confirmation", save.pIMLC.Confirmation);
                param.Add("@Restricted", save.pIMLC.Restricted);
                param.Add("@AvailWith", save.pIMLC.AvailWith);
                param.Add("@AvailBy", save.pIMLC.AvailBy);
                param.Add("@AvailCnty", save.pIMLC.AvailCnty);
                param.Add("@Drawee", save.pIMLC.Drawee);
                param.Add("@AdBankCode", save.pIMLC.AdBankCode);
                param.Add("@ConfBankCode", save.pIMLC.ConfBankCode);
                param.Add("@BenInfo1", save.pIMLC.BenInfo1);
                param.Add("@BenInfo2", save.pIMLC.BenInfo2);
                param.Add("@BenInfo3", save.pIMLC.BenInfo3);
                param.Add("@BenInfo4", save.pIMLC.BenInfo4);
                param.Add("@BenCity", save.pIMLC.BenCity);
                param.Add("@BenCnty", save.pIMLC.BenCnty);
                param.Add("@PrevBenInfo", save.pIMLC.PrevBenInfo);
                param.Add("@AdThruBank", save.pIMLC.AdThruBank);
                param.Add("@AdThruInfo1", save.pIMLC.AdThruInfo1);
                param.Add("@AdThruCity", save.pIMLC.AdThruCity);
                param.Add("@AdThruCnty", save.pIMLC.AdThruCnty);
                param.Add("@OutsideCharge", save.pIMLC.OutsideCharge);
                param.Add("@ConfirmComm", save.pIMLC.ConfirmComm);
                param.Add("@Incoterms", save.pIMLC.Incoterms);
                param.Add("@ShipmentFrom", save.pIMLC.ShipmentFrom);
                param.Add("@TransportTo", save.pIMLC.TransportTo);
                param.Add("@DateLateShip", save.pIMLC.DateLateShip);
                param.Add("@PresentDay", save.pIMLC.PresentDay);
                param.Add("@PresentPeriod", save.pIMLC.PresentPeriod);
                param.Add("@PartialShipment", save.pIMLC.PartialShipment);
                param.Add("@Transhipment", save.pIMLC.Transhipment);
                param.Add("@TransportType", save.pIMLC.TransportType);
                param.Add("@ShipPlace", save.pIMLC.ShipPlace);
                param.Add("@GoodsCode", save.pIMLC.GoodsCode);
                param.Add("@PurposeCode", save.pIMLC.PurposeCode);
                param.Add("@ReimPay", save.pIMLC.ReimPay);
                param.Add("@ReimBank", save.pIMLC.ReimBank);
                param.Add("@ReimAddr", save.pIMLC.ReimAddr);
                param.Add("@ReimMT740", save.pIMLC.ReimMT740);
                param.Add("@ReimCharge", save.pIMLC.ReimCharge);
                param.Add("@ReimNote", save.pIMLC.ReimNote);
                param.Add("@Charge740", save.pIMLC.Charge740);
                param.Add("@Bank740", save.pIMLC.Bank740);
                param.Add("@MT747_Flag", save.pIMLC.MT747_Flag);
                param.Add("@Charge71B", save.pIMLC.Charge71B);
                param.Add("@BanktoBank72", save.pIMLC.BanktoBank72);
                param.Add("@CommType", save.pIMLC.CommType);
                param.Add("@CommLCRate", save.pIMLC.CommLCRate);
                param.Add("@PeriodComm", save.pIMLC.PeriodComm);
                param.Add("@PeriodCommExt", save.pIMLC.PeriodCommExt);
                param.Add("@TaxRefund", save.pIMLC.TaxRefund);
                param.Add("@CommBenCCy", save.pIMLC.CommBenCCy);
                param.Add("@CommAmt", save.pIMLC.CommAmt);
                param.Add("@CableAmt", save.pIMLC.CableAmt);
                param.Add("@PostageAmt", save.pIMLC.PostageAmt);
                param.Add("@DutyAmt", save.pIMLC.DutyAmt);
                param.Add("@PayableAmt", save.pIMLC.PayableAmt);
                param.Add("@OtherAmt", save.pIMLC.OtherAmt);
                param.Add("@TaxAmt", save.pIMLC.TaxAmt);
                param.Add("@PayFlag", save.pIMLC.PayFlag);
                param.Add("@PayMethod", save.pIMLC.PayMethod);
                param.Add("@PayRemark", save.pIMLC.PayRemark);
                param.Add("@DateLastPaid", save.pIMLC.DateLastPaid);
                //param.Add("@UpdateDate", save.pIMLC.UpdateDate);
                param.Add("@UserCode", USER_ID);
                //param.Add("@AuthDate", save.pIMLC.AuthDate);
                //param.Add("@AuthCode", save.pIMLC.AuthCode);
                param.Add("@BPOFlag", save.pIMLC.BPOFlag);

                //pIMLCGoods
                param.Add("@GoodsDesc", save.pIMLCGoods.GoodsDesc);

                //pIMLCAmend
                param.Add("@Narr77A", save.pIMLCAmend.Narr77A);
                param.Add("@Amend79", save.pIMLCAmend.Amend79);

                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                await _db.SaveData(
                  storedProcedure: "usp_pIMLC_Amend_Release", param);
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
        public async Task<ActionResult<IMLCResultResponse>> delete([FromBody] IMLC_DeleteAmend_JSON_req save)
        {
            IMLCResultResponse response = new();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
            // Class validate
            //if (save.ListType.ListType != "NEW" && save.ListType.ListType != "EDIT")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be NEW or EDIT";
            //    response.Data = new IMLC_SaveAmend_JSON_rsp();
            //    return BadRequest(response);
            //}

            try
            {
                DynamicParameters param = new DynamicParameters();

                //ListType
                param.Add("@LoadLC", save.ListType.LoadLC);

                //pIMTR
                param.Add("@LCNumber", save.pIMLC.LCNumber);
                param.Add("@LCSeqno", save.pIMLC.LCSeqno);
                param.Add("@CenterID", USER_CENTER_ID);
                param.Add("@UserCode", USER_ID);
                param.Add("@AmendFlag", save.pIMLC.AmendFlag);

                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                await _db.SaveData(
                  storedProcedure: "usp_pIMLC_Amend_Delete", param);
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


        [HttpHead("Remark1/1.Remark for Save,Release,Delete Menu Amend L/C Amount , Amend L/C Other")]
        [HttpHead("Remark2/2.LoadLC = 'AMEND-AMT' or @LoadLC = 'AMEND-OTH'")]
        public async Task<ActionResult<IMLCResultResponse>> Remark([FromBody] IMLC_RemarkAmend_JSON_req save)
        {
            IMLCResultResponse response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            //if (save.ListType.ListType != "NEW" && save.ListType.ListType != "EDIT")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be NEW or EDIT";
            //    response.Data = new IMLC_SaveAmend_JSON_rsp();
            //    return BadRequest(response);
            //}

            try
            {
                DynamicParameters param = new DynamicParameters();

                ////ListType
                param.Add("@LoadLC", save.ListType.LoadLC);

    
                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                await _db.SaveData(
                  storedProcedure: "usp_pIMLC_Amend_Release", param);
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


        [HttpPost("saveSWIFT")]
        public async Task<ActionResult<IMLC_SaveAmendSWIFT_Response>> SaveSWIFT([FromBody] IMLC_SaveAmendSWIFT_JSON_req save)
        {
            IMLC_SaveAmendSWIFT_Response response = new();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
            // Class validate
            //if (save.ListType.ListType != "NEW" && save.ListType.ListType != "EDIT")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be NEW or EDIT";
            //    response.Data = new IMLC_SaveIssue_JSON_rsp();
            //    return BadRequest(response);
            //}
            try
            {
                DynamicParameters param = new DynamicParameters();

                //pIMTR
                param.Add("@LCNumber", save.pIMLC.LCNumber);
                param.Add("@LCSeqno", save.pIMLC.LCSeqno);
                param.Add("@CenterID", USER_CENTER_ID);
                param.Add("@UserCode", USER_ID);

                //pSWIMLC
                param.Add("@LCNo", save.pSWIMLC.LCNo);
                param.Add("@LCSeq", save.pSWIMLC.LCSeq);
                param.Add("@LCEvent", save.pSWIMLC.LCEvent);
                param.Add("@SwiftFile", save.pSWIMLC.SwiftFile);
                param.Add("@ToBank", save.pSWIMLC.ToBank);
                param.Add("@ToReim", save.pSWIMLC.ToReim);
                param.Add("@ValueDate", save.pSWIMLC.ValueDate);
                param.Add("@LCCcy", save.pSWIMLC.LCCcy);
                param.Add("@LCAmount", save.pSWIMLC.LCAmount);
                param.Add("@Flag701", save.pSWIMLC.Flag701);
                param.Add("@Flag740", save.pSWIMLC.Flag740);
                param.Add("@Flag747", save.pSWIMLC.Flag747);
                param.Add("@F27", save.pSWIMLC.F27);
                param.Add("@F21", save.pSWIMLC.F21);
                param.Add("@F23", save.pSWIMLC.F23);
                param.Add("@F26E", save.pSWIMLC.F26E);
                param.Add("@F30", save.pSWIMLC.F30);
                param.Add("@F31C", save.pSWIMLC.F31C);
                param.Add("@F31D", save.pSWIMLC.F31D);
                param.Add("@F31E", save.pSWIMLC.F31E);
                param.Add("@F32B", save.pSWIMLC.F32B);
                param.Add("@F33B", save.pSWIMLC.F33B);
                param.Add("@F34B", save.pSWIMLC.F34B);
                param.Add("@F39A", save.pSWIMLC.F39A);
                param.Add("@F39B", save.pSWIMLC.F39B);
                param.Add("@F39C", save.pSWIMLC.F39C);
                param.Add("@F40A", save.pSWIMLC.F40A);
                param.Add("@F40E", save.pSWIMLC.F40E);
                param.Add("@F40F", save.pSWIMLC.F40F);
                param.Add("@F41A", save.pSWIMLC.F41A);
                param.Add("@F41D", save.pSWIMLC.F41D);
                param.Add("@F41UID", save.pSWIMLC.F41UID);
                param.Add("@F42A", save.pSWIMLC.F42A);
                param.Add("@F42D", save.pSWIMLC.F42D);
                param.Add("@F42UID", save.pSWIMLC.F42UID);
                param.Add("@F42C", save.pSWIMLC.F42C);
                param.Add("@F42M", save.pSWIMLC.F42M);
                param.Add("@F42P", save.pSWIMLC.F42P);
                param.Add("@F43P", save.pSWIMLC.F43P);
                param.Add("@F43T", save.pSWIMLC.F43T);
                param.Add("@F44A", save.pSWIMLC.F44A);
                param.Add("@F44B", save.pSWIMLC.F44B);
                param.Add("@F44C", save.pSWIMLC.F44C);
                param.Add("@F44D", save.pSWIMLC.F44D);
                param.Add("@F44E", save.pSWIMLC.F44E);
                param.Add("@F44F", save.pSWIMLC.F44F);
                param.Add("@F48", save.pSWIMLC.F48);
                param.Add("@F49", save.pSWIMLC.F49);
                param.Add("@F50", save.pSWIMLC.F50);
                param.Add("@F51A", save.pSWIMLC.F51A);
                param.Add("@F51D", save.pSWIMLC.F51D);
                param.Add("@F51UID", save.pSWIMLC.F51UID);
                param.Add("@F53A", save.pSWIMLC.F53A);
                param.Add("@F53D", save.pSWIMLC.F53D);
                param.Add("@F53UID", save.pSWIMLC.F53UID);
                param.Add("@F57A", save.pSWIMLC.F57A);
                param.Add("@F57D", save.pSWIMLC.F57D);
                param.Add("@F57UID", save.pSWIMLC.F57UID);
                param.Add("@F58A", save.pSWIMLC.F58A);
                param.Add("@F58D", save.pSWIMLC.F58D);
                param.Add("@F58UID", save.pSWIMLC.F58UID);
                param.Add("@F59", save.pSWIMLC.F59);
                param.Add("@F59UID", save.pSWIMLC.F59UID);
                param.Add("@F71B", save.pSWIMLC.F71B);
                param.Add("@F72", save.pSWIMLC.F72);
                param.Add("@F78", save.pSWIMLC.F78);
                param.Add("@F79", save.pSWIMLC.F79);
                param.Add("@F25", save.pSWIMLC.F25);
                param.Add("@F77A", save.pSWIMLC.F77A);
                param.Add("@F71A", save.pSWIMLC.F71A);
                param.Add("@F21_X", save.pSWIMLC.F21_X);
                param.Add("@F27_X", save.pSWIMLC.F27_X);
                param.Add("@F72_X", save.pSWIMLC.F72_X);
                param.Add("@F71B_X", save.pSWIMLC.F71B_X);
                param.Add("@F41Flag", save.pSWIMLC.F41Flag);
                param.Add("@F79C", save.pSWIMLC.F79C);
                param.Add("@F21C", save.pSWIMLC.F21C);
                param.Add("@F20", save.pSWIMLC.F20);
                param.Add("@F58A1", save.pSWIMLC.F58A1);
                param.Add("@F58D1", save.pSWIMLC.F58D1);
                param.Add("@F58UID1", save.pSWIMLC.F58UID1);
                param.Add("@F57D1", save.pSWIMLC.F57D1);
                param.Add("@F57UID1", save.pSWIMLC.F57UID1);
                param.Add("@F23S", save.pSWIMLC.F23S);
                param.Add("@F22R", save.pSWIMLC.F22R);
                param.Add("@F57A1", save.pSWIMLC.F57A1);
                param.Add("@F31DX", save.pSWIMLC.F31DX);
                param.Add("@F59DX", save.pSWIMLC.F59DX);
                param.Add("@F59UIDX", save.pSWIMLC.F59UIDX);
                param.Add("@F50DX", save.pSWIMLC.F50DX);
                //param.Add("@", save.pSWIMLC.);

                //pIMLCGoods
                param.Add("@T45", save.pIMLCGoods.T45);
                param.Add("@Tm45", save.pIMLCGoods.Tm45);

                //pIMLCDocs
                param.Add("@T46", save.pIMLCDocs.T46);
                param.Add("@Tm46", save.pIMLCDocs.Tm46);

                //pIMLCCond
                param.Add("@T47", save.pIMLCCond.T47);
                param.Add("@Tm47", save.pIMLCCond.Tm47);

                //pSWImpText
                param.Add("@T49G", save.pSWImpText.T49G);
                param.Add("@T49H", save.pSWImpText.T49H);
                param.Add("@Tm49G", save.pSWImpText.Tm49G);
                param.Add("@Tm49H", save.pSWImpText.Tm49H);

                param.Add("@Resp", dbType: DbType.Int32,
                          direction: System.Data.ParameterDirection.Output,
                          size: 12800);

                param.Add("@SaveResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<IMLC_SaveAmendSWIFT_JSON_rsp, dynamic>(
                    storedProcedure: "usp_pIMLC_Amend_SaveSWIFT",
                    param);

                var Resp = param.Get<int>("@Resp");
                var SaveResp = param.Get<dynamic>("@SaveResp");

                //var Resp = param.Get<int>("@Resp");
                if (Resp > 0)
                {
                    IMLC_SaveAmendSWIFT_JSON_rsp jsonResponse = JsonSerializer.Deserialize<IMLC_SaveAmendSWIFT_JSON_rsp>(SaveResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Save Error";
                    response.Data = new IMLC_SaveAmendSWIFT_JSON_rsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new IMLC_SaveAmendSWIFT_JSON_rsp();
                return BadRequest(response);
            }

        }








    }
}