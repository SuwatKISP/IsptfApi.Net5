using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.DomesticLC;
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
    public class DMLCEditAdjustBEController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        //private const string BUSINESS_TYPE = "4";
        //private const string EVENT_TYPE = "Accept Due";

        public DMLCEditAdjustBEController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

   
        [HttpGet("list")]
        public async Task<ActionResult<EditAdjustBEListPageResponse>> List(string? ListType,string? CenterID, string? @BENumber, string? CustCode, string? @CustName, string? Page, string? PageSize)
        {
            EditAdjustBEListPageResponse response = new EditAdjustBEListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || string.IsNullOrEmpty(Page) || string.IsNullOrEmpty(PageSize))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EditAdjustBEListPageRsp>();
                return BadRequest(response);
            }
            if (ListType == "RELEASE" && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EditAdjustBEListPageRsp>();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@CenterID", CenterID);
                param.Add("@BENumber", BENumber);
                param.Add("@CustCode", CustCode);
                param.Add("@CustName", CustName);
                param.Add("@UserCode", USER_ID);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                if (BENumber == null)
                {
                    param.Add("@BENumber", "");
                }
                if (CustCode == null)
                {
                    param.Add("@CustCode", "");
                }
                if (CustName == null)
                {
                    param.Add("@CustName", "");
                }

                var results = await _db.LoadData<Q_EditAdjustBEListPageRsp, dynamic>(
                            storedProcedure: "usp_q_DMLC_EditAdjustBEListPage",
                            param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EditAdjustBEListPageRsp>)results;

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
                response.Data = new List<Q_EditAdjustBEListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("select")]
        public async Task<ActionResult<Q_DMLC_EditAdjustBE_Select_Response>> ListSelect(string? ListType, string? BENumber, int? BESeqno, string? RecType, string? Event, string? CustCode)
        {
            Q_DMLC_EditAdjustBE_Select_Response response = new Q_DMLC_EditAdjustBE_Select_Response();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(ListType))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType is required";
                response.Data = new Q_DMLC_EditAdjustBE_Select_JSON_rsp();
                return BadRequest(response);
            }

            if (ListType != "NEW" && ListType != "EDIT" && ListType != "RELEASE")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType should be NEW, EDIT, RELEASE";
                response.Data = new Q_DMLC_EditAdjustBE_Select_JSON_rsp();
                return BadRequest(response);
            }

            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@BENumber", BENumber);
                param.Add("@BESeqno", BESeqno);
                param.Add("@RecType", RecType);
                param.Add("@Event", Event);
                param.Add("@CustCode", CustCode);


                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@SelectResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_DMLC_EditAdjustBE_Select_JSON_rsp, dynamic>(
                            storedProcedure: "usp_q_DMLC_EditAdjustBEListSelect",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var SelectResp = param.Get<dynamic>("@SelectResp");

                if (Resp == 1)
                {
                    Q_DMLC_EditAdjustBE_Select_JSON_rsp jsonResponse = JsonSerializer.Deserialize<Q_DMLC_EditAdjustBE_Select_JSON_rsp>(SelectResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_DMLC_EditAdjustBE_Select_JSON_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_DMLC_EditAdjustBE_Select_JSON_rsp();
                return BadRequest(response);
            }
        }

        [HttpPost("save")]
        public async Task<ActionResult<DMLC_SaveEditAdjustBE_Response>> Save([FromBody] DMLC_SaveEditAdjustBE_JSON_req save)
        {
            DMLC_SaveEditAdjustBE_Response response = new();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();
            // Class validate
            if (string.IsNullOrEmpty(save.ListType.ListType))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType is required";
                response.Data = new DMLC_SaveEditAdjustBE_JSON_rsp();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new DynamicParameters();

                //ListType
                param.Add("@ListType", save.ListType.ListType);
                param.Add("@LoadBL", save.ListType.LoadBL);

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

                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@SaveResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<DMLC_SaveEditAdjustBE_JSON_rsp, dynamic>(
                    storedProcedure: "usp_pDOMBE_EditAdjustBE_Save",
                    param);

                var Resp = param.Get<int>("@Resp");
                var SaveResp = param.Get<dynamic>("@SaveResp");

                //var Resp = param.Get<int>("@Resp");
                if (Resp > 0)
                {
                    DMLC_SaveEditAdjustBE_JSON_rsp jsonResponse = JsonSerializer.Deserialize<DMLC_SaveEditAdjustBE_JSON_rsp>(SaveResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Save Error";
                    response.Data = new DMLC_SaveEditAdjustBE_JSON_rsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new DMLC_SaveEditAdjustBE_JSON_rsp();
                return BadRequest(response);
            }

        }

        [HttpPost("release")]
        public async Task<ActionResult<DMLCResultResponse>> Release([FromBody] DMLC_ReleaseEditAdjustBE_JSON_req release)
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
            param.Add("@LoadBL", release.ListType.LoadBL);
            param.Add("@DmaskNewDate", release.ListType.DmaskNewDate);
            param.Add("@MaskNewDate", release.ListType.MaskNewDate);
            param.Add("@MaskStartInt", release.ListType.MaskStartInt);

            //pDOMBE
            //param.Add("@", release.);
            param.Add("@BENumber", release.pDOMBE.BENumber);
            param.Add("@RecType", release.pDOMBE.RecType);
            param.Add("@BESeqno", release.pDOMBE.BESeqno);
            param.Add("@AutoOverDue", release.pDOMBE.AutoOverDue);
            param.Add("@TenorType", release.pDOMBE.TenorType);
            param.Add("@DueDate", release.pDOMBE.DueDate);
            param.Add("@IntRateCode", release.pDOMBE.IntRateCode);
            param.Add("@IntRate", release.pDOMBE.IntRate);
            param.Add("@IntSpread", release.pDOMBE.IntSpread);
            param.Add("@IntFlag", release.pDOMBE.IntFlag);
            param.Add("@IntBaseDay", release.pDOMBE.IntBaseDay);
            param.Add("@UserCode", USER_ID);
            param.Add("@CenterID", USER_CENTER_ID);

            param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pDOMBE_EditAdjustBE_Release", param);
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
        public async Task<ActionResult<DMLCResultResponse>> delete([FromBody] DMLC_DeleteEditAdjustBE_JSON_req delete)
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
            //param.Add("@LoadLC", delete.ListType.LoadLC);

            //pDOMLC
            param.Add("@BENumber", delete.pDOMBE.BENumber);
            param.Add("@BESeqno", delete.pDOMBE.BESeqno);
            param.Add("@UserCode", USER_ID);
            param.Add("@CenterID", USER_CENTER_ID);
            //param.Add("@", release.);

            param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pDOMBE_EditAdjustBE_Delete", param);
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
