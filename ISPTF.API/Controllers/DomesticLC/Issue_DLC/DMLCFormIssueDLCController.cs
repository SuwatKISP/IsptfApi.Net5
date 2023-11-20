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
    public class DMLCFormIssueDLCController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        //private const string BUSINESS_TYPE = "4";
        //private const string EVENT_TYPE = "Accept Due";

        public DMLCFormIssueDLCController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }


        [HttpGet("select")]
        public async Task<ActionResult<Q_DMLC_Issue_Select_Response>> NewSelect(string? ListType, string? LoadLC, string? DLCNumber, int? DLCSeqno, string? RecType, string? Event, string? CustCode)
        {
            Q_DMLC_Issue_Select_Response response = new Q_DMLC_Issue_Select_Response();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(LoadLC))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, LoadLC is required";
                response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                return BadRequest(response);
            }
            if (LoadLC != "ISSUE" && LoadLC != "REOPEN" & LoadLC != "AMEND-OTH" && LoadLC != "REVERSE" )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LoadLC shoud be ISSUE, REOPEN, AMEND-OTH, REVERSE";
                response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                return BadRequest(response);
            }
            if (LoadLC == "ISSUE" && ListType != "EDIT" && ListType != "RELEASE")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LoadLC = ISSUE ListType should be EDIT, RELEASE";
                response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                return BadRequest(response);
            }
            if (LoadLC != "ISSUE" && ListType != "NEW" && ListType != "EDIT" && ListType != "RELEASE")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType should be NEW, EDIT, RELEASE";
                response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@LoadLC", LoadLC);
                param.Add("@DLCNumber", DLCNumber);
                param.Add("@DLCSeqno", DLCSeqno);
                param.Add("@RecType", RecType);
                param.Add("@Event", Event);
                param.Add("@CustCode", CustCode);


                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@IssueResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_DMLC_Issue_Select_JSON_rsp, dynamic>(
                            storedProcedure: "[usp_q_DMLC_IssueDLCListSelect]",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var IssueResp = param.Get<dynamic>("@IssueResp");

                if (Resp == 1)
                {
                    Q_DMLC_Issue_Select_JSON_rsp jsonResponse = JsonSerializer.Deserialize<Q_DMLC_Issue_Select_JSON_rsp>(IssueResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_DMLC_Issue_Select_JSON_rsp();
                return BadRequest(response);
            }
        }

        [HttpHead("Remark1/1.For Select LoadLC = ISSUE with ListType = EDIT")]
        [HttpHead("Remark2/2.For Select Menu AmendOther, ReOpenDLC, ReverseDLC")]
        [HttpHead("Remark3/3.ListType for Remark 2 = NEW, EDIT, RELEASE")]
        [HttpHead("Remark4/4.LoadLC for Remark 2 = AMEND-OTH, REOPEN, REVERSE ")]
        public async Task<ActionResult<IMLCResultResponse>> Remark([FromBody] IMLC_RemarkAmend_JSON_req save)
        {
            IMLCResultResponse response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            try
            {
                DynamicParameters param = new DynamicParameters();
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
        public async Task<ActionResult<DMLC_SaveIssueForm_Response>> Save([FromBody] DMLC_SaveIssueForm_JSON_req save)
        {
            DMLC_SaveIssueForm_Response response = new();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
            // Class validate
            if (string.IsNullOrEmpty(save.ListType.LoadLC))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LoadLC is required";
                response.Data = new DMLC_SaveIssueForm_JSON_rsp();
                return BadRequest(response);
            }
            if (save.ListType.LoadLC != "ISSUE" && save.ListType.LoadLC != "REOPEN" && save.ListType.LoadLC != "AMEND-OTH" && save.ListType.LoadLC != "REVERSE")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType should be ISSUE, REOPEN, AMENT-OTH, REVERSE";
                response.Data = new DMLC_SaveIssueForm_JSON_rsp();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new DynamicParameters();

                //ListType
                param.Add("@LoadLC", save.ListType.LoadLC);
                param.Add("@ls_FacNo", save.ListType.ls_FacNo);
                param.Add("@ls_AppvNo", save.ListType.ls_AppvNo);

                //pDOMLC
                param.Add("@DLCNumber", save.pDOMLC.DLCNumber);
                param.Add("@RecType", save.pDOMLC.RecType);
                param.Add("@DLCSeqno", save.pDOMLC.DLCSeqno);
                param.Add("@DLCStatus", save.pDOMLC.DLCStatus);
                param.Add("@EventMode", save.pDOMLC.EventMode);
                param.Add("@Event", save.pDOMLC.Event);
                param.Add("@EventDate", save.pDOMLC.EventDate);
                param.Add("@EventFlag", save.pDOMLC.EventFlag);
                param.Add("@RecStatus", save.pDOMLC.RecStatus);
                param.Add("@InUse", save.pDOMLC.InUse);
                param.Add("@LOCode", save.pDOMLC.LOCode);
                param.Add("@AOCode", save.pDOMLC.AOCode);
                param.Add("@AmendSeq", save.pDOMLC.AmendSeq);
                param.Add("@AmendNo", save.pDOMLC.AmendNo);
                param.Add("@DLCMove", save.pDOMLC.DLCMove);
                param.Add("@DLCRefNo", save.pDOMLC.DLCRefNo);
                param.Add("@DateIssue", save.pDOMLC.DateIssue);
                param.Add("@NoVary", save.pDOMLC.NoVary);
                param.Add("@DLCCcy", save.pDOMLC.DLCCcy);
                param.Add("@DLCAmt", save.pDOMLC.DLCAmt);
                param.Add("@DLCBal", save.pDOMLC.DLCBal);
                param.Add("@DLCAvalBal", save.pDOMLC.DLCAvalBal);
                param.Add("@DLCNet", save.pDOMLC.DLCNet);
                param.Add("@BillAmount", save.pDOMLC.BillAmount);
                param.Add("@DLCPostAmt", save.pDOMLC.DLCPostAmt);
                param.Add("@AllowPlus", save.pDOMLC.AllowPlus);
                param.Add("@AllowMinus", save.pDOMLC.AllowMinus);
                param.Add("@AmendFlag", save.pDOMLC.AmendFlag);
                param.Add("@AmendAmt", save.pDOMLC.AmendAmt);
                param.Add("@AmendPlus", save.pDOMLC.AmendPlus);
                param.Add("@AmendMinus", save.pDOMLC.AmendMinus);
                param.Add("@DEPlus_flag", save.pDOMLC.DEPlus_flag);
                param.Add("@PrevDLCAmt", save.pDOMLC.PrevDLCAmt);
                param.Add("@PrevDLCBal", save.pDOMLC.PrevDLCBal);
                param.Add("@PrevDLCAvalBal", save.pDOMLC.PrevDLCAvalBal);
                param.Add("@PrevDLCNet", save.pDOMLC.PrevDLCNet);
                param.Add("@PrevDateExpiry", save.pDOMLC.PrevDateExpiry);
                param.Add("@DateExpiry", save.pDOMLC.DateExpiry);
                param.Add("@LCDays", save.pDOMLC.LCDays);
                param.Add("@PrevLCDays", save.pDOMLC.PrevLCDays);
                param.Add("@TenorType", save.pDOMLC.TenorType);
                param.Add("@TenorDay", save.pDOMLC.TenorDay);
                param.Add("@TenorTerm", save.pDOMLC.TenorTerm);
                param.Add("@CustCode", save.pDOMLC.CustCode);
                param.Add("@CustAddr", save.pDOMLC.CustAddr);
                param.Add("@BenCode", save.pDOMLC.BenCode);
                param.Add("@BenInfo", save.pDOMLC.BenInfo);
                param.Add("@PrevBenCode", save.pDOMLC.PrevBenCode);
                param.Add("@PrevBenInfo", save.pDOMLC.PrevBenInfo);
                param.Add("@DateLateShip", save.pDOMLC.DateLateShip);
                param.Add("@PresentDay", save.pDOMLC.PresentDay);
                param.Add("@TranShipment", save.pDOMLC.TranShipment);
                param.Add("@PartialShipment", save.pDOMLC.PartialShipment);
                param.Add("@GoodsCode", save.pDOMLC.GoodsCode);
                param.Add("@PurposeCode", save.pDOMLC.PurposeCode);
                param.Add("@GoodsDesc", save.pDOMLC.GoodsDesc);
                param.Add("@SpecialInfo", save.pDOMLC.SpecialInfo);
                param.Add("@InvoiceInfo", save.pDOMLC.InvoiceInfo);
                param.Add("@ExchRate", save.pDOMLC.ExchRate);
                param.Add("@CommLCRate", save.pDOMLC.CommLCRate);
                param.Add("@TaxRefund", save.pDOMLC.TaxRefund);
                param.Add("@CableMail", save.pDOMLC.CableMail);
                param.Add("@PostageAmt", save.pDOMLC.PostageAmt);
                param.Add("@CommAmt", save.pDOMLC.CommAmt);
                param.Add("@DutyStamp", save.pDOMLC.DutyStamp);
                param.Add("@PayableStamp", save.pDOMLC.PayableStamp);
                param.Add("@OthCharge", save.pDOMLC.OthCharge);
                param.Add("@AmendAmtDec", save.pDOMLC.AmendAmtDec);
                param.Add("@AmendAmtInc", save.pDOMLC.AmendAmtInc);
                param.Add("@TaxAmt", save.pDOMLC.TaxAmt);
                param.Add("@PayFlag", save.pDOMLC.PayFlag);
                param.Add("@PayMethod", save.pDOMLC.PayMethod);
                param.Add("@PayRemark", save.pDOMLC.PayRemark);
                param.Add("@DateLastPaid", save.pDOMLC.DateLastPaid);
                param.Add("@LastReceiptNo", save.pDOMLC.LastReceiptNo);
                param.Add("@AppvNo", save.pDOMLC.AppvNo);
                param.Add("@TRAppvNo", save.pDOMLC.TRAppvNo);
                param.Add("@FacNo", save.pDOMLC.FacNo);
                //param.Add("@UpdateDate", save.pDOMLC.UpdateDate);
                param.Add("@UserCode", USER_ID);
                //param.Add("@AuthDate", save.pDOMLC.AuthDate);
                //param.Add("@AuthCode", save.pDOMLC.AuthCode);
                param.Add("@GenAccFlag", save.pDOMLC.GenAccFlag);
                param.Add("@DateGenAcc", save.pDOMLC.DateGenAcc);
                param.Add("@VoucherID", save.pDOMLC.VoucherID);
                param.Add("@DMS", save.pDOMLC.DMS);
                param.Add("@Allocation", save.pDOMLC.Allocation);
                param.Add("@ShipmentFrom", save.pDOMLC.ShipmentFrom);
                param.Add("@ShipmentTo", save.pDOMLC.ShipmentTo);
                param.Add("@CenterID", USER_CENTER_ID);
                param.Add("@CCS_ACCT", save.pDOMLC.CCS_ACCT);
                param.Add("@CCS_LmType", save.pDOMLC.CCS_LmType);
                param.Add("@CCS_CNUM", save.pDOMLC.CCS_CNUM);
                param.Add("@CCS_CIFRef", save.pDOMLC.CCS_CIFRef);
                param.Add("@BPOFlag", save.pDOMLC.BPOFlag);
                param.Add("@Campaign_Code", save.pDOMLC.Campaign_Code);
                param.Add("@Campaign_EffDate", save.pDOMLC.Campaign_EffDate);

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

                var results = await _db.LoadData<DMLC_SaveIssueForm_JSON_rsp, dynamic>(
                    storedProcedure: "usp_pDOMLC_IssueDLC_Save",
                    param);

                var Resp = param.Get<int>("@Resp");
                var SaveResp = param.Get<dynamic>("@SaveResp");

                //var Resp = param.Get<int>("@Resp");
                if (Resp > 0)
                {
                    DMLC_SaveIssueForm_JSON_rsp jsonResponse = JsonSerializer.Deserialize<DMLC_SaveIssueForm_JSON_rsp>(SaveResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Save Error";
                    response.Data = new DMLC_SaveIssueForm_JSON_rsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new DMLC_SaveIssueForm_JSON_rsp();
                return BadRequest(response);
            }

        }

        [HttpPost("release")]
        public async Task<ActionResult<DMLCResultResponse>> Release([FromBody] DMLC_ReleaseIssueForm_JSON_req release)
        {
            DMLCResultResponse response = new();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
            // Class validate
            //if (saveissue.pIMTR.ListType != "NEW" && saveissue.pIMTR.ListType != "EDIT")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be NEW or EDIT";
            //    response.Data = new IMTR_SaveIssue_JSON_rsp();
            //    return BadRequest(response);
            //}

            DynamicParameters param = new DynamicParameters();

            //ListType
            param.Add("@LoadLC", release.ListType.LoadLC);
            param.Add("@LbLCAmt", release.ListType.LbLCAmt);
            param.Add("@LbLCAvalBal", release.ListType.LbLCAvalBal);

            //pDOMLC
            param.Add("@DLCNumber", release.pDOMLC.DLCNumber);
            param.Add("@RecType", release.pDOMLC.RecType);
            param.Add("@DLCSeqno", release.pDOMLC.DLCSeqno);
            param.Add("@Event", release.pDOMLC.Event);
            param.Add("@RecStatus", release.pDOMLC.RecStatus);
            param.Add("@DLCAmt", release.pDOMLC.DLCAmt);
            param.Add("@UserCode", USER_ID);
            //param.Add("@", release.);

            //UpdateAmend
            param.Add("@MaskEvent", release.UpdateAmend.MaskEvent);
            param.Add("@TxAmendSeq", release.UpdateAmend.TxAmendSeq);
            param.Add("@MaskExpiry", release.UpdateAmend.MaskExpiry);
            param.Add("@CmbTenor", release.UpdateAmend.CmbTenor);
            param.Add("@TxTenorDay", release.UpdateAmend.TxTenorDay);
            param.Add("@CmbTerm", release.UpdateAmend.CmbTerm);
            param.Add("@TxBen", release.UpdateAmend.TxBen);
            param.Add("@TxBenAddr", release.UpdateAmend.TxBenAddr);
            param.Add("@OldBenCode", release.UpdateAmend.OldBenCode);
            param.Add("@OldBenInfo", release.UpdateAmend.OldBenInfo);
            param.Add("@MaskShip", release.UpdateAmend.MaskShip);
            param.Add("@TxPreDay", release.UpdateAmend.TxPreDay);
            param.Add("@OpPartYes", release.UpdateAmend.OpPartYes);
            param.Add("@OpTransyes", release.UpdateAmend.OpTransyes);
            param.Add("@TxGoods", release.UpdateAmend.TxGoods);
            param.Add("@LbPurCode", release.UpdateAmend.LbPurCode); 
            param.Add("@TxGoods01", release.UpdateAmend.TxGoods01);
            param.Add("@TxCommRate", release.UpdateAmend.TxCommRate);
            param.Add("@OpTaxYes", release.UpdateAmend.OpTaxYes);
            param.Add("@TxTaxAmt", release.UpdateAmend.TxTaxAmt);
            param.Add("@OpPaid", release.UpdateAmend.OpPaid);
            param.Add("@CmbPayment", release.UpdateAmend.CmbPayment);
            param.Add("@TxCommAmt", release.UpdateAmend.TxCommAmt);
            param.Add("@TxDutyAmt", release.UpdateAmend.TxDutyAmt);
            param.Add("@TxPayable", release.UpdateAmend.TxPayable);
            param.Add("@TxOthAmt", release.UpdateAmend.TxOthAmt);
            //param.Add("@", release.UpdateAmend.);
            //param.Add("@", release.UpdateAmend.);


            param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pDOMLC_IssueDLC_Release", param);
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
        public async Task<ActionResult<DMLCResultResponse>> delete([FromBody] DMLC_DeleteIssueForm_JSON_req release)
        {
            DMLCResultResponse response = new();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
            // Class validate
            //if (saveissue.pIMTR.ListType != "NEW" && saveissue.pIMTR.ListType != "EDIT")
            //{
            //    response.Code = Constants.RESPONSE_FIELD_REQUIRED;
            //    response.Message = "ListType should be NEW or EDIT";
            //    response.Data = new IMTR_SaveIssue_JSON_rsp();
            //    return BadRequest(response);
            //}

            DynamicParameters param = new DynamicParameters();

            //ListType
            param.Add("@LoadLC", release.ListType.LoadLC);

            //pDOMLC
            param.Add("@DLCNumber", release.pDOMLC.DLCNumber);
            param.Add("@RecType", release.pDOMLC.RecType);
            param.Add("@DLCSeqno", release.pDOMLC.DLCSeqno);
            param.Add("@UserCode", USER_ID);
            //param.Add("@", release.);

            param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pDOMLC_IssueDLC_Delete", param);
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





























    }
}
