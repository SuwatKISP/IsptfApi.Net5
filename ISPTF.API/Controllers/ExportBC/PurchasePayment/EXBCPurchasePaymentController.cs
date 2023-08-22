using Dapper;
using ISPTF.DataAccess.DbAccess;
using ISPTF.Models;
using ISPTF.Models.LoginRegis;
using ISPTF.Models.ExportBC;
using ISPTF.Models.PurchasePayment;
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

namespace ISPTF.API.Controllers.ExportBC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class EXBCPurchasePaymentController : ControllerBase
    {
        private readonly ISPTFContext _context;
        private readonly ISqlDataAccess _db;

        public EXBCPurchasePaymentController(ISqlDataAccess db, ISPTFContext context)
        {
            _db = db;
            _context = context;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXBCPurchasePaymentListPageResponse>> GetAllList(string? @ListType, string? CenterID, string? EXPORT_BC_NO, string? BENName, int? Page, int? PageSize)
        {
            EXBCPurchasePaymentListPageResponse response = new EXBCPurchasePaymentListPageResponse();
            var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || Page == null || PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXBCPurchasePaymentListPageRsp>();
                return BadRequest(response);
            }
            if (ListType.Equals("RELEASE") && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EXBCPurchasePaymentListPageRsp>();
                return BadRequest(response);
            }


            DynamicParameters param = new();
            param.Add("@ListType", @ListType);
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
                var results = await _db.LoadData<Q_EXBCPurchasePaymentListPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXBC_PurchasePaymentListPage",
                        param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCPurchasePaymentListPageRsp>)results;
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
                response.Data = new List<Q_EXBCPurchasePaymentListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("query")]
        public async Task<ActionResult<EXBCPurchasePaymentQueryResponse>> GetAllQuery(string? CenterID, string? EXPORT_BC_NO, string? BENName, int? Page, int? PageSize)
        {
            EXBCPurchasePaymentQueryResponse response = new EXBCPurchasePaymentQueryResponse();
            string USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) || Page == null || PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXBCPurchasePaymentQueryPageRsp>();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            //param.Add("@ListType", @ListType);
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
                var results = await _db.LoadData<Q_EXBCPurchasePaymentQueryPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXBC_PurchasePaymentQueryPage",
                        param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCPurchasePaymentQueryPageRsp>)results;
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
                response.Data = new List<Q_EXBCPurchasePaymentQueryPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("select")]
        //      public async Task<IEnumerable<PEXBCPEXPaymentRsp>> GetAllSelect(string? EXPORT_BC_NO , string? EVENT_NO, string? LFROM)
        public async Task<ActionResult<PEXBCPEXPaymentResponse>> GetAllSelect(string? EXPORT_BC_NO, string? EVENT_NO, string? LFROM)
        {
            PEXBCPEXPaymentResponse response = new PEXBCPEXPaymentResponse();
            string USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(EXPORT_BC_NO) || string.IsNullOrEmpty(EVENT_NO) || string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXBCPEXPaymentRsp();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@EVENT_NO", EVENT_NO);
            param.Add("@LFROM", LFROM);
            param.Add("@PExBcRsp", dbType: DbType.Int32,
                        direction: System.Data.ParameterDirection.Output,
                        size: 12800);
            param.Add("@PEXBCPEXPaymentRsp", dbType: DbType.String,
                        direction: System.Data.ParameterDirection.Output,
                        size: 5215585);

            try
            {
                var results = await _db.LoadData<PEXBCPEXPaymentRsp, dynamic>(
                            storedProcedure: "usp_pEXBC_PurchasePayment_Select",
                            param);
                var PExBcRsp = param.Get<dynamic>("@PExBcRsp");
                var pexbcpexpaymentrsp = param.Get<dynamic>("@PEXBCPEXPaymentRsp");

                if (PExBcRsp == 1 && !string.IsNullOrEmpty(pexbcpexpaymentrsp))
                {
                    PEXBCPEXPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXBCPEXPaymentRsp>(pexbcpexpaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT_BC_NO Select Error";
                    response.Data = new PEXBCPEXPaymentRsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXBCPEXPaymentRsp();
            }
            return BadRequest(response);
        }

        [HttpPost("save")]
        public async Task<ActionResult<PEXBCPEXPaymentResponse>> Insert([FromBody] PEXBCPEXPaymentSaveReq pexbcppaymentreq)
        {
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

            PEXBCPEXPaymentResponse response = new PEXBCPEXPaymentResponse();


            // Validate
            if (pexbcppaymentreq.PEXBC == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "PEXBC is required.";
                response.Data = new PEXBCPEXPaymentRsp();
                return BadRequest(response);
            }
            //if (pexbcppaymentreq.PEXPayment == null)
            //{
            //    response.Code = Constants.RESPONSE_ERROR;
            //    response.Message = "PEXPayment is required.";
            //    response.Data = new PEXBCPEXPaymentRsp();
            //    return BadRequest(response);
            //}
            try
            {
              
                DynamicParameters param = new DynamicParameters();
                //pExBc
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
                //pExPayment
                if (pexbcppaymentreq.PEXPayment != null)
                {
                    param.Add("@DOCNUMBER", pexbcppaymentreq.PEXPayment.DOCNUMBER);
                    param.Add("@PAY_TYPE", pexbcppaymentreq.PEXPayment.PAY_TYPE);
                    param.Add("@PAYMENT_DATE", pexbcppaymentreq.PEXPayment.PAYMENT_DATE);
                    param.Add("@AGENT_PAY_BY", pexbcppaymentreq.PEXPayment.AGENT_PAY_BY);
                    param.Add("@SETTLEMENT_CREDIT", pexbcppaymentreq.PEXPayment.SETTLEMENT_CREDIT);
                    param.Add("@MTFLAG", pexbcppaymentreq.PEXPayment.MTFLAG);
                    param.Add("@SIGHT_PAID_AMT", pexbcppaymentreq.PEXPayment.SIGHT_PAID_AMT);
                    param.Add("@SIGHT_PAID_RATE", pexbcppaymentreq.PEXPayment.SIGHT_PAID_RATE);
                    param.Add("@SIGHT_PAID_THB", pexbcppaymentreq.PEXPayment.SIGHT_PAID_THB);
                    param.Add("@SIGHT_FORWARD", pexbcppaymentreq.PEXPayment.SIGHT_FORWARD);
                    param.Add("@TERM_PAID_AMT", pexbcppaymentreq.PEXPayment.TERM_PAID_AMT);
                    param.Add("@TERM_PAID_RATE", pexbcppaymentreq.PEXPayment.TERM_PAID_RATE);
                    param.Add("@TERM_PAID_THB", pexbcppaymentreq.PEXPayment.TERM_PAID_THB);
                    param.Add("@TERM_FORWARD", pexbcppaymentreq.PEXPayment.TERM_FORWARD);
                    param.Add("@TOT_PRINC_PAID", pexbcppaymentreq.PEXPayment.TOT_PRINC_PAID);
                    param.Add("@Com_Lieu", pexbcppaymentreq.PEXPayment.Com_Lieu);
                    param.Add("@ComLieuRate", pexbcppaymentreq.PEXPayment.ComLieuRate);
                    param.Add("@fb_ccy", pexbcppaymentreq.PEXPayment.fb_ccy);
                    param.Add("@Agent_amt", pexbcppaymentreq.PEXPayment.Agent_amt);
                    param.Add("@Agent_rate", pexbcppaymentreq.PEXPayment.Agent_rate);
                    param.Add("@Agent_thb", pexbcppaymentreq.PEXPayment.Agent_thb);
                    param.Add("@over_paid_amt", pexbcppaymentreq.PEXPayment.over_paid_amt);
                    param.Add("@over_paid_rate", pexbcppaymentreq.PEXPayment.over_paid_rate);
                    param.Add("@over_paid_thb", pexbcppaymentreq.PEXPayment.over_paid_thb);
                    param.Add("@int_day", pexbcppaymentreq.PEXPayment.int_day);
                    param.Add("@int_paid_amt", pexbcppaymentreq.PEXPayment.int_paid_amt);
                    param.Add("@int_paid_rate", pexbcppaymentreq.PEXPayment.int_paid_rate);
                    param.Add("@int_exch_rate", pexbcppaymentreq.PEXPayment.int_exch_rate);
                    param.Add("@int_paid_thb", pexbcppaymentreq.PEXPayment.int_paid_thb);
                    param.Add("@prn_paid_thb", pexbcppaymentreq.PEXPayment.prn_paid_thb);
                    param.Add("@Charge_Ccy", pexbcppaymentreq.PEXPayment.Charge_Ccy);
                    param.Add("@Charge_Rate", pexbcppaymentreq.PEXPayment.Charge_Rate);
                    param.Add("@Charge_Thb", pexbcppaymentreq.PEXPayment.Charge_Thb);
                    param.Add("@TOTAL_DUE_TO_CUS", pexbcppaymentreq.PEXPayment.TOTAL_DUE_TO_CUS);
                    param.Add("@FcdAmt", pexbcppaymentreq.PEXPayment.FcdAmt);
                    param.Add("@FcdAcc", pexbcppaymentreq.PEXPayment.FcdAcc);
                    param.Add("@MTAmt", pexbcppaymentreq.PEXPayment.MTAmt);
                    param.Add("@Debit_credit_flag", pexbcppaymentreq.PEXPayment.Debit_credit_flag);
                    param.Add("@ACCOUNT_NO1", pexbcppaymentreq.PEXPayment.ACCOUNT_NO1);
                    param.Add("@ACCOUNT_NO2", pexbcppaymentreq.PEXPayment.ACCOUNT_NO2);
                    param.Add("@ACCOUNT_NO3", pexbcppaymentreq.PEXPayment.ACCOUNT_NO3);
                    param.Add("@AMT_DEBIT_AC1", pexbcppaymentreq.PEXPayment.AMT_DEBIT_AC1);
                    param.Add("@AMT_DEBIT_AC2", pexbcppaymentreq.PEXPayment.AMT_DEBIT_AC2);
                    param.Add("@AMT_DEBIT_AC3", pexbcppaymentreq.PEXPayment.AMT_DEBIT_AC3);
                    param.Add("@AMT_CREDIT_AC1", pexbcppaymentreq.PEXPayment.AMT_CREDIT_AC1);
                    param.Add("@AMT_CREDIT_AC2", pexbcppaymentreq.PEXPayment.AMT_CREDIT_AC2);
                    param.Add("@AMT_CREDIT_AC3", pexbcppaymentreq.PEXPayment.AMT_CREDIT_AC3);
                    param.Add("@CASH", pexbcppaymentreq.PEXPayment.CASH);
                    param.Add("@CHEQUE_AMT", pexbcppaymentreq.PEXPayment.CHEQUE_AMT);
                    param.Add("@CHEQUE_NO", pexbcppaymentreq.PEXPayment.CHEQUE_NO);
                    param.Add("@CHEQUE_BK_BRN", pexbcppaymentreq.PEXPayment.CHEQUE_BK_BRN);
                }
                //PPayment
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
                param.Add("@PExBcRsp", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@PEXBCPEXPaymentRsp", dbType: DbType.String,
                           direction: System.Data.ParameterDirection.Output,
                           size: 5215585);

                //param.Add("@Resp", dbType: DbType.Int32,
                param.Add("@Resp", dbType: DbType.String,
                   direction: System.Data.ParameterDirection.Output,
                   size: 5215585);
                param.Add("@ResSeqNo", dbType: DbType.Int32,
                           direction: System.Data.ParameterDirection.Output,
                           size: 12800);

                param.Add("@ResReceiptNo", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

                var results = await _db.LoadData<PEXBCPEXPaymentRsp, dynamic>(
                            storedProcedure: "usp_pEXBC_PurchasePayment_Save",
                            param);

                var PExBcRsp = param.Get<dynamic>("@PExBcRsp");
                var pexbcpexpaymentrsp = param.Get<dynamic>("@PEXBCPEXPaymentRsp");

                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                var resSeqNo = param.Get<int>("@ResSeqNo");
                var resReceiptNo = param.Get<string>("@ResReceiptNo");

                if (PExBcRsp == 1 && !string.IsNullOrEmpty(pexbcpexpaymentrsp))
                {
                    PEXBCPEXPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXBCPEXPaymentRsp>(pexbcpexpaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT_BC_NO Select Error";
                    response.Data = new PEXBCPEXPaymentRsp();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXBCPEXPaymentRsp();
            }
            return BadRequest(response);
        }

        [HttpPost("delete")]
        public async Task<ActionResult<EXBCResultResponse>> EXBCAcceptTermDueDelete([FromBody] PEXBCPurchasePaymentDeleteReq pExBcPurchasePaymentDelete)
        {
            EXBCResultResponse response = new EXBCResultResponse();

            // Validate
            if (string.IsNullOrEmpty(pExBcPurchasePaymentDelete.EXPORT_BC_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO is required";
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", pExBcPurchasePaymentDelete.EXPORT_BC_NO);
            param.Add("@VOUCH_ID", pExBcPurchasePaymentDelete.VOUCH_ID);
            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_PurchasePayment_Delete", param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                /*if (resp == "0")
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export B/C Deleted";
                    return Ok(response);
                }
                else if (resp == "99")
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Export B/C: " + pExBcDelete.EXPORT_BC_NO + " Not Found.";
                    return BadRequest(response);
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
                        response.Message = "Error Deleting Export B/C";
                    }
                    return BadRequest(response);
                }*/
                if (resp == "1")
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export B/C Deleted";
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Export B/C: " + pExBcPurchasePaymentDelete.EXPORT_BC_NO + " Not Found.";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPost("release")]
        public async Task<ActionResult<EXBCResultResponse>> PEXBCPurchasePaymentReleaseReq([FromBody] PEXBCPurchasePaymentReleaseReq PEXBCPurchasePaymentRelease)
        {
            EXBCResultResponse response = new EXBCResultResponse();
            string USER_ID = User.Identity.Name;

            if (string.IsNullOrEmpty(PEXBCPurchasePaymentRelease.EXPORT_BC_NO) || 
                string.IsNullOrEmpty(PEXBCPurchasePaymentRelease.EVENT_NO.ToString()) || 
                string.IsNullOrEmpty(PEXBCPurchasePaymentRelease.CenterID) || 
                string.IsNullOrEmpty(PEXBCPurchasePaymentRelease.USER_ID)
               )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "CENTER_ID, EXPORT_BC_NO, RELEASE_ACTION, METHOD, PAYMENT_INSTRU, EVENT_DATE, CLAIM_TYPE, REFER_BC_NO is required";
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", PEXBCPurchasePaymentRelease.EXPORT_BC_NO);
            param.Add("@EVENT_NO", PEXBCPurchasePaymentRelease.EVENT_NO);
            param.Add("@CenterID", PEXBCPurchasePaymentRelease.CenterID);
            param.Add("@USER_ID", PEXBCPurchasePaymentRelease.USER_ID);
            param.Add("@EVENT_DATE", PEXBCPurchasePaymentRelease.EVENT_DATE);
            param.Add("@BENE_ID", PEXBCPurchasePaymentRelease.BENE_ID);
            param.Add("@ParTnor_Type1", PEXBCPurchasePaymentRelease.ParTnor_Type1);
            param.Add("@ParTnor_Type2", PEXBCPurchasePaymentRelease.ParTnor_Type2);
            param.Add("@ParTnor_Type3", PEXBCPurchasePaymentRelease.ParTnor_Type3);
            param.Add("@ParTnor_Type4", PEXBCPurchasePaymentRelease.ParTnor_Type4);
            param.Add("@ParTnor_Type5", PEXBCPurchasePaymentRelease.ParTnor_Type5);
            param.Add("@ParTnor_Type6", PEXBCPurchasePaymentRelease.ParTnor_Type6);
            param.Add("@PARTIAL_AMT1", PEXBCPurchasePaymentRelease.PARTIAL_AMT1);
            param.Add("@PARTIAL_AMT2", PEXBCPurchasePaymentRelease.PARTIAL_AMT2);
            param.Add("@PARTIAL_AMT3", PEXBCPurchasePaymentRelease.PARTIAL_AMT3);
            param.Add("@PARTIAL_AMT4", PEXBCPurchasePaymentRelease.PARTIAL_AMT4);
            param.Add("@PARTIAL_AMT5", PEXBCPurchasePaymentRelease.PARTIAL_AMT5);
            param.Add("@PARTIAL_AMT6", PEXBCPurchasePaymentRelease.PARTIAL_AMT6);
            param.Add("@PARTIAL_AMT1_THB", PEXBCPurchasePaymentRelease.PARTIAL_AMT1_THB);
            param.Add("@PARTIAL_AMT2_THB", PEXBCPurchasePaymentRelease.PARTIAL_AMT2_THB);
            param.Add("@PARTIAL_AMT3_THB", PEXBCPurchasePaymentRelease.PARTIAL_AMT3_THB);
            param.Add("@PARTIAL_AMT4_THB", PEXBCPurchasePaymentRelease.PARTIAL_AMT4_THB);
            param.Add("@PARTIAL_AMT5_THB", PEXBCPurchasePaymentRelease.PARTIAL_AMT5_THB);
            param.Add("@PARTIAL_AMT6_THB", PEXBCPurchasePaymentRelease.PARTIAL_AMT6_THB);
            param.Add("@PARTIAL_FULL_RATE", PEXBCPurchasePaymentRelease.PARTIAL_FULL_RATE);
            param.Add("@TENOR_OF_COLL", PEXBCPurchasePaymentRelease.TENOR_OF_COLL);
            param.Add("@INVOICE", PEXBCPurchasePaymentRelease.INVOICE);
            param.Add("@VOUCH_ID", PEXBCPurchasePaymentRelease.VOUCH_ID);
            param.Add("@RELETE_PACK", PEXBCPurchasePaymentRelease.RELETE_PACK);
            param.Add("@PurposeCode", PEXBCPurchasePaymentRelease.PurposeCode);
            param.Add("@TOT_NEGO_AMT", PEXBCPurchasePaymentRelease.TOT_NEGO_AMT);
            param.Add("@TOTAL_NEGO_BALANCE", PEXBCPurchasePaymentRelease.TOTAL_NEGO_BALANCE);
            param.Add("@TOTAL_NEGO_BAL_THB", PEXBCPurchasePaymentRelease.TOTAL_NEGO_BAL_THB);
            param.Add("@NEGO_COMM", PEXBCPurchasePaymentRelease.NEGO_COMM);
            param.Add("@TELEX_SWIFT", PEXBCPurchasePaymentRelease.TELEX_SWIFT);
            param.Add("@COURIER_POSTAGE", PEXBCPurchasePaymentRelease.COURIER_POSTAGE);
            param.Add("@STAMP_FEE", PEXBCPurchasePaymentRelease.STAMP_FEE);
            param.Add("@BE_STAMP", PEXBCPurchasePaymentRelease.BE_STAMP);
            param.Add("@COMM_OTHER", PEXBCPurchasePaymentRelease.COMM_OTHER);
            param.Add("@HANDING_FEE", PEXBCPurchasePaymentRelease.HANDING_FEE);
            param.Add("@DRAFTCOMM", PEXBCPurchasePaymentRelease.DRAFTCOMM);
            param.Add("@TOTAL_CHARGE", PEXBCPurchasePaymentRelease.TOTAL_CHARGE);
            param.Add("@REFUND_TAX_YN", PEXBCPurchasePaymentRelease.REFUND_TAX_YN);
            param.Add("@REFUND_TAX_AMT", PEXBCPurchasePaymentRelease.REFUND_TAX_AMT);
            param.Add("@TOTAL_AMOUNT", PEXBCPurchasePaymentRelease.TOTAL_AMOUNT);
            param.Add("@PAYMENT_INSTRU", PEXBCPurchasePaymentRelease.PAYMENT_INSTRU);
            param.Add("@METHOD", PEXBCPurchasePaymentRelease.METHOD);
            param.Add("@DISCOUNT_CCY", PEXBCPurchasePaymentRelease.DISCOUNT_CCY);
            param.Add("@DISCRATE", PEXBCPurchasePaymentRelease.DISCRATE);
            param.Add("@DISCOUNT_AMT", PEXBCPurchasePaymentRelease.DISCOUNT_AMT);
            param.Add("@ValueDate", PEXBCPurchasePaymentRelease.ValueDate);
            param.Add("@DRAFT_CCY", PEXBCPurchasePaymentRelease.DRAFT_CCY);
            param.Add("@CURRENT_INT_RATE", PEXBCPurchasePaymentRelease.CURRENT_INT_RATE);
            param.Add("@BASE_DAY", PEXBCPurchasePaymentRelease.BASE_DAY);
            param.Add("@SIGHT_START_DATE", PEXBCPurchasePaymentRelease.SIGHT_START_DATE);
            param.Add("@TERM_DUE_DATE", PEXBCPurchasePaymentRelease.TERM_DUE_DATE);
            param.Add("@SIGHT_PAID_AMT", PEXBCPurchasePaymentRelease.SIGHT_START_DATE);
            param.Add("@TERM_PAID_AMT", PEXBCPurchasePaymentRelease.TERM_PAID_AMT);
            param.Add("@SETTLEMENT_CREDIT", PEXBCPurchasePaymentRelease.SETTLEMENT_CREDIT);
            param.Add("@SIGHT_PAID_THB", PEXBCPurchasePaymentRelease.SIGHT_PAID_THB);
            param.Add("@TERM_PAID_THB", PEXBCPurchasePaymentRelease.TERM_PAID_THB);
            param.Add("@NEGO_AMT", PEXBCPurchasePaymentRelease.NEGO_AMT);
            param.Add("@LESS_AGENT", PEXBCPurchasePaymentRelease.LESS_AGENT);
            param.Add("@TOT_NEGO_AMOUNT", PEXBCPurchasePaymentRelease.TOT_NEGO_AMOUNT);
            param.Add("@NET_PROCEED_CLAIM", PEXBCPurchasePaymentRelease.NET_PROCEED_CLAIM);
            param.Add("@BANK_CHARGE_AMT", PEXBCPurchasePaymentRelease.BANK_CHARGE_AMT);
            param.Add("@PaymentType", PEXBCPurchasePaymentRelease.PaymentType);
            param.Add("@int_day", PEXBCPurchasePaymentRelease.int_day);
            param.Add("@PAYMENT_DATE", PEXBCPurchasePaymentRelease.PAYMENT_DATE);
            param.Add("@int_paid_amt", PEXBCPurchasePaymentRelease.int_paid_amt);
            param.Add("@int_paid_thb", PEXBCPurchasePaymentRelease.int_paid_thb);
            param.Add("@int_exch_rate", PEXBCPurchasePaymentRelease.int_exch_rate);


            param.Add("@RespPEXBC", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 12800);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_PurchasePayment_Release", param);

                var resppexbc = param.Get<int>("@RespPEXBC");
                var resp = param.Get<string>("@Resp");

                if (resppexbc > 0)
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export B/C NO Release Complete";
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
                        response.Message = "Export BC does not exist";
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
