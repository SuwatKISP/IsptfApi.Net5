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
    public class DMLCIFormDBEIssueController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        private readonly ISPTFContext _context;

        //private const string BUSINESS_TYPE = "4";
        //private const string EVENT_TYPE = "Accept Due";

        public DMLCIFormDBEIssueController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("select")]
        public async Task<ActionResult<Q_DMLC_IssueDBE_Select_Response>> Select(string? ListType, string? LoadBL, string? BENumber, string? RecType, int? BESeqno, string? Event, string? RecStatus, string? CustCode)
        {
            Q_DMLC_IssueDBE_Select_Response response = new Q_DMLC_IssueDBE_Select_Response();
            var USER_ID = User.Identity.Name;
            //var USER_ID = "API";
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(LoadBL))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, LoadBL is required";
                response.Data = new Q_DMLC_IssueDBE_Select_JSON_rsp();
                return BadRequest(response);
            }
            if (LoadBL != "BEISSUE" && LoadBL != "BEREVERSE" )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LoadBL shoud be BEISSUE, BEREVERSE";
                response.Data = new Q_DMLC_IssueDBE_Select_JSON_rsp();
                return BadRequest(response);
            }
            if (ListType == "NEW" && LoadBL == "BEISSUE")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType shoud be EDIT, RELEASE for LoadBL is BEISSUE";
                response.Data = new Q_DMLC_IssueDBE_Select_JSON_rsp();
                return BadRequest(response);
            }


            // Call Store Procedure
            try
            {
                DynamicParameters param = new();
                param.Add("@ListType", ListType);
                param.Add("@LoadBL", LoadBL);
                param.Add("@BENumber", BENumber);
                param.Add("@RecType", RecType);
                param.Add("@BESeqno", BESeqno);
                param.Add("@Event", Event);
                param.Add("@RecStatus", RecStatus);
                param.Add("@CustCode", CustCode);


                param.Add("@Resp", dbType: DbType.Int32,
                   direction: System.Data.ParameterDirection.Output,
                   size: 12800);

                param.Add("@IssueResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);


                var results = await _db.LoadData<Q_DMLC_IssueDBE_Select_JSON_rsp, dynamic>(
                            storedProcedure: "[usp_q_DMLC_IssueDBEListSelect]",
                            param);

                var Resp = param.Get<dynamic>("@Resp");
                var IssueResp = param.Get<dynamic>("@IssueResp");

                if (Resp == 1)
                {
                    Q_DMLC_IssueDBE_Select_JSON_rsp jsonResponse = JsonSerializer.Deserialize<Q_DMLC_IssueDBE_Select_JSON_rsp>(IssueResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse; // (List<Q_Inq_CreditLimit_SumAndTotal_rsp>)results;
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "No Data";
                    response.Data = new Q_DMLC_IssueDBE_Select_JSON_rsp();
                    return BadRequest(response);
                }

            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new Q_DMLC_IssueDBE_Select_JSON_rsp();
                return BadRequest(response);
            }
        }

        [HttpHead("Remark1/1.For Select LoadBL = BEISSUE with ListType = EDIT")]
        [HttpHead("Remark2/2.For Select Menu Reverse Drawn Bills")]
        [HttpHead("Remark3/3.ListType for Remark 2 = NEW, EDIT, RELEASE")]
        [HttpHead("Remark4/4.LoadBL for Remark 2 = BEREVERSE ")]
        public async Task<ActionResult<IMLCResultResponse>> RemarkList([FromBody] IMLC_RemarkAmend_JSON_req save)
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
        public async Task<ActionResult<DMLC_SaveIssueDBE_Response>> Save([FromBody] DMLC_SaveIssueDBE_JSON_req save)
        {
            DMLC_SaveIssueDBE_Response response = new();
            var USER_ID = User.Identity.Name;
            // Class validate
            if (string.IsNullOrEmpty(save.ListType.LoadBL))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "LoadLC is required";
                response.Data = new DMLC_SaveIssueDBE_JSON_rsp();
                return BadRequest(response);
            }
            if (save.ListType.LoadBL != "BEISSUE" && save.ListType.LoadBL != "BEREVERSE")
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType should be BEISSUE, BEREVERSE";
                response.Data = new DMLC_SaveIssueDBE_JSON_rsp();
                return BadRequest(response);
            }

            try
            {
                DynamicParameters param = new DynamicParameters();

                //ListType
                param.Add("@ListType", save.ListType.ListType);
                param.Add("@LoadBL", save.ListType.LoadBL);
                param.Add("@ls_FacNo", save.ListType.ls_FacNo);
                param.Add("@ls_AppvNo", save.ListType.ls_AppvNo);

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
                param.Add("@UserCode", save.pDOMBE.UserCode);
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
                param.Add("@CenterID", save.pDOMBE.CenterID);
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

                var dtCust = new DataTable();
                //----pIMBLDocs-------------
                dtCust.Columns.Add("CenterID", typeof(string));
                dtCust.Columns.Add("ADNumber", typeof(string));
                dtCust.Columns.Add("SeqNo", typeof(int));
                dtCust.Columns.Add("DocDetails", typeof(string));
                dtCust.Columns.Add("OrgCopy", typeof(string));
                dtCust.Columns.Add("Copy", typeof(string));
                if (save.pIMBLDocs != null)
                {
                    for (int i = 0; i < save.pIMBLDocs.Length; i++)
                    {
                        dtCust.Rows.Add(
                            save.pIMBLDocs[i].CenterID,
                            save.pIMBLDocs[i].ADNumber,
                            save.pIMBLDocs[i].SeqNo,
                            save.pIMBLDocs[i].DocDetails,
                            save.pIMBLDocs[i].OrgCopy,
                            save.pIMBLDocs[i].Copy
                            );
                    }
                }
                param.Add("@pIMBLDocs", dtCust.AsTableValuedParameter("Type_pIMBLDocs"));

                param.Add("@Resp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@SaveResp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                var results = await _db.LoadData<DMLC_SaveIssueDBE_JSON_rsp, dynamic>(
                    storedProcedure: "usp_pDOMBE_IssueBE_Save",
                    param);

                var Resp = param.Get<int>("@Resp");
                var SaveResp = param.Get<dynamic>("@SaveResp");

                //var Resp = param.Get<int>("@Resp");
                if (Resp > 0)
                {
                    DMLC_SaveIssueDBE_JSON_rsp jsonResponse = JsonSerializer.Deserialize<DMLC_SaveIssueDBE_JSON_rsp>(SaveResp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Save Error";
                    response.Data = new DMLC_SaveIssueDBE_JSON_rsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new DMLC_SaveIssueDBE_JSON_rsp();
                return BadRequest(response);
            }

        }

        [HttpPost("release")]
        public async Task<ActionResult<DMLCResultResponse>> Release([FromBody] DMLC_ReleaseIssueDBE_JSON_req release)
        {
            DMLCResultResponse response = new();
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

            //ListType
            param.Add("@LoadBL", release.ListType.LoadBL);

            //pDOMBE
            param.Add("@BENumber", release.pDOMBE.BENumber);
            param.Add("@RecType", release.pDOMBE.RecType);
            param.Add("@BESeqno", release.pDOMBE.BESeqno);
            param.Add("@BEStatus", release.pDOMBE.BEStatus);
            param.Add("@RecStatus", release.pDOMBE.RecStatus);
            param.Add("@Event", release.pDOMBE.Event);
            param.Add("@EventDate", release.pDOMBE.EventDate);
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
            param.Add("@PayFlag", release.pDOMBE.PayFlag);
            param.Add("@LastReceiptNo", release.pDOMBE.LastReceiptNo);
            param.Add("@UserCode", release.pDOMBE.UserCode);

            param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pDOMBE_IssueBE_Release", param);
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
        public async Task<ActionResult<DMLCResultResponse>> Delete([FromBody] DMLC_DeleteIssueDBE_JSON_req delete)
        {
            DMLCResultResponse response = new();
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

            //ListType
            param.Add("@LoadBL", delete.ListType.LoadBL);

            //pDOMBE
            param.Add("@BENumber", delete.pDOMBE.BENumber);
            param.Add("@RecType", delete.pDOMBE.RecType);
            param.Add("@BESeqno", delete.pDOMBE.BESeqno);
            param.Add("@RecStatus", delete.pDOMBE.RecStatus);
            param.Add("@Event", delete.pDOMBE.Event);
            param.Add("@DLCNumber", delete.pDOMBE.DLCNumber);
            param.Add("@CustCode", delete.pDOMBE.CustCode);
            param.Add("@BECcy", delete.pDOMBE.BECcy);
            param.Add("@BEAmount", delete.pDOMBE.BEAmount);
            param.Add("@UserCode", delete.pDOMBE.UserCode);

            param.Add("@Resp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pDOMBE_IssueBE_Delete", param);
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
