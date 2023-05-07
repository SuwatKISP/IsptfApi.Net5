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

namespace ISPTF.API.Controllers.ExportBC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXBCPaymentOverDueController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public EXBCPaymentOverDueController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXBCPaymentOverDueListPageResponse>> GetAllList(string? ListType, string? CenterID, string? EXPORT_BC_NO, string? BENName, int? Page, int? PageSize)
        {
            EXBCPaymentOverDueListPageResponse response = new EXBCPaymentOverDueListPageResponse();
            string USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || Page == null || PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXBCPaymentOverDueListPageRsp>();
                return BadRequest(response);
            }
            if (ListType.Equals("RELEASE") && string.IsNullOrEmpty(USER_ID))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "USER_ID is required";
                response.Data = new List<Q_EXBCPaymentOverDueListPageRsp>();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@ListType", ListType);
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
                var results = await _db.LoadData<Q_EXBCPaymentOverDueListPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXBC_PaymentOverDueListPage",
                        param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCPaymentOverDueListPageRsp>)results;
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
                response.Data = new List<Q_EXBCPaymentOverDueListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("query")]
        public async Task<ActionResult<EXBCPaymentOverDueQueryPageResponse>> GetAllQuery(string? CenterID, string? EXPORT_BC_NO, string? BENName, int? Page, int? PageSize)
        {
            EXBCPaymentOverDueQueryPageResponse response = new EXBCPaymentOverDueQueryPageResponse();
            string USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) || Page == null || PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXBCPaymentOverDueQueryPageRsp>();
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
                var results = await _db.LoadData<Q_EXBCPaymentOverDueQueryPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXBC_PaymentOverDueQueryPage",
                        param);

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCPaymentOverDueQueryPageRsp>)results;
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
                response.Data = new List<Q_EXBCPaymentOverDueQueryPageRsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("select")]
        public async Task<ActionResult<PEXBCPEXPaymentResponse>> GetAllSelect(string? EXPORT_BC_NO, string? EVENT_NO, string? LFROM)
        {
            PEXBCPEXPaymentResponse response = new PEXBCPEXPaymentResponse();
            string USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(EXPORT_BC_NO) || string.IsNullOrEmpty(EVENT_NO) || string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO, EVENT_NO, LFROM is required";
                response.Data = new PEXBCPPaymentRsp();
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
                           storedProcedure: "usp_pEXBC_PaymentOverDue_Select",
                           param);
                var PExBcRsp = param.Get<dynamic>("@PExBcRsp");
                var pexbcpexpaymentrsp = param.Get<dynamic>("@PEXBCPEXPaymentRsp");

                if (PExBcRsp > 0 && !string.IsNullOrEmpty(pexbcpexpaymentrsp))
                {
                    PEXBCPPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXBCPPaymentRsp>(pexbcpexpaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT_BC_NO Select Error";
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

        [HttpPost("save")]
        public async Task<ActionResult<PEXBCPEXPaymentResponse>> Insert([FromBody] PEXBCPEXPaymentSaveReq pexbcsave)
        {
            PEXBCPEXPaymentResponse response = new PEXBCPEXPaymentResponse();
            string USER_ID = User.Identity.Name;

            // Validate
            if (pexbcsave.PEXBC == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "PEXBC is required.";
                response.Data = new PEXBCPPaymentRsp();
                return BadRequest(response);
            }
            if (pexbcsave.PEXPayment == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "PEXPayment is required.";
                response.Data = new PEXBCPPaymentRsp();
                return BadRequest(response);
            }

            DynamicParameters param = new DynamicParameters();
            //pExBc
            param.Add("@RECORD_TYPE", pexbcsave.PEXBC.RECORD_TYPE);
            param.Add("@REC_STATUS", pexbcsave.PEXBC.REC_STATUS);
            param.Add("@EVENT_NO", pexbcsave.PEXBC.EVENT_NO);
            param.Add("@EXPORT_BC_NO", pexbcsave.PEXBC.EXPORT_BC_NO);
            param.Add("@EVENT_MODE", pexbcsave.PEXBC.EVENT_MODE);
            param.Add("@BUSINESS_TYPE", pexbcsave.PEXBC.BUSINESS_TYPE);
            param.Add("@EVENT_TYPE", pexbcsave.PEXBC.EVENT_TYPE);
            param.Add("@EVENT_DATE", pexbcsave.PEXBC.EVENT_DATE);
            param.Add("@TENOR_OF_COLL", pexbcsave.PEXBC.TENOR_OF_COLL);
            param.Add("@TENOR_TYPE", pexbcsave.PEXBC.TENOR_TYPE);
            param.Add("@INVOICE", pexbcsave.PEXBC.INVOICE);
            param.Add("@REFER_BC_NO", pexbcsave.PEXBC.REFER_BC_NO);
            param.Add("@RELETE_PACK", pexbcsave.PEXBC.RELETE_PACK);
            param.Add("@DRAFT_CCY", pexbcsave.PEXBC.DRAFT_CCY);
            param.Add("@DRAFT_AMT", pexbcsave.PEXBC.DRAFT_AMT);
            param.Add("@SIGHT_AMT", pexbcsave.PEXBC.SIGHT_AMT);
            param.Add("@TERM_AMT", pexbcsave.PEXBC.TERM_AMT);
            param.Add("@GOOD_CODE", pexbcsave.PEXBC.GOOD_CODE);
            param.Add("@REL_CODE", pexbcsave.PEXBC.REL_CODE);
            param.Add("@CLAIM_TYPE", pexbcsave.PEXBC.CLAIM_TYPE);
            param.Add("@SIGHT_START_DATE", pexbcsave.PEXBC.SIGHT_START_DATE);
            param.Add("@SIGHT_DUE_DATE", pexbcsave.PEXBC.SIGHT_DUE_DATE);
            param.Add("@TENOR_DAY", pexbcsave.PEXBC.TENOR_DAY);
            param.Add("@TENOR_DAY_DESC", pexbcsave.PEXBC.TENOR_DAY_DESC);
            param.Add("@TERM_START_DATE", pexbcsave.PEXBC.TERM_START_DATE);
            param.Add("@TERM_DUE_DATE", pexbcsave.PEXBC.TERM_DUE_DATE);
            param.Add("@PURCH_DISC_DATE", pexbcsave.PEXBC.PURCH_DISC_DATE);
            param.Add("@DRAWEE_INFO", pexbcsave.PEXBC.DRAWEE_INFO);
            param.Add("@CNTY_CODE", pexbcsave.PEXBC.CNTY_CODE);
            param.Add("@Cust_AO", pexbcsave.PEXBC.Cust_AO);
            param.Add("@Cust_LO", pexbcsave.PEXBC.Cust_LO);
            param.Add("@BENE_ID", pexbcsave.PEXBC.BENE_ID);
            param.Add("@BENE_INFO", pexbcsave.PEXBC.BENE_INFO);
            param.Add("@ISSUE_BANK_ID", pexbcsave.PEXBC.ISSUE_BANK_ID);
            param.Add("@ISSUE_BANK_INFO", pexbcsave.PEXBC.ISSUE_BANK_INFO);
            param.Add("@COLLECT_AGENT", pexbcsave.PEXBC.COLLECT_AGENT);
            param.Add("@AGENT_BANK_ID", pexbcsave.PEXBC.AGENT_BANK_ID);
            param.Add("@AGENT_BANK_INFO", pexbcsave.PEXBC.AGENT_BANK_INFO);
            param.Add("@AGENT_BANK_REF", pexbcsave.PEXBC.AGENT_BANK_REF);
            param.Add("@AGENT_BANK_NOSTRO", pexbcsave.PEXBC.AGENT_BANK_NOSTRO);
            param.Add("@RESTRICT", pexbcsave.PEXBC.RESTRICT);
            param.Add("@RESTRICT_TO_BK_NAME", pexbcsave.PEXBC.RESTRICT_TO_BK_NAME);
            param.Add("@RESTRICT_TO_BK_ADDR1", pexbcsave.PEXBC.RESTRICT_TO_BK_ADDR1);
            param.Add("@RESTRICT_TO_BK_ADDR2", pexbcsave.PEXBC.RESTRICT_TO_BK_ADDR2);
            param.Add("@RESTRICT_TO_BK_ADDR3", pexbcsave.PEXBC.RESTRICT_TO_BK_ADDR3);
            param.Add("@RESTRICT_REFER", pexbcsave.PEXBC.RESTRICT_REFER);
            param.Add("@RESTRICT_FR_BK_NAME", pexbcsave.PEXBC.RESTRICT_FR_BK_NAME);
            param.Add("@RESTRICT_FR_BK_ADDR1", pexbcsave.PEXBC.RESTRICT_FR_BK_ADDR1);
            param.Add("@RESTRICT_FR_BK_ADDR2", pexbcsave.PEXBC.RESTRICT_FR_BK_ADDR2);
            param.Add("@RESTRICT_FR_BK_ADDR3", pexbcsave.PEXBC.RESTRICT_FR_BK_ADDR3);
            param.Add("@PARTIAL_FULL_RATE", pexbcsave.PEXBC.PARTIAL_FULL_RATE);
            param.Add("@INT_RATE_METHOD", pexbcsave.PEXBC.INT_RATE_METHOD);
            param.Add("@TYPE_OF_ACCOUNT", pexbcsave.PEXBC.TYPE_OF_ACCOUNT);
            param.Add("@CREDIT_CURRENCY", pexbcsave.PEXBC.CREDIT_CURRENCY);
            param.Add("@DISCOUNT_DAY", pexbcsave.PEXBC.DISCOUNT_DAY);
            param.Add("@GRACE_PERIOD", pexbcsave.PEXBC.GRACE_PERIOD);
            param.Add("@DISC_BASE_DAY", pexbcsave.PEXBC.DISC_BASE_DAY);
            param.Add("@BASE_DAY", pexbcsave.PEXBC.BASE_DAY);
            param.Add("@DISCOUNT_RATE", pexbcsave.PEXBC.DISCOUNT_RATE);
            param.Add("@INT_BASE_RATE", pexbcsave.PEXBC.INT_BASE_RATE);
            param.Add("@INT_SPREAD_RATE", pexbcsave.PEXBC.INT_SPREAD_RATE);
            param.Add("@CURRENT_DIS_RATE", pexbcsave.PEXBC.CURRENT_DIS_RATE);
            param.Add("@CURRENT_INT_RATE", pexbcsave.PEXBC.CURRENT_INT_RATE);
            param.Add("@PAY_BY", pexbcsave.PEXBC.PAY_BY);
            param.Add("@NEGO_AMT", pexbcsave.PEXBC.NEGO_AMT);
            param.Add("@LESS_AGENT", pexbcsave.PEXBC.LESS_AGENT);
            param.Add("@PURCHASE_AMT", pexbcsave.PEXBC.PURCHASE_AMT);
            param.Add("@PURCHASE_RATE", pexbcsave.PEXBC.PURCHASE_RATE);
            param.Add("@TOTAL_NEGO_BALANCE", pexbcsave.PEXBC.TOTAL_NEGO_BALANCE);
            param.Add("@TOTAL_NEGO_BAL_THB", pexbcsave.PEXBC.TOTAL_NEGO_BAL_THB);
            param.Add("@TOT_NEGO_AMT", pexbcsave.PEXBC.TOT_NEGO_AMT);
            param.Add("@TOT_NEGO_AMOUNT", pexbcsave.PEXBC.TOT_NEGO_AMOUNT);
            param.Add("@BANK_CHARGE_AMT", pexbcsave.PEXBC.BANK_CHARGE_AMT);
            param.Add("@NET_PROCEED_CLAIM", pexbcsave.PEXBC.NET_PROCEED_CLAIM);
            param.Add("@CLAIM_PAY_BY", pexbcsave.PEXBC.CLAIM_PAY_BY);
            param.Add("@ParTnor_Type1", pexbcsave.PEXBC.ParTnor_Type1);
            param.Add("@ParTnor_Type2", pexbcsave.PEXBC.ParTnor_Type2);
            param.Add("@ParTnor_Type3", pexbcsave.PEXBC.ParTnor_Type3);
            param.Add("@ParTnor_Type4", pexbcsave.PEXBC.ParTnor_Type4);
            param.Add("@ParTnor_Type5", pexbcsave.PEXBC.ParTnor_Type5);
            param.Add("@ParTnor_Type6", pexbcsave.PEXBC.ParTnor_Type6);
            param.Add("@PARTIAL_AMT1", pexbcsave.PEXBC.PARTIAL_AMT1);
            param.Add("@PARTIAL_AMT2", pexbcsave.PEXBC.PARTIAL_AMT2);
            param.Add("@PARTIAL_AMT3", pexbcsave.PEXBC.PARTIAL_AMT3);
            param.Add("@PARTIAL_AMT4", pexbcsave.PEXBC.PARTIAL_AMT4);
            param.Add("@PARTIAL_AMT5", pexbcsave.PEXBC.PARTIAL_AMT5);
            param.Add("@PARTIAL_AMT6", pexbcsave.PEXBC.PARTIAL_AMT6);
            param.Add("@PARTIAL_RATE1", pexbcsave.PEXBC.PARTIAL_RATE1);
            param.Add("@PARTIAL_RATE2", pexbcsave.PEXBC.PARTIAL_RATE2);
            param.Add("@PARTIAL_RATE3", pexbcsave.PEXBC.PARTIAL_RATE3);
            param.Add("@PARTIAL_RATE4", pexbcsave.PEXBC.PARTIAL_RATE4);
            param.Add("@PARTIAL_RATE5", pexbcsave.PEXBC.PARTIAL_RATE5);
            param.Add("@PARTIAL_RATE6", pexbcsave.PEXBC.PARTIAL_RATE6);
            param.Add("@PARTIAL_AMT1_THB", pexbcsave.PEXBC.PARTIAL_AMT1_THB);
            param.Add("@PARTIAL_AMT2_THB", pexbcsave.PEXBC.PARTIAL_AMT2_THB);
            param.Add("@PARTIAL_AMT3_THB", pexbcsave.PEXBC.PARTIAL_AMT3_THB);
            param.Add("@PARTIAL_AMT4_THB", pexbcsave.PEXBC.PARTIAL_AMT4_THB);
            param.Add("@PARTIAL_AMT5_THB", pexbcsave.PEXBC.PARTIAL_AMT5_THB);
            param.Add("@PARTIAL_AMT6_THB", pexbcsave.PEXBC.PARTIAL_AMT6_THB);
            param.Add("@FORWARD_CONRACT_NO", pexbcsave.PEXBC.FORWARD_CONRACT_NO);
            param.Add("@FORWARD_CONRACT_NO1", pexbcsave.PEXBC.FORWARD_CONRACT_NO1);
            param.Add("@FORWARD_CONRACT_NO2", pexbcsave.PEXBC.FORWARD_CONRACT_NO2);
            param.Add("@FORWARD_CONRACT_NO3", pexbcsave.PEXBC.FORWARD_CONRACT_NO3);
            param.Add("@FORWARD_CONRACT_NO4", pexbcsave.PEXBC.FORWARD_CONRACT_NO4);
            param.Add("@FORWARD_CONRACT_NO5", pexbcsave.PEXBC.FORWARD_CONRACT_NO5);
            param.Add("@FORWARD_CONRACT_NO6", pexbcsave.PEXBC.FORWARD_CONRACT_NO6);
            param.Add("@NEGO_COMM", pexbcsave.PEXBC.NEGO_COMM);
            param.Add("@TELEX_SWIFT", pexbcsave.PEXBC.TELEX_SWIFT);
            param.Add("@COURIER_POSTAGE", pexbcsave.PEXBC.COURIER_POSTAGE);
            param.Add("@STAMP_FEE", pexbcsave.PEXBC.STAMP_FEE);
            param.Add("@BE_STAMP", pexbcsave.PEXBC.BE_STAMP);
            param.Add("@COMM_OTHER", pexbcsave.PEXBC.COMM_OTHER);
            param.Add("@HANDING_FEE", pexbcsave.PEXBC.HANDING_FEE);
            param.Add("@DRAFTCOMM", pexbcsave.PEXBC.DRAFTCOMM);
            param.Add("@INT_AMT_THB", pexbcsave.PEXBC.INT_AMT_THB);
            param.Add("@COMMONTT", pexbcsave.PEXBC.COMMONTT);
            param.Add("@TOTAL_CHARGE", pexbcsave.PEXBC.TOTAL_CHARGE);
            param.Add("@REFUND_TAX_YN", pexbcsave.PEXBC.REFUND_TAX_YN);
            param.Add("@REFUND_TAX_AMT", pexbcsave.PEXBC.REFUND_TAX_AMT);
            param.Add("@DISCOUNT_CCY", pexbcsave.PEXBC.DISCOUNT_CCY);
            param.Add("@DISCRATE", pexbcsave.PEXBC.DISCRATE);
            param.Add("@DISCOUNT_AMT", pexbcsave.PEXBC.DISCOUNT_AMT);
            param.Add("@TOTAL_AMOUNT", pexbcsave.PEXBC.TOTAL_AMOUNT);
            param.Add("@PAYMENT_INSTRU", pexbcsave.PEXBC.PAYMENT_INSTRU);
            param.Add("@METHOD", pexbcsave.PEXBC.METHOD);
            param.Add("@ACBAHTNET", pexbcsave.PEXBC.ACBAHTNET);
            param.Add("@BAHTNET", pexbcsave.PEXBC.BAHTNET);
            param.Add("@RECEIVED_NO", pexbcsave.PEXBC.RECEIVED_NO);
            param.Add("@ALLOCATION", pexbcsave.PEXBC.ALLOCATION);
            param.Add("@NARRATIVE", pexbcsave.PEXBC.NARRATIVE);
            param.Add("@SEQ_ACCEPT_DUE", pexbcsave.PEXBC.SEQ_ACCEPT_DUE);
            param.Add("@COMFIRM_DUE", pexbcsave.PEXBC.COMFIRM_DUE);
            param.Add("@PLUS_MINUS_DISC", pexbcsave.PEXBC.PLUS_MINUS_DISC);
            param.Add("@DISC_DAYS_PLUS_MINUS", pexbcsave.PEXBC.DISC_DAYS_PLUS_MINUS);
            param.Add("@RECEIVE_PAY_AMT", pexbcsave.PEXBC.RECEIVE_PAY_AMT);
            param.Add("@EXCHANGE_RATE", pexbcsave.PEXBC.EXCHANGE_RATE);
            param.Add("@REFUND_DISC_RECEIVE", pexbcsave.PEXBC.REFUND_DISC_RECEIVE);
            param.Add("@DISC_RECEIVE", pexbcsave.PEXBC.DISC_RECEIVE);
            param.Add("@LC_DATE", pexbcsave.PEXBC.LC_DATE);
            param.Add("@COVERING_DATE", pexbcsave.PEXBC.COVERING_DATE);
            param.Add("@COVERING_FOR", pexbcsave.PEXBC.COVERING_FOR);
            param.Add("@ADVICE_ISSUE_BANK", pexbcsave.PEXBC.ADVICE_ISSUE_BANK);
            param.Add("@ADVICE_FORMAT", pexbcsave.PEXBC.ADVICE_FORMAT);
            param.Add("@REMIT_CLAIM_TYPE", pexbcsave.PEXBC.REMIT_CLAIM_TYPE);
            param.Add("@REIMBURSE_BANK_ID", pexbcsave.PEXBC.REIMBURSE_BANK_ID);
            param.Add("@REIMBURSE_BANK_INFO", pexbcsave.PEXBC.REIMBURSE_BANK_INFO);
            param.Add("@SWIFT_BANK", pexbcsave.PEXBC.SWIFT_BANK);
            param.Add("@SWIFT_MAIL", pexbcsave.PEXBC.SWIFT_MAIL);
            param.Add("@CLAIM_FORMAT", pexbcsave.PEXBC.CLAIM_FORMAT);
            param.Add("@VALUE_DATE", pexbcsave.PEXBC.VALUE_DATE);
            param.Add("@THIRD_BANK_ID", pexbcsave.PEXBC.THIRD_BANK_ID);
            param.Add("@THIRD_BANK_INFO", pexbcsave.PEXBC.THIRD_BANK_INFO);
            param.Add("@DISCREPANCY_TYPE", pexbcsave.PEXBC.DISCREPANCY_TYPE);
            param.Add("@SWIFT_DISC", pexbcsave.PEXBC.SWIFT_DISC);
            param.Add("@DOCUMENT_COPY", pexbcsave.PEXBC.DOCUMENT_COPY);

            // Convert bool to string => DB BIT (0/1)
            string SIGHT_BASIS = "0";
            if (pexbcsave.PEXBC.SIGHT_BASIS == true)
            {
                SIGHT_BASIS = "1";
            }
            string ART44A = "0";
            if (pexbcsave.PEXBC.ART44A == true)
            {
                ART44A = "1";
            }
            string ENDORSED = "0";
            if (pexbcsave.PEXBC.ENDORSED == true)
            {
                ENDORSED = "1";
            }
            string MT750 = "0";
            if (pexbcsave.PEXBC.MT750 == true)
            {
                MT750 = "1";
            }

            param.Add("@SIGHT_BASIS", SIGHT_BASIS);
            param.Add("@ART44A", ART44A);
            param.Add("@ENDORSED", ENDORSED);
            param.Add("@MT750", MT750);

            param.Add("@ADJ_TOT_NEGO_AMOUNT", pexbcsave.PEXBC.ADJ_TOT_NEGO_AMOUNT);
            param.Add("@ADJ_LESS_CHARGE_AMT", pexbcsave.PEXBC.ADJ_LESS_CHARGE_AMT);
            param.Add("@ADJUST_COVERING_AMT", pexbcsave.PEXBC.ADJUST_COVERING_AMT);
            param.Add("@ADJUST_TENOR", pexbcsave.PEXBC.ADJUST_TENOR);
            param.Add("@ADJUST_LC_REF", pexbcsave.PEXBC.ADJUST_LC_REF);
            param.Add("@PAYMENT_INSTRC", pexbcsave.PEXBC.PAYMENT_INSTRC);
            param.Add("@TXTDOCUMENT", pexbcsave.PEXBC.TXTDOCUMENT);
            param.Add("@CHARGE_ACC", pexbcsave.PEXBC.CHARGE_ACC);
            param.Add("@DRAFT", pexbcsave.PEXBC.DRAFT);
            param.Add("@MT202", pexbcsave.PEXBC.MT202);
            param.Add("@FB_CURRENCY", pexbcsave.PEXBC.FB_CURRENCY);
            param.Add("@FB_AMT", pexbcsave.PEXBC.FB_AMT);
            param.Add("@FB_RATE", pexbcsave.PEXBC.FB_RATE);
            param.Add("@FB_AMT_THB", pexbcsave.PEXBC.FB_AMT_THB);
            param.Add("@COLLECT_REFUND", pexbcsave.PEXBC.COLLECT_REFUND);
            param.Add("@USER_ID", pexbcsave.PEXBC.USER_ID);
            param.Add("@IN_USE", pexbcsave.PEXBC.IN_USE);
            param.Add("@AUTH_CODE", pexbcsave.PEXBC.AUTH_CODE);
            param.Add("@GENACC_FLAG", pexbcsave.PEXBC.GENACC_FLAG);
            param.Add("@VOUCH_ID", pexbcsave.PEXBC.VOUCH_ID);
            param.Add("@APPVNO", pexbcsave.PEXBC.APPVNO);
            param.Add("@FACNO", pexbcsave.PEXBC.FACNO);
            param.Add("@AUTOOVERDUE", pexbcsave.PEXBC.AUTOOVERDUE);
            param.Add("@LCOVERDUE", pexbcsave.PEXBC.LCOVERDUE);
            param.Add("@OVESEQNO", pexbcsave.PEXBC.OVESEQNO);
            param.Add("@INTFLAG", pexbcsave.PEXBC.INTFLAG);
            param.Add("@IntRateCode", pexbcsave.PEXBC.IntRateCode);
            param.Add("@CFRRate", pexbcsave.PEXBC.CFRRate);
            param.Add("@INTCODE", pexbcsave.PEXBC.INTCODE);
            param.Add("@OINTRATE", pexbcsave.PEXBC.OINTRATE);
            param.Add("@OINTSPDRATE", pexbcsave.PEXBC.OINTSPDRATE);
            param.Add("@OINTCURRATE", pexbcsave.PEXBC.OINTCURRATE);
            param.Add("@OINTDAY", pexbcsave.PEXBC.OINTDAY);
            param.Add("@OBASEDAY", pexbcsave.PEXBC.OBASEDAY);
            param.Add("@BFINTAMT", pexbcsave.PEXBC.BFINTAMT);
            param.Add("@SELLING_RATE", pexbcsave.PEXBC.SELLING_RATE);
            param.Add("@BFINTTHB", pexbcsave.PEXBC.BFINTTHB);
            param.Add("@INTBALANCE", pexbcsave.PEXBC.INTBALANCE);
            param.Add("@PRNBALANCE", pexbcsave.PEXBC.PRNBALANCE);
            param.Add("@LASTINTAMT", pexbcsave.PEXBC.LASTINTAMT);
            param.Add("@DMS", pexbcsave.PEXBC.DMS);
            param.Add("@LASTINTDATE", pexbcsave.PEXBC.LASTINTDATE);
            param.Add("@PAYMENTTYPE", pexbcsave.PEXBC.PAYMENTTYPE);
            param.Add("@CONFIRM_DATE", pexbcsave.PEXBC.CONFIRM_DATE);
            param.Add("@TOTALACCRUAMT", pexbcsave.PEXBC.TOTALACCRUAMT);
            param.Add("@TOTALACCRUBHT", pexbcsave.PEXBC.TOTALACCRUBHT);
            param.Add("@ACCRUAMT", pexbcsave.PEXBC.ACCRUAMT);
            param.Add("@ACCRUBHT", pexbcsave.PEXBC.ACCRUBHT);
            param.Add("@DATELASTACCRU", pexbcsave.PEXBC.DATELASTACCRU);
            param.Add("@PASTDUEDATE", pexbcsave.PEXBC.PASTDUEDATE);
            param.Add("@PASTDUEFLAG", pexbcsave.PEXBC.PASTDUEFLAG);
            param.Add("@TOTALSUSPAMT", pexbcsave.PEXBC.TOTALSUSPAMT);
            param.Add("@TOTALSUSPBHT", pexbcsave.PEXBC.TOTALSUSPBHT);
            param.Add("@SUSPAMT", pexbcsave.PEXBC.SUSPAMT);
            param.Add("@SUSPBHT", pexbcsave.PEXBC.SUSPBHT);
            param.Add("@CenterID", pexbcsave.PEXBC.CenterID);
            param.Add("@BCPastDue", pexbcsave.PEXBC.BCPastDue);
            param.Add("@DateStartAccru", pexbcsave.PEXBC.DateStartAccru);
            param.Add("@DateToStop", pexbcsave.PEXBC.DateToStop);
            param.Add("@ValueDate", pexbcsave.PEXBC.ValueDate);
            param.Add("@FlagBack", pexbcsave.PEXBC.FlagBack);
            param.Add("@NewAccruCcy", pexbcsave.PEXBC.NewAccruCcy);
            param.Add("@NewAccruAmt", pexbcsave.PEXBC.NewAccruAmt);
            param.Add("@AccruPending", pexbcsave.PEXBC.AccruPending);
            param.Add("@LastAccruCcy", pexbcsave.PEXBC.LastAccruCcy);
            param.Add("@LastAccruAmt", pexbcsave.PEXBC.LastAccruAmt);
            param.Add("@DAccruAmt", pexbcsave.PEXBC.DAccruAmt);
            param.Add("@CCS_ACCT", pexbcsave.PEXBC.CCS_ACCT);
            param.Add("@CCS_LmType", pexbcsave.PEXBC.CCS_LmType);
            param.Add("@CCS_CNUM", pexbcsave.PEXBC.CCS_CNUM);
            param.Add("@CCS_CIFRef", pexbcsave.PEXBC.CCS_CIFRef);
            param.Add("@ObjectType", pexbcsave.PEXBC.ObjectType);
            param.Add("@UnderlyName", pexbcsave.PEXBC.UnderlyName);
            param.Add("@BPOFlag", pexbcsave.PEXBC.BPOFlag);
            param.Add("@Campaign_Code", pexbcsave.PEXBC.Campaign_Code);
            param.Add("@Campaign_EffDate", pexbcsave.PEXBC.Campaign_EffDate);
            param.Add("@PurposeCode", pexbcsave.PEXBC.PurposeCode);
            //pExPayment
            param.Add("@DOCNUMBER", pexbcsave.PEXPayment.DOCNUMBER);
            param.Add("@PAY_TYPE", pexbcsave.PEXPayment.PAY_TYPE);
            param.Add("@PAYMENT_DATE", pexbcsave.PEXPayment.PAYMENT_DATE);
            param.Add("@AGENT_PAY_BY", pexbcsave.PEXPayment.AGENT_PAY_BY);
            param.Add("@SETTLEMENT_CREDIT", pexbcsave.PEXPayment.SETTLEMENT_CREDIT);
            param.Add("@MTFLAG", pexbcsave.PEXPayment.MTFLAG);
            param.Add("@SIGHT_PAID_AMT", pexbcsave.PEXPayment.SIGHT_PAID_AMT);
            param.Add("@SIGHT_PAID_RATE", pexbcsave.PEXPayment.SIGHT_PAID_RATE);
            param.Add("@SIGHT_PAID_THB", pexbcsave.PEXPayment.SIGHT_PAID_THB);
            param.Add("@SIGHT_FORWARD", pexbcsave.PEXPayment.SIGHT_FORWARD);
            param.Add("@TERM_PAID_AMT", pexbcsave.PEXPayment.TERM_PAID_AMT);
            param.Add("@TERM_PAID_RATE", pexbcsave.PEXPayment.TERM_PAID_RATE);
            param.Add("@TERM_PAID_THB", pexbcsave.PEXPayment.TERM_PAID_THB);
            param.Add("@TERM_FORWARD", pexbcsave.PEXPayment.TERM_FORWARD);
            param.Add("@TOT_PRINC_PAID", pexbcsave.PEXPayment.TOT_PRINC_PAID);
            param.Add("@Com_Lieu", pexbcsave.PEXPayment.Com_Lieu);
            param.Add("@ComLieuRate", pexbcsave.PEXPayment.ComLieuRate);
            param.Add("@fb_ccy", pexbcsave.PEXPayment.fb_ccy);
            param.Add("@Agent_amt", pexbcsave.PEXPayment.Agent_amt);
            param.Add("@Agent_rate", pexbcsave.PEXPayment.Agent_rate);
            param.Add("@Agent_thb", pexbcsave.PEXPayment.Agent_thb);
            param.Add("@over_paid_amt", pexbcsave.PEXPayment.over_paid_amt);
            param.Add("@over_paid_rate", pexbcsave.PEXPayment.over_paid_rate);
            param.Add("@over_paid_thb", pexbcsave.PEXPayment.over_paid_thb);
            param.Add("@int_day", pexbcsave.PEXPayment.int_day);
            param.Add("@int_paid_amt", pexbcsave.PEXPayment.int_paid_amt);
            param.Add("@int_paid_rate", pexbcsave.PEXPayment.int_paid_rate);
            param.Add("@int_exch_rate", pexbcsave.PEXPayment.int_exch_rate);
            param.Add("@int_paid_thb", pexbcsave.PEXPayment.int_paid_thb);
            param.Add("@prn_paid_thb", pexbcsave.PEXPayment.prn_paid_thb);
            param.Add("@Charge_Ccy", pexbcsave.PEXPayment.Charge_Ccy);
            param.Add("@Charge_Rate", pexbcsave.PEXPayment.Charge_Rate);
            param.Add("@Charge_Thb", pexbcsave.PEXPayment.Charge_Thb);
            param.Add("@TOTAL_DUE_TO_CUS", pexbcsave.PEXPayment.TOTAL_DUE_TO_CUS);
            param.Add("@FcdAmt", pexbcsave.PEXPayment.FcdAmt);
            param.Add("@FcdAcc", pexbcsave.PEXPayment.FcdAcc);
            param.Add("@MTAmt", pexbcsave.PEXPayment.MTAmt);
            param.Add("@Debit_credit_flag", pexbcsave.PEXPayment.Debit_credit_flag);
            param.Add("@ACCOUNT_NO1", pexbcsave.PEXPayment.ACCOUNT_NO1);
            param.Add("@ACCOUNT_NO2", pexbcsave.PEXPayment.ACCOUNT_NO2);
            param.Add("@ACCOUNT_NO3", pexbcsave.PEXPayment.ACCOUNT_NO3);
            param.Add("@AMT_DEBIT_AC1", pexbcsave.PEXPayment.AMT_DEBIT_AC1);
            param.Add("@AMT_DEBIT_AC2", pexbcsave.PEXPayment.AMT_DEBIT_AC2);
            param.Add("@AMT_DEBIT_AC3", pexbcsave.PEXPayment.AMT_DEBIT_AC3);
            param.Add("@AMT_CREDIT_AC1", pexbcsave.PEXPayment.AMT_CREDIT_AC1);
            param.Add("@AMT_CREDIT_AC2", pexbcsave.PEXPayment.AMT_CREDIT_AC2);
            param.Add("@AMT_CREDIT_AC3", pexbcsave.PEXPayment.AMT_CREDIT_AC3);
            param.Add("@CASH", pexbcsave.PEXPayment.CASH);
            param.Add("@CHEQUE_AMT", pexbcsave.PEXPayment.CHEQUE_AMT);
            param.Add("@CHEQUE_NO", pexbcsave.PEXPayment.CHEQUE_NO);
            param.Add("@CHEQUE_BK_BRN", pexbcsave.PEXPayment.CHEQUE_BK_BRN);
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

            try
            {
                var results = await _db.LoadData<PEXBCPEXPaymentRsp, dynamic>(
                            storedProcedure: "usp_pEXBC_PaymentOverDue_Save",
                            param);

                var PExBcRsp = param.Get<dynamic>("@PExBcRsp");
                var pexbcpexpaymentrsp = param.Get<dynamic>("@PEXBCPEXPaymentRsp");

                if (PExBcRsp == 1 && !string.IsNullOrEmpty(pexbcpexpaymentrsp))
                {
                    PEXBCPPaymentRsp jsonResponse = JsonSerializer.Deserialize<PEXBCPPaymentRsp>(pexbcpexpaymentrsp);
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = jsonResponse;
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT_BC_NO Select Error";
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

        [HttpPost("delete")]
        public async Task<ActionResult<string>> EXPCPaymentOverDueDeleteReq([FromBody] EXPCPaymentOverDueDeleteReq data)
        {
            EXBCResultResponse response = new EXBCResultResponse();
            // Validate
            if (string.IsNullOrEmpty(data.EXPORT_BC_NO) ||
                string.IsNullOrEmpty(data.VOUCH_ID) ||
                string.IsNullOrEmpty(data.EVENT_DATE)
                )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO, VOUCH_ID, EVENT_DATE is required";
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("EXPORT_BC_NO", data.EXPORT_BC_NO);
            param.Add("VOUCH_ID", data.VOUCH_ID);
            param.Add("EVENT_DATE", data.EVENT_DATE);

            param.Add("PExBcRsp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 12800);

            //param.Add("Resp", dbType: DbType.Int32,
            param.Add("Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_PaymentOverDue_Delete", param);
                //var resp = param.Get<int>("Resp");
                var pexbcrsp = param.Get<int>("PExBcRsp");

                var resp = param.Get<string>("Resp");

                if (pexbcrsp > 0)
                {

                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export B/C Number Deleted";
                    return Ok(response);
                }
                else
                {

                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Export B/C Number Delete Error";
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
        public async Task<ActionResult<string>> EXPCPaymentOverDueReleaseReq([FromBody] EXPCPaymentOverDueReleaseReq exbcpaymentoverduerelease)
        {
            EXBCResultResponse response = new EXBCResultResponse();

            // Validate
            if (string.IsNullOrEmpty(exbcpaymentoverduerelease.EXPORT_BC_NO)
                || string.IsNullOrEmpty(exbcpaymentoverduerelease.METHOD)
                || string.IsNullOrEmpty(exbcpaymentoverduerelease.PAYMENT_INSTRU)
               )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO, METHOD, PAYMENT_INSTRU is required";
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", exbcpaymentoverduerelease.EXPORT_BC_NO);
            param.Add("@BENE_ID", exbcpaymentoverduerelease.BENE_ID);
            param.Add("@VOUCH_ID", exbcpaymentoverduerelease.VOUCH_ID);
            param.Add("@EVENT_DATE", exbcpaymentoverduerelease.EVENT_DATE);
            param.Add("@CenterID", exbcpaymentoverduerelease.CenterID);
            param.Add("@TxBaseDay", exbcpaymentoverduerelease.TxBaseDay);
            param.Add("@USER_ID", exbcpaymentoverduerelease.USER_ID);
            param.Add("@ValueDate", exbcpaymentoverduerelease.ValueDate);
            param.Add("@NEGO_COMM", exbcpaymentoverduerelease.NEGO_COMM);
            param.Add("@TELEX_SWIFT", exbcpaymentoverduerelease.TELEX_SWIFT);
            param.Add("@COURIER_POSTAGE", exbcpaymentoverduerelease.COURIER_POSTAGE);
            param.Add("@STAMP_FEE", exbcpaymentoverduerelease.STAMP_FEE);
            param.Add("@BE_STAMP", exbcpaymentoverduerelease.BE_STAMP);
            param.Add("@COMM_OTHER", exbcpaymentoverduerelease.COMM_OTHER);
            param.Add("@HANDING_FEE", exbcpaymentoverduerelease.HANDING_FEE);
            param.Add("@DRAFTCOMM", exbcpaymentoverduerelease.DRAFTCOMM);
            param.Add("@TOTAL_CHARGE", exbcpaymentoverduerelease.TOTAL_CHARGE);
            param.Add("@REFUND_TAX_YN", exbcpaymentoverduerelease.REFUND_TAX_YN);
            param.Add("@REFUND_TAX_AMT", exbcpaymentoverduerelease.REFUND_TAX_AMT);
            param.Add("@PAYMENTTYPE", exbcpaymentoverduerelease.PAYMENTTYPE);
            param.Add("@NARRATIVE", exbcpaymentoverduerelease.NARRATIVE);
            param.Add("@ALLOCATION", exbcpaymentoverduerelease.ALLOCATION);
            param.Add("@AUTOOVERDUE", exbcpaymentoverduerelease.AUTOOVERDUE);
            param.Add("@LCOVERDUE", exbcpaymentoverduerelease.LCOVERDUE);
            param.Add("@PAYMENT_INSTRU", exbcpaymentoverduerelease.PAYMENT_INSTRU);
            param.Add("@METHOD", exbcpaymentoverduerelease.METHOD);
            param.Add("@INTCODE", exbcpaymentoverduerelease.INTCODE);
            param.Add("@OINTRATE", exbcpaymentoverduerelease.OINTRATE);
            param.Add("@OINTSPDRATE", exbcpaymentoverduerelease.OINTSPDRATE);
            param.Add("@OINTCURRATE", exbcpaymentoverduerelease.OINTCURRATE);
            param.Add("@OINTDAY", exbcpaymentoverduerelease.OINTDAY);
            param.Add("@INTBALANCE", exbcpaymentoverduerelease.INTBALANCE);
            param.Add("@LASTINTAMT", exbcpaymentoverduerelease.LASTINTAMT);
            param.Add("@PRNBALANCE", exbcpaymentoverduerelease.PRNBALANCE);
            param.Add("@TOTAL_NEGO_BALANCE", exbcpaymentoverduerelease.TOTAL_NEGO_BALANCE);
            param.Add("@VALUE_DATE", exbcpaymentoverduerelease.VALUE_DATE);
            param.Add("@PASTDUEDATE", exbcpaymentoverduerelease.PASTDUEDATE);
            param.Add("@int_paid_thb", exbcpaymentoverduerelease.int_paid_thb);

            param.Add("PExBcRsp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 12800);

            //param.Add("Resp", dbType: DbType.Int32,
            param.Add("Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_PaymentOverDue_Release", param);
                //var resp = param.Get<int>("Resp");
                var pexbcrsp = param.Get<int>("PExBcRsp");

                var resp = param.Get<string>("Resp");

                if (pexbcrsp > 0)
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
                        response.Message = "Export BC does not Exist";
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
