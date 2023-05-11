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

namespace ISPTF.API.Controllers.ExportBC
{
    [ApiController]
    [Route("api/[controller]")]
    public class EXBCAdviceDiscrepancyController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public EXBCAdviceDiscrepancyController(ISqlDataAccess db)
        {
            _db = db;
        }

        //[HttpGet("newlist")]
        //public async Task<IEnumerable<Q_EXBCIssueNewPageRsp>> GetAllNew(string? CenterID, string? RegDocNo, string? BENName, string? Page, string? PageSize)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@CenterID", CenterID);
        //    param.Add("@RegDocNo", RegDocNo);
        //    param.Add("@BENName", BENName);
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    if (RegDocNo == null)
        //    {
        //        param.Add("@RegDocNo", "");
        //    }
        //    if (BENName == null)
        //    {
        //        param.Add("@BENName", "");
        //    }

        //    var results = await _db.LoadData<Q_EXBCIssueNewPageRsp, dynamic>(
        //                storedProcedure: "usp_q_EXBC_IssueCollNewPage",
        //                param);
        //    return results;
        //}

        [HttpGet("list")]
        public async Task<ActionResult<EXBCAdviceDiscrepancyPageResponse>> GetAllEdit(string? ListType,string? CenterID, string? EXPORT_BC_NO, string? BENNAME, int? Page, int? PageSize)
        {
            EXBCAdviceDiscrepancyPageResponse response = new EXBCAdviceDiscrepancyPageResponse();
            var USER_ID = User.Identity.Name;
            // Validate
            if (string.IsNullOrEmpty(ListType) || string.IsNullOrEmpty(CenterID) || Page == null || PageSize == null)
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "ListType, CenterID, Page, PageSize is required";
                response.Data = new List<Q_EXBCAdviceDiscrepancyPageRsp>();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@ListType", ListType);
            param.Add("@CenterID", CenterID);
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@BENName", BENNAME);
            param.Add("@USER_ID", USER_ID);
            param.Add("@Page", Page);
            param.Add("@PageSize", PageSize);


            if (EXPORT_BC_NO == null)
            {
                param.Add("@EXPORT_BC_NO", "");
            }
            if (BENNAME == null)
            {
                param.Add("@BENNAME", "");
            }
            if (USER_ID == null)
            {
                param.Add("@USER_ID", "");
            }

            try
            {
                var results = await _db.LoadData<Q_EXBCAdviceDiscrepancyPageRsp, dynamic>(
                            storedProcedure: "usp_q_EXBC_AdviceDiscrepancyListPage",
                            param);
                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = (List<Q_EXBCAdviceDiscrepancyPageRsp>)results;
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
                response.Data = new List<Q_EXBCAdviceDiscrepancyPageRsp>();
            }
            return BadRequest(response);
        }

        //[HttpGet("releaselist")]
        //public async Task<IEnumerable<Q_EXBCAdviceDiscrepancyPageRsp>> GetAllRelease(string? UserID, string? CenterID, string? EXPORT_BC_NO, string? BENNAME, string? Page, string? PageSize)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@UserID", UserID);
        //    param.Add("@CenterID", CenterID);
        //    param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
        //    param.Add("@BENNAME", BENNAME);
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    if (EXPORT_BC_NO == null)
        //    {
        //        param.Add("@EXPORT_BC_NO", "");
        //    }
        //    if (BENNAME == null)
        //    {
        //        param.Add("@BENNAME", "");
        //    }

        //    var results = await _db.LoadData<Q_EXBCAdviceDiscrepancyPageRsp, dynamic>(
        //                storedProcedure: "usp_q_EXBC_AdviceDiscrepancyReleasePage",
        //                param);
        //    return results;
        //}

        //[HttpGet("querylist")]
        //public async Task<IEnumerable<Q_EXBCAdviceDiscrepancyPageRsp>> GetAllQurey(string? CenterID, string? EXPORT_BC_NO, string? BENNAME, string? Page, string? PageSize)
        //{
        //    DynamicParameters param = new();

        //    param.Add("@CenterID", CenterID);
        //    param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
        //    param.Add("@BENNAME", BENNAME);
        //    param.Add("@Page", Page);
        //    param.Add("@PageSize", PageSize);

        //    if (EXPORT_BC_NO == null)
        //    {
        //        param.Add("@EXPORT_BC_NO", "");
        //    }
        //    if (BENNAME == null)
        //    {
        //        param.Add("@BENNAME", "");
        //    }

        //    var results = await _db.LoadData<Q_EXBCAdviceDiscrepancyPageRsp, dynamic>(
        //                storedProcedure: "usp_q_EXBC_AdviceDiscrepancyQueryPage",
        //                param);
        //    return results;
        //}


        [HttpGet("select")]
        public async Task<ActionResult<PEXBCResponse>> GetAllSelect(string? EXPORT_BC_NO, string? RECORD_TYPE, string? REC_STATUS)
        {
            PEXBCResponse response = new PEXBCResponse();
            var USER_ID = User.Identity.Name;

            // Validate
            if (string.IsNullOrEmpty(EXPORT_BC_NO) || string.IsNullOrEmpty(RECORD_TYPE) || string.IsNullOrEmpty(REC_STATUS))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO, RECORD_TYPE, REC_STATUS is required";
                response.Data = new PEXBCDataContainer();
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@RECORD_TYPE", RECORD_TYPE);
            param.Add("@REC_STATUS", REC_STATUS);

            try
            {
                var results = await _db.LoadData<pExbc, dynamic>(
                        storedProcedure: "usp_pEXBC_AdviceDiscrepancy_Select",
                        param);

                var pEXBCContainer = new PEXBCDataContainer(results.FirstOrDefault());

                response.Code = Constants.RESPONSE_OK;
                response.Message = "Success";
                response.Data = pEXBCContainer;

                // Manual Serialize need for nested class
                string json = JsonConvert.SerializeObject(response);
                return Content(json, "application/json");
            }
            catch (Exception e)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = e.ToString();
                response.Data = new PEXBCDataContainer();
            }
            return BadRequest(response);
        }

        [HttpPost("insert")]
        public async Task<ActionResult<PEXBCResponse>> Insert([FromBody] PEXBC_PAYMENT pexbcreq)
        {
            PEXBCResponse response = new PEXBCResponse();
            // Validate
            if (pexbcreq == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "pexbc is required.";
                response.Data = new PEXBCDataContainer();
                return BadRequest(response);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@RECORD_TYPE", pexbcreq.RECORD_TYPE);
            param.Add("@REC_STATUS", pexbcreq.REC_STATUS);
            param.Add("@EVENT_NO", pexbcreq.EVENT_NO);
            param.Add("@EXPORT_BC_NO", pexbcreq.EXPORT_BC_NO);
            param.Add("@EVENT_MODE", pexbcreq.EVENT_MODE);
            param.Add("@BUSINESS_TYPE", pexbcreq.BUSINESS_TYPE);
            param.Add("@EVENT_TYPE", pexbcreq.EVENT_TYPE);
            param.Add("@EVENT_DATE", pexbcreq.EVENT_DATE);
            param.Add("@TENOR_OF_COLL", pexbcreq.TENOR_OF_COLL);
            param.Add("@TENOR_TYPE", pexbcreq.TENOR_TYPE);
            param.Add("@INVOICE", pexbcreq.INVOICE);
            param.Add("@REFER_BC_NO", pexbcreq.REFER_BC_NO);
            param.Add("@RELETE_PACK", pexbcreq.RELETE_PACK);
            param.Add("@DRAFT_CCY", pexbcreq.DRAFT_CCY);
            param.Add("@DRAFT_AMT", pexbcreq.DRAFT_AMT);
            param.Add("@SIGHT_AMT", pexbcreq.SIGHT_AMT);
            param.Add("@TERM_AMT", pexbcreq.TERM_AMT);
            param.Add("@GOOD_CODE", pexbcreq.GOOD_CODE);
            param.Add("@REL_CODE", pexbcreq.REL_CODE);
            param.Add("@CLAIM_TYPE", pexbcreq.CLAIM_TYPE);
            param.Add("@SIGHT_START_DATE", pexbcreq.SIGHT_START_DATE);
            param.Add("@SIGHT_DUE_DATE", pexbcreq.SIGHT_DUE_DATE);
            param.Add("@TENOR_DAY", pexbcreq.TENOR_DAY);
            param.Add("@TENOR_DAY_DESC", pexbcreq.TENOR_DAY_DESC);
            param.Add("@TERM_START_DATE", pexbcreq.TERM_START_DATE);
            param.Add("@TERM_DUE_DATE", pexbcreq.TERM_DUE_DATE);
            param.Add("@PURCH_DISC_DATE", pexbcreq.PURCH_DISC_DATE);
            param.Add("@DRAWEE_INFO", pexbcreq.DRAWEE_INFO);
            param.Add("@CNTY_CODE", pexbcreq.CNTY_CODE);
            param.Add("@Cust_AO", pexbcreq.Cust_AO);
            param.Add("@Cust_LO", pexbcreq.Cust_LO);
            param.Add("@BENE_ID", pexbcreq.BENE_ID);
            param.Add("@BENE_INFO", pexbcreq.BENE_INFO);
            param.Add("@ISSUE_BANK_ID", pexbcreq.ISSUE_BANK_ID);
            param.Add("@ISSUE_BANK_INFO", pexbcreq.ISSUE_BANK_INFO);
            param.Add("@COLLECT_AGENT", pexbcreq.COLLECT_AGENT);
            param.Add("@AGENT_BANK_ID", pexbcreq.AGENT_BANK_ID);
            param.Add("@AGENT_BANK_INFO", pexbcreq.AGENT_BANK_INFO);
            param.Add("@AGENT_BANK_REF", pexbcreq.AGENT_BANK_REF);
            param.Add("@AGENT_BANK_NOSTRO", pexbcreq.AGENT_BANK_NOSTRO);
            param.Add("@RESTRICT", pexbcreq.RESTRICT);
            param.Add("@RESTRICT_TO_BK_NAME", pexbcreq.RESTRICT_TO_BK_NAME);
            param.Add("@RESTRICT_TO_BK_ADDR1", pexbcreq.RESTRICT_TO_BK_ADDR1);
            param.Add("@RESTRICT_TO_BK_ADDR2", pexbcreq.RESTRICT_TO_BK_ADDR2);
            param.Add("@RESTRICT_TO_BK_ADDR3", pexbcreq.RESTRICT_TO_BK_ADDR3);
            param.Add("@RESTRICT_REFER", pexbcreq.RESTRICT_REFER);
            param.Add("@RESTRICT_FR_BK_NAME", pexbcreq.RESTRICT_FR_BK_NAME);
            param.Add("@RESTRICT_FR_BK_ADDR1", pexbcreq.RESTRICT_FR_BK_ADDR1);
            param.Add("@RESTRICT_FR_BK_ADDR2", pexbcreq.RESTRICT_FR_BK_ADDR2);
            param.Add("@RESTRICT_FR_BK_ADDR3", pexbcreq.RESTRICT_FR_BK_ADDR3);
            param.Add("@PARTIAL_FULL_RATE", pexbcreq.PARTIAL_FULL_RATE);
            param.Add("@INT_RATE_METHOD", pexbcreq.INT_RATE_METHOD);
            param.Add("@TYPE_OF_ACCOUNT", pexbcreq.TYPE_OF_ACCOUNT);
            param.Add("@CREDIT_CURRENCY", pexbcreq.CREDIT_CURRENCY);
            param.Add("@DISCOUNT_DAY", pexbcreq.DISCOUNT_DAY);
            param.Add("@GRACE_PERIOD", pexbcreq.GRACE_PERIOD);
            param.Add("@DISC_BASE_DAY", pexbcreq.DISC_BASE_DAY);
            param.Add("@BASE_DAY", pexbcreq.BASE_DAY);
            param.Add("@DISCOUNT_RATE", pexbcreq.DISCOUNT_RATE);
            param.Add("@INT_BASE_RATE", pexbcreq.INT_BASE_RATE);
            param.Add("@INT_SPREAD_RATE", pexbcreq.INT_SPREAD_RATE);
            param.Add("@CURRENT_DIS_RATE", pexbcreq.CURRENT_DIS_RATE);
            param.Add("@CURRENT_INT_RATE", pexbcreq.CURRENT_INT_RATE);
            param.Add("@PAY_BY", pexbcreq.PAY_BY);
            param.Add("@NEGO_AMT", pexbcreq.NEGO_AMT);
            param.Add("@LESS_AGENT", pexbcreq.LESS_AGENT);
            param.Add("@PURCHASE_AMT", pexbcreq.PURCHASE_AMT);
            param.Add("@PURCHASE_RATE", pexbcreq.PURCHASE_RATE);
            param.Add("@TOTAL_NEGO_BALANCE", pexbcreq.TOTAL_NEGO_BALANCE);
            param.Add("@TOTAL_NEGO_BAL_THB", pexbcreq.TOTAL_NEGO_BAL_THB);
            param.Add("@TOT_NEGO_AMT", pexbcreq.TOT_NEGO_AMT);
            param.Add("@TOT_NEGO_AMOUNT", pexbcreq.TOT_NEGO_AMOUNT);
            param.Add("@BANK_CHARGE_AMT", pexbcreq.BANK_CHARGE_AMT);
            param.Add("@NET_PROCEED_CLAIM", pexbcreq.NET_PROCEED_CLAIM);
            param.Add("@CLAIM_PAY_BY", pexbcreq.CLAIM_PAY_BY);
            param.Add("@ParTnor_Type1", pexbcreq.ParTnor_Type1);
            param.Add("@ParTnor_Type2", pexbcreq.ParTnor_Type2);
            param.Add("@ParTnor_Type3", pexbcreq.ParTnor_Type3);
            param.Add("@ParTnor_Type4", pexbcreq.ParTnor_Type4);
            param.Add("@ParTnor_Type5", pexbcreq.ParTnor_Type5);
            param.Add("@ParTnor_Type6", pexbcreq.ParTnor_Type6);
            param.Add("@PARTIAL_AMT1", pexbcreq.PARTIAL_AMT1);
            param.Add("@PARTIAL_AMT2", pexbcreq.PARTIAL_AMT2);
            param.Add("@PARTIAL_AMT3", pexbcreq.PARTIAL_AMT3);
            param.Add("@PARTIAL_AMT4", pexbcreq.PARTIAL_AMT4);
            param.Add("@PARTIAL_AMT5", pexbcreq.PARTIAL_AMT5);
            param.Add("@PARTIAL_AMT6", pexbcreq.PARTIAL_AMT6);
            param.Add("@PARTIAL_RATE1", pexbcreq.PARTIAL_RATE1);
            param.Add("@PARTIAL_RATE2", pexbcreq.PARTIAL_RATE2);
            param.Add("@PARTIAL_RATE3", pexbcreq.PARTIAL_RATE3);
            param.Add("@PARTIAL_RATE4", pexbcreq.PARTIAL_RATE4);
            param.Add("@PARTIAL_RATE5", pexbcreq.PARTIAL_RATE5);
            param.Add("@PARTIAL_RATE6", pexbcreq.PARTIAL_RATE6);
            param.Add("@PARTIAL_AMT1_THB", pexbcreq.PARTIAL_AMT1_THB);
            param.Add("@PARTIAL_AMT2_THB", pexbcreq.PARTIAL_AMT2_THB);
            param.Add("@PARTIAL_AMT3_THB", pexbcreq.PARTIAL_AMT3_THB);
            param.Add("@PARTIAL_AMT4_THB", pexbcreq.PARTIAL_AMT4_THB);
            param.Add("@PARTIAL_AMT5_THB", pexbcreq.PARTIAL_AMT5_THB);
            param.Add("@PARTIAL_AMT6_THB", pexbcreq.PARTIAL_AMT6_THB);
            param.Add("@FORWARD_CONRACT_NO", pexbcreq.FORWARD_CONRACT_NO);
            param.Add("@FORWARD_CONRACT_NO1", pexbcreq.FORWARD_CONRACT_NO1);
            param.Add("@FORWARD_CONRACT_NO2", pexbcreq.FORWARD_CONRACT_NO2);
            param.Add("@FORWARD_CONRACT_NO3", pexbcreq.FORWARD_CONRACT_NO3);
            param.Add("@FORWARD_CONRACT_NO4", pexbcreq.FORWARD_CONRACT_NO4);
            param.Add("@FORWARD_CONRACT_NO5", pexbcreq.FORWARD_CONRACT_NO5);
            param.Add("@FORWARD_CONRACT_NO6", pexbcreq.FORWARD_CONRACT_NO6);
            param.Add("@NEGO_COMM", pexbcreq.NEGO_COMM);
            param.Add("@TELEX_SWIFT", pexbcreq.TELEX_SWIFT);
            param.Add("@COURIER_POSTAGE", pexbcreq.COURIER_POSTAGE);
            param.Add("@STAMP_FEE", pexbcreq.STAMP_FEE);
            param.Add("@BE_STAMP", pexbcreq.BE_STAMP);
            param.Add("@COMM_OTHER", pexbcreq.COMM_OTHER);
            param.Add("@HANDING_FEE", pexbcreq.HANDING_FEE);
            param.Add("@DRAFTCOMM", pexbcreq.DRAFTCOMM);
            param.Add("@INT_AMT_THB", pexbcreq.INT_AMT_THB);
            param.Add("@COMMONTT", pexbcreq.COMMONTT);
            param.Add("@TOTAL_CHARGE", pexbcreq.TOTAL_CHARGE);
            param.Add("@REFUND_TAX_YN", pexbcreq.REFUND_TAX_YN);
            param.Add("@REFUND_TAX_AMT", pexbcreq.REFUND_TAX_AMT);
            param.Add("@DISCOUNT_CCY", pexbcreq.DISCOUNT_CCY);
            param.Add("@DISCRATE", pexbcreq.DISCRATE);
            param.Add("@DISCOUNT_AMT", pexbcreq.DISCOUNT_AMT);
            param.Add("@TOTAL_AMOUNT", pexbcreq.TOTAL_AMOUNT);
            param.Add("@PAYMENT_INSTRU", pexbcreq.PAYMENT_INSTRU);
            param.Add("@METHOD", pexbcreq.METHOD);
            param.Add("@ACBAHTNET", pexbcreq.ACBAHTNET);
            param.Add("@BAHTNET", pexbcreq.BAHTNET);
            param.Add("@RECEIVED_NO", pexbcreq.RECEIVED_NO);
            param.Add("@ALLOCATION", pexbcreq.ALLOCATION);
            param.Add("@NARRATIVE", pexbcreq.NARRATIVE);
            param.Add("@SEQ_ACCEPT_DUE", pexbcreq.SEQ_ACCEPT_DUE);
            param.Add("@COMFIRM_DUE", pexbcreq.COMFIRM_DUE);
            param.Add("@PLUS_MINUS_DISC", pexbcreq.PLUS_MINUS_DISC);
            param.Add("@DISC_DAYS_PLUS_MINUS", pexbcreq.DISC_DAYS_PLUS_MINUS);
            param.Add("@RECEIVE_PAY_AMT", pexbcreq.RECEIVE_PAY_AMT);
            param.Add("@EXCHANGE_RATE", pexbcreq.EXCHANGE_RATE);
            param.Add("@REFUND_DISC_RECEIVE", pexbcreq.REFUND_DISC_RECEIVE);
            param.Add("@DISC_RECEIVE", pexbcreq.DISC_RECEIVE);
            param.Add("@LC_DATE", pexbcreq.LC_DATE);
            param.Add("@COVERING_DATE", pexbcreq.COVERING_DATE);
            param.Add("@COVERING_FOR", pexbcreq.COVERING_FOR);
            param.Add("@ADVICE_ISSUE_BANK", pexbcreq.ADVICE_ISSUE_BANK);
            param.Add("@ADVICE_FORMAT", pexbcreq.ADVICE_FORMAT);
            param.Add("@REMIT_CLAIM_TYPE", pexbcreq.REMIT_CLAIM_TYPE);
            param.Add("@REIMBURSE_BANK_ID", pexbcreq.REIMBURSE_BANK_ID);
            param.Add("@REIMBURSE_BANK_INFO", pexbcreq.REIMBURSE_BANK_INFO);
            param.Add("@SWIFT_BANK", pexbcreq.SWIFT_BANK);
            param.Add("@SWIFT_MAIL", pexbcreq.SWIFT_MAIL);
            param.Add("@CLAIM_FORMAT", pexbcreq.CLAIM_FORMAT);
            param.Add("@VALUE_DATE", pexbcreq.VALUE_DATE);
            param.Add("@THIRD_BANK_ID", pexbcreq.THIRD_BANK_ID);
            param.Add("@THIRD_BANK_INFO", pexbcreq.THIRD_BANK_INFO);
            param.Add("@DISCREPANCY_TYPE", pexbcreq.DISCREPANCY_TYPE);
            param.Add("@SWIFT_DISC", pexbcreq.SWIFT_DISC);
            param.Add("@DOCUMENT_COPY", pexbcreq.DOCUMENT_COPY);

           
            param.Add("@SIGHT_BASIS", null);
            param.Add("@ART44A", null);
            param.Add("@ENDORSED", null);
            param.Add("@MT750", null);

            param.Add("@ADJ_TOT_NEGO_AMOUNT", pexbcreq.ADJ_TOT_NEGO_AMOUNT);
            param.Add("@ADJ_LESS_CHARGE_AMT", pexbcreq.ADJ_LESS_CHARGE_AMT);
            param.Add("@ADJUST_COVERING_AMT", pexbcreq.ADJUST_COVERING_AMT);
            param.Add("@ADJUST_TENOR", pexbcreq.ADJUST_TENOR);
            param.Add("@ADJUST_LC_REF", pexbcreq.ADJUST_LC_REF);
            param.Add("@PAYMENT_INSTRC", pexbcreq.PAYMENT_INSTRC);
            param.Add("@TXTDOCUMENT", pexbcreq.TXTDOCUMENT);
            param.Add("@CHARGE_ACC", pexbcreq.CHARGE_ACC);
            param.Add("@DRAFT", pexbcreq.DRAFT);
            param.Add("@MT202", pexbcreq.MT202);
            param.Add("@FB_CURRENCY", pexbcreq.FB_CURRENCY);
            param.Add("@FB_AMT", pexbcreq.FB_AMT);
            param.Add("@FB_RATE", pexbcreq.FB_RATE);
            param.Add("@FB_AMT_THB", pexbcreq.FB_AMT_THB);
            param.Add("@COLLECT_REFUND", pexbcreq.COLLECT_REFUND);
            param.Add("@USER_ID", pexbcreq.USER_ID);
            param.Add("@IN_USE", pexbcreq.IN_USE);
            param.Add("@AUTH_CODE", pexbcreq.AUTH_CODE);
            param.Add("@GENACC_FLAG", pexbcreq.GENACC_FLAG);
            param.Add("@VOUCH_ID", pexbcreq.VOUCH_ID);
            param.Add("@APPVNO", pexbcreq.APPVNO);
            param.Add("@FACNO", pexbcreq.FACNO);
            param.Add("@AUTOOVERDUE", pexbcreq.AUTOOVERDUE);
            param.Add("@LCOVERDUE", pexbcreq.LCOVERDUE);
            param.Add("@OVESEQNO", pexbcreq.OVESEQNO);
            param.Add("@INTFLAG", pexbcreq.INTFLAG);
            param.Add("@IntRateCode", pexbcreq.IntRateCode);
            param.Add("@CFRRate", pexbcreq.CFRRate);
            param.Add("@INTCODE", pexbcreq.INTCODE);
            param.Add("@OINTRATE", pexbcreq.OINTRATE);
            param.Add("@OINTSPDRATE", pexbcreq.OINTSPDRATE);
            param.Add("@OINTCURRATE", pexbcreq.OINTCURRATE);
            param.Add("@OINTDAY", pexbcreq.OINTDAY);
            param.Add("@OBASEDAY", pexbcreq.OBASEDAY);
            param.Add("@BFINTAMT", pexbcreq.BFINTAMT);
            param.Add("@SELLING_RATE", pexbcreq.SELLING_RATE);
            param.Add("@BFINTTHB", pexbcreq.BFINTTHB);
            param.Add("@INTBALANCE", pexbcreq.INTBALANCE);
            param.Add("@PRNBALANCE", pexbcreq.PRNBALANCE);
            param.Add("@LASTINTAMT", pexbcreq.LASTINTAMT);
            param.Add("@DMS", pexbcreq.DMS);
            param.Add("@LASTINTDATE", pexbcreq.LASTINTDATE);
            param.Add("@PAYMENTTYPE", pexbcreq.PAYMENTTYPE);
            param.Add("@CONFIRM_DATE", pexbcreq.CONFIRM_DATE);
            param.Add("@TOTALACCRUAMT", pexbcreq.TOTALACCRUAMT);
            param.Add("@TOTALACCRUBHT", pexbcreq.TOTALACCRUBHT);
            param.Add("@ACCRUAMT", pexbcreq.ACCRUAMT);
            param.Add("@ACCRUBHT", pexbcreq.ACCRUBHT);
            param.Add("@DATELASTACCRU", pexbcreq.DATELASTACCRU);
            param.Add("@PASTDUEDATE", pexbcreq.PASTDUEDATE);
            param.Add("@PASTDUEFLAG", pexbcreq.PASTDUEFLAG);
            param.Add("@TOTALSUSPAMT", pexbcreq.TOTALSUSPAMT);
            param.Add("@TOTALSUSPBHT", pexbcreq.TOTALSUSPBHT);
            param.Add("@SUSPAMT", pexbcreq.SUSPAMT);
            param.Add("@SUSPBHT", pexbcreq.SUSPBHT);
            param.Add("@CenterID", pexbcreq.CenterID);
            param.Add("@BCPastDue", pexbcreq.BCPastDue);
            param.Add("@DateStartAccru", pexbcreq.DateStartAccru);
            param.Add("@DateToStop", pexbcreq.DateToStop);
            param.Add("@ValueDate", pexbcreq.ValueDate);
            param.Add("@FlagBack", pexbcreq.FlagBack);
            param.Add("@NewAccruCcy", pexbcreq.NewAccruCcy);
            param.Add("@NewAccruAmt", pexbcreq.NewAccruAmt);
            param.Add("@AccruPending", pexbcreq.AccruPending);
            param.Add("@LastAccruCcy", pexbcreq.LastAccruCcy);
            param.Add("@LastAccruAmt", pexbcreq.LastAccruAmt);
            param.Add("@DAccruAmt", pexbcreq.DAccruAmt);
            param.Add("@CCS_ACCT", pexbcreq.CCS_ACCT);
            param.Add("@CCS_LmType", pexbcreq.CCS_LmType);
            param.Add("@CCS_CNUM", pexbcreq.CCS_CNUM);
            param.Add("@CCS_CIFRef", pexbcreq.CCS_CIFRef);
            param.Add("@ObjectType", pexbcreq.ObjectType);
            param.Add("@UnderlyName", pexbcreq.UnderlyName);
            param.Add("@BPOFlag", pexbcreq.BPOFlag);
            param.Add("@Campaign_Code", pexbcreq.Campaign_Code);
            param.Add("@Campaign_EffDate", pexbcreq.Campaign_EffDate);
            param.Add("@PurposeCode", pexbcreq.PurposeCode);
            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            try
            {
                var results = await _db.LoadData<pExbc, dynamic>(
                            storedProcedure: "usp_pEXBC_AdviceDiscrepancy_Insert",
                            param);
                var resp = param.Get<string>("@Resp");

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

        [HttpPost("update")]
        public async Task<ActionResult<PEXBCResponse>> Update([FromBody] PEXBCAdviceDiscrepancyUpdReq pexbcAdvDisUpdreq)
        {
            PEXBCResponse response = new PEXBCResponse();
            // Validate
            if (pexbcAdvDisUpdreq == null)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = "pexbc is required.";
                response.Data = new PEXBCDataContainer();
                return BadRequest(response);
            }

            DynamicParameters param = new DynamicParameters();
            param.Add("@EXPORT_BC_NO", pexbcAdvDisUpdreq.EXPORT_BC_NO);
            param.Add("@EVENT_DATE", pexbcAdvDisUpdreq.EVENT_DATE);
            param.Add("@TENOR_OF_COLL", pexbcAdvDisUpdreq.TENOR_OF_COLL);
            param.Add("@INVOICE", pexbcAdvDisUpdreq.INVOICE);
            param.Add("@DRAFT_CCY", pexbcAdvDisUpdreq.DRAFT_CCY);
            param.Add("@DRAFT_AMT", pexbcAdvDisUpdreq.DRAFT_AMT);
            param.Add("@BENE_ID", pexbcAdvDisUpdreq.BENE_ID);
            param.Add("@BENE_INFO", pexbcAdvDisUpdreq.BENE_INFO);
            param.Add("@ISSUE_BANK_ID", pexbcAdvDisUpdreq.ISSUE_BANK_ID);
            param.Add("@ISSUE_BANK_INFO", pexbcAdvDisUpdreq.ISSUE_BANK_INFO);
            param.Add("@NARRATIVE", pexbcAdvDisUpdreq.NARRATIVE);
            param.Add("@EVENT_NO", pexbcAdvDisUpdreq.EVENT_NO);
            param.Add("@USER_ID", pexbcAdvDisUpdreq.USER_ID);
            param.Add("@CenterID", pexbcAdvDisUpdreq.CenterID);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            try
            {
                var results = await _db.LoadData<pExbc, dynamic>(
                            storedProcedure: "usp_pEXBC_AdviceDiscrepancy_Update",
                            param);
                var resp = param.Get<string>("@Resp");

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
        public async Task<ActionResult<EXBCResultResponse>> EXBCAdviceDiscrepancyDelete([FromBody] EXBCAdviceDiscrepancyDelete pExBcADVDiscDelete)
        {
            EXBCResultResponse response = new EXBCResultResponse();
            if (string.IsNullOrEmpty(pExBcADVDiscDelete.EXPORT_BC_NO))
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO is required";
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", pExBcADVDiscDelete.EXPORT_BC_NO);
            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_AdviceDiscrepancy_Delete", param);
                var resp = param.Get<string>("@Resp");
                if (resp == "0")
                {
                    response.Code = Constants.RESPONSE_OK;
                    response.Message = "Export B/C Deleted";
                    return Ok(response);
                }
                else if (resp == "99")
                {
                    response.Code = Constants.RESPONSE_ERROR;
                    response.Message = "Export B/C: " + pExBcADVDiscDelete.EXPORT_BC_NO + " Not Found.";
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
        public async Task<ActionResult<EXBCResultResponse>> EXBCAdviceDiscrepancyRelease([FromBody] EXBCAdviceDiscrepancyRelease pExBcADVDiscRelease)
        {
            EXBCResultResponse response = new EXBCResultResponse();

            // Validate
            if (string.IsNullOrEmpty(pExBcADVDiscRelease.EXPORT_BC_NO)
                || string.IsNullOrEmpty(pExBcADVDiscRelease.USER_ID)
                || string.IsNullOrEmpty(pExBcADVDiscRelease.NARRATIVE)
               )
            {
                response.Code = Constants.RESPONSE_FIELD_REQUIRED;
                response.Message = "EXPORT_BC_NO, USER_ID, NARRATIVE is required";
                return BadRequest(response);
            }

            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", pExBcADVDiscRelease.EXPORT_BC_NO);
            param.Add("@USER_ID", pExBcADVDiscRelease.USER_ID);
            param.Add("@NARRATIVE", pExBcADVDiscRelease.NARRATIVE);
            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);

            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_AdviceDiscrepancy_Release", param);
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
            catch (Exception ex)
            {
                response.Code = Constants.RESPONSE_ERROR;
                response.Message = ex.ToString();
                return BadRequest(response);

            }
        }
    }
}
