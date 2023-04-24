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
        public async Task<ActionResult<EXBCAcceptTermDueQueryPageResponse>> GetAllQuery(string? CenterID, string? EXPORT_BC_NO, string? BENName, string? USER_ID, int? Page, int? PageSize)
        {
            EXBCAcceptTermDueQueryPageResponse response = new EXBCAcceptTermDueQueryPageResponse();

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
        public async Task<ActionResult<PEXBCListResponse>> GetAllSelect(string? EXPORT_BC_NO, string? RECORD_TYPE, string? REC_STATUS)
        {
            PEXBCListResponse response = new PEXBCListResponse();

            // Validate
            if (string.IsNullOrEmpty(EXPORT_BC_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO, RECORD_TYPE, REC_STATUS is required";
                response.Data = new List<PEXBC>();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            //param.Add("@EVENT_NO", EVENT_NO);
            //param.Add("@LFROM", LFROM);
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@RECORD_TYPE", RECORD_TYPE);
            param.Add("@REC_STATUS", REC_STATUS);

            try
            {
                var results = await _db.LoadData<PEXBC, dynamic>(
                            storedProcedure: "usp_pEXBC_AcceptTermDue_Select",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<PEXBC>)results;


                response.Page = 1;
                response.Total = response.Data.Count;
                response.TotalPage = 1;

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
        public async Task<ActionResult<PEXBCResponse>> Insert([FromBody] PEXBC pexbc)
        {
            PEXBCResponse response = new PEXBCResponse();
            // Validate
            if (pexbc == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "PEXBC is required.";
                response.Data = new PEXBCDataContainer();
                return BadRequest(response);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@RECORD_TYPE", pexbc.RECORD_TYPE);
            param.Add("@REC_STATUS", pexbc.REC_STATUS);
            param.Add("@EVENT_NO", pexbc.EVENT_NO);
            param.Add("@EXPORT_BC_NO", pexbc.EXPORT_BC_NO);
            param.Add("@EVENT_MODE", pexbc.EVENT_MODE);
            param.Add("@BUSINESS_TYPE", pexbc.BUSINESS_TYPE);
            param.Add("@EVENT_TYPE", pexbc.EVENT_TYPE);
            param.Add("@EVENT_DATE", pexbc.EVENT_DATE);
            param.Add("@TENOR_OF_COLL", pexbc.TENOR_OF_COLL);
            param.Add("@TENOR_TYPE", pexbc.TENOR_TYPE);
            param.Add("@INVOICE", pexbc.INVOICE);
            param.Add("@REFER_BC_NO", pexbc.REFER_BC_NO);
            param.Add("@RELETE_PACK", pexbc.RELETE_PACK);
            param.Add("@DRAFT_CCY", pexbc.DRAFT_CCY);
            param.Add("@DRAFT_AMT", pexbc.DRAFT_AMT);
            param.Add("@SIGHT_AMT", pexbc.SIGHT_AMT);
            param.Add("@TERM_AMT", pexbc.TERM_AMT);
            param.Add("@GOOD_CODE", pexbc.GOOD_CODE);
            param.Add("@REL_CODE", pexbc.REL_CODE);
            param.Add("@CLAIM_TYPE", pexbc.CLAIM_TYPE);
            param.Add("@SIGHT_START_DATE", pexbc.SIGHT_START_DATE);
            param.Add("@SIGHT_DUE_DATE", pexbc.SIGHT_DUE_DATE);
            param.Add("@TENOR_DAY", pexbc.TENOR_DAY);
            param.Add("@TENOR_DAY_DESC", pexbc.TENOR_DAY_DESC);
            param.Add("@TERM_START_DATE", pexbc.TERM_START_DATE);
            param.Add("@TERM_DUE_DATE", pexbc.TERM_DUE_DATE);
            param.Add("@PURCH_DISC_DATE", pexbc.PURCH_DISC_DATE);
            param.Add("@DRAWEE_INFO", pexbc.DRAWEE_INFO);
            param.Add("@CNTY_CODE", pexbc.CNTY_CODE);
            param.Add("@Cust_AO", pexbc.Cust_AO);
            param.Add("@Cust_LO", pexbc.Cust_LO);
            param.Add("@BENE_ID", pexbc.BENE_ID);
            param.Add("@BENE_INFO", pexbc.BENE_INFO);
            param.Add("@ISSUE_BANK_ID", pexbc.ISSUE_BANK_ID);
            param.Add("@ISSUE_BANK_INFO", pexbc.ISSUE_BANK_INFO);
            param.Add("@COLLECT_AGENT", pexbc.COLLECT_AGENT);
            param.Add("@AGENT_BANK_ID", pexbc.AGENT_BANK_ID);
            param.Add("@AGENT_BANK_INFO", pexbc.AGENT_BANK_INFO);
            param.Add("@AGENT_BANK_REF", pexbc.AGENT_BANK_REF);
            param.Add("@AGENT_BANK_NOSTRO", pexbc.AGENT_BANK_NOSTRO);
            param.Add("@RESTRICT", pexbc.RESTRICT);
            param.Add("@RESTRICT_TO_BK_NAME", pexbc.RESTRICT_TO_BK_NAME);
            param.Add("@RESTRICT_TO_BK_ADDR1", pexbc.RESTRICT_TO_BK_ADDR1);
            param.Add("@RESTRICT_TO_BK_ADDR2", pexbc.RESTRICT_TO_BK_ADDR2);
            param.Add("@RESTRICT_TO_BK_ADDR3", pexbc.RESTRICT_TO_BK_ADDR3);
            param.Add("@RESTRICT_REFER", pexbc.RESTRICT_REFER);
            param.Add("@RESTRICT_FR_BK_NAME", pexbc.RESTRICT_FR_BK_NAME);
            param.Add("@RESTRICT_FR_BK_ADDR1", pexbc.RESTRICT_FR_BK_ADDR1);
            param.Add("@RESTRICT_FR_BK_ADDR2", pexbc.RESTRICT_FR_BK_ADDR2);
            param.Add("@RESTRICT_FR_BK_ADDR3", pexbc.RESTRICT_FR_BK_ADDR3);
            param.Add("@PARTIAL_FULL_RATE", pexbc.PARTIAL_FULL_RATE);
            param.Add("@INT_RATE_METHOD", pexbc.INT_RATE_METHOD);
            param.Add("@TYPE_OF_ACCOUNT", pexbc.TYPE_OF_ACCOUNT);
            param.Add("@CREDIT_CURRENCY", pexbc.CREDIT_CURRENCY);
            param.Add("@DISCOUNT_DAY", pexbc.DISCOUNT_DAY);
            param.Add("@GRACE_PERIOD", pexbc.GRACE_PERIOD);
            param.Add("@DISC_BASE_DAY", pexbc.DISC_BASE_DAY);
            param.Add("@BASE_DAY", pexbc.BASE_DAY);
            param.Add("@DISCOUNT_RATE", pexbc.DISCOUNT_RATE);
            param.Add("@INT_BASE_RATE", pexbc.INT_BASE_RATE);
            param.Add("@INT_SPREAD_RATE", pexbc.INT_SPREAD_RATE);
            param.Add("@CURRENT_DIS_RATE", pexbc.CURRENT_DIS_RATE);
            param.Add("@CURRENT_INT_RATE", pexbc.CURRENT_INT_RATE);
            param.Add("@PAY_BY", pexbc.PAY_BY);
            param.Add("@NEGO_AMT", pexbc.NEGO_AMT);
            param.Add("@LESS_AGENT", pexbc.LESS_AGENT);
            param.Add("@PURCHASE_AMT", pexbc.PURCHASE_AMT);
            param.Add("@PURCHASE_RATE", pexbc.PURCHASE_RATE);
            param.Add("@TOTAL_NEGO_BALANCE", pexbc.TOTAL_NEGO_BALANCE);
            param.Add("@TOTAL_NEGO_BAL_THB", pexbc.TOTAL_NEGO_BAL_THB);
            param.Add("@TOT_NEGO_AMT", pexbc.TOT_NEGO_AMT);
            param.Add("@TOT_NEGO_AMOUNT", pexbc.TOT_NEGO_AMOUNT);
            param.Add("@BANK_CHARGE_AMT", pexbc.BANK_CHARGE_AMT);
            param.Add("@NET_PROCEED_CLAIM", pexbc.NET_PROCEED_CLAIM);
            param.Add("@CLAIM_PAY_BY", pexbc.CLAIM_PAY_BY);
            param.Add("@ParTnor_Type1", pexbc.ParTnor_Type1);
            param.Add("@ParTnor_Type2", pexbc.ParTnor_Type2);
            param.Add("@ParTnor_Type3", pexbc.ParTnor_Type3);
            param.Add("@ParTnor_Type4", pexbc.ParTnor_Type4);
            param.Add("@ParTnor_Type5", pexbc.ParTnor_Type5);
            param.Add("@ParTnor_Type6", pexbc.ParTnor_Type6);
            param.Add("@PARTIAL_AMT1", pexbc.PARTIAL_AMT1);
            param.Add("@PARTIAL_AMT2", pexbc.PARTIAL_AMT2);
            param.Add("@PARTIAL_AMT3", pexbc.PARTIAL_AMT3);
            param.Add("@PARTIAL_AMT4", pexbc.PARTIAL_AMT4);
            param.Add("@PARTIAL_AMT5", pexbc.PARTIAL_AMT5);
            param.Add("@PARTIAL_AMT6", pexbc.PARTIAL_AMT6);
            param.Add("@PARTIAL_RATE1", pexbc.PARTIAL_RATE1);
            param.Add("@PARTIAL_RATE2", pexbc.PARTIAL_RATE2);
            param.Add("@PARTIAL_RATE3", pexbc.PARTIAL_RATE3);
            param.Add("@PARTIAL_RATE4", pexbc.PARTIAL_RATE4);
            param.Add("@PARTIAL_RATE5", pexbc.PARTIAL_RATE5);
            param.Add("@PARTIAL_RATE6", pexbc.PARTIAL_RATE6);
            param.Add("@PARTIAL_AMT1_THB", pexbc.PARTIAL_AMT1_THB);
            param.Add("@PARTIAL_AMT2_THB", pexbc.PARTIAL_AMT2_THB);
            param.Add("@PARTIAL_AMT3_THB", pexbc.PARTIAL_AMT3_THB);
            param.Add("@PARTIAL_AMT4_THB", pexbc.PARTIAL_AMT4_THB);
            param.Add("@PARTIAL_AMT5_THB", pexbc.PARTIAL_AMT5_THB);
            param.Add("@PARTIAL_AMT6_THB", pexbc.PARTIAL_AMT6_THB);
            param.Add("@FORWARD_CONRACT_NO", pexbc.FORWARD_CONRACT_NO);
            param.Add("@FORWARD_CONRACT_NO1", pexbc.FORWARD_CONRACT_NO1);
            param.Add("@FORWARD_CONRACT_NO2", pexbc.FORWARD_CONRACT_NO2);
            param.Add("@FORWARD_CONRACT_NO3", pexbc.FORWARD_CONRACT_NO3);
            param.Add("@FORWARD_CONRACT_NO4", pexbc.FORWARD_CONRACT_NO4);
            param.Add("@FORWARD_CONRACT_NO5", pexbc.FORWARD_CONRACT_NO5);
            param.Add("@FORWARD_CONRACT_NO6", pexbc.FORWARD_CONRACT_NO6);
            param.Add("@NEGO_COMM", pexbc.NEGO_COMM);
            param.Add("@TELEX_SWIFT", pexbc.TELEX_SWIFT);
            param.Add("@COURIER_POSTAGE", pexbc.COURIER_POSTAGE);
            param.Add("@STAMP_FEE", pexbc.STAMP_FEE);
            param.Add("@BE_STAMP", pexbc.BE_STAMP);
            param.Add("@COMM_OTHER", pexbc.COMM_OTHER);
            param.Add("@HANDING_FEE", pexbc.HANDING_FEE);
            param.Add("@DRAFTCOMM", pexbc.DRAFTCOMM);
            param.Add("@INT_AMT_THB", pexbc.INT_AMT_THB);
            param.Add("@COMMONTT", pexbc.COMMONTT);
            param.Add("@TOTAL_CHARGE", pexbc.TOTAL_CHARGE);
            param.Add("@REFUND_TAX_YN", pexbc.REFUND_TAX_YN);
            param.Add("@REFUND_TAX_AMT", pexbc.REFUND_TAX_AMT);
            param.Add("@DISCOUNT_CCY", pexbc.DISCOUNT_CCY);
            param.Add("@DISCRATE", pexbc.DISCRATE);
            param.Add("@DISCOUNT_AMT", pexbc.DISCOUNT_AMT);
            param.Add("@TOTAL_AMOUNT", pexbc.TOTAL_AMOUNT);
            param.Add("@PAYMENT_INSTRU", pexbc.PAYMENT_INSTRU);
            param.Add("@METHOD", pexbc.METHOD);
            param.Add("@ACBAHTNET", pexbc.ACBAHTNET);
            param.Add("@BAHTNET", pexbc.BAHTNET);
            param.Add("@RECEIVED_NO", pexbc.RECEIVED_NO);
            param.Add("@ALLOCATION", pexbc.ALLOCATION);
            param.Add("@NARRATIVE", pexbc.NARRATIVE);
            param.Add("@SEQ_ACCEPT_DUE", pexbc.SEQ_ACCEPT_DUE);
            param.Add("@COMFIRM_DUE", pexbc.COMFIRM_DUE);
            param.Add("@PLUS_MINUS_DISC", pexbc.PLUS_MINUS_DISC);
            param.Add("@DISC_DAYS_PLUS_MINUS", pexbc.DISC_DAYS_PLUS_MINUS);
            param.Add("@RECEIVE_PAY_AMT", pexbc.RECEIVE_PAY_AMT);
            param.Add("@EXCHANGE_RATE", pexbc.EXCHANGE_RATE);
            param.Add("@REFUND_DISC_RECEIVE", pexbc.REFUND_DISC_RECEIVE);
            param.Add("@DISC_RECEIVE", pexbc.DISC_RECEIVE);
            param.Add("@LC_DATE", pexbc.LC_DATE);
            param.Add("@COVERING_DATE", pexbc.COVERING_DATE);
            param.Add("@COVERING_FOR", pexbc.COVERING_FOR);
            param.Add("@ADVICE_ISSUE_BANK", pexbc.ADVICE_ISSUE_BANK);
            param.Add("@ADVICE_FORMAT", pexbc.ADVICE_FORMAT);
            param.Add("@REMIT_CLAIM_TYPE", pexbc.REMIT_CLAIM_TYPE);
            param.Add("@REIMBURSE_BANK_ID", pexbc.REIMBURSE_BANK_ID);
            param.Add("@REIMBURSE_BANK_INFO", pexbc.REIMBURSE_BANK_INFO);
            param.Add("@SWIFT_BANK", pexbc.SWIFT_BANK);
            param.Add("@SWIFT_MAIL", pexbc.SWIFT_MAIL);
            param.Add("@CLAIM_FORMAT", pexbc.CLAIM_FORMAT);
            param.Add("@VALUE_DATE", pexbc.VALUE_DATE);
            param.Add("@THIRD_BANK_ID", pexbc.THIRD_BANK_ID);
            param.Add("@THIRD_BANK_INFO", pexbc.THIRD_BANK_INFO);
            param.Add("@DISCREPANCY_TYPE", pexbc.DISCREPANCY_TYPE);
            param.Add("@SWIFT_DISC", pexbc.SWIFT_DISC);
            param.Add("@DOCUMENT_COPY", pexbc.DOCUMENT_COPY);

            // Convert bool to string => DB BIT (0/1)
            string SIGHT_BASIS = "0";
            if (pexbc.SIGHT_BASIS == true)
            {
                SIGHT_BASIS = "1";
            }
            string ART44A = "0";
            if (pexbc.ART44A == true)
            {
                ART44A = "1";
            }
            string ENDORSED = "0";
            if (pexbc.ENDORSED == true)
            {
                ENDORSED = "1";
            }
            string MT750 = "0";
            if (pexbc.MT750 == true)
            {
                MT750 = "1";
            }
            param.Add("@SIGHT_BASIS", SIGHT_BASIS);
            param.Add("@ART44A", ART44A);
            param.Add("@ENDORSED", ENDORSED);
            param.Add("@MT750", MT750);

            param.Add("@ADJ_TOT_NEGO_AMOUNT", pexbc.ADJ_TOT_NEGO_AMOUNT);
            param.Add("@ADJ_LESS_CHARGE_AMT", pexbc.ADJ_LESS_CHARGE_AMT);
            param.Add("@ADJUST_COVERING_AMT", pexbc.ADJUST_COVERING_AMT);
            param.Add("@ADJUST_TENOR", pexbc.ADJUST_TENOR);
            param.Add("@ADJUST_LC_REF", pexbc.ADJUST_LC_REF);
            param.Add("@PAYMENT_INSTRC", pexbc.PAYMENT_INSTRC);
            param.Add("@TXTDOCUMENT", pexbc.TXTDOCUMENT);
            param.Add("@CHARGE_ACC", pexbc.CHARGE_ACC);
            param.Add("@DRAFT", pexbc.DRAFT);
            param.Add("@MT202", pexbc.MT202);
            param.Add("@FB_CURRENCY", pexbc.FB_CURRENCY);
            param.Add("@FB_AMT", pexbc.FB_AMT);
            param.Add("@FB_RATE", pexbc.FB_RATE);
            param.Add("@FB_AMT_THB", pexbc.FB_AMT_THB);
            param.Add("@COLLECT_REFUND", pexbc.COLLECT_REFUND);
            param.Add("@USER_ID", pexbc.USER_ID);
            param.Add("@IN_USE", pexbc.IN_USE);
            param.Add("@AUTH_CODE", pexbc.AUTH_CODE);
            param.Add("@GENACC_FLAG", pexbc.GENACC_FLAG);
            param.Add("@VOUCH_ID", pexbc.VOUCH_ID);
            param.Add("@APPVNO", pexbc.APPVNO);
            param.Add("@FACNO", pexbc.FACNO);
            param.Add("@AUTOOVERDUE", pexbc.AUTOOVERDUE);
            param.Add("@LCOVERDUE", pexbc.LCOVERDUE);
            param.Add("@OVESEQNO", pexbc.OVESEQNO);
            param.Add("@INTFLAG", pexbc.INTFLAG);
            param.Add("@IntRateCode", pexbc.IntRateCode);
            param.Add("@CFRRate", pexbc.CFRRate);
            param.Add("@INTCODE", pexbc.INTCODE);
            param.Add("@OINTRATE", pexbc.OINTRATE);
            param.Add("@OINTSPDRATE", pexbc.OINTSPDRATE);
            param.Add("@OINTCURRATE", pexbc.OINTCURRATE);
            param.Add("@OINTDAY", pexbc.OINTDAY);
            param.Add("@OBASEDAY", pexbc.OBASEDAY);
            param.Add("@BFINTAMT", pexbc.BFINTAMT);
            param.Add("@SELLING_RATE", pexbc.SELLING_RATE);
            param.Add("@BFINTTHB", pexbc.BFINTTHB);
            param.Add("@INTBALANCE", pexbc.INTBALANCE);
            param.Add("@PRNBALANCE", pexbc.PRNBALANCE);
            param.Add("@LASTINTAMT", pexbc.LASTINTAMT);
            param.Add("@DMS", pexbc.DMS);
            param.Add("@LASTINTDATE", pexbc.LASTINTDATE);
            param.Add("@PAYMENTTYPE", pexbc.PAYMENTTYPE);
            param.Add("@CONFIRM_DATE", pexbc.CONFIRM_DATE);
            param.Add("@TOTALACCRUAMT", pexbc.TOTALACCRUAMT);
            param.Add("@TOTALACCRUBHT", pexbc.TOTALACCRUBHT);
            param.Add("@ACCRUAMT", pexbc.ACCRUAMT);
            param.Add("@ACCRUBHT", pexbc.ACCRUBHT);
            param.Add("@DATELASTACCRU", pexbc.DATELASTACCRU);
            param.Add("@PASTDUEDATE", pexbc.PASTDUEDATE);
            param.Add("@PASTDUEFLAG", pexbc.PASTDUEFLAG);
            param.Add("@TOTALSUSPAMT", pexbc.TOTALSUSPAMT);
            param.Add("@TOTALSUSPBHT", pexbc.TOTALSUSPBHT);
            param.Add("@SUSPAMT", pexbc.SUSPAMT);
            param.Add("@SUSPBHT", pexbc.SUSPBHT);
            param.Add("@CenterID", pexbc.CenterID);
            param.Add("@BCPastDue", pexbc.BCPastDue);
            param.Add("@DateStartAccru", pexbc.DateStartAccru);
            param.Add("@DateToStop", pexbc.DateToStop);
            param.Add("@ValueDate", pexbc.ValueDate);
            param.Add("@FlagBack", pexbc.FlagBack);
            param.Add("@NewAccruCcy", pexbc.NewAccruCcy);
            param.Add("@NewAccruAmt", pexbc.NewAccruAmt);
            param.Add("@AccruPending", pexbc.AccruPending);
            param.Add("@LastAccruCcy", pexbc.LastAccruCcy);
            param.Add("@LastAccruAmt", pexbc.LastAccruAmt);
            param.Add("@DAccruAmt", pexbc.DAccruAmt);
            param.Add("@CCS_ACCT", pexbc.CCS_ACCT);
            param.Add("@CCS_LmType", pexbc.CCS_LmType);
            param.Add("@CCS_CNUM", pexbc.CCS_CNUM);
            param.Add("@CCS_CIFRef", pexbc.CCS_CIFRef);
            param.Add("@ObjectType", pexbc.ObjectType);
            param.Add("@UnderlyName", pexbc.UnderlyName);
            param.Add("@BPOFlag", pexbc.BPOFlag);
            param.Add("@Campaign_Code", pexbc.Campaign_Code);
            param.Add("@Campaign_EffDate", pexbc.Campaign_EffDate);
            param.Add("@PurposeCode", pexbc.PurposeCode);
            //param.Add("@Resp", dbType: DbType.Int32,




            param.Add("@Resp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            try
            {
                var results = await _db.LoadData<pExbc, dynamic>(
                    storedProcedure: "usp_pEXBC_AcceptTermDue_Save",
                    param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                var pEXBCContainer = new PEXBCDataContainer(results.FirstOrDefault());
                
                if (resp == "1")
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Success";
                    response.Data = pEXBCContainer;

                    // Manual Serialize need for nested class
                    string json = JsonConvert.SerializeObject(response);

                    return Content(json, "application/json");
                }
                else
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "EXPORT_BC Save Error";
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
        public async Task<ActionResult<EXBCResultResponse>> PEXBCAcceptTermDueReleaseReq([FromBody] PEXBCAcceptTermDueReleaseReq pExBcAcceptTermDueRelease)
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
            param.Add("@EVENT_NO", pExBcAcceptTermDueRelease.EVENT_NO);
            //param.Add("@USER_ID", pExBcAcceptTermDueRelease.USER_ID);
            param.Add("@USER_ID", USER_ID);

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
                    response.Message = "Export B/C do not exist";
                    return BadRequest(response);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }

        }
    }
}
