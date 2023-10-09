using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;

namespace ISPTF.API.Controllers.ExportBC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXBCAcceptTermDueController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public EXBCAcceptTermDueController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXBCAcceptTermDueListPageResponse>> GetAllList(string? @ListType, string? CenterID, string? EXPORT_BC_NO, string? BENName, int? Page, int? PageSize)
        {
            EXBCAcceptTermDueListPageResponse response = new EXBCAcceptTermDueListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(@ListType) || string.IsNullOrEmpty(CenterID) || Page == null || PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXBCAcceptTermDueListPageRsp>();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@ListType", @ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@BENName", BENName);
            //param.Add("@USER_ID", USER_ID);
            param.Add("@USER_ID", USER_ID);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (EXPORT_BC_NO == null)
            {
                param.Add("@EXPORT_BC_NO", "");
            }
            if (BENName == null)
            {
                param.Add("@BENName", "");
            }

            try
            {
                var results = await _db.LoadData<Q_EXBCAcceptTermDueListPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXBC_AcceptTermDueListPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCAcceptTermDueListPageRsp>)results;
                try
                {
                    response.Page = (int)Page;
                    response.Total = (int)response.Data[0].RCount;
                    response.TotalPage = (int)((response.Total + PageSize - 1) / PageSize);
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
                response.Data = new List<Q_EXBCAcceptTermDueListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("query")]
        public async Task<ActionResult<EXBCAcceptTermDueQueryPageResponse>> GetAllQuery(string? CenterID, string? EXPORT_BC_NO, string? BENName, int? Page, int? PageSize)
        {
            EXBCAcceptTermDueQueryPageResponse response = new EXBCAcceptTermDueQueryPageResponse();
            var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) || Page == null || PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXBCAcceptTermDueQueryPageRsp>();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@CenterID", CenterID);
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@BENName", BENName);
            param.Add("@USER_ID", USER_ID);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);

            if (EXPORT_BC_NO == null)
            {
                param.Add("@EXPORT_BC_NO", "");
            }
            if (BENName == null)
            {
                param.Add("@BENName", "");
            }

            try
            {
                var results = await _db.LoadData<Q_EXBCAcceptTermDueQueryPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXBC_AcceptTermDueQueryPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCAcceptTermDueQueryPageRsp>)results;
                try
                {
                    response.Page = (int)Page;
                    response.Total = (int)response.Data[0].RCount;
                    response.TotalPage = (int)((response.Total + PageSize - 1) / PageSize);
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
                response.Data = new List<Q_EXBCAcceptTermDueQueryPageRsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("select")]
        public async Task<ActionResult<PEXBCPPaymentListResponse>> GetAllSelect(string? EXPORT_BC_NO, string? EVENT_NO, string? LFROM)
        {
            PEXBCPPaymentListResponse response = new PEXBCPPaymentListResponse();
            var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(EXPORT_BC_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO, EVENT_NO, LFROM is required";
                response.Data = new List<PEXBCPPaymentRsp>();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@EVENT_NO", EVENT_NO);
            param.Add("@LFROM", LFROM);

            param.Add("@PExBcRsp", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);
            param.Add("@PEXBCPPaymentRsp", dbType: DbType.String,
                       direction: System.Data.ParameterDirection.Output,
                       size: 5215585);
            try
            {
                var results = await _db.LoadData<PEXBCPPaymentRsp, dynamic>(
                            storedProcedure: "usp_pEXBC_AcceptTermDue_Select",
                            param);

                var PExBcRsp = param.Get<dynamic>("@PExBcRsp");
                var pexbcppaymentrsp = param.Get<dynamic>("@PEXBCPPaymentRsp");

                if (PExBcRsp > 0 && !string.IsNullOrEmpty(pexbcppaymentrsp))
                {
                    PEXBCPPaymentRsp jsonResponse = System.Text.Json.JsonSerializer.Deserialize<PEXBCPPaymentRsp>(pexbcppaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = new List<PEXBCPPaymentRsp>(){jsonResponse};
                    // response.Data = jsonResponse;
                    // response.Data = (List<PEXBCPPaymentRsp>)pexbcppaymentrsp;
                    response.Page = 1;
                    response.Total = response.Data.Count;
                    response.TotalPage = 1;

                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT B/C NO does not exit";
                    response.Data = new List<PEXBCPPaymentRsp>();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<PEXBCPPaymentRsp>();
            }
            return BadRequest(response);
        }

        [HttpPost("save")]
        public async Task<ActionResult<PEXBCPPaymentResponse>> Insert([FromBody] PEXBCPPaymentRsp pexbcppaymentreq)
        {
            PEXBCPPaymentResponse response = new PEXBCPPaymentResponse();
            // Validate
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

            // Validate
            if (pexbcppaymentreq.PEXBC == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "Export BC is required.";
                response.Data = new PEXBCPPaymentRsp();
                return BadRequest(response);
            }

            DynamicParameters param = new DynamicParameters();
            //PEXBC
            param.Add("@RECORD_TYPE", pexbcppaymentreq.PEXBC.RECORD_TYPE);
            param.Add("@REC_STATUS", pexbcppaymentreq.PEXBC.REC_STATUS);
            param.Add("@EVENT_NO", pexbcppaymentreq.PEXBC.EVENT_NO);
            param.Add("@EXPORT_BC_NO", pexbcppaymentreq.PEXBC.EXPORT_BC_NO);
            param.Add("@EVENT_MODE", pexbcppaymentreq.PEXBC.EVENT_MODE);
            param.Add("@BUSINESS_TYPE", pexbcppaymentreq.PEXBC.BUSINESS_TYPE);
            param.Add("@EVENT_TYPE", pexbcppaymentreq.PEXBC.EVENT_TYPE);
            param.Add("@EVENT_DATE", pexbcppaymentreq.PEXBC.EVENT_DATE);
            param.Add("@TENOR_OF_COLL", pexbcppaymentreq.PEXBC.TENOR_OF_COLL);
            param.Add("@TENOR_TYPE", pexbcppaymentreq.PEXBC.TENOR_TYPE);
            param.Add("@INVOICE", pexbcppaymentreq.PEXBC.INVOICE);
            param.Add("@REFER_BC_NO", pexbcppaymentreq.PEXBC.REFER_BC_NO);
            param.Add("@RELETE_PACK", pexbcppaymentreq.PEXBC.RELETE_PACK);
            param.Add("@DRAFT_CCY", pexbcppaymentreq.PEXBC.DRAFT_CCY);
            param.Add("@DRAFT_AMT", pexbcppaymentreq.PEXBC.DRAFT_AMT);
            param.Add("@SIGHT_AMT", pexbcppaymentreq.PEXBC.SIGHT_AMT);
            param.Add("@TERM_AMT", pexbcppaymentreq.PEXBC.TERM_AMT);
            param.Add("@GOOD_CODE", pexbcppaymentreq.PEXBC.GOOD_CODE);
            param.Add("@REL_CODE", pexbcppaymentreq.PEXBC.REL_CODE);
            param.Add("@CLAIM_TYPE", pexbcppaymentreq.PEXBC.CLAIM_TYPE);
            param.Add("@SIGHT_START_DATE", pexbcppaymentreq.PEXBC.SIGHT_START_DATE);
            param.Add("@SIGHT_DUE_DATE", pexbcppaymentreq.PEXBC.SIGHT_DUE_DATE);
            param.Add("@TENOR_DAY", pexbcppaymentreq.PEXBC.TENOR_DAY);
            param.Add("@TENOR_DAY_DESC", pexbcppaymentreq.PEXBC.TENOR_DAY_DESC);
            param.Add("@TERM_START_DATE", pexbcppaymentreq.PEXBC.TERM_START_DATE);
            param.Add("@TERM_DUE_DATE", pexbcppaymentreq.PEXBC.TERM_DUE_DATE);
            param.Add("@PURCH_DISC_DATE", pexbcppaymentreq.PEXBC.PURCH_DISC_DATE);
            param.Add("@DRAWEE_INFO", pexbcppaymentreq.PEXBC.DRAWEE_INFO);
            param.Add("@CNTY_CODE", pexbcppaymentreq.PEXBC.CNTY_CODE);
            param.Add("@Cust_AO", pexbcppaymentreq.PEXBC.Cust_AO);
            param.Add("@Cust_LO", pexbcppaymentreq.PEXBC.Cust_LO);
            param.Add("@BENE_ID", pexbcppaymentreq.PEXBC.BENE_ID);
            param.Add("@BENE_INFO", pexbcppaymentreq.PEXBC.BENE_INFO);
            param.Add("@ISSUE_BANK_ID", pexbcppaymentreq.PEXBC.ISSUE_BANK_ID);
            param.Add("@ISSUE_BANK_INFO", pexbcppaymentreq.PEXBC.ISSUE_BANK_INFO);
            param.Add("@COLLECT_AGENT", pexbcppaymentreq.PEXBC.COLLECT_AGENT);
            param.Add("@AGENT_BANK_ID", pexbcppaymentreq.PEXBC.AGENT_BANK_ID);
            param.Add("@AGENT_BANK_INFO", pexbcppaymentreq.PEXBC.AGENT_BANK_INFO);
            param.Add("@AGENT_BANK_REF", pexbcppaymentreq.PEXBC.AGENT_BANK_REF);
            param.Add("@AGENT_BANK_NOSTRO", pexbcppaymentreq.PEXBC.AGENT_BANK_NOSTRO);
            param.Add("@RESTRICT", pexbcppaymentreq.PEXBC.RESTRICT);
            param.Add("@RESTRICT_TO_BK_NAME", pexbcppaymentreq.PEXBC.RESTRICT_TO_BK_NAME);
            param.Add("@RESTRICT_TO_BK_ADDR1", pexbcppaymentreq.PEXBC.RESTRICT_TO_BK_ADDR1);
            param.Add("@RESTRICT_TO_BK_ADDR2", pexbcppaymentreq.PEXBC.RESTRICT_TO_BK_ADDR2);
            param.Add("@RESTRICT_TO_BK_ADDR3", pexbcppaymentreq.PEXBC.RESTRICT_TO_BK_ADDR3);
            param.Add("@RESTRICT_REFER", pexbcppaymentreq.PEXBC.RESTRICT_REFER);
            param.Add("@RESTRICT_FR_BK_NAME", pexbcppaymentreq.PEXBC.RESTRICT_FR_BK_NAME);
            param.Add("@RESTRICT_FR_BK_ADDR1", pexbcppaymentreq.PEXBC.RESTRICT_FR_BK_ADDR1);
            param.Add("@RESTRICT_FR_BK_ADDR2", pexbcppaymentreq.PEXBC.RESTRICT_FR_BK_ADDR2);
            param.Add("@RESTRICT_FR_BK_ADDR3", pexbcppaymentreq.PEXBC.RESTRICT_FR_BK_ADDR3);
            param.Add("@PARTIAL_FULL_RATE", pexbcppaymentreq.PEXBC.PARTIAL_FULL_RATE);
            param.Add("@INT_RATE_METHOD", pexbcppaymentreq.PEXBC.INT_RATE_METHOD);
            param.Add("@TYPE_OF_ACCOUNT", pexbcppaymentreq.PEXBC.TYPE_OF_ACCOUNT);
            param.Add("@CREDIT_CURRENCY", pexbcppaymentreq.PEXBC.CREDIT_CURRENCY);
            param.Add("@DISCOUNT_DAY", pexbcppaymentreq.PEXBC.DISCOUNT_DAY);
            param.Add("@GRACE_PERIOD", pexbcppaymentreq.PEXBC.GRACE_PERIOD);
            param.Add("@DISC_BASE_DAY", pexbcppaymentreq.PEXBC.DISC_BASE_DAY);
            param.Add("@BASE_DAY", pexbcppaymentreq.PEXBC.BASE_DAY);
            param.Add("@DISCOUNT_RATE", pexbcppaymentreq.PEXBC.DISCOUNT_RATE);
            param.Add("@INT_BASE_RATE", pexbcppaymentreq.PEXBC.INT_BASE_RATE);
            param.Add("@INT_SPREAD_RATE", pexbcppaymentreq.PEXBC.INT_SPREAD_RATE);
            param.Add("@CURRENT_DIS_RATE", pexbcppaymentreq.PEXBC.CURRENT_DIS_RATE);
            param.Add("@CURRENT_INT_RATE", pexbcppaymentreq.PEXBC.CURRENT_INT_RATE);
            param.Add("@PAY_BY", pexbcppaymentreq.PEXBC.PAY_BY);
            param.Add("@NEGO_AMT", pexbcppaymentreq.PEXBC.NEGO_AMT);
            param.Add("@LESS_AGENT", pexbcppaymentreq.PEXBC.LESS_AGENT);
            param.Add("@PURCHASE_AMT", pexbcppaymentreq.PEXBC.PURCHASE_AMT);
            param.Add("@PURCHASE_RATE", pexbcppaymentreq.PEXBC.PURCHASE_RATE);
            param.Add("@TOTAL_NEGO_BALANCE", pexbcppaymentreq.PEXBC.TOTAL_NEGO_BALANCE);
            param.Add("@TOTAL_NEGO_BAL_THB", pexbcppaymentreq.PEXBC.TOTAL_NEGO_BAL_THB);
            param.Add("@TOT_NEGO_AMT", pexbcppaymentreq.PEXBC.TOT_NEGO_AMT);
            param.Add("@TOT_NEGO_AMOUNT", pexbcppaymentreq.PEXBC.TOT_NEGO_AMOUNT);
            param.Add("@BANK_CHARGE_AMT", pexbcppaymentreq.PEXBC.BANK_CHARGE_AMT);
            param.Add("@NET_PROCEED_CLAIM", pexbcppaymentreq.PEXBC.NET_PROCEED_CLAIM);
            param.Add("@CLAIM_PAY_BY", pexbcppaymentreq.PEXBC.CLAIM_PAY_BY);
            param.Add("@ParTnor_Type1", pexbcppaymentreq.PEXBC.ParTnor_Type1);
            param.Add("@ParTnor_Type2", pexbcppaymentreq.PEXBC.ParTnor_Type2);
            param.Add("@ParTnor_Type3", pexbcppaymentreq.PEXBC.ParTnor_Type3);
            param.Add("@ParTnor_Type4", pexbcppaymentreq.PEXBC.ParTnor_Type4);
            param.Add("@ParTnor_Type5", pexbcppaymentreq.PEXBC.ParTnor_Type5);
            param.Add("@ParTnor_Type6", pexbcppaymentreq.PEXBC.ParTnor_Type6);
            param.Add("@PARTIAL_AMT1", pexbcppaymentreq.PEXBC.PARTIAL_AMT1);
            param.Add("@PARTIAL_AMT2", pexbcppaymentreq.PEXBC.PARTIAL_AMT2);
            param.Add("@PARTIAL_AMT3", pexbcppaymentreq.PEXBC.PARTIAL_AMT3);
            param.Add("@PARTIAL_AMT4", pexbcppaymentreq.PEXBC.PARTIAL_AMT4);
            param.Add("@PARTIAL_AMT5", pexbcppaymentreq.PEXBC.PARTIAL_AMT5);
            param.Add("@PARTIAL_AMT6", pexbcppaymentreq.PEXBC.PARTIAL_AMT6);
            param.Add("@PARTIAL_RATE1", pexbcppaymentreq.PEXBC.PARTIAL_RATE1);
            param.Add("@PARTIAL_RATE2", pexbcppaymentreq.PEXBC.PARTIAL_RATE2);
            param.Add("@PARTIAL_RATE3", pexbcppaymentreq.PEXBC.PARTIAL_RATE3);
            param.Add("@PARTIAL_RATE4", pexbcppaymentreq.PEXBC.PARTIAL_RATE4);
            param.Add("@PARTIAL_RATE5", pexbcppaymentreq.PEXBC.PARTIAL_RATE5);
            param.Add("@PARTIAL_RATE6", pexbcppaymentreq.PEXBC.PARTIAL_RATE6);
            param.Add("@PARTIAL_AMT1_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT1_THB);
            param.Add("@PARTIAL_AMT2_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT2_THB);
            param.Add("@PARTIAL_AMT3_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT3_THB);
            param.Add("@PARTIAL_AMT4_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT4_THB);
            param.Add("@PARTIAL_AMT5_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT5_THB);
            param.Add("@PARTIAL_AMT6_THB", pexbcppaymentreq.PEXBC.PARTIAL_AMT6_THB);
            param.Add("@FORWARD_CONRACT_NO", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO);
            param.Add("@FORWARD_CONRACT_NO1", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO1);
            param.Add("@FORWARD_CONRACT_NO2", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO2);
            param.Add("@FORWARD_CONRACT_NO3", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO3);
            param.Add("@FORWARD_CONRACT_NO4", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO4);
            param.Add("@FORWARD_CONRACT_NO5", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO5);
            param.Add("@FORWARD_CONRACT_NO6", pexbcppaymentreq.PEXBC.FORWARD_CONRACT_NO6);
            param.Add("@NEGO_COMM", pexbcppaymentreq.PEXBC.NEGO_COMM);
            param.Add("@TELEX_SWIFT", pexbcppaymentreq.PEXBC.TELEX_SWIFT);
            param.Add("@COURIER_POSTAGE", pexbcppaymentreq.PEXBC.COURIER_POSTAGE);
            param.Add("@STAMP_FEE", pexbcppaymentreq.PEXBC.STAMP_FEE);
            param.Add("@BE_STAMP", pexbcppaymentreq.PEXBC.BE_STAMP);
            param.Add("@COMM_OTHER", pexbcppaymentreq.PEXBC.COMM_OTHER);
            param.Add("@HANDING_FEE", pexbcppaymentreq.PEXBC.HANDING_FEE);
            param.Add("@DRAFTCOMM", pexbcppaymentreq.PEXBC.DRAFTCOMM);
            param.Add("@INT_AMT_THB", pexbcppaymentreq.PEXBC.INT_AMT_THB);
            param.Add("@COMMONTT", pexbcppaymentreq.PEXBC.COMMONTT);
            param.Add("@TOTAL_CHARGE", pexbcppaymentreq.PEXBC.TOTAL_CHARGE);
            param.Add("@REFUND_TAX_YN", pexbcppaymentreq.PEXBC.REFUND_TAX_YN);
            param.Add("@REFUND_TAX_AMT", pexbcppaymentreq.PEXBC.REFUND_TAX_AMT);
            param.Add("@DISCOUNT_CCY", pexbcppaymentreq.PEXBC.DISCOUNT_CCY);
            param.Add("@DISCRATE", pexbcppaymentreq.PEXBC.DISCRATE);
            param.Add("@DISCOUNT_AMT", pexbcppaymentreq.PEXBC.DISCOUNT_AMT);
            param.Add("@TOTAL_AMOUNT", pexbcppaymentreq.PEXBC.TOTAL_AMOUNT);
            param.Add("@PAYMENT_INSTRU", pexbcppaymentreq.PEXBC.PAYMENT_INSTRU);
            param.Add("@METHOD", pexbcppaymentreq.PEXBC.METHOD);
            param.Add("@ACBAHTNET", pexbcppaymentreq.PEXBC.ACBAHTNET);
            param.Add("@BAHTNET", pexbcppaymentreq.PEXBC.BAHTNET);
            param.Add("@RECEIVED_NO", pexbcppaymentreq.PEXBC.RECEIVED_NO);
            param.Add("@ALLOCATION", pexbcppaymentreq.PEXBC.ALLOCATION);
            param.Add("@NARRATIVE", pexbcppaymentreq.PEXBC.NARRATIVE);
            param.Add("@SEQ_ACCEPT_DUE", pexbcppaymentreq.PEXBC.SEQ_ACCEPT_DUE);
            param.Add("@COMFIRM_DUE", pexbcppaymentreq.PEXBC.COMFIRM_DUE);
            param.Add("@PLUS_MINUS_DISC", pexbcppaymentreq.PEXBC.PLUS_MINUS_DISC);
            param.Add("@DISC_DAYS_PLUS_MINUS", pexbcppaymentreq.PEXBC.DISC_DAYS_PLUS_MINUS);
            param.Add("@RECEIVE_PAY_AMT", pexbcppaymentreq.PEXBC.RECEIVE_PAY_AMT);
            param.Add("@EXCHANGE_RATE", pexbcppaymentreq.PEXBC.EXCHANGE_RATE);
            param.Add("@REFUND_DISC_RECEIVE", pexbcppaymentreq.PEXBC.REFUND_DISC_RECEIVE);
            param.Add("@DISC_RECEIVE", pexbcppaymentreq.PEXBC.DISC_RECEIVE);
            param.Add("@LC_DATE", pexbcppaymentreq.PEXBC.LC_DATE);
            param.Add("@COVERING_DATE", pexbcppaymentreq.PEXBC.COVERING_DATE);
            param.Add("@COVERING_FOR", pexbcppaymentreq.PEXBC.COVERING_FOR);
            param.Add("@ADVICE_ISSUE_BANK", pexbcppaymentreq.PEXBC.ADVICE_ISSUE_BANK);
            param.Add("@ADVICE_FORMAT", pexbcppaymentreq.PEXBC.ADVICE_FORMAT);
            param.Add("@REMIT_CLAIM_TYPE", pexbcppaymentreq.PEXBC.REMIT_CLAIM_TYPE);
            param.Add("@REIMBURSE_BANK_ID", pexbcppaymentreq.PEXBC.REIMBURSE_BANK_ID);
            param.Add("@REIMBURSE_BANK_INFO", pexbcppaymentreq.PEXBC.REIMBURSE_BANK_INFO);
            param.Add("@SWIFT_BANK", pexbcppaymentreq.PEXBC.SWIFT_BANK);
            param.Add("@SWIFT_MAIL", pexbcppaymentreq.PEXBC.SWIFT_MAIL);
            param.Add("@CLAIM_FORMAT", pexbcppaymentreq.PEXBC.CLAIM_FORMAT);
            param.Add("@VALUE_DATE", pexbcppaymentreq.PEXBC.VALUE_DATE);
            param.Add("@THIRD_BANK_ID", pexbcppaymentreq.PEXBC.THIRD_BANK_ID);
            param.Add("@THIRD_BANK_INFO", pexbcppaymentreq.PEXBC.THIRD_BANK_INFO);
            param.Add("@DISCREPANCY_TYPE", pexbcppaymentreq.PEXBC.DISCREPANCY_TYPE);
            param.Add("@SWIFT_DISC", pexbcppaymentreq.PEXBC.SWIFT_DISC);
            param.Add("@DOCUMENT_COPY", pexbcppaymentreq.PEXBC.DOCUMENT_COPY);
            param.Add("@SIGHT_BASIS", pexbcppaymentreq.PEXBC.SIGHT_BASIS);
            param.Add("@ART44A", pexbcppaymentreq.PEXBC.ART44A);
            param.Add("@ENDORSED", pexbcppaymentreq.PEXBC.ENDORSED);
            param.Add("@MT750", pexbcppaymentreq.PEXBC.MT750);
            param.Add("@ADJ_TOT_NEGO_AMOUNT", pexbcppaymentreq.PEXBC.ADJ_TOT_NEGO_AMOUNT);
            param.Add("@ADJ_LESS_CHARGE_AMT", pexbcppaymentreq.PEXBC.ADJ_LESS_CHARGE_AMT);
            param.Add("@ADJUST_COVERING_AMT", pexbcppaymentreq.PEXBC.ADJUST_COVERING_AMT);
            param.Add("@ADJUST_TENOR", pexbcppaymentreq.PEXBC.ADJUST_TENOR);
            param.Add("@ADJUST_LC_REF", pexbcppaymentreq.PEXBC.ADJUST_LC_REF);
            param.Add("@PAYMENT_INSTRC", pexbcppaymentreq.PEXBC.PAYMENT_INSTRC);
            param.Add("@TXTDOCUMENT", pexbcppaymentreq.PEXBC.TXTDOCUMENT);
            param.Add("@CHARGE_ACC", pexbcppaymentreq.PEXBC.CHARGE_ACC);
            param.Add("@DRAFT", pexbcppaymentreq.PEXBC.DRAFT);
            param.Add("@MT202", pexbcppaymentreq.PEXBC.MT202);
            param.Add("@FB_CURRENCY", pexbcppaymentreq.PEXBC.FB_CURRENCY);
            param.Add("@FB_AMT", pexbcppaymentreq.PEXBC.FB_AMT);
            param.Add("@FB_RATE", pexbcppaymentreq.PEXBC.FB_RATE);
            param.Add("@FB_AMT_THB", pexbcppaymentreq.PEXBC.FB_AMT_THB);
            param.Add("@COLLECT_REFUND", pexbcppaymentreq.PEXBC.COLLECT_REFUND);
            param.Add("@USER_ID", USER_ID);
            param.Add("@IN_USE", pexbcppaymentreq.PEXBC.IN_USE);
            param.Add("@AUTH_CODE", pexbcppaymentreq.PEXBC.AUTH_CODE);
            param.Add("@GENACC_FLAG", pexbcppaymentreq.PEXBC.GENACC_FLAG);
            param.Add("@VOUCH_ID", pexbcppaymentreq.PEXBC.VOUCH_ID);
            param.Add("@APPVNO", pexbcppaymentreq.PEXBC.APPVNO);
            param.Add("@FACNO", pexbcppaymentreq.PEXBC.FACNO);
            param.Add("@AUTOOVERDUE", pexbcppaymentreq.PEXBC.AUTOOVERDUE);
            param.Add("@LCOVERDUE", pexbcppaymentreq.PEXBC.LCOVERDUE);
            param.Add("@OVESEQNO", pexbcppaymentreq.PEXBC.OVESEQNO);
            param.Add("@INTFLAG", pexbcppaymentreq.PEXBC.INTFLAG);
            param.Add("@IntRateCode", pexbcppaymentreq.PEXBC.IntRateCode);
            param.Add("@CFRRate", pexbcppaymentreq.PEXBC.CFRRate);
            param.Add("@INTCODE", pexbcppaymentreq.PEXBC.INTCODE);
            param.Add("@OINTRATE", pexbcppaymentreq.PEXBC.OINTRATE);
            param.Add("@OINTSPDRATE", pexbcppaymentreq.PEXBC.OINTSPDRATE);
            param.Add("@OINTCURRATE", pexbcppaymentreq.PEXBC.OINTCURRATE);
            param.Add("@OINTDAY", pexbcppaymentreq.PEXBC.OINTDAY);
            param.Add("@OBASEDAY", pexbcppaymentreq.PEXBC.OBASEDAY);
            param.Add("@BFINTAMT", pexbcppaymentreq.PEXBC.BFINTAMT);
            param.Add("@SELLING_RATE", pexbcppaymentreq.PEXBC.SELLING_RATE);
            param.Add("@BFINTTHB", pexbcppaymentreq.PEXBC.BFINTTHB);
            param.Add("@INTBALANCE", pexbcppaymentreq.PEXBC.INTBALANCE);
            param.Add("@PRNBALANCE", pexbcppaymentreq.PEXBC.PRNBALANCE);
            param.Add("@LASTINTAMT", pexbcppaymentreq.PEXBC.LASTINTAMT);
            param.Add("@DMS", pexbcppaymentreq.PEXBC.DMS);
            param.Add("@LASTINTDATE", pexbcppaymentreq.PEXBC.LASTINTDATE);
            param.Add("@PAYMENTTYPE", pexbcppaymentreq.PEXBC.PAYMENTTYPE);
            param.Add("@CONFIRM_DATE", pexbcppaymentreq.PEXBC.CONFIRM_DATE);
            param.Add("@TOTALACCRUAMT", pexbcppaymentreq.PEXBC.TOTALACCRUAMT);
            param.Add("@TOTALACCRUBHT", pexbcppaymentreq.PEXBC.TOTALACCRUBHT);
            param.Add("@ACCRUAMT", pexbcppaymentreq.PEXBC.ACCRUAMT);
            param.Add("@ACCRUBHT", pexbcppaymentreq.PEXBC.ACCRUBHT);
            param.Add("@DATELASTACCRU", pexbcppaymentreq.PEXBC.DATELASTACCRU);
            param.Add("@PASTDUEDATE", pexbcppaymentreq.PEXBC.PASTDUEDATE);
            param.Add("@PASTDUEFLAG", pexbcppaymentreq.PEXBC.PASTDUEFLAG);
            param.Add("@TOTALSUSPAMT", pexbcppaymentreq.PEXBC.TOTALSUSPAMT);
            param.Add("@TOTALSUSPBHT", pexbcppaymentreq.PEXBC.TOTALSUSPBHT);
            param.Add("@SUSPAMT", pexbcppaymentreq.PEXBC.SUSPAMT);
            param.Add("@SUSPBHT", pexbcppaymentreq.PEXBC.SUSPBHT);
            param.Add("@CenterID", USER_CENTER_ID);
            param.Add("@BCPastDue", pexbcppaymentreq.PEXBC.BCPastDue);
            param.Add("@DateStartAccru", pexbcppaymentreq.PEXBC.DateStartAccru);
            param.Add("@DateToStop", pexbcppaymentreq.PEXBC.DateToStop);
            param.Add("@ValueDate", pexbcppaymentreq.PEXBC.ValueDate);
            param.Add("@FlagBack", pexbcppaymentreq.PEXBC.FlagBack);
            param.Add("@NewAccruCcy", pexbcppaymentreq.PEXBC.NewAccruCcy);
            param.Add("@NewAccruAmt", pexbcppaymentreq.PEXBC.NewAccruAmt);
            param.Add("@AccruPending", pexbcppaymentreq.PEXBC.AccruPending);
            param.Add("@LastAccruCcy", pexbcppaymentreq.PEXBC.LastAccruCcy);
            param.Add("@LastAccruAmt", pexbcppaymentreq.PEXBC.LastAccruAmt);
            param.Add("@DAccruAmt", pexbcppaymentreq.PEXBC.DAccruAmt);
            param.Add("@CCS_ACCT", pexbcppaymentreq.PEXBC.CCS_ACCT);
            param.Add("@CCS_LmType", pexbcppaymentreq.PEXBC.CCS_LmType);
            param.Add("@CCS_CNUM", pexbcppaymentreq.PEXBC.CCS_CNUM);
            param.Add("@CCS_CIFRef", pexbcppaymentreq.PEXBC.CCS_CIFRef);
            param.Add("@ObjectType", pexbcppaymentreq.PEXBC.ObjectType);
            param.Add("@UnderlyName", pexbcppaymentreq.PEXBC.UnderlyName);
            param.Add("@BPOFlag", pexbcppaymentreq.PEXBC.BPOFlag);
            param.Add("@Campaign_Code", pexbcppaymentreq.PEXBC.Campaign_Code);
            param.Add("@Campaign_EffDate", pexbcppaymentreq.PEXBC.Campaign_EffDate);
            param.Add("@PurposeCode", pexbcppaymentreq.PEXBC.PurposeCode);
            //param.Add("@Resp", dbType: DbType.Int32,
            if (pexbcppaymentreq.PPayment != null)
            {
                param.Add("@RpPayDate", pexbcppaymentreq.PPayment.RpPayDate);
                param.Add("@RpNote", pexbcppaymentreq.PPayment.RpNote);
                param.Add("@RpCashAmt", pexbcppaymentreq.PPayment.RpCashAmt);
                param.Add("@RpChqAmt", pexbcppaymentreq.PPayment.RpChqAmt);
                param.Add("@RpChqNo", pexbcppaymentreq.PPayment.RpChqNo);
                param.Add("@RpChqBank", pexbcppaymentreq.PPayment.RpChqBank);
                param.Add("@RpChqBranch", pexbcppaymentreq.PPayment.RpChqBranch);
                param.Add("@RpCustAc1", pexbcppaymentreq.PPayment.RpCustAc1);
                param.Add("@RpCustAmt1", pexbcppaymentreq.PPayment.RpCustAmt1);
                param.Add("@RpCustAc2", pexbcppaymentreq.PPayment.RpCustAc2);
                param.Add("@RpCustAmt2", pexbcppaymentreq.PPayment.RpCustAmt2);
                param.Add("@RpCustAc3", pexbcppaymentreq.PPayment.RpCustAc3);
                param.Add("@RpCustAmt3", pexbcppaymentreq.PPayment.RpCustAmt3);
                param.Add("@RpStatus", pexbcppaymentreq.PPayment.RpStatus);
            }
            param.Add("@Resp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            param.Add("@PEXBCPEXPaymentRsp", dbType: DbType.String,
                       direction: System.Data.ParameterDirection.Output,
                       size: 5215585);

            param.Add("@ResSeqNo", dbType: DbType.Int32,
                         direction: System.Data.ParameterDirection.Output,
                         size: 12800);

            param.Add("@ResReceiptNo", dbType: DbType.String,
           direction: System.Data.ParameterDirection.Output,
           size: 5215585);


            try
            {
                var results = await _db.LoadData<pExbc, dynamic>(
                    storedProcedure: "usp_pEXBC_AcceptTermDue_Save",
                    param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                var pEXBCPEXPaymentRsp = param.Get<string>("@PEXBCPEXPaymentRsp");

                var jsonData = JsonConvert.DeserializeObject<PEXBCPPaymentRsp>(pEXBCPEXPaymentRsp);

                if (resp == "1")
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonData;

                    bool resGL;
                    bool resPayD;
                    string eventDate;
                    string resVoucherID;

                    eventDate = pexbcppaymentreq.PEXBC.EVENT_DATE.ToString("dd/MM/yyyy");
                    if (pexbcppaymentreq.PEXBC.PAYMENT_INSTRU == "PAID")
                    {
                        if (pexbcppaymentreq.PEXBC.COLLECT_REFUND=="1")
                        {
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXBC(pexbcppaymentreq.PEXBC.EXPORT_BC_NO,
                                eventDate,
                                response.Data.PEXBC.EVENT_TYPE,
                                response.Data.PEXBC.EVENT_NO,
                                "ACCEPT-C");
                        }
                        else
                        {
                            resVoucherID = ISPModule.GeneratrEXP.StartPEXBC(pexbcppaymentreq.PEXBC.EXPORT_BC_NO,
                                eventDate,
                                response.Data.PEXBC.EVENT_TYPE,
                                response.Data.PEXBC.EVENT_NO,
                              "ACCEPT-R");
                        }
                        if (resVoucherID != "ERROR")
                        {
                            resGL = true;
                            response.Data.PEXBC.VOUCH_ID = resVoucherID;
                        }
                        else
                        {
                            resGL = false;
                        }

                    }
                    else
                    {
                        resVoucherID = "";

                    }

                    string resPayDetail;
                    if (pexbcppaymentreq.PPayment != null)
                    {
                        resPayDetail = ISPModule.PayDetailEXBC.PayDetail_AcceptDue(pexbcppaymentreq.PEXBC.EXPORT_BC_NO, 
                            response.Data.PEXBC.EVENT_NO, response.Data.PEXBC.RECEIVED_NO);
                        if (resPayDetail != "ERROR")
                        {
                            resPayD = true;
                        }
                        else
                        {
                            resPayD = false;
                        }
                    }
                    else
                    {
                        resPayD = true;
                    }
                    return Ok(response);

                    // Manual Serialize need for nested class
                    //string json = JsonConvert.SerializeObject(response);

                    //return Content(json, "application/json");
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT_BC Save Error";
                    response.Data = new PEXBCPPaymentRsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXBCPPaymentRsp();
            }
            return BadRequest(response);
        }

        //[HttpPost("update")]
        //public async Task<ActionResult<List<PEXBC>>> Update([FromBody] PEXBC pexbc)
        //{
        //    DynamicParameters param = new DynamicParameters();
        //    param.Add("@RECORD_TYPE", pexbc.RECORD_TYPE);
        //    param.Add("@REC_STATUS", pexbc.REC_STATUS);
        //    param.Add("@EVENT_NO", pexbc.EVENT_NO);
        //    param.Add("@EXPORT_BC_NO", pexbc.EXPORT_BC_NO);
        //    param.Add("@EVENT_MODE", pexbc.EVENT_MODE);
        //    param.Add("@BUSINESS_TYPE", pexbc.BUSINESS_TYPE);
        //    param.Add("@EVENT_TYPE", pexbc.EVENT_TYPE);
        //    param.Add("@EVENT_DATE", pexbc.EVENT_DATE);
        //    param.Add("@TENOR_OF_COLL", pexbc.TENOR_OF_COLL);
        //    param.Add("@TENOR_TYPE", pexbc.TENOR_TYPE);
        //    param.Add("@INVOICE", pexbc.INVOICE);
        //    param.Add("@REFER_BC_NO", pexbc.REFER_BC_NO);
        //    param.Add("@RELETE_PACK", pexbc.RELETE_PACK);
        //    param.Add("@DRAFT_CCY", pexbc.DRAFT_CCY);
        //    param.Add("@DRAFT_AMT", pexbc.DRAFT_AMT);
        //    param.Add("@SIGHT_AMT", pexbc.SIGHT_AMT);
        //    param.Add("@TERM_AMT", pexbc.TERM_AMT);
        //    param.Add("@GOOD_CODE", pexbc.GOOD_CODE);
        //    param.Add("@REL_CODE", pexbc.REL_CODE);
        //    param.Add("@CLAIM_TYPE", pexbc.CLAIM_TYPE);
        //    param.Add("@SIGHT_START_DATE", pexbc.SIGHT_START_DATE);
        //    param.Add("@SIGHT_DUE_DATE", pexbc.SIGHT_DUE_DATE);
        //    param.Add("@TENOR_DAY", pexbc.TENOR_DAY);
        //    param.Add("@TENOR_DAY_DESC", pexbc.TENOR_DAY_DESC);
        //    param.Add("@TERM_START_DATE", pexbc.TERM_START_DATE);
        //    param.Add("@TERM_DUE_DATE", pexbc.TERM_DUE_DATE);
        //    param.Add("@PURCH_DISC_DATE", pexbc.PURCH_DISC_DATE);
        //    param.Add("@DRAWEE_INFO", pexbc.DRAWEE_INFO);
        //    param.Add("@CNTY_CODE", pexbc.CNTY_CODE);
        //    param.Add("@Cust_AO", pexbc.Cust_AO);
        //    param.Add("@Cust_LO", pexbc.Cust_LO);
        //    param.Add("@BENE_ID", pexbc.BENE_ID);
        //    param.Add("@BENE_INFO", pexbc.BENE_INFO);
        //    param.Add("@ISSUE_BANK_ID", pexbc.ISSUE_BANK_ID);
        //    param.Add("@ISSUE_BANK_INFO", pexbc.ISSUE_BANK_INFO);
        //    param.Add("@COLLECT_AGENT", pexbc.COLLECT_AGENT);
        //    param.Add("@AGENT_BANK_ID", pexbc.AGENT_BANK_ID);
        //    param.Add("@AGENT_BANK_INFO", pexbc.AGENT_BANK_INFO);
        //    param.Add("@AGENT_BANK_REF", pexbc.AGENT_BANK_REF);
        //    param.Add("@AGENT_BANK_NOSTRO", pexbc.AGENT_BANK_NOSTRO);
        //    param.Add("@RESTRICT", pexbc.RESTRICT);
        //    param.Add("@RESTRICT_TO_BK_NAME", pexbc.RESTRICT_TO_BK_NAME);
        //    param.Add("@RESTRICT_TO_BK_ADDR1", pexbc.RESTRICT_TO_BK_ADDR1);
        //    param.Add("@RESTRICT_TO_BK_ADDR2", pexbc.RESTRICT_TO_BK_ADDR2);
        //    param.Add("@RESTRICT_TO_BK_ADDR3", pexbc.RESTRICT_TO_BK_ADDR3);
        //    param.Add("@RESTRICT_REFER", pexbc.RESTRICT_REFER);
        //    param.Add("@RESTRICT_FR_BK_NAME", pexbc.RESTRICT_FR_BK_NAME);
        //    param.Add("@RESTRICT_FR_BK_ADDR1", pexbc.RESTRICT_FR_BK_ADDR1);
        //    param.Add("@RESTRICT_FR_BK_ADDR2", pexbc.RESTRICT_FR_BK_ADDR2);
        //    param.Add("@RESTRICT_FR_BK_ADDR3", pexbc.RESTRICT_FR_BK_ADDR3);
        //    param.Add("@PARTIAL_FULL_RATE", pexbc.PARTIAL_FULL_RATE);
        //    param.Add("@INT_RATE_METHOD", pexbc.INT_RATE_METHOD);
        //    param.Add("@TYPE_OF_ACCOUNT", pexbc.TYPE_OF_ACCOUNT);
        //    param.Add("@CREDIT_CURRENCY", pexbc.CREDIT_CURRENCY);
        //    param.Add("@DISCOUNT_DAY", pexbc.DISCOUNT_DAY);
        //    param.Add("@GRACE_PERIOD", pexbc.GRACE_PERIOD);
        //    param.Add("@DISC_BASE_DAY", pexbc.DISC_BASE_DAY);
        //    param.Add("@BASE_DAY", pexbc.BASE_DAY);
        //    param.Add("@DISCOUNT_RATE", pexbc.DISCOUNT_RATE);
        //    param.Add("@INT_BASE_RATE", pexbc.INT_BASE_RATE);
        //    param.Add("@INT_SPREAD_RATE", pexbc.INT_SPREAD_RATE);
        //    param.Add("@CURRENT_DIS_RATE", pexbc.CURRENT_DIS_RATE);
        //    param.Add("@CURRENT_INT_RATE", pexbc.CURRENT_INT_RATE);
        //    param.Add("@PAY_BY", pexbc.PAY_BY);
        //    param.Add("@NEGO_AMT", pexbc.NEGO_AMT);
        //    param.Add("@LESS_AGENT", pexbc.LESS_AGENT);
        //    param.Add("@PURCHASE_AMT", pexbc.PURCHASE_AMT);
        //    param.Add("@PURCHASE_RATE", pexbc.PURCHASE_RATE);
        //    param.Add("@TOTAL_NEGO_BALANCE", pexbc.TOTAL_NEGO_BALANCE);
        //    param.Add("@TOTAL_NEGO_BAL_THB", pexbc.TOTAL_NEGO_BAL_THB);
        //    param.Add("@TOT_NEGO_AMT", pexbc.TOT_NEGO_AMT);
        //    param.Add("@TOT_NEGO_AMOUNT", pexbc.TOT_NEGO_AMOUNT);
        //    param.Add("@BANK_CHARGE_AMT", pexbc.BANK_CHARGE_AMT);
        //    param.Add("@NET_PROCEED_CLAIM", pexbc.NET_PROCEED_CLAIM);
        //    param.Add("@CLAIM_PAY_BY", pexbc.CLAIM_PAY_BY);
        //    param.Add("@ParTnor_Type1", pexbc.ParTnor_Type1);
        //    param.Add("@ParTnor_Type2", pexbc.ParTnor_Type2);
        //    param.Add("@ParTnor_Type3", pexbc.ParTnor_Type3);
        //    param.Add("@ParTnor_Type4", pexbc.ParTnor_Type4);
        //    param.Add("@ParTnor_Type5", pexbc.ParTnor_Type5);
        //    param.Add("@ParTnor_Type6", pexbc.ParTnor_Type6);
        //    param.Add("@PARTIAL_AMT1", pexbc.PARTIAL_AMT1);
        //    param.Add("@PARTIAL_AMT2", pexbc.PARTIAL_AMT2);
        //    param.Add("@PARTIAL_AMT3", pexbc.PARTIAL_AMT3);
        //    param.Add("@PARTIAL_AMT4", pexbc.PARTIAL_AMT4);
        //    param.Add("@PARTIAL_AMT5", pexbc.PARTIAL_AMT5);
        //    param.Add("@PARTIAL_AMT6", pexbc.PARTIAL_AMT6);
        //    param.Add("@PARTIAL_RATE1", pexbc.PARTIAL_RATE1);
        //    param.Add("@PARTIAL_RATE2", pexbc.PARTIAL_RATE2);
        //    param.Add("@PARTIAL_RATE3", pexbc.PARTIAL_RATE3);
        //    param.Add("@PARTIAL_RATE4", pexbc.PARTIAL_RATE4);
        //    param.Add("@PARTIAL_RATE5", pexbc.PARTIAL_RATE5);
        //    param.Add("@PARTIAL_RATE6", pexbc.PARTIAL_RATE6);
        //    param.Add("@PARTIAL_AMT1_THB", pexbc.PARTIAL_AMT1_THB);
        //    param.Add("@PARTIAL_AMT2_THB", pexbc.PARTIAL_AMT2_THB);
        //    param.Add("@PARTIAL_AMT3_THB", pexbc.PARTIAL_AMT3_THB);
        //    param.Add("@PARTIAL_AMT4_THB", pexbc.PARTIAL_AMT4_THB);
        //    param.Add("@PARTIAL_AMT5_THB", pexbc.PARTIAL_AMT5_THB);
        //    param.Add("@PARTIAL_AMT6_THB", pexbc.PARTIAL_AMT6_THB);
        //    param.Add("@FORWARD_CONRACT_NO", pexbc.FORWARD_CONRACT_NO);
        //    param.Add("@FORWARD_CONRACT_NO1", pexbc.FORWARD_CONRACT_NO1);
        //    param.Add("@FORWARD_CONRACT_NO2", pexbc.FORWARD_CONRACT_NO2);
        //    param.Add("@FORWARD_CONRACT_NO3", pexbc.FORWARD_CONRACT_NO3);
        //    param.Add("@FORWARD_CONRACT_NO4", pexbc.FORWARD_CONRACT_NO4);
        //    param.Add("@FORWARD_CONRACT_NO5", pexbc.FORWARD_CONRACT_NO5);
        //    param.Add("@FORWARD_CONRACT_NO6", pexbc.FORWARD_CONRACT_NO6);
        //    param.Add("@NEGO_COMM", pexbc.NEGO_COMM);
        //    param.Add("@TELEX_SWIFT", pexbc.TELEX_SWIFT);
        //    param.Add("@COURIER_POSTAGE", pexbc.COURIER_POSTAGE);
        //    param.Add("@STAMP_FEE", pexbc.STAMP_FEE);
        //    param.Add("@BE_STAMP", pexbc.BE_STAMP);
        //    param.Add("@COMM_OTHER", pexbc.COMM_OTHER);
        //    param.Add("@HANDING_FEE", pexbc.HANDING_FEE);
        //    param.Add("@DRAFTCOMM", pexbc.DRAFTCOMM);
        //    param.Add("@INT_AMT_THB", pexbc.INT_AMT_THB);
        //    param.Add("@COMMONTT", pexbc.COMMONTT);
        //    param.Add("@TOTAL_CHARGE", pexbc.TOTAL_CHARGE);
        //    param.Add("@REFUND_TAX_YN", pexbc.REFUND_TAX_YN);
        //    param.Add("@REFUND_TAX_AMT", pexbc.REFUND_TAX_AMT);
        //    param.Add("@DISCOUNT_CCY", pexbc.DISCOUNT_CCY);
        //    param.Add("@DISCRATE", pexbc.DISCRATE);
        //    param.Add("@DISCOUNT_AMT", pexbc.DISCOUNT_AMT);
        //    param.Add("@TOTAL_AMOUNT", pexbc.TOTAL_AMOUNT);
        //    param.Add("@PAYMENT_INSTRU", pexbc.PAYMENT_INSTRU);
        //    param.Add("@METHOD", pexbc.METHOD);
        //    param.Add("@ACBAHTNET", pexbc.ACBAHTNET);
        //    param.Add("@BAHTNET", pexbc.BAHTNET);
        //    param.Add("@RECEIVED_NO", pexbc.RECEIVED_NO);
        //    param.Add("@ALLOCATION", pexbc.ALLOCATION);
        //    param.Add("@NARRATIVE", pexbc.NARRATIVE);
        //    param.Add("@SEQ_ACCEPT_DUE", pexbc.SEQ_ACCEPT_DUE);
        //    param.Add("@COMFIRM_DUE", pexbc.COMFIRM_DUE);
        //    param.Add("@PLUS_MINUS_DISC", pexbc.PLUS_MINUS_DISC);
        //    param.Add("@DISC_DAYS_PLUS_MINUS", pexbc.DISC_DAYS_PLUS_MINUS);
        //    param.Add("@RECEIVE_PAY_AMT", pexbc.RECEIVE_PAY_AMT);
        //    param.Add("@EXCHANGE_RATE", pexbc.EXCHANGE_RATE);
        //    param.Add("@REFUND_DISC_RECEIVE", pexbc.REFUND_DISC_RECEIVE);
        //    param.Add("@DISC_RECEIVE", pexbc.DISC_RECEIVE);
        //    param.Add("@LC_DATE", pexbc.LC_DATE);
        //    param.Add("@COVERING_DATE", pexbc.COVERING_DATE);
        //    param.Add("@COVERING_FOR", pexbc.COVERING_FOR);
        //    param.Add("@ADVICE_ISSUE_BANK", pexbc.ADVICE_ISSUE_BANK);
        //    param.Add("@ADVICE_FORMAT", pexbc.ADVICE_FORMAT);
        //    param.Add("@REMIT_CLAIM_TYPE", pexbc.REMIT_CLAIM_TYPE);
        //    param.Add("@REIMBURSE_BANK_ID", pexbc.REIMBURSE_BANK_ID);
        //    param.Add("@REIMBURSE_BANK_INFO", pexbc.REIMBURSE_BANK_INFO);
        //    param.Add("@SWIFT_BANK", pexbc.SWIFT_BANK);
        //    param.Add("@SWIFT_MAIL", pexbc.SWIFT_MAIL);
        //    param.Add("@CLAIM_FORMAT", pexbc.CLAIM_FORMAT);
        //    param.Add("@VALUE_DATE", pexbc.VALUE_DATE);
        //    param.Add("@THIRD_BANK_ID", pexbc.THIRD_BANK_ID);
        //    param.Add("@THIRD_BANK_INFO", pexbc.THIRD_BANK_INFO);
        //    param.Add("@DISCREPANCY_TYPE", pexbc.DISCREPANCY_TYPE);
        //    param.Add("@SWIFT_DISC", pexbc.SWIFT_DISC);
        //    param.Add("@DOCUMENT_COPY", pexbc.DOCUMENT_COPY);
        //    param.Add("@SIGHT_BASIS", pexbc.SIGHT_BASIS);
        //    param.Add("@ART44A", pexbc.ART44A);
        //    param.Add("@ENDORSED", pexbc.ENDORSED);
        //    param.Add("@MT750", pexbc.MT750);
        //    param.Add("@ADJ_TOT_NEGO_AMOUNT", pexbc.ADJ_TOT_NEGO_AMOUNT);
        //    param.Add("@ADJ_LESS_CHARGE_AMT", pexbc.ADJ_LESS_CHARGE_AMT);
        //    param.Add("@ADJUST_COVERING_AMT", pexbc.ADJUST_COVERING_AMT);
        //    param.Add("@ADJUST_TENOR", pexbc.ADJUST_TENOR);
        //    param.Add("@ADJUST_LC_REF", pexbc.ADJUST_LC_REF);
        //    param.Add("@PAYMENT_INSTRC", pexbc.PAYMENT_INSTRC);
        //    param.Add("@TXTDOCUMENT", pexbc.TXTDOCUMENT);
        //    param.Add("@CHARGE_ACC", pexbc.CHARGE_ACC);
        //    param.Add("@DRAFT", pexbc.DRAFT);
        //    param.Add("@MT202", pexbc.MT202);
        //    param.Add("@FB_CURRENCY", pexbc.FB_CURRENCY);
        //    param.Add("@FB_AMT", pexbc.FB_AMT);
        //    param.Add("@FB_RATE", pexbc.FB_RATE);
        //    param.Add("@FB_AMT_THB", pexbc.FB_AMT_THB);
        //    param.Add("@COLLECT_REFUND", pexbc.COLLECT_REFUND);
        //    param.Add("@USER_ID", pexbc.USER_ID);
        //    param.Add("@IN_USE", pexbc.IN_USE);
        //    param.Add("@AUTH_CODE", pexbc.AUTH_CODE);
        //    param.Add("@GENACC_FLAG", pexbc.GENACC_FLAG);
        //    param.Add("@VOUCH_ID", pexbc.VOUCH_ID);
        //    param.Add("@APPVNO", pexbc.APPVNO);
        //    param.Add("@FACNO", pexbc.FACNO);
        //    param.Add("@AUTOOVERDUE", pexbc.AUTOOVERDUE);
        //    param.Add("@LCOVERDUE", pexbc.LCOVERDUE);
        //    param.Add("@OVESEQNO", pexbc.OVESEQNO);
        //    param.Add("@INTFLAG", pexbc.INTFLAG);
        //    param.Add("@IntRateCode", pexbc.IntRateCode);
        //    param.Add("@CFRRate", pexbc.CFRRate);
        //    param.Add("@INTCODE", pexbc.INTCODE);
        //    param.Add("@OINTRATE", pexbc.OINTRATE);
        //    param.Add("@OINTSPDRATE", pexbc.OINTSPDRATE);
        //    param.Add("@OINTCURRATE", pexbc.OINTCURRATE);
        //    param.Add("@OINTDAY", pexbc.OINTDAY);
        //    param.Add("@OBASEDAY", pexbc.OBASEDAY);
        //    param.Add("@BFINTAMT", pexbc.BFINTAMT);
        //    param.Add("@SELLING_RATE", pexbc.SELLING_RATE);
        //    param.Add("@BFINTTHB", pexbc.BFINTTHB);
        //    param.Add("@INTBALANCE", pexbc.INTBALANCE);
        //    param.Add("@PRNBALANCE", pexbc.PRNBALANCE);
        //    param.Add("@LASTINTAMT", pexbc.LASTINTAMT);
        //    param.Add("@DMS", pexbc.DMS);
        //    param.Add("@LASTINTDATE", pexbc.LASTINTDATE);
        //    param.Add("@PAYMENTTYPE", pexbc.PAYMENTTYPE);
        //    param.Add("@CONFIRM_DATE", pexbc.CONFIRM_DATE);
        //    param.Add("@TOTALACCRUAMT", pexbc.TOTALACCRUAMT);
        //    param.Add("@TOTALACCRUBHT", pexbc.TOTALACCRUBHT);
        //    param.Add("@ACCRUAMT", pexbc.ACCRUAMT);
        //    param.Add("@ACCRUBHT", pexbc.ACCRUBHT);
        //    param.Add("@DATELASTACCRU", pexbc.DATELASTACCRU);
        //    param.Add("@PASTDUEDATE", pexbc.PASTDUEDATE);
        //    param.Add("@PASTDUEFLAG", pexbc.PASTDUEFLAG);
        //    param.Add("@TOTALSUSPAMT", pexbc.TOTALSUSPAMT);
        //    param.Add("@TOTALSUSPBHT", pexbc.TOTALSUSPBHT);
        //    param.Add("@SUSPAMT", pexbc.SUSPAMT);
        //    param.Add("@SUSPBHT", pexbc.SUSPBHT);
        //    param.Add("@CenterID", pexbc.CenterID);
        //    param.Add("@BCPastDue", pexbc.BCPastDue);
        //    param.Add("@DateStartAccru", pexbc.DateStartAccru);
        //    param.Add("@DateToStop", pexbc.DateToStop);
        //    param.Add("@ValueDate", pexbc.ValueDate);
        //    param.Add("@FlagBack", pexbc.FlagBack);
        //    param.Add("@NewAccruCcy", pexbc.NewAccruCcy);
        //    param.Add("@NewAccruAmt", pexbc.NewAccruAmt);
        //    param.Add("@AccruPending", pexbc.AccruPending);
        //    param.Add("@LastAccruCcy", pexbc.LastAccruCcy);
        //    param.Add("@LastAccruAmt", pexbc.LastAccruAmt);
        //    param.Add("@DAccruAmt", pexbc.DAccruAmt);
        //    param.Add("@CCS_ACCT", pexbc.CCS_ACCT);
        //    param.Add("@CCS_LmType", pexbc.CCS_LmType);
        //    param.Add("@CCS_CNUM", pexbc.CCS_CNUM);
        //    param.Add("@CCS_CIFRef", pexbc.CCS_CIFRef);
        //    param.Add("@ObjectType", pexbc.ObjectType);
        //    param.Add("@UnderlyName", pexbc.UnderlyName);
        //    param.Add("@BPOFlag", pexbc.BPOFlag);
        //    param.Add("@Campaign_Code", pexbc.Campaign_Code);
        //    param.Add("@Campaign_EffDate", pexbc.Campaign_EffDate);
        //    param.Add("@PurposeCode", pexbc.PurposeCode);

        //    //param.Add("@Resp", dbType: DbType.Int32,
        //    param.Add("@Resp", dbType: DbType.String,
        //       direction: System.Data.ParameterDirection.Output,
        //       size: 5215585);
        //    try
        //    {
        //        var results = await _db.LoadData<PEXBC_PAYMENT, dynamic>(
        //            storedProcedure: "usp_pEXBCIssuePurchUpdate",
        //            param);
        //        //var resp = param.Get<int>("@Resp");
        //        var resp = param.Get<string>("@Resp");
        //        if (resp == "1")
        //        {
        //            return Ok(results);
        //        }
        //        else
        //        {

        //            ReturnResponse response = new();
        //            response.StatusCode = "400";
        //            response.Message = resp.ToString(); //= "EXPORT_BC_NO Insert Error";
        //            return BadRequest(response);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost("delete")]
        public async Task<ActionResult<EXBCResultResponse>> EXBCAcceptTermDueDelete([FromBody] PEXBCAcceptTermDueDeleteReq pExBcAcceptTermDueDelete)
        {
            EXBCResultResponse response = new EXBCResultResponse();

            // Validate
            if (string.IsNullOrEmpty(pExBcAcceptTermDueDelete.EXPORT_BC_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO is required";
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", pExBcAcceptTermDueDelete.EXPORT_BC_NO);
            param.Add("@VOUCH_ID", pExBcAcceptTermDueDelete.VOUCH_ID);
            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_AcceptTermDue_Delete", param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                if (resp == "1")
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export B/C Number Deleted";
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Export B/C NO Not Exist";
                    //response.Message = resp.ToString();
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

        [HttpPost("release")]
        public async Task<ActionResult<EXBCResultResponse>> Release([FromBody] PEXBCAcceptTermDueReleaseReq pExBcAcceptTermDueRelease)
        {
            EXBCResultResponse response = new EXBCResultResponse();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

            // Validate
            if (string.IsNullOrEmpty(pExBcAcceptTermDueRelease.EXPORT_BC_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO is required";
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@CenterID", USER_CENTER_ID);
            param.Add("@EXPORT_BC_NO", pExBcAcceptTermDueRelease.EXPORT_BC_NO);
            param.Add("@EVENT_NO", pExBcAcceptTermDueRelease.EVENT_NO.ToString());
            param.Add("@USER_ID", USER_ID);
            param.Add("@VOUCH_ID", pExBcAcceptTermDueRelease.VOUCH_ID);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_AcceptTermDue_Release", param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                if (resp == "1")
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export B/C NO Release Complete";
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Export B/C Release Error Resp=0 check store procedure";
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
