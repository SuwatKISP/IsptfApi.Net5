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
using ISPTF.Models.Controllers.ExportBC;

namespace ISPTF.API.Controllers.ExportBC
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EXBCReversePurchaseController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public EXBCReversePurchaseController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public async Task<ActionResult<EXBCReversePurchaseListPageResponse>> List(string? ListType, string? CenterID, string? EXPORT_BC_NO, string? BENName, int? Page, int? PageSize)
        {
            EXBCReversePurchaseListPageResponse response = new EXBCReversePurchaseListPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || 
                string.IsNullOrEmpty(CenterID) || 
                Page == null || 
                PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXBCReversePurchaseListPageRsp>();
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
                var results = await _db.LoadData<Q_EXBCReversePurchaseListPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXBC_ReversePurchaseListPage",
                        param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCReversePurchaseListPageRsp>)results;
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
                response.Data = new List<Q_EXBCReversePurchaseListPageRsp>();
            }
            return BadRequest(response);
        }

        [HttpGet("query")]
        public async Task<ActionResult<EXBCReversePurchaseQueryPageResponse>> Query(string? CenterID, string? EXPORT_BC_NO, string? BENName, int? Page, int? PageSize)
        {
            EXBCReversePurchaseQueryPageResponse response = new EXBCReversePurchaseQueryPageResponse();
            var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(CenterID) || Page == null || PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXBCReversePurchaseQueryPageRsp>();
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
                var results = await _db.LoadData<Q_EXBCReversePurchaseQueryPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXBC_ReversePurchaseQueryPage",
                        param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCReversePurchaseQueryPageRsp>)results;
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
                response.Data = new List<Q_EXBCReversePurchaseQueryPageRsp>();
            }
            return BadRequest(response);
        }


        [HttpGet("select")]
        public async Task<ActionResult<PEXBCResponse>> Select(string? EXPORT_BC_NO, string? EVENT_NO, string? LFROM)
        {
            PEXBCListResponse response = new PEXBCListResponse();
            var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(EXPORT_BC_NO) || string.IsNullOrEmpty(EVENT_NO) || string.IsNullOrEmpty(LFROM))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO, EVENT_NO, LFROM is required";
                response.Data = new List<PEXBC>();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@EVENT_NO", EVENT_NO);
            param.Add("@LFROM", LFROM);

            try
            {
                var results = await _db.LoadData<PEXBC, dynamic>(
                        storedProcedure: "usp_pEXBC_ReversePurchase_Select",
                        param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<PEXBC>)results;
                return Ok(response);
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new List<PEXBC>();
            }
            return BadRequest(response);
        }

        [HttpPost("save")]
        public async Task<ActionResult<PEXBCResponse>> Insert([FromBody] PEXBCRsp pexbcsave)
        {
            PEXBCResponse response = new PEXBCResponse();
            // Validate
            if (pexbcsave == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "pexbc is required.";
                response.Data = new PEXBCDataContainer();
                return BadRequest(response);
            }

            DynamicParameters param = new DynamicParameters();
            //pExBc
            param.Add("@RECORD_TYPE", pexbcsave.RECORD_TYPE);
            param.Add("@REC_STATUS", pexbcsave.REC_STATUS);
            param.Add("@EVENT_NO", pexbcsave.EVENT_NO);
            param.Add("@EXPORT_BC_NO", pexbcsave.EXPORT_BC_NO);
            param.Add("@EVENT_MODE", pexbcsave.EVENT_MODE);
            param.Add("@BUSINESS_TYPE", pexbcsave.BUSINESS_TYPE);
            param.Add("@EVENT_TYPE", pexbcsave.EVENT_TYPE);
            param.Add("@EVENT_DATE", pexbcsave.EVENT_DATE);
            param.Add("@TENOR_OF_COLL", pexbcsave.TENOR_OF_COLL);
            param.Add("@TENOR_TYPE", pexbcsave.TENOR_TYPE);
            param.Add("@INVOICE", pexbcsave.INVOICE);
            param.Add("@REFER_BC_NO", pexbcsave.REFER_BC_NO);
            param.Add("@RELETE_PACK", pexbcsave.RELETE_PACK);
            param.Add("@DRAFT_CCY", pexbcsave.DRAFT_CCY);
            param.Add("@DRAFT_AMT", pexbcsave.DRAFT_AMT);
            param.Add("@SIGHT_AMT", pexbcsave.SIGHT_AMT);
            param.Add("@TERM_AMT", pexbcsave.TERM_AMT);
            param.Add("@GOOD_CODE", pexbcsave.GOOD_CODE);
            param.Add("@REL_CODE", pexbcsave.REL_CODE);
            param.Add("@CLAIM_TYPE", pexbcsave.CLAIM_TYPE);
            param.Add("@SIGHT_START_DATE", pexbcsave.SIGHT_START_DATE);
            param.Add("@SIGHT_DUE_DATE", pexbcsave.SIGHT_DUE_DATE);
            param.Add("@TENOR_DAY", pexbcsave.TENOR_DAY);
            param.Add("@TENOR_DAY_DESC", pexbcsave.TENOR_DAY_DESC);
            param.Add("@TERM_START_DATE", pexbcsave.TERM_START_DATE);
            param.Add("@TERM_DUE_DATE", pexbcsave.TERM_DUE_DATE);
            param.Add("@PURCH_DISC_DATE", pexbcsave.PURCH_DISC_DATE);
            param.Add("@DRAWEE_INFO", pexbcsave.DRAWEE_INFO);
            param.Add("@CNTY_CODE", pexbcsave.CNTY_CODE);
            param.Add("@Cust_AO", pexbcsave.Cust_AO);
            param.Add("@Cust_LO", pexbcsave.Cust_LO);
            param.Add("@BENE_ID", pexbcsave.BENE_ID);
            param.Add("@BENE_INFO", pexbcsave.BENE_INFO);
            param.Add("@ISSUE_BANK_ID", pexbcsave.ISSUE_BANK_ID);
            param.Add("@ISSUE_BANK_INFO", pexbcsave.ISSUE_BANK_INFO);
            param.Add("@COLLECT_AGENT", pexbcsave.COLLECT_AGENT);
            param.Add("@AGENT_BANK_ID", pexbcsave.AGENT_BANK_ID);
            param.Add("@AGENT_BANK_INFO", pexbcsave.AGENT_BANK_INFO);
            param.Add("@AGENT_BANK_REF", pexbcsave.AGENT_BANK_REF);
            param.Add("@AGENT_BANK_NOSTRO", pexbcsave.AGENT_BANK_NOSTRO);
            param.Add("@RESTRICT", pexbcsave.RESTRICT);
            param.Add("@RESTRICT_TO_BK_NAME", pexbcsave.RESTRICT_TO_BK_NAME);
            param.Add("@RESTRICT_TO_BK_ADDR1", pexbcsave.RESTRICT_TO_BK_ADDR1);
            param.Add("@RESTRICT_TO_BK_ADDR2", pexbcsave.RESTRICT_TO_BK_ADDR2);
            param.Add("@RESTRICT_TO_BK_ADDR3", pexbcsave.RESTRICT_TO_BK_ADDR3);
            param.Add("@RESTRICT_REFER", pexbcsave.RESTRICT_REFER);
            param.Add("@RESTRICT_FR_BK_NAME", pexbcsave.RESTRICT_FR_BK_NAME);
            param.Add("@RESTRICT_FR_BK_ADDR1", pexbcsave.RESTRICT_FR_BK_ADDR1);
            param.Add("@RESTRICT_FR_BK_ADDR2", pexbcsave.RESTRICT_FR_BK_ADDR2);
            param.Add("@RESTRICT_FR_BK_ADDR3", pexbcsave.RESTRICT_FR_BK_ADDR3);
            param.Add("@PARTIAL_FULL_RATE", pexbcsave.PARTIAL_FULL_RATE);
            param.Add("@INT_RATE_METHOD", pexbcsave.INT_RATE_METHOD);
            param.Add("@TYPE_OF_ACCOUNT", pexbcsave.TYPE_OF_ACCOUNT);
            param.Add("@CREDIT_CURRENCY", pexbcsave.CREDIT_CURRENCY);
            param.Add("@DISCOUNT_DAY", pexbcsave.DISCOUNT_DAY);
            param.Add("@GRACE_PERIOD", pexbcsave.GRACE_PERIOD);
            param.Add("@DISC_BASE_DAY", pexbcsave.DISC_BASE_DAY);
            param.Add("@BASE_DAY", pexbcsave.BASE_DAY);
            param.Add("@DISCOUNT_RATE", pexbcsave.DISCOUNT_RATE);
            param.Add("@INT_BASE_RATE", pexbcsave.INT_BASE_RATE);
            param.Add("@INT_SPREAD_RATE", pexbcsave.INT_SPREAD_RATE);
            param.Add("@CURRENT_DIS_RATE", pexbcsave.CURRENT_DIS_RATE);
            param.Add("@CURRENT_INT_RATE", pexbcsave.CURRENT_INT_RATE);
            param.Add("@PAY_BY", pexbcsave.PAY_BY);
            param.Add("@NEGO_AMT", pexbcsave.NEGO_AMT);
            param.Add("@LESS_AGENT", pexbcsave.LESS_AGENT);
            param.Add("@PURCHASE_AMT", pexbcsave.PURCHASE_AMT);
            param.Add("@PURCHASE_RATE", pexbcsave.PURCHASE_RATE);
            param.Add("@TOTAL_NEGO_BALANCE", pexbcsave.TOTAL_NEGO_BALANCE);
            param.Add("@TOTAL_NEGO_BAL_THB", pexbcsave.TOTAL_NEGO_BAL_THB);
            param.Add("@TOT_NEGO_AMT", pexbcsave.TOT_NEGO_AMT);
            param.Add("@TOT_NEGO_AMOUNT", pexbcsave.TOT_NEGO_AMOUNT);
            param.Add("@BANK_CHARGE_AMT", pexbcsave.BANK_CHARGE_AMT);
            param.Add("@NET_PROCEED_CLAIM", pexbcsave.NET_PROCEED_CLAIM);
            param.Add("@CLAIM_PAY_BY", pexbcsave.CLAIM_PAY_BY);
            param.Add("@ParTnor_Type1", pexbcsave.ParTnor_Type1);
            param.Add("@ParTnor_Type2", pexbcsave.ParTnor_Type2);
            param.Add("@ParTnor_Type3", pexbcsave.ParTnor_Type3);
            param.Add("@ParTnor_Type4", pexbcsave.ParTnor_Type4);
            param.Add("@ParTnor_Type5", pexbcsave.ParTnor_Type5);
            param.Add("@ParTnor_Type6", pexbcsave.ParTnor_Type6);
            param.Add("@PARTIAL_AMT1", pexbcsave.PARTIAL_AMT1);
            param.Add("@PARTIAL_AMT2", pexbcsave.PARTIAL_AMT2);
            param.Add("@PARTIAL_AMT3", pexbcsave.PARTIAL_AMT3);
            param.Add("@PARTIAL_AMT4", pexbcsave.PARTIAL_AMT4);
            param.Add("@PARTIAL_AMT5", pexbcsave.PARTIAL_AMT5);
            param.Add("@PARTIAL_AMT6", pexbcsave.PARTIAL_AMT6);
            param.Add("@PARTIAL_RATE1", pexbcsave.PARTIAL_RATE1);
            param.Add("@PARTIAL_RATE2", pexbcsave.PARTIAL_RATE2);
            param.Add("@PARTIAL_RATE3", pexbcsave.PARTIAL_RATE3);
            param.Add("@PARTIAL_RATE4", pexbcsave.PARTIAL_RATE4);
            param.Add("@PARTIAL_RATE5", pexbcsave.PARTIAL_RATE5);
            param.Add("@PARTIAL_RATE6", pexbcsave.PARTIAL_RATE6);
            param.Add("@PARTIAL_AMT1_THB", pexbcsave.PARTIAL_AMT1_THB);
            param.Add("@PARTIAL_AMT2_THB", pexbcsave.PARTIAL_AMT2_THB);
            param.Add("@PARTIAL_AMT3_THB", pexbcsave.PARTIAL_AMT3_THB);
            param.Add("@PARTIAL_AMT4_THB", pexbcsave.PARTIAL_AMT4_THB);
            param.Add("@PARTIAL_AMT5_THB", pexbcsave.PARTIAL_AMT5_THB);
            param.Add("@PARTIAL_AMT6_THB", pexbcsave.PARTIAL_AMT6_THB);
            param.Add("@FORWARD_CONRACT_NO", pexbcsave.FORWARD_CONRACT_NO);
            param.Add("@FORWARD_CONRACT_NO1", pexbcsave.FORWARD_CONRACT_NO1);
            param.Add("@FORWARD_CONRACT_NO2", pexbcsave.FORWARD_CONRACT_NO2);
            param.Add("@FORWARD_CONRACT_NO3", pexbcsave.FORWARD_CONRACT_NO3);
            param.Add("@FORWARD_CONRACT_NO4", pexbcsave.FORWARD_CONRACT_NO4);
            param.Add("@FORWARD_CONRACT_NO5", pexbcsave.FORWARD_CONRACT_NO5);
            param.Add("@FORWARD_CONRACT_NO6", pexbcsave.FORWARD_CONRACT_NO6);
            param.Add("@NEGO_COMM", pexbcsave.NEGO_COMM);
            param.Add("@TELEX_SWIFT", pexbcsave.TELEX_SWIFT);
            param.Add("@COURIER_POSTAGE", pexbcsave.COURIER_POSTAGE);
            param.Add("@STAMP_FEE", pexbcsave.STAMP_FEE);
            param.Add("@BE_STAMP", pexbcsave.BE_STAMP);
            param.Add("@COMM_OTHER", pexbcsave.COMM_OTHER);
            param.Add("@HANDING_FEE", pexbcsave.HANDING_FEE);
            param.Add("@DRAFTCOMM", pexbcsave.DRAFTCOMM);
            param.Add("@INT_AMT_THB", pexbcsave.INT_AMT_THB);
            param.Add("@COMMONTT", pexbcsave.COMMONTT);
            param.Add("@TOTAL_CHARGE", pexbcsave.TOTAL_CHARGE);
            param.Add("@REFUND_TAX_YN", pexbcsave.REFUND_TAX_YN);
            param.Add("@REFUND_TAX_AMT", pexbcsave.REFUND_TAX_AMT);
            param.Add("@DISCOUNT_CCY", pexbcsave.DISCOUNT_CCY);
            param.Add("@DISCRATE", pexbcsave.DISCRATE);
            param.Add("@DISCOUNT_AMT", pexbcsave.DISCOUNT_AMT);
            param.Add("@TOTAL_AMOUNT", pexbcsave.TOTAL_AMOUNT);
            param.Add("@PAYMENT_INSTRU", pexbcsave.PAYMENT_INSTRU);
            param.Add("@METHOD", pexbcsave.METHOD);
            param.Add("@ACBAHTNET", pexbcsave.ACBAHTNET);
            param.Add("@BAHTNET", pexbcsave.BAHTNET);
            param.Add("@RECEIVED_NO", pexbcsave.RECEIVED_NO);
            param.Add("@ALLOCATION", pexbcsave.ALLOCATION);
            param.Add("@NARRATIVE", pexbcsave.NARRATIVE);
            param.Add("@SEQ_ACCEPT_DUE", pexbcsave.SEQ_ACCEPT_DUE);
            param.Add("@COMFIRM_DUE", pexbcsave.COMFIRM_DUE);
            param.Add("@PLUS_MINUS_DISC", pexbcsave.PLUS_MINUS_DISC);
            param.Add("@DISC_DAYS_PLUS_MINUS", pexbcsave.DISC_DAYS_PLUS_MINUS);
            param.Add("@RECEIVE_PAY_AMT", pexbcsave.RECEIVE_PAY_AMT);
            param.Add("@EXCHANGE_RATE", pexbcsave.EXCHANGE_RATE);
            param.Add("@REFUND_DISC_RECEIVE", pexbcsave.REFUND_DISC_RECEIVE);
            param.Add("@DISC_RECEIVE", pexbcsave.DISC_RECEIVE);
            param.Add("@LC_DATE", pexbcsave.LC_DATE);
            param.Add("@COVERING_DATE", pexbcsave.COVERING_DATE);
            param.Add("@COVERING_FOR", pexbcsave.COVERING_FOR);
            param.Add("@ADVICE_ISSUE_BANK", pexbcsave.ADVICE_ISSUE_BANK);
            param.Add("@ADVICE_FORMAT", pexbcsave.ADVICE_FORMAT);
            param.Add("@REMIT_CLAIM_TYPE", pexbcsave.REMIT_CLAIM_TYPE);
            param.Add("@REIMBURSE_BANK_ID", pexbcsave.REIMBURSE_BANK_ID);
            param.Add("@REIMBURSE_BANK_INFO", pexbcsave.REIMBURSE_BANK_INFO);
            param.Add("@SWIFT_BANK", pexbcsave.SWIFT_BANK);
            param.Add("@SWIFT_MAIL", pexbcsave.SWIFT_MAIL);
            param.Add("@CLAIM_FORMAT", pexbcsave.CLAIM_FORMAT);
            param.Add("@VALUE_DATE", pexbcsave.VALUE_DATE);
            param.Add("@THIRD_BANK_ID", pexbcsave.THIRD_BANK_ID);
            param.Add("@THIRD_BANK_INFO", pexbcsave.THIRD_BANK_INFO);
            param.Add("@DISCREPANCY_TYPE", pexbcsave.DISCREPANCY_TYPE);
            param.Add("@SWIFT_DISC", pexbcsave.SWIFT_DISC);
            param.Add("@DOCUMENT_COPY", pexbcsave.DOCUMENT_COPY);
            param.Add("@SIGHT_BASIS", pexbcsave.SIGHT_BASIS);
            param.Add("@ART44A", pexbcsave.ART44A);
            param.Add("@ENDORSED", pexbcsave.ENDORSED);
            param.Add("@MT750", pexbcsave.MT750);
            param.Add("@ADJ_TOT_NEGO_AMOUNT", pexbcsave.ADJ_TOT_NEGO_AMOUNT);
            param.Add("@ADJ_LESS_CHARGE_AMT", pexbcsave.ADJ_LESS_CHARGE_AMT);
            param.Add("@ADJUST_COVERING_AMT", pexbcsave.ADJUST_COVERING_AMT);
            param.Add("@ADJUST_TENOR", pexbcsave.ADJUST_TENOR);
            param.Add("@ADJUST_LC_REF", pexbcsave.ADJUST_LC_REF);
            param.Add("@PAYMENT_INSTRC", pexbcsave.PAYMENT_INSTRC);
            param.Add("@TXTDOCUMENT", pexbcsave.TXTDOCUMENT);
            param.Add("@CHARGE_ACC", pexbcsave.CHARGE_ACC);
            param.Add("@DRAFT", pexbcsave.DRAFT);
            param.Add("@MT202", pexbcsave.MT202);
            param.Add("@FB_CURRENCY", pexbcsave.FB_CURRENCY);
            param.Add("@FB_AMT", pexbcsave.FB_AMT);
            param.Add("@FB_RATE", pexbcsave.FB_RATE);
            param.Add("@FB_AMT_THB", pexbcsave.FB_AMT_THB);
            param.Add("@COLLECT_REFUND", pexbcsave.COLLECT_REFUND);
            param.Add("@USER_ID", pexbcsave.USER_ID);
            param.Add("@IN_USE", pexbcsave.IN_USE);
            param.Add("@AUTH_CODE", pexbcsave.AUTH_CODE);
            param.Add("@GENACC_FLAG", pexbcsave.GENACC_FLAG);
            param.Add("@VOUCH_ID", pexbcsave.VOUCH_ID);
            param.Add("@APPVNO", pexbcsave.APPVNO);
            param.Add("@FACNO", pexbcsave.FACNO);
            param.Add("@AUTOOVERDUE", pexbcsave.AUTOOVERDUE);
            param.Add("@LCOVERDUE", pexbcsave.LCOVERDUE);
            param.Add("@OVESEQNO", pexbcsave.OVESEQNO);
            param.Add("@INTFLAG", pexbcsave.INTFLAG);
            param.Add("@IntRateCode", pexbcsave.IntRateCode);
            param.Add("@CFRRate", pexbcsave.CFRRate);
            param.Add("@INTCODE", pexbcsave.INTCODE);
            param.Add("@OINTRATE", pexbcsave.OINTRATE);
            param.Add("@OINTSPDRATE", pexbcsave.OINTSPDRATE);
            param.Add("@OINTCURRATE", pexbcsave.OINTCURRATE);
            param.Add("@OINTDAY", pexbcsave.OINTDAY);
            param.Add("@OBASEDAY", pexbcsave.OBASEDAY);
            param.Add("@BFINTAMT", pexbcsave.BFINTAMT);
            param.Add("@SELLING_RATE", pexbcsave.SELLING_RATE);
            param.Add("@BFINTTHB", pexbcsave.BFINTTHB);
            param.Add("@INTBALANCE", pexbcsave.INTBALANCE);
            param.Add("@PRNBALANCE", pexbcsave.PRNBALANCE);
            param.Add("@LASTINTAMT", pexbcsave.LASTINTAMT);
            param.Add("@DMS", pexbcsave.DMS);
            param.Add("@LASTINTDATE", pexbcsave.LASTINTDATE);
            param.Add("@PAYMENTTYPE", pexbcsave.PAYMENTTYPE);
            param.Add("@CONFIRM_DATE", pexbcsave.CONFIRM_DATE);
            param.Add("@TOTALACCRUAMT", pexbcsave.TOTALACCRUAMT);
            param.Add("@TOTALACCRUBHT", pexbcsave.TOTALACCRUBHT);
            param.Add("@ACCRUAMT", pexbcsave.ACCRUAMT);
            param.Add("@ACCRUBHT", pexbcsave.ACCRUBHT);
            param.Add("@DATELASTACCRU", pexbcsave.DATELASTACCRU);
            param.Add("@PASTDUEDATE", pexbcsave.PASTDUEDATE);
            param.Add("@PASTDUEFLAG", pexbcsave.PASTDUEFLAG);
            param.Add("@TOTALSUSPAMT", pexbcsave.TOTALSUSPAMT);
            param.Add("@TOTALSUSPBHT", pexbcsave.TOTALSUSPBHT);
            param.Add("@SUSPAMT", pexbcsave.SUSPAMT);
            param.Add("@SUSPBHT", pexbcsave.SUSPBHT);
            param.Add("@CenterID", pexbcsave.CenterID);
            param.Add("@BCPastDue", pexbcsave.BCPastDue);
            param.Add("@DateStartAccru", pexbcsave.DateStartAccru);
            param.Add("@DateToStop", pexbcsave.DateToStop);
            param.Add("@ValueDate", pexbcsave.ValueDate);
            param.Add("@FlagBack", pexbcsave.FlagBack);
            param.Add("@NewAccruCcy", pexbcsave.NewAccruCcy);
            param.Add("@NewAccruAmt", pexbcsave.NewAccruAmt);
            param.Add("@AccruPending", pexbcsave.AccruPending);
            param.Add("@LastAccruCcy", pexbcsave.LastAccruCcy);
            param.Add("@LastAccruAmt", pexbcsave.LastAccruAmt);
            param.Add("@DAccruAmt", pexbcsave.DAccruAmt);
            param.Add("@CCS_ACCT", pexbcsave.CCS_ACCT);
            param.Add("@CCS_LmType", pexbcsave.CCS_LmType);
            param.Add("@CCS_CNUM", pexbcsave.CCS_CNUM);
            param.Add("@CCS_CIFRef", pexbcsave.CCS_CIFRef);
            param.Add("@ObjectType", pexbcsave.ObjectType);
            param.Add("@UnderlyName", pexbcsave.UnderlyName);
            param.Add("@BPOFlag", pexbcsave.BPOFlag);
            param.Add("@Campaign_Code", pexbcsave.Campaign_Code);
            param.Add("@Campaign_EffDate", pexbcsave.Campaign_EffDate);
            param.Add("@PurposeCode", pexbcsave.PurposeCode);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            param.Add("@ResSeqNo", dbType: DbType.Int32,
                       direction: System.Data.ParameterDirection.Output,
                       size: 12800);

            param.Add("@PEXBCPRsp", dbType: DbType.String,
            direction: System.Data.ParameterDirection.Output,
            size: 5215585);

            try
            {
                var results = await _db.LoadData<pExbc, dynamic>(
                            storedProcedure: "usp_pEXBC_ReversePurchase_Save",
                            param);
                var resp = param.Get<string>("@Resp");
                var resSeqNo = param.Get<int>("@ResSeqNo");
                var respexbc = param.Get<dynamic>("@PEXBCPRsp");

                if (resp == "1")
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = new PEXBCDataContainer(results.First());
                    return Ok(response);
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT_BC_NO Save Error";
                    response.Data = new PEXBCDataContainer();
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXBCDataContainer();
            }
            return BadRequest(response);
        }

        [HttpPost("delete")]
        public async Task<ActionResult<string>> Delete([FromBody] PEXBCReversePurchaseDeleteReq EXBCReversePurchaseDel)
        {
            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", EXBCReversePurchaseDel.EXPORT_BC_NO);
            param.Add("@VOUCH_ID", EXBCReversePurchaseDel.VOUCH_ID);
            param.Add("@EVENT_DATE", EXBCReversePurchaseDel.EVENT_DATE);


            param.Add("PExBcRsp", dbType: DbType.Int32,
               direction: System.Data.ParameterDirection.Output,
               size: 12800);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_ReversePurchase_Delete", param);
                //var resp = param.Get<int>("@Resp");

                var pexbcrsp = param.Get<int>("@PExBcRsp");
                var resp = param.Get<string>("@Resp");

                if (resp == "1")
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Export B/C Number Deleted";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Export B/C NO does not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                ReturnResponse response = new();
                response.StatusCode = "400";
                response.Message = e.Message;
                return BadRequest(response);
            }

        }

        [HttpPost("release")]
        public async Task<ActionResult<string>> ReversePurchaseReleaseReq([FromBody] PEXBCReversePurchaseReleaseReq PEXBCReversePurchRelease)
        {
            EXBCResultResponse response = new EXBCResultResponse();
            var USER_ID = User.Identity.Name;
            var claimsPrincipal = HttpContext.User;
            var USER_CENTER_ID = claimsPrincipal.FindFirst("UserBranch").Value.ToString();

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", PEXBCReversePurchRelease.EXPORT_BC_NO);
            param.Add("@EVENT_NO", PEXBCReversePurchRelease.EVENT_NO);
            //param.Add("@USER_ID", PEXBCReversePurchRelease.USER_ID);
            //param.Add("@CenterID", PEXBCReversePurchRelease.CenterID);
            param.Add("@USER_ID", USER_ID);
            param.Add("@CenterID", USER_CENTER_ID);
            param.Add("@VOUCHID", PEXBCReversePurchRelease.VOUCHID);
            param.Add("@EVENTDATE", PEXBCReversePurchRelease.EVENTDATE);
            param.Add("@DRAFT_CCY", PEXBCReversePurchRelease.DRAFT_CCY);
            param.Add("@TOT_NEGO_AMT", PEXBCReversePurchRelease.TOT_NEGO_AMT);
            param.Add("@TOTAL_NEGO_BAL_THB", PEXBCReversePurchRelease.TOTAL_NEGO_BAL_THB);
            param.Add("@BENE_ID", PEXBCReversePurchRelease.BENE_ID);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@PExBcRsp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_ReversePurchase_Release", param);
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
                    response.Message = "Export B/C does not exist";
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
