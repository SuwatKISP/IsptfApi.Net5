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
    public class IMLC_CollectRefundController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;
        public IMLC_CollectRefundController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("listpage")]
        public async Task<ActionResult<Q_IMLC_CollectRefund_ListPage_Response>> ListPage(string? ListType, string? LCNumber, string CustCode, string? CustName, string? CenterID, string? Page, string? PageSize)
        {
            Q_IMLC_CollectRefund_ListPage_Response response = new Q_IMLC_CollectRefund_ListPage_Response();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_IMLC_CollectRefund_ListPage_rsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_IMLC_CollectRefund_ListPage_rsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@LCNumber", LCNumber);
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
                if (LCNumber == null)
                {
                    param.Add("@LCNumber", "");
                }


                var results = await _db.LoadData<Q_IMLC_CollectRefund_ListPage_rsp, dynamic>(
                            storedProcedure: "usp_q_IMLC_CollectRefundListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_IMLC_CollectRefund_ListPage_rsp>)results;

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
                response.Data = new List<Q_IMLC_CollectRefund_ListPage_rsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("Select")]
        public async Task<ActionResult<Q_IMLC_CollectRefund_Select_Response>> Select(string? LCNumber, string? LCSeqno, string? RecType, string? Event)
        {
            Q_IMLC_CollectRefund_Select_Response response = new Q_IMLC_CollectRefund_Select_Response();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(LCNumber) || string.IsNullOrEmpty(LCSeqno) ||
                string.IsNullOrEmpty(RecType) || string.IsNullOrEmpty(Event))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LCNumber, LCSeqno, RecType, Event are required";
                response.Data = new Q_IMLC_CollectRefund_Select_JSON_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@LCNumber", LCNumber);
                param.Add("@LCSeqno", LCSeqno);
                param.Add("@Event", Event);
                param.Add("@RecType", RecType);

                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@ListResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_IMLC_CollectRefund_Select_JSON_rsp, dynamic>(
                            storedProcedure: "usp_Q_IMLC_CollectRefundSelect",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var ListResp = param.Get<dynamic>("@ListResp");

                if (Resp == 1)
                {
                    Q_IMLC_CollectRefund_Select_JSON_rsp jsonResponse = JsonSerializer.Deserialize<Q_IMLC_CollectRefund_Select_JSON_rsp>(ListResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_IMLC_CollectRefund_Select_JSON_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_IMLC_CollectRefund_Select_JSON_rsp();
                return BadRequest(response);
            }
        }

        [HttpPost("save")]
        public async Task<ActionResult<IMLC_SaveCollectRefund_Response>> Save([FromBody] IMLC_SaveCollectRefund_JSON_req save)
        {
            IMLC_SaveCollectRefund_Response response = new();
            var USER_ID = User.Identity.Name;
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
                param.Add("@RecType", save.pIMLC.RecType);
                param.Add("@LCSeqno", save.pIMLC.LCSeqno);
                param.Add("@CenterID", save.pIMLC.CenterID);
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
                param.Add("@UserCode", save.pIMLC.UserCode);
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

  
                //pPayment
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


                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@SaveResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<IMLC_SaveCollectRefund_JSON_rsp, dynamic>(
                    storedProcedure: "usp_pIMLC_CollectRefund_Save",
                    param);

                var Resp = param.Get<int>("@Resp");
                var SaveResp = param.Get<dynamic>("@SaveResp");

                //var Resp = param.Get<int>("@Resp");
                if (Resp > 0)
                {
                    IMLC_SaveCollectRefund_JSON_rsp jsonResponse = JsonSerializer.Deserialize<IMLC_SaveCollectRefund_JSON_rsp>(SaveResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Save Error";
                    response.Data = new IMLC_SaveCollectRefund_JSON_rsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new IMLC_SaveCollectRefund_JSON_rsp();
                return BadRequest(response);
            }

        }

        [HttpPost("release")]
        public async Task<ActionResult<IMLCResultResponse>> Release([FromBody] IMLC_ReleaseCollectRefund_JSON_req release)
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


                //pIMTR
                param.Add("@LCNumber", release.pIMLC.LCNumber);
                param.Add("@LCSeqno", release.pIMLC.LCSeqno);
                param.Add("@CenterID", release.pIMLC.CenterID);
                param.Add("@UserCode", release.pIMLC.UserCode);
                param.Add("@CollectRefund", release.pIMLC.CollectRefund);
                param.Add("@LastReceiptNo", release.pIMLC.LastReceiptNo);
                param.Add("@CommAmt", release.pIMLC.CommAmt);
                param.Add("@CableAmt", release.pIMLC.CableAmt);
                param.Add("@PostageAmt", release.pIMLC.PostageAmt);
                param.Add("@DutyAmt", release.pIMLC.DutyAmt);
                param.Add("@PayableAmt", release.pIMLC.PayableAmt);
                param.Add("@OtherAmt", release.pIMLC.OtherAmt);

                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                await _db.SaveData(
                  storedProcedure: "usp_pIMLC_CollectRefund_Release", param);
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
        public async Task<ActionResult<IMLCResultResponse>> Delete([FromBody] IMLC_DeleteCollectRefund_JSON_req delete)
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


                //pIMTR
                param.Add("@LCNumber", delete.pIMLC.LCNumber);
                param.Add("@LCSeqno", delete.pIMLC.LCSeqno);
                param.Add("@CenterID", delete.pIMLC.CenterID);
                param.Add("@UserCode", delete.pIMLC.UserCode);
                param.Add("@CollectRefund", delete.pIMLC.CollectRefund);
                param.Add("@LastReceiptNo", delete.pIMLC.LastReceiptNo);
 
                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                await _db.SaveData(
                  storedProcedure: "usp_pIMLC_CollectRefund_Delete", param);
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