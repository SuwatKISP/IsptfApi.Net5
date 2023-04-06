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
 
namespace ISPTF.API.Controllers.ExportBC
{
    [ApiController]
    [Route("api/[controller]")]
    public class EXBCCoveringLetterController : ControllerBase
    {
        private readonly ISqlDataAccess _db;
        public EXBCCoveringLetterController(ISqlDataAccess db)
        {
            _db = db;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<Q_EXBCCoveringLetterListPageRsp>> GetAllList(string? @ListType, string? CenterID, string? EXPORT_BC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        {
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

            var results = await _db.LoadData<Q_EXBCCoveringLetterListPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXBC_CoveringLetterListPage",
                        param);
            return results;
        }

        [HttpGet("query")]
        public async Task<IEnumerable<Q_EXBCCoveringLetterQueryPageRsp>> GetAllQuery(string? @ListType, string? CenterID, string? EXPORT_BC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        {
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

            var results = await _db.LoadData<Q_EXBCCoveringLetterQueryPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXBC_CoveringLetterQueryPage",
                        param);
            return results;
        }


        [HttpGet("select")]
        public async Task<ActionResult<PEXBC_PSWExport_PEXDOC_Rsp>> Select(string? EXPORT_BC_NO, string? RECORD_TYPE, string? REC_STATUS)//, string? EVENT_NO)
//        public async Task<IEnumerable<PEXBC_PEXDOC_Rsp>> GetAllSelect(string? EXPORT_BC_NO, string? RECORD_TYPE, string? REC_STATUS)//, string? EVENT_NO)
        {
            DynamicParameters param = new();

            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@RECORD_TYPE", RECORD_TYPE);
            param.Add("@REC_STATUS", REC_STATUS);
            //param.Add("@EVENT_NO", EVENT_NO);

            param.Add("@PEXBCPEXDOCRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            var results = await _db.LoadData<PEXBC_PSWExport_PEXDOC_Rsp, dynamic>(
                    storedProcedure: "usp_pEXBC_CoveringLetter_Select",
                    param);

            var pexbcpexdoc = param.Get<dynamic>("@PEXBCPEXDOCRsp");
            return Ok(pexbcpexdoc);
        }

        [HttpPost("save")]
        public async Task<ActionResult<PEXBC_PSWExport_PEXDOC_Rsp>> Save([FromBody] PEXBC_PSWExport_PEXDOC_Covering_Req pexbcreq)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RECORD_TYPE", pexbcreq.PEXBC.RECORD_TYPE);
            param.Add("@REC_STATUS", pexbcreq.PEXBC.REC_STATUS);
            param.Add("@EVENT_NO", pexbcreq.PEXBC.EVENT_NO);
            param.Add("@EXPORT_BC_NO", pexbcreq.PEXBC.EXPORT_BC_NO);
            param.Add("@EVENT_MODE", pexbcreq.PEXBC.EVENT_MODE);
            param.Add("@BUSINESS_TYPE", pexbcreq.PEXBC.BUSINESS_TYPE);
            param.Add("@EVENT_TYPE", pexbcreq.PEXBC.EVENT_TYPE);
            param.Add("@EVENT_DATE", pexbcreq.PEXBC.EVENT_DATE);
            param.Add("@TENOR_OF_COLL", pexbcreq.PEXBC.TENOR_OF_COLL);
            param.Add("@TENOR_TYPE", pexbcreq.PEXBC.TENOR_TYPE);
            param.Add("@INVOICE", pexbcreq.PEXBC.INVOICE);
            param.Add("@REFER_BC_NO", pexbcreq.PEXBC.REFER_BC_NO);
            param.Add("@RELETE_PACK", pexbcreq.PEXBC.RELETE_PACK);
            param.Add("@DRAFT_CCY", pexbcreq.PEXBC.DRAFT_CCY);
            param.Add("@DRAFT_AMT", pexbcreq.PEXBC.DRAFT_AMT);
            param.Add("@SIGHT_AMT", pexbcreq.PEXBC.SIGHT_AMT);
            param.Add("@TERM_AMT", pexbcreq.PEXBC.TERM_AMT);
            param.Add("@GOOD_CODE", pexbcreq.PEXBC.GOOD_CODE);
            param.Add("@REL_CODE", pexbcreq.PEXBC.REL_CODE);
            param.Add("@CLAIM_TYPE", pexbcreq.PEXBC.CLAIM_TYPE);
            param.Add("@SIGHT_START_DATE", pexbcreq.PEXBC.SIGHT_START_DATE);
            param.Add("@SIGHT_DUE_DATE", pexbcreq.PEXBC.SIGHT_DUE_DATE);
            param.Add("@TENOR_DAY", pexbcreq.PEXBC.TENOR_DAY);
            param.Add("@TENOR_DAY_DESC", pexbcreq.PEXBC.TENOR_DAY_DESC);
            param.Add("@TERM_START_DATE", pexbcreq.PEXBC.TERM_START_DATE);
            param.Add("@TERM_DUE_DATE", pexbcreq.PEXBC.TERM_DUE_DATE);
            param.Add("@PURCH_DISC_DATE", pexbcreq.PEXBC.PURCH_DISC_DATE);
            param.Add("@DRAWEE_INFO", pexbcreq.PEXBC.DRAWEE_INFO);
            param.Add("@CNTY_CODE", pexbcreq.PEXBC.CNTY_CODE);
            param.Add("@Cust_AO", pexbcreq.PEXBC.Cust_AO);
            param.Add("@Cust_LO", pexbcreq.PEXBC.Cust_LO);
            param.Add("@BENE_ID", pexbcreq.PEXBC.BENE_ID);
            param.Add("@BENE_INFO", pexbcreq.PEXBC.BENE_INFO);
            param.Add("@ISSUE_BANK_ID", pexbcreq.PEXBC.ISSUE_BANK_ID);
            param.Add("@ISSUE_BANK_INFO", pexbcreq.PEXBC.ISSUE_BANK_INFO);
            param.Add("@COLLECT_AGENT", pexbcreq.PEXBC.COLLECT_AGENT);
            param.Add("@AGENT_BANK_ID", pexbcreq.PEXBC.AGENT_BANK_ID);
            param.Add("@AGENT_BANK_INFO", pexbcreq.PEXBC.AGENT_BANK_INFO);
            param.Add("@AGENT_BANK_REF", pexbcreq.PEXBC.AGENT_BANK_REF);
            param.Add("@AGENT_BANK_NOSTRO", pexbcreq.PEXBC.AGENT_BANK_NOSTRO);
            param.Add("@RESTRICT", pexbcreq.PEXBC.RESTRICT);
            param.Add("@RESTRICT_TO_BK_NAME", pexbcreq.PEXBC.RESTRICT_TO_BK_NAME);
            param.Add("@RESTRICT_TO_BK_ADDR1", pexbcreq.PEXBC.RESTRICT_TO_BK_ADDR1);
            param.Add("@RESTRICT_TO_BK_ADDR2", pexbcreq.PEXBC.RESTRICT_TO_BK_ADDR2);
            param.Add("@RESTRICT_TO_BK_ADDR3", pexbcreq.PEXBC.RESTRICT_TO_BK_ADDR3);
            param.Add("@RESTRICT_REFER", pexbcreq.PEXBC.RESTRICT_REFER);
            param.Add("@RESTRICT_FR_BK_NAME", pexbcreq.PEXBC.RESTRICT_FR_BK_NAME);
            param.Add("@RESTRICT_FR_BK_ADDR1", pexbcreq.PEXBC.RESTRICT_FR_BK_ADDR1);
            param.Add("@RESTRICT_FR_BK_ADDR2", pexbcreq.PEXBC.RESTRICT_FR_BK_ADDR2);
            param.Add("@RESTRICT_FR_BK_ADDR3", pexbcreq.PEXBC.RESTRICT_FR_BK_ADDR3);
            param.Add("@PARTIAL_FULL_RATE", pexbcreq.PEXBC.PARTIAL_FULL_RATE);
            param.Add("@INT_RATE_METHOD", pexbcreq.PEXBC.INT_RATE_METHOD);
            param.Add("@TYPE_OF_ACCOUNT", pexbcreq.PEXBC.TYPE_OF_ACCOUNT);
            param.Add("@CREDIT_CURRENCY", pexbcreq.PEXBC.CREDIT_CURRENCY);
            param.Add("@DISCOUNT_DAY", pexbcreq.PEXBC.DISCOUNT_DAY);
            param.Add("@GRACE_PERIOD", pexbcreq.PEXBC.GRACE_PERIOD);
            param.Add("@DISC_BASE_DAY", pexbcreq.PEXBC.DISC_BASE_DAY);
            param.Add("@BASE_DAY", pexbcreq.PEXBC.BASE_DAY);
            param.Add("@DISCOUNT_RATE", pexbcreq.PEXBC.DISCOUNT_RATE);
            param.Add("@INT_BASE_RATE", pexbcreq.PEXBC.INT_BASE_RATE);
            param.Add("@INT_SPREAD_RATE", pexbcreq.PEXBC.INT_SPREAD_RATE);
            param.Add("@CURRENT_DIS_RATE", pexbcreq.PEXBC.CURRENT_DIS_RATE);
            param.Add("@CURRENT_INT_RATE", pexbcreq.PEXBC.CURRENT_INT_RATE);
            param.Add("@PAY_BY", pexbcreq.PEXBC.PAY_BY);
            param.Add("@NEGO_AMT", pexbcreq.PEXBC.NEGO_AMT);
            param.Add("@LESS_AGENT", pexbcreq.PEXBC.LESS_AGENT);
            param.Add("@PURCHASE_AMT", pexbcreq.PEXBC.PURCHASE_AMT);
            param.Add("@PURCHASE_RATE", pexbcreq.PEXBC.PURCHASE_RATE);
            param.Add("@TOTAL_NEGO_BALANCE", pexbcreq.PEXBC.TOTAL_NEGO_BALANCE);
            param.Add("@TOTAL_NEGO_BAL_THB", pexbcreq.PEXBC.TOTAL_NEGO_BAL_THB);
            param.Add("@TOT_NEGO_AMT", pexbcreq.PEXBC.TOT_NEGO_AMT);
            param.Add("@TOT_NEGO_AMOUNT", pexbcreq.PEXBC.TOT_NEGO_AMOUNT);
            param.Add("@BANK_CHARGE_AMT", pexbcreq.PEXBC.BANK_CHARGE_AMT);
            param.Add("@NET_PROCEED_CLAIM", pexbcreq.PEXBC.NET_PROCEED_CLAIM);
            param.Add("@CLAIM_PAY_BY", pexbcreq.PEXBC.CLAIM_PAY_BY);
            param.Add("@ParTnor_Type1", pexbcreq.PEXBC.ParTnor_Type1);
            param.Add("@ParTnor_Type2", pexbcreq.PEXBC.ParTnor_Type2);
            param.Add("@ParTnor_Type3", pexbcreq.PEXBC.ParTnor_Type3);
            param.Add("@ParTnor_Type4", pexbcreq.PEXBC.ParTnor_Type4);
            param.Add("@ParTnor_Type5", pexbcreq.PEXBC.ParTnor_Type5);
            param.Add("@ParTnor_Type6", pexbcreq.PEXBC.ParTnor_Type6);
            param.Add("@PARTIAL_AMT1", pexbcreq.PEXBC.PARTIAL_AMT1);
            param.Add("@PARTIAL_AMT2", pexbcreq.PEXBC.PARTIAL_AMT2);
            param.Add("@PARTIAL_AMT3", pexbcreq.PEXBC.PARTIAL_AMT3);
            param.Add("@PARTIAL_AMT4", pexbcreq.PEXBC.PARTIAL_AMT4);
            param.Add("@PARTIAL_AMT5", pexbcreq.PEXBC.PARTIAL_AMT5);
            param.Add("@PARTIAL_AMT6", pexbcreq.PEXBC.PARTIAL_AMT6);
            param.Add("@PARTIAL_RATE1", pexbcreq.PEXBC.PARTIAL_RATE1);
            param.Add("@PARTIAL_RATE2", pexbcreq.PEXBC.PARTIAL_RATE2);
            param.Add("@PARTIAL_RATE3", pexbcreq.PEXBC.PARTIAL_RATE3);
            param.Add("@PARTIAL_RATE4", pexbcreq.PEXBC.PARTIAL_RATE4);
            param.Add("@PARTIAL_RATE5", pexbcreq.PEXBC.PARTIAL_RATE5);
            param.Add("@PARTIAL_RATE6", pexbcreq.PEXBC.PARTIAL_RATE6);
            param.Add("@PARTIAL_AMT1_THB", pexbcreq.PEXBC.PARTIAL_AMT1_THB);
            param.Add("@PARTIAL_AMT2_THB", pexbcreq.PEXBC.PARTIAL_AMT2_THB);
            param.Add("@PARTIAL_AMT3_THB", pexbcreq.PEXBC.PARTIAL_AMT3_THB);
            param.Add("@PARTIAL_AMT4_THB", pexbcreq.PEXBC.PARTIAL_AMT4_THB);
            param.Add("@PARTIAL_AMT5_THB", pexbcreq.PEXBC.PARTIAL_AMT5_THB);
            param.Add("@PARTIAL_AMT6_THB", pexbcreq.PEXBC.PARTIAL_AMT6_THB);
            param.Add("@FORWARD_CONRACT_NO", pexbcreq.PEXBC.FORWARD_CONRACT_NO);
            param.Add("@FORWARD_CONRACT_NO1", pexbcreq.PEXBC.FORWARD_CONRACT_NO1);
            param.Add("@FORWARD_CONRACT_NO2", pexbcreq.PEXBC.FORWARD_CONRACT_NO2);
            param.Add("@FORWARD_CONRACT_NO3", pexbcreq.PEXBC.FORWARD_CONRACT_NO3);
            param.Add("@FORWARD_CONRACT_NO4", pexbcreq.PEXBC.FORWARD_CONRACT_NO4);
            param.Add("@FORWARD_CONRACT_NO5", pexbcreq.PEXBC.FORWARD_CONRACT_NO5);
            param.Add("@FORWARD_CONRACT_NO6", pexbcreq.PEXBC.FORWARD_CONRACT_NO6);
            param.Add("@NEGO_COMM", pexbcreq.PEXBC.NEGO_COMM);
            param.Add("@TELEX_SWIFT", pexbcreq.PEXBC.TELEX_SWIFT);
            param.Add("@COURIER_POSTAGE", pexbcreq.PEXBC.COURIER_POSTAGE);
            param.Add("@STAMP_FEE", pexbcreq.PEXBC.STAMP_FEE);
            param.Add("@BE_STAMP", pexbcreq.PEXBC.BE_STAMP);
            param.Add("@COMM_OTHER", pexbcreq.PEXBC.COMM_OTHER);
            param.Add("@HANDING_FEE", pexbcreq.PEXBC.HANDING_FEE);
            param.Add("@DRAFTCOMM", pexbcreq.PEXBC.DRAFTCOMM);
            param.Add("@INT_AMT_THB", pexbcreq.PEXBC.INT_AMT_THB);
            param.Add("@COMMONTT", pexbcreq.PEXBC.COMMONTT);
            param.Add("@TOTAL_CHARGE", pexbcreq.PEXBC.TOTAL_CHARGE);
            param.Add("@REFUND_TAX_YN", pexbcreq.PEXBC.REFUND_TAX_YN);
            param.Add("@REFUND_TAX_AMT", pexbcreq.PEXBC.REFUND_TAX_AMT);
            param.Add("@DISCOUNT_CCY", pexbcreq.PEXBC.DISCOUNT_CCY);
            param.Add("@DISCRATE", pexbcreq.PEXBC.DISCRATE);
            param.Add("@DISCOUNT_AMT", pexbcreq.PEXBC.DISCOUNT_AMT);
            param.Add("@TOTAL_AMOUNT", pexbcreq.PEXBC.TOTAL_AMOUNT);
            param.Add("@PAYMENT_INSTRU", pexbcreq.PEXBC.PAYMENT_INSTRU);
            param.Add("@METHOD", pexbcreq.PEXBC.METHOD);
            param.Add("@ACBAHTNET", pexbcreq.PEXBC.ACBAHTNET);
            param.Add("@BAHTNET", pexbcreq.PEXBC.BAHTNET);
            param.Add("@RECEIVED_NO", pexbcreq.PEXBC.RECEIVED_NO);
            param.Add("@ALLOCATION", pexbcreq.PEXBC.ALLOCATION);
            param.Add("@NARRATIVE", pexbcreq.PEXBC.NARRATIVE);
            param.Add("@SEQ_ACCEPT_DUE", pexbcreq.PEXBC.SEQ_ACCEPT_DUE);
            param.Add("@COMFIRM_DUE", pexbcreq.PEXBC.COMFIRM_DUE);
            param.Add("@PLUS_MINUS_DISC", pexbcreq.PEXBC.PLUS_MINUS_DISC);
            param.Add("@DISC_DAYS_PLUS_MINUS", pexbcreq.PEXBC.DISC_DAYS_PLUS_MINUS);
            param.Add("@RECEIVE_PAY_AMT", pexbcreq.PEXBC.RECEIVE_PAY_AMT);
            param.Add("@EXCHANGE_RATE", pexbcreq.PEXBC.EXCHANGE_RATE);
            param.Add("@REFUND_DISC_RECEIVE", pexbcreq.PEXBC.REFUND_DISC_RECEIVE);
            param.Add("@DISC_RECEIVE", pexbcreq.PEXBC.DISC_RECEIVE);
            param.Add("@LC_DATE", pexbcreq.PEXBC.LC_DATE);
            param.Add("@COVERING_DATE", pexbcreq.PEXBC.COVERING_DATE);
            param.Add("@COVERING_FOR", pexbcreq.PEXBC.COVERING_FOR);
            param.Add("@ADVICE_ISSUE_BANK", pexbcreq.PEXBC.ADVICE_ISSUE_BANK);
            param.Add("@ADVICE_FORMAT", pexbcreq.PEXBC.ADVICE_FORMAT);
            param.Add("@REMIT_CLAIM_TYPE", pexbcreq.PEXBC.REMIT_CLAIM_TYPE);
            param.Add("@REIMBURSE_BANK_ID", pexbcreq.PEXBC.REIMBURSE_BANK_ID);
            param.Add("@REIMBURSE_BANK_INFO", pexbcreq.PEXBC.REIMBURSE_BANK_INFO);
            param.Add("@SWIFT_BANK", pexbcreq.PEXBC.SWIFT_BANK);
            param.Add("@SWIFT_MAIL", pexbcreq.PEXBC.SWIFT_MAIL);
            param.Add("@CLAIM_FORMAT", pexbcreq.PEXBC.CLAIM_FORMAT);
            param.Add("@VALUE_DATE", pexbcreq.PEXBC.VALUE_DATE);
            param.Add("@THIRD_BANK_ID", pexbcreq.PEXBC.THIRD_BANK_ID);
            param.Add("@THIRD_BANK_INFO", pexbcreq.PEXBC.THIRD_BANK_INFO);
            param.Add("@DISCREPANCY_TYPE", pexbcreq.PEXBC.DISCREPANCY_TYPE);
            param.Add("@SWIFT_DISC", pexbcreq.PEXBC.SWIFT_DISC);
            param.Add("@DOCUMENT_COPY", pexbcreq.PEXBC.DOCUMENT_COPY);
            param.Add("@SIGHT_BASIS", pexbcreq.PEXBC.SIGHT_BASIS);
            param.Add("@ART44A", pexbcreq.PEXBC.ART44A);
            param.Add("@ENDORSED", pexbcreq.PEXBC.ENDORSED);
            param.Add("@MT750", pexbcreq.PEXBC.MT750);
            param.Add("@ADJ_TOT_NEGO_AMOUNT", pexbcreq.PEXBC.ADJ_TOT_NEGO_AMOUNT);
            param.Add("@ADJ_LESS_CHARGE_AMT", pexbcreq.PEXBC.ADJ_LESS_CHARGE_AMT);
            param.Add("@ADJUST_COVERING_AMT", pexbcreq.PEXBC.ADJUST_COVERING_AMT);
            param.Add("@ADJUST_TENOR", pexbcreq.PEXBC.ADJUST_TENOR);
            param.Add("@ADJUST_LC_REF", pexbcreq.PEXBC.ADJUST_LC_REF);
            param.Add("@PAYMENT_INSTRC", pexbcreq.PEXBC.PAYMENT_INSTRC);
            param.Add("@TXTDOCUMENT", pexbcreq.PEXBC.TXTDOCUMENT);
            param.Add("@CHARGE_ACC", pexbcreq.PEXBC.CHARGE_ACC);
            param.Add("@DRAFT", pexbcreq.PEXBC.DRAFT);
            param.Add("@MT202", pexbcreq.PEXBC.MT202);
            param.Add("@FB_CURRENCY", pexbcreq.PEXBC.FB_CURRENCY);
            param.Add("@FB_AMT", pexbcreq.PEXBC.FB_AMT);
            param.Add("@FB_RATE", pexbcreq.PEXBC.FB_RATE);
            param.Add("@FB_AMT_THB", pexbcreq.PEXBC.FB_AMT_THB);
            param.Add("@COLLECT_REFUND", pexbcreq.PEXBC.COLLECT_REFUND);
            param.Add("@USER_ID", pexbcreq.PEXBC.USER_ID);
            param.Add("@IN_USE", pexbcreq.PEXBC.IN_USE);
            param.Add("@AUTH_CODE", pexbcreq.PEXBC.AUTH_CODE);
            param.Add("@GENACC_FLAG", pexbcreq.PEXBC.GENACC_FLAG);
            param.Add("@VOUCH_ID", pexbcreq.PEXBC.VOUCH_ID);
            param.Add("@APPVNO", pexbcreq.PEXBC.APPVNO);
            param.Add("@FACNO", pexbcreq.PEXBC.FACNO);
            param.Add("@AUTOOVERDUE", pexbcreq.PEXBC.AUTOOVERDUE);
            param.Add("@LCOVERDUE", pexbcreq.PEXBC.LCOVERDUE);
            param.Add("@OVESEQNO", pexbcreq.PEXBC.OVESEQNO);
            param.Add("@INTFLAG", pexbcreq.PEXBC.INTFLAG);
            param.Add("@IntRateCode", pexbcreq.PEXBC.IntRateCode);
            param.Add("@CFRRate", pexbcreq.PEXBC.CFRRate);
            param.Add("@INTCODE", pexbcreq.PEXBC.INTCODE);
            param.Add("@OINTRATE", pexbcreq.PEXBC.OINTRATE);
            param.Add("@OINTSPDRATE", pexbcreq.PEXBC.OINTSPDRATE);
            param.Add("@OINTCURRATE", pexbcreq.PEXBC.OINTCURRATE);
            param.Add("@OINTDAY", pexbcreq.PEXBC.OINTDAY);
            param.Add("@OBASEDAY", pexbcreq.PEXBC.OBASEDAY);
            param.Add("@BFINTAMT", pexbcreq.PEXBC.BFINTAMT);
            param.Add("@SELLING_RATE", pexbcreq.PEXBC.SELLING_RATE);
            param.Add("@BFINTTHB", pexbcreq.PEXBC.BFINTTHB);
            param.Add("@INTBALANCE", pexbcreq.PEXBC.INTBALANCE);
            param.Add("@PRNBALANCE", pexbcreq.PEXBC.PRNBALANCE);
            param.Add("@LASTINTAMT", pexbcreq.PEXBC.LASTINTAMT);
            param.Add("@DMS", pexbcreq.PEXBC.DMS);
            param.Add("@LASTINTDATE", pexbcreq.PEXBC.LASTINTDATE);
            param.Add("@PAYMENTTYPE", pexbcreq.PEXBC.PAYMENTTYPE);
            param.Add("@CONFIRM_DATE", pexbcreq.PEXBC.CONFIRM_DATE);
            param.Add("@TOTALACCRUAMT", pexbcreq.PEXBC.TOTALACCRUAMT);
            param.Add("@TOTALACCRUBHT", pexbcreq.PEXBC.TOTALACCRUBHT);
            param.Add("@ACCRUAMT", pexbcreq.PEXBC.ACCRUAMT);
            param.Add("@ACCRUBHT", pexbcreq.PEXBC.ACCRUBHT);
            param.Add("@DATELASTACCRU", pexbcreq.PEXBC.DATELASTACCRU);
            param.Add("@PASTDUEDATE", pexbcreq.PEXBC.PASTDUEDATE);
            param.Add("@PASTDUEFLAG", pexbcreq.PEXBC.PASTDUEFLAG);
            param.Add("@TOTALSUSPAMT", pexbcreq.PEXBC.TOTALSUSPAMT);
            param.Add("@TOTALSUSPBHT", pexbcreq.PEXBC.TOTALSUSPBHT);
            param.Add("@SUSPAMT", pexbcreq.PEXBC.SUSPAMT);
            param.Add("@SUSPBHT", pexbcreq.PEXBC.SUSPBHT);
            param.Add("@CenterID", pexbcreq.PEXBC.CenterID);
            param.Add("@BCPastDue", pexbcreq.PEXBC.BCPastDue);
            param.Add("@DateStartAccru", pexbcreq.PEXBC.DateStartAccru);
            param.Add("@DateToStop", pexbcreq.PEXBC.DateToStop);
            param.Add("@ValueDate", pexbcreq.PEXBC.ValueDate);
            param.Add("@FlagBack", pexbcreq.PEXBC.FlagBack);
            param.Add("@NewAccruCcy", pexbcreq.PEXBC.NewAccruCcy);
            param.Add("@NewAccruAmt", pexbcreq.PEXBC.NewAccruAmt);
            param.Add("@AccruPending", pexbcreq.PEXBC.AccruPending);
            param.Add("@LastAccruCcy", pexbcreq.PEXBC.LastAccruCcy);
            param.Add("@LastAccruAmt", pexbcreq.PEXBC.LastAccruAmt);
            param.Add("@DAccruAmt", pexbcreq.PEXBC.DAccruAmt);
            param.Add("@CCS_ACCT", pexbcreq.PEXBC.CCS_ACCT);
            param.Add("@CCS_LmType", pexbcreq.PEXBC.CCS_LmType);
            param.Add("@CCS_CNUM", pexbcreq.PEXBC.CCS_CNUM);
            param.Add("@CCS_CIFRef", pexbcreq.PEXBC.CCS_CIFRef);
            param.Add("@ObjectType", pexbcreq.PEXBC.ObjectType);
            param.Add("@UnderlyName", pexbcreq.PEXBC.UnderlyName);
            param.Add("@BPOFlag", pexbcreq.PEXBC.BPOFlag);
            param.Add("@Campaign_Code", pexbcreq.PEXBC.Campaign_Code);
            param.Add("@Campaign_EffDate", pexbcreq.PEXBC.Campaign_EffDate);
            param.Add("@PurposeCode", pexbcreq.PEXBC.PurposeCode);

            //---------------- pSWExport --------------------
            if (pexbcreq.PSWEXPORT != null)
            {
                param.Add("@AutoNum", pexbcreq.PSWEXPORT.AutoNum);
                param.Add("@DocNo", pexbcreq.PSWEXPORT.DocNo);
                param.Add("@Event_No", pexbcreq.PSWEXPORT.Event_No);
                param.Add("@Event", pexbcreq.PSWEXPORT.Event);
                param.Add("@SwiftFile", pexbcreq.PSWEXPORT.SwiftFile);
                param.Add("@MTType", pexbcreq.PSWEXPORT.MTType);
                param.Add("@BankType", pexbcreq.PSWEXPORT.BankType);
                param.Add("@BankID", pexbcreq.PSWEXPORT.BankID);
                param.Add("@BankInFo", pexbcreq.PSWEXPORT.BankInFo);
                param.Add("@NBankID", pexbcreq.PSWEXPORT.NBankID);
                param.Add("@NBankInfo", pexbcreq.PSWEXPORT.NBankInfo);
                param.Add("@MT742", pexbcreq.PSWEXPORT.MT742);
                param.Add("@MT730", pexbcreq.PSWEXPORT.MT730);
                param.Add("@MT499", pexbcreq.PSWEXPORT.MT499);
                param.Add("@MT799", pexbcreq.PSWEXPORT.MT799);
                param.Add("@MT999", pexbcreq.PSWEXPORT.MT999);
                param.Add("@ValueDate", pexbcreq.PSWEXPORT.ValueDate);
                param.Add("@RemitCcy", pexbcreq.PSWEXPORT.RemitCcy);
                param.Add("@RemitAmt", pexbcreq.PSWEXPORT.RemitAmt);
                param.Add("@ChargeAmt", pexbcreq.PSWEXPORT.ChargeAmt);
                param.Add("@F20", pexbcreq.PSWEXPORT.F20);
                param.Add("@F21", pexbcreq.PSWEXPORT.F21);
                param.Add("@F23B", pexbcreq.PSWEXPORT.F23B);
                param.Add("@F25", pexbcreq.PSWEXPORT.F25);
                param.Add("@F26T", pexbcreq.PSWEXPORT.F26T);
                param.Add("@F31", pexbcreq.PSWEXPORT.F31);
                param.Add("@F32A", pexbcreq.PSWEXPORT.F32A);
                param.Add("@F32B", pexbcreq.PSWEXPORT.F32B);
                param.Add("@F33B", pexbcreq.PSWEXPORT.F33B);
                param.Add("@F34A", pexbcreq.PSWEXPORT.F34A);
                param.Add("@F34B", pexbcreq.PSWEXPORT.F34B);
                param.Add("@F52A", pexbcreq.PSWEXPORT.F52A);
                param.Add("@F52D", pexbcreq.PSWEXPORT.F52D);
                param.Add("@F52UID", pexbcreq.PSWEXPORT.F52UID);
                param.Add("@F53A", pexbcreq.PSWEXPORT.F53A);
                param.Add("@F53D", pexbcreq.PSWEXPORT.F53D);
                param.Add("@F56A", pexbcreq.PSWEXPORT.F56A);
                param.Add("@F56D", pexbcreq.PSWEXPORT.F56D);
                param.Add("@F56UID", pexbcreq.PSWEXPORT.F56UID);
                param.Add("@F57A", pexbcreq.PSWEXPORT.F57A);
                param.Add("@F57AC", pexbcreq.PSWEXPORT.F57AC);
                param.Add("@F57D", pexbcreq.PSWEXPORT.F57D);
                param.Add("@F57UID", pexbcreq.PSWEXPORT.F57UID);
                param.Add("@F58A", pexbcreq.PSWEXPORT.F58A);
                param.Add("@F58AC", pexbcreq.PSWEXPORT.F58AC);
                param.Add("@F58D", pexbcreq.PSWEXPORT.F58D);
                param.Add("@F58UID", pexbcreq.PSWEXPORT.F58UID);
                param.Add("@F59A", pexbcreq.PSWEXPORT.F59A);
                param.Add("@F59D", pexbcreq.PSWEXPORT.F59D);
                param.Add("@F59UID", pexbcreq.PSWEXPORT.F59UID);
                param.Add("@F71B", pexbcreq.PSWEXPORT.F71B);
                param.Add("@F72", pexbcreq.PSWEXPORT.F72);
                param.Add("@F73", pexbcreq.PSWEXPORT.F73);
                param.Add("@F77", pexbcreq.PSWEXPORT.F77);
                param.Add("@F77B", pexbcreq.PSWEXPORT.F77B);
                param.Add("@F79", pexbcreq.PSWEXPORT.F79);
                param.Add("@MT768", pexbcreq.PSWEXPORT.MT768);

                param.Add("@TX30", pexbcreq.PSWEXPORT.TX30);
                param.Add("@TX31C", pexbcreq.PSWEXPORT.TX31C);
            }

            //---------------- pExDoc --------------------
            var dtExDoc = new DataTable();
            dtExDoc.Columns.Add("EXLC_NO", typeof(string));
            dtExDoc.Columns.Add("SEQNO", typeof(int));
            dtExDoc.Columns.Add("EVENT_NO", typeof(int));
            dtExDoc.Columns.Add("DOCUMENT_ID", typeof(string));
            dtExDoc.Columns.Add("DOCUMENT_NAME", typeof(string));
            dtExDoc.Columns.Add("FMail_No", typeof(string));
            dtExDoc.Columns.Add("SMail_No", typeof(string));
            dtExDoc.Columns.Add("MODULE_TYPE", typeof(string));
            dtExDoc.Columns.Add("EVENT_DATE", typeof(DateTime));
            dtExDoc.Columns.Add("CenterID", typeof(string));

            if (pexbcreq.PEXDOC != null)
            {
                for (int i = 0; i < pexbcreq.PEXDOC.Length; i++)
                {
                    dtExDoc.Rows.Add(
                          pexbcreq.PEXDOC[i].EXLC_NO
                        , pexbcreq.PEXDOC[i].SEQNO
                        , pexbcreq.PEXDOC[i].EVENT_NO
                        , pexbcreq.PEXDOC[i].DOCUMENT_ID
                        , pexbcreq.PEXDOC[i].DOCUMENT_NAME
                        , pexbcreq.PEXDOC[i].FMail_No
                        , pexbcreq.PEXDOC[i].SMail_No
                        , pexbcreq.PEXDOC[i].MODULE_TYPE
                        , pexbcreq.PEXDOC[i].EVENT_DATE
                        , pexbcreq.PEXDOC[i].CenterID
                        );
                }
            }
            param.Add("@EXDOC", dtExDoc.AsTableValuedParameter("Type_pExDoc"));

            param.Add("@PEXBCPEXDOCRsp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
               direction: System.Data.ParameterDirection.Output,
               size: 5215585);
            try
            {
                var results = await _db.LoadData<PEXBC_PSWExport_PEXDOC_Rsp, dynamic>(
                    storedProcedure: "usp_pEXBC_CoveringLetter_Save",
                    param);

                var pexbcpexdocrsp = param.Get<dynamic>("@PEXBCPEXDOCRsp");

                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
               // return Ok(resp);
                if (Int16.Parse(resp) > 0)
                {
                    return Ok(pexbcpexdocrsp);
                }
                else
                {
                    ReturnResponse response = new();
                    //    response.StatusCode = "400";
                    response.Message = resp.ToString(); //= "EXPORT_BC_NO Insert Error";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

   
        [HttpPost("delete")]
        public async Task<ActionResult<string>> EXBCCoveringLetterDelete([FromBody] PEXBCCoveringLetterDeleteReq pExBcCoveringLetterDelete)
        {
            DynamicParameters param = new();
            param.Add("@EXPORT_BC_NO", pExBcCoveringLetterDelete.EXPORTT_BC_NO);
            param.Add("@DMS", pExBcCoveringLetterDelete.DMS);

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_CoveringLetter_Delete", param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                if (Int16.Parse(resp) > 0)
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
                    response.Message = "Export B/C NO Not Exist";
                    //response.Message = resp.ToString();
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("release")]
        public async Task<ActionResult<string>> PEXBCCoveringLetterReleaseReq([FromBody] PEXBCCoveringLetterReleaseReq pexbcRelease)
        {
            DynamicParameters param = new();
            param.Add("@CenterID", pexbcRelease.CenterID);
            param.Add("@EXPORT_BC_NO", pexbcRelease.EXPORT_BC_NO);
            param.Add("@EVENT_NO", pexbcRelease.EVENT_NO);
            param.Add("@USER_ID", pexbcRelease.USER_ID);

            //---------------- pExDoc --------------------
            var dtExDoc = new DataTable();
            dtExDoc.Columns.Add("EXLC_NO", typeof(string));
            dtExDoc.Columns.Add("SEQNO", typeof(int));
            dtExDoc.Columns.Add("EVENT_NO", typeof(int));
            dtExDoc.Columns.Add("DOCUMENT_ID", typeof(string));
            dtExDoc.Columns.Add("DOCUMENT_NAME", typeof(string));
            dtExDoc.Columns.Add("FMail_No", typeof(string));
            dtExDoc.Columns.Add("SMail_No", typeof(string));
            dtExDoc.Columns.Add("MODULE_TYPE", typeof(string));
            dtExDoc.Columns.Add("EVENT_DATE", typeof(string));
            dtExDoc.Columns.Add("CenterID", typeof(string));

            if (pexbcRelease.PEXDOC != null)
            {
                for (int i = 0; i < pexbcRelease.PEXDOC.Length; i++)
                {
                    dtExDoc.Rows.Add(
                          pexbcRelease.PEXDOC[i].EXLC_NO
                        , pexbcRelease.PEXDOC[i].SEQNO
                        , pexbcRelease.PEXDOC[i].EVENT_NO
                        , pexbcRelease.PEXDOC[i].DOCUMENT_ID
                        , pexbcRelease.PEXDOC[i].DOCUMENT_NAME
                        , pexbcRelease.PEXDOC[i].FMail_No
                        , pexbcRelease.PEXDOC[i].SMail_No
                        , pexbcRelease.PEXDOC[i].MODULE_TYPE
                        , pexbcRelease.PEXDOC[i].EVENT_DATE
                        , pexbcRelease.PEXDOC[i].CenterID
                        );
                }
            }
            param.Add("@EXDOC", dtExDoc.AsTableValuedParameter("Type_pExDoc"));

            //param.Add("@Resp", dbType: DbType.Int32,
            param.Add("@Resp", dbType: DbType.String,
                direction: System.Data.ParameterDirection.Output,
                size: 5215585);
            try
            {
                await _db.SaveData(
                  storedProcedure: "usp_pEXBC_CoveringLetter_Release", param);
                //var resp = param.Get<int>("@Resp");
                var resp = param.Get<string>("@Resp");
                if (Int16.Parse(resp) > 0)
                {

                    ReturnResponse response = new();
                    response.StatusCode = "200";
                    response.Message = "Export B/C NO Release Complete";
                    return Ok(response);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = "Export BC No Not Exist";
                    //response.Message = resp.ToString();
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }








    }
}
