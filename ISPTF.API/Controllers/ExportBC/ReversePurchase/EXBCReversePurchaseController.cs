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
 
namespace ISPTF.API.Controllers.ExportBC
{
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
        public async Task<IEnumerable<Q_EXBCReversePurchaseListPageRsp>> GetAllList(string? @ListType, string? CenterID, string? EXPORT_BC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
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

            var results = await _db.LoadData<Q_EXBCReversePurchaseListPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXBC_ReversePurchaseListPage",
                        param);
            return results;
        }

        [HttpGet("query")]
        public async Task<IEnumerable<Q_EXBCReversePurchaseQueryPageRsp>> GetAllQuery( string? CenterID, string? EXPORT_BC_NO, string? BENName, string? USER_ID, string? Page, string? PageSize)
        {
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

            var results = await _db.LoadData<Q_EXBCReversePurchaseQueryPageRsp, dynamic>(
                        storedProcedure: "usp_q_EXBC_ReversePurchaseQueryPage",
                        param);
            return results;
        }


        [HttpGet("select")]
        public async Task<IEnumerable<PEXBCRsp>> GetAllSelect(string? EXPORT_BC_NO, string? EVENT_NO, string? LFROM)
        //          public async Task<ActionResult<List<PEXBCjsonRsp>>> GetAllSelect(string? EXPORT_BC_NO, string? EVENT_NO, string? LFROM)
        {
            DynamicParameters param = new();

            param.Add("@EXPORT_BC_NO", EXPORT_BC_NO);
            param.Add("@EVENT_NO", EVENT_NO);
            param.Add("@LFROM", LFROM);

            var results = await _db.LoadData<PEXBCRsp, dynamic>(
                        storedProcedure: "usp_pEXBC_ReversePurchase_Select",
                        param);
            return results;
        }

        [HttpPost("save")]
        public async Task<ActionResult<List<PEXBCRsp>>> Insert([FromBody] PEXBCRsp pexbcsave)
        {
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

            string SIGHT_BASIS = "0";
            if (pexbcsave.SIGHT_BASIS == true)
            {
                SIGHT_BASIS = "1";
            }
            string ART44A = "0";
            if (pexbcsave.ART44A == true)
            {
                ART44A = "1";
            }
            string ENDORSED = "0";
            if (pexbcsave.ENDORSED == true)
            {
                ENDORSED = "1";
            }
            string MT750 = "0";
            if (pexbcsave.MT750 == true)
            {
                MT750 = "1";
            }
            param.Add("@SIGHT_BASIS", SIGHT_BASIS);
            param.Add("@ART44A", ART44A);
            param.Add("@ENDORSED", ENDORSED);
            param.Add("@MT750", MT750);

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
            try
            {
                var results = await _db.LoadData<PEXBCRsp, dynamic>(
                            storedProcedure: "usp_pEXBC_ReversePurchase_Save",
                            param);

                var resp = param.Get<string>("@Resp");
                if (resp == "1")
                {
                    return Ok(results);
                }
                else
                {

                    ReturnResponse response = new();
                    response.StatusCode = "400";
                    response.Message = resp.ToString();
                    //response.Message = "EXPORT B/C NO does not exit";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        ////        [HttpPost("save")]
        ////        public async Task<ActionResult<List<PEXBCPEXPaymentRsp>>> Insert([FromBody] PEXBCPEXPaymentSaveReq pexbcsave)
        ////        {
        ////            DynamicParameters param = new DynamicParameters();
        //////pExBc
        ////            param.Add("@RECORD_TYPE", pexbcsave.PEXBC.RECORD_TYPE);
        ////            param.Add("@REC_STATUS", pexbcsave.PEXBC.REC_STATUS);
        ////            param.Add("@EVENT_NO", pexbcsave.PEXBC.EVENT_NO);
        ////            param.Add("@EXPORT_BC_NO", pexbcsave.PEXBC.EXPORT_BC_NO);
        ////            param.Add("@EVENT_MODE", pexbcsave.PEXBC.EVENT_MODE);
        ////            param.Add("@BUSINESS_TYPE", pexbcsave.PEXBC.BUSINESS_TYPE);
        ////            param.Add("@EVENT_TYPE", pexbcsave.PEXBC.EVENT_TYPE);
        ////            param.Add("@EVENT_DATE", pexbcsave.PEXBC.EVENT_DATE);
        ////            param.Add("@TENOR_OF_COLL", pexbcsave.PEXBC.TENOR_OF_COLL);
        ////            param.Add("@TENOR_TYPE", pexbcsave.PEXBC.TENOR_TYPE);
        ////            param.Add("@INVOICE", pexbcsave.PEXBC.INVOICE);
        ////            param.Add("@REFER_BC_NO", pexbcsave.PEXBC.REFER_BC_NO);
        ////            param.Add("@RELETE_PACK", pexbcsave.PEXBC.RELETE_PACK);
        ////            param.Add("@DRAFT_CCY", pexbcsave.PEXBC.DRAFT_CCY);
        ////            param.Add("@DRAFT_AMT", pexbcsave.PEXBC.DRAFT_AMT);
        ////            param.Add("@SIGHT_AMT", pexbcsave.PEXBC.SIGHT_AMT);
        ////            param.Add("@TERM_AMT", pexbcsave.PEXBC.TERM_AMT);
        ////            param.Add("@GOOD_CODE", pexbcsave.PEXBC.GOOD_CODE);
        ////            param.Add("@REL_CODE", pexbcsave.PEXBC.REL_CODE);
        ////            param.Add("@CLAIM_TYPE", pexbcsave.PEXBC.CLAIM_TYPE);
        ////            param.Add("@SIGHT_START_DATE", pexbcsave.PEXBC.SIGHT_START_DATE);
        ////            param.Add("@SIGHT_DUE_DATE", pexbcsave.PEXBC.SIGHT_DUE_DATE);
        ////            param.Add("@TENOR_DAY", pexbcsave.PEXBC.TENOR_DAY);
        ////            param.Add("@TENOR_DAY_DESC", pexbcsave.PEXBC.TENOR_DAY_DESC);
        ////            param.Add("@TERM_START_DATE", pexbcsave.PEXBC.TERM_START_DATE);
        ////            param.Add("@TERM_DUE_DATE", pexbcsave.PEXBC.TERM_DUE_DATE);
        ////            param.Add("@PURCH_DISC_DATE", pexbcsave.PEXBC.PURCH_DISC_DATE);
        ////            param.Add("@DRAWEE_INFO", pexbcsave.PEXBC.DRAWEE_INFO);
        ////            param.Add("@CNTY_CODE", pexbcsave.PEXBC.CNTY_CODE);
        ////            param.Add("@Cust_AO", pexbcsave.PEXBC.Cust_AO);
        ////            param.Add("@Cust_LO", pexbcsave.PEXBC.Cust_LO);
        ////            param.Add("@BENE_ID", pexbcsave.PEXBC.BENE_ID);
        ////            param.Add("@BENE_INFO", pexbcsave.PEXBC.BENE_INFO);
        ////            param.Add("@ISSUE_BANK_ID", pexbcsave.PEXBC.ISSUE_BANK_ID);
        ////            param.Add("@ISSUE_BANK_INFO", pexbcsave.PEXBC.ISSUE_BANK_INFO);
        ////            param.Add("@COLLECT_AGENT", pexbcsave.PEXBC.COLLECT_AGENT);
        ////            param.Add("@AGENT_BANK_ID", pexbcsave.PEXBC.AGENT_BANK_ID);
        ////            param.Add("@AGENT_BANK_INFO", pexbcsave.PEXBC.AGENT_BANK_INFO);
        ////            param.Add("@AGENT_BANK_REF", pexbcsave.PEXBC.AGENT_BANK_REF);
        ////            param.Add("@AGENT_BANK_NOSTRO", pexbcsave.PEXBC.AGENT_BANK_NOSTRO);
        ////            param.Add("@RESTRICT", pexbcsave.PEXBC.RESTRICT);
        ////            param.Add("@RESTRICT_TO_BK_NAME", pexbcsave.PEXBC.RESTRICT_TO_BK_NAME);
        ////            param.Add("@RESTRICT_TO_BK_ADDR1", pexbcsave.PEXBC.RESTRICT_TO_BK_ADDR1);
        ////            param.Add("@RESTRICT_TO_BK_ADDR2", pexbcsave.PEXBC.RESTRICT_TO_BK_ADDR2);
        ////            param.Add("@RESTRICT_TO_BK_ADDR3", pexbcsave.PEXBC.RESTRICT_TO_BK_ADDR3);
        ////            param.Add("@RESTRICT_REFER", pexbcsave.PEXBC.RESTRICT_REFER);
        ////            param.Add("@RESTRICT_FR_BK_NAME", pexbcsave.PEXBC.RESTRICT_FR_BK_NAME);
        ////            param.Add("@RESTRICT_FR_BK_ADDR1", pexbcsave.PEXBC.RESTRICT_FR_BK_ADDR1);
        ////            param.Add("@RESTRICT_FR_BK_ADDR2", pexbcsave.PEXBC.RESTRICT_FR_BK_ADDR2);
        ////            param.Add("@RESTRICT_FR_BK_ADDR3", pexbcsave.PEXBC.RESTRICT_FR_BK_ADDR3);
        ////            param.Add("@PARTIAL_FULL_RATE", pexbcsave.PEXBC.PARTIAL_FULL_RATE);
        ////            param.Add("@INT_RATE_METHOD", pexbcsave.PEXBC.INT_RATE_METHOD);
        ////            param.Add("@TYPE_OF_ACCOUNT", pexbcsave.PEXBC.TYPE_OF_ACCOUNT);
        ////            param.Add("@CREDIT_CURRENCY", pexbcsave.PEXBC.CREDIT_CURRENCY);
        ////            param.Add("@DISCOUNT_DAY", pexbcsave.PEXBC.DISCOUNT_DAY);
        ////            param.Add("@GRACE_PERIOD", pexbcsave.PEXBC.GRACE_PERIOD);
        ////            param.Add("@DISC_BASE_DAY", pexbcsave.PEXBC.DISC_BASE_DAY);
        ////            param.Add("@BASE_DAY", pexbcsave.PEXBC.BASE_DAY);
        ////            param.Add("@DISCOUNT_RATE", pexbcsave.PEXBC.DISCOUNT_RATE);
        ////            param.Add("@INT_BASE_RATE", pexbcsave.PEXBC.INT_BASE_RATE);
        ////            param.Add("@INT_SPREAD_RATE", pexbcsave.PEXBC.INT_SPREAD_RATE);
        ////            param.Add("@CURRENT_DIS_RATE", pexbcsave.PEXBC.CURRENT_DIS_RATE);
        ////            param.Add("@CURRENT_INT_RATE", pexbcsave.PEXBC.CURRENT_INT_RATE);
        ////            param.Add("@PAY_BY", pexbcsave.PEXBC.PAY_BY);
        ////            param.Add("@NEGO_AMT", pexbcsave.PEXBC.NEGO_AMT);
        ////            param.Add("@LESS_AGENT", pexbcsave.PEXBC.LESS_AGENT);
        ////            param.Add("@PURCHASE_AMT", pexbcsave.PEXBC.PURCHASE_AMT);
        ////            param.Add("@PURCHASE_RATE", pexbcsave.PEXBC.PURCHASE_RATE);
        ////            param.Add("@TOTAL_NEGO_BALANCE", pexbcsave.PEXBC.TOTAL_NEGO_BALANCE);
        ////            param.Add("@TOTAL_NEGO_BAL_THB", pexbcsave.PEXBC.TOTAL_NEGO_BAL_THB);
        ////            param.Add("@TOT_NEGO_AMT", pexbcsave.PEXBC.TOT_NEGO_AMT);
        ////            param.Add("@TOT_NEGO_AMOUNT", pexbcsave.PEXBC.TOT_NEGO_AMOUNT);
        ////            param.Add("@BANK_CHARGE_AMT", pexbcsave.PEXBC.BANK_CHARGE_AMT);
        ////            param.Add("@NET_PROCEED_CLAIM", pexbcsave.PEXBC.NET_PROCEED_CLAIM);
        ////            param.Add("@CLAIM_PAY_BY", pexbcsave.PEXBC.CLAIM_PAY_BY);
        ////            param.Add("@ParTnor_Type1", pexbcsave.PEXBC.ParTnor_Type1);
        ////            param.Add("@ParTnor_Type2", pexbcsave.PEXBC.ParTnor_Type2);
        ////            param.Add("@ParTnor_Type3", pexbcsave.PEXBC.ParTnor_Type3);
        ////            param.Add("@ParTnor_Type4", pexbcsave.PEXBC.ParTnor_Type4);
        ////            param.Add("@ParTnor_Type5", pexbcsave.PEXBC.ParTnor_Type5);
        ////            param.Add("@ParTnor_Type6", pexbcsave.PEXBC.ParTnor_Type6);
        ////            param.Add("@PARTIAL_AMT1", pexbcsave.PEXBC.PARTIAL_AMT1);
        ////            param.Add("@PARTIAL_AMT2", pexbcsave.PEXBC.PARTIAL_AMT2);
        ////            param.Add("@PARTIAL_AMT3", pexbcsave.PEXBC.PARTIAL_AMT3);
        ////            param.Add("@PARTIAL_AMT4", pexbcsave.PEXBC.PARTIAL_AMT4);
        ////            param.Add("@PARTIAL_AMT5", pexbcsave.PEXBC.PARTIAL_AMT5);
        ////            param.Add("@PARTIAL_AMT6", pexbcsave.PEXBC.PARTIAL_AMT6);
        ////            param.Add("@PARTIAL_RATE1", pexbcsave.PEXBC.PARTIAL_RATE1);
        ////            param.Add("@PARTIAL_RATE2", pexbcsave.PEXBC.PARTIAL_RATE2);
        ////            param.Add("@PARTIAL_RATE3", pexbcsave.PEXBC.PARTIAL_RATE3);
        ////            param.Add("@PARTIAL_RATE4", pexbcsave.PEXBC.PARTIAL_RATE4);
        ////            param.Add("@PARTIAL_RATE5", pexbcsave.PEXBC.PARTIAL_RATE5);
        ////            param.Add("@PARTIAL_RATE6", pexbcsave.PEXBC.PARTIAL_RATE6);
        ////            param.Add("@PARTIAL_AMT1_THB", pexbcsave.PEXBC.PARTIAL_AMT1_THB);
        ////            param.Add("@PARTIAL_AMT2_THB", pexbcsave.PEXBC.PARTIAL_AMT2_THB);
        ////            param.Add("@PARTIAL_AMT3_THB", pexbcsave.PEXBC.PARTIAL_AMT3_THB);
        ////            param.Add("@PARTIAL_AMT4_THB", pexbcsave.PEXBC.PARTIAL_AMT4_THB);
        ////            param.Add("@PARTIAL_AMT5_THB", pexbcsave.PEXBC.PARTIAL_AMT5_THB);
        ////            param.Add("@PARTIAL_AMT6_THB", pexbcsave.PEXBC.PARTIAL_AMT6_THB);
        ////            param.Add("@FORWARD_CONRACT_NO", pexbcsave.PEXBC.FORWARD_CONRACT_NO);
        ////            param.Add("@FORWARD_CONRACT_NO1", pexbcsave.PEXBC.FORWARD_CONRACT_NO1);
        ////            param.Add("@FORWARD_CONRACT_NO2", pexbcsave.PEXBC.FORWARD_CONRACT_NO2);
        ////            param.Add("@FORWARD_CONRACT_NO3", pexbcsave.PEXBC.FORWARD_CONRACT_NO3);
        ////            param.Add("@FORWARD_CONRACT_NO4", pexbcsave.PEXBC.FORWARD_CONRACT_NO4);
        ////            param.Add("@FORWARD_CONRACT_NO5", pexbcsave.PEXBC.FORWARD_CONRACT_NO5);
        ////            param.Add("@FORWARD_CONRACT_NO6", pexbcsave.PEXBC.FORWARD_CONRACT_NO6);
        ////            param.Add("@NEGO_COMM", pexbcsave.PEXBC.NEGO_COMM);
        ////            param.Add("@TELEX_SWIFT", pexbcsave.PEXBC.TELEX_SWIFT);
        ////            param.Add("@COURIER_POSTAGE", pexbcsave.PEXBC.COURIER_POSTAGE);
        ////            param.Add("@STAMP_FEE", pexbcsave.PEXBC.STAMP_FEE);
        ////            param.Add("@BE_STAMP", pexbcsave.PEXBC.BE_STAMP);
        ////            param.Add("@COMM_OTHER", pexbcsave.PEXBC.COMM_OTHER);
        ////            param.Add("@HANDING_FEE", pexbcsave.PEXBC.HANDING_FEE);
        ////            param.Add("@DRAFTCOMM", pexbcsave.PEXBC.DRAFTCOMM);
        ////            param.Add("@INT_AMT_THB", pexbcsave.PEXBC.INT_AMT_THB);
        ////            param.Add("@COMMONTT", pexbcsave.PEXBC.COMMONTT);
        ////            param.Add("@TOTAL_CHARGE", pexbcsave.PEXBC.TOTAL_CHARGE);
        ////            param.Add("@REFUND_TAX_YN", pexbcsave.PEXBC.REFUND_TAX_YN);
        ////            param.Add("@REFUND_TAX_AMT", pexbcsave.PEXBC.REFUND_TAX_AMT);
        ////            param.Add("@DISCOUNT_CCY", pexbcsave.PEXBC.DISCOUNT_CCY);
        ////            param.Add("@DISCRATE", pexbcsave.PEXBC.DISCRATE);
        ////            param.Add("@DISCOUNT_AMT", pexbcsave.PEXBC.DISCOUNT_AMT);
        ////            param.Add("@TOTAL_AMOUNT", pexbcsave.PEXBC.TOTAL_AMOUNT);
        ////            param.Add("@PAYMENT_INSTRU", pexbcsave.PEXBC.PAYMENT_INSTRU);
        ////            param.Add("@METHOD", pexbcsave.PEXBC.METHOD);
        ////            param.Add("@ACBAHTNET", pexbcsave.PEXBC.ACBAHTNET);
        ////            param.Add("@BAHTNET", pexbcsave.PEXBC.BAHTNET);
        ////            param.Add("@RECEIVED_NO", pexbcsave.PEXBC.RECEIVED_NO);
        ////            param.Add("@ALLOCATION", pexbcsave.PEXBC.ALLOCATION);
        ////            param.Add("@NARRATIVE", pexbcsave.PEXBC.NARRATIVE);
        ////            param.Add("@SEQ_ACCEPT_DUE", pexbcsave.PEXBC.SEQ_ACCEPT_DUE);
        ////            param.Add("@COMFIRM_DUE", pexbcsave.PEXBC.COMFIRM_DUE);
        ////            param.Add("@PLUS_MINUS_DISC", pexbcsave.PEXBC.PLUS_MINUS_DISC);
        ////            param.Add("@DISC_DAYS_PLUS_MINUS", pexbcsave.PEXBC.DISC_DAYS_PLUS_MINUS);
        ////            param.Add("@RECEIVE_PAY_AMT", pexbcsave.PEXBC.RECEIVE_PAY_AMT);
        ////            param.Add("@EXCHANGE_RATE", pexbcsave.PEXBC.EXCHANGE_RATE);
        ////            param.Add("@REFUND_DISC_RECEIVE", pexbcsave.PEXBC.REFUND_DISC_RECEIVE);
        ////            param.Add("@DISC_RECEIVE", pexbcsave.PEXBC.DISC_RECEIVE);
        ////            param.Add("@LC_DATE", pexbcsave.PEXBC.LC_DATE);
        ////            param.Add("@COVERING_DATE", pexbcsave.PEXBC.COVERING_DATE);
        ////            param.Add("@COVERING_FOR", pexbcsave.PEXBC.COVERING_FOR);
        ////            param.Add("@ADVICE_ISSUE_BANK", pexbcsave.PEXBC.ADVICE_ISSUE_BANK);
        ////            param.Add("@ADVICE_FORMAT", pexbcsave.PEXBC.ADVICE_FORMAT);
        ////            param.Add("@REMIT_CLAIM_TYPE", pexbcsave.PEXBC.REMIT_CLAIM_TYPE);
        ////            param.Add("@REIMBURSE_BANK_ID", pexbcsave.PEXBC.REIMBURSE_BANK_ID);
        ////            param.Add("@REIMBURSE_BANK_INFO", pexbcsave.PEXBC.REIMBURSE_BANK_INFO);
        ////            param.Add("@SWIFT_BANK", pexbcsave.PEXBC.SWIFT_BANK);
        ////            param.Add("@SWIFT_MAIL", pexbcsave.PEXBC.SWIFT_MAIL);
        ////            param.Add("@CLAIM_FORMAT", pexbcsave.PEXBC.CLAIM_FORMAT);
        ////            param.Add("@VALUE_DATE", pexbcsave.PEXBC.VALUE_DATE);
        ////            param.Add("@THIRD_BANK_ID", pexbcsave.PEXBC.THIRD_BANK_ID);
        ////            param.Add("@THIRD_BANK_INFO", pexbcsave.PEXBC.THIRD_BANK_INFO);
        ////            param.Add("@DISCREPANCY_TYPE", pexbcsave.PEXBC.DISCREPANCY_TYPE);
        ////            param.Add("@SWIFT_DISC", pexbcsave.PEXBC.SWIFT_DISC);
        ////            param.Add("@DOCUMENT_COPY", pexbcsave.PEXBC.DOCUMENT_COPY);
        ////            param.Add("@SIGHT_BASIS", pexbcsave.PEXBC.SIGHT_BASIS);
        ////            param.Add("@ART44A", pexbcsave.PEXBC.ART44A);
        ////            param.Add("@ENDORSED", pexbcsave.PEXBC.ENDORSED);
        ////            param.Add("@MT750", pexbcsave.PEXBC.MT750);
        ////            param.Add("@ADJ_TOT_NEGO_AMOUNT", pexbcsave.PEXBC.ADJ_TOT_NEGO_AMOUNT);
        ////            param.Add("@ADJ_LESS_CHARGE_AMT", pexbcsave.PEXBC.ADJ_LESS_CHARGE_AMT);
        ////            param.Add("@ADJUST_COVERING_AMT", pexbcsave.PEXBC.ADJUST_COVERING_AMT);
        ////            param.Add("@ADJUST_TENOR", pexbcsave.PEXBC.ADJUST_TENOR);
        ////            param.Add("@ADJUST_LC_REF", pexbcsave.PEXBC.ADJUST_LC_REF);
        ////            param.Add("@PAYMENT_INSTRC", pexbcsave.PEXBC.PAYMENT_INSTRC);
        ////            param.Add("@TXTDOCUMENT", pexbcsave.PEXBC.TXTDOCUMENT);
        ////            param.Add("@CHARGE_ACC", pexbcsave.PEXBC.CHARGE_ACC);
        ////            param.Add("@DRAFT", pexbcsave.PEXBC.DRAFT);
        ////            param.Add("@MT202", pexbcsave.PEXBC.MT202);
        ////            param.Add("@FB_CURRENCY", pexbcsave.PEXBC.FB_CURRENCY);
        ////            param.Add("@FB_AMT", pexbcsave.PEXBC.FB_AMT);
        ////            param.Add("@FB_RATE", pexbcsave.PEXBC.FB_RATE);
        ////            param.Add("@FB_AMT_THB", pexbcsave.PEXBC.FB_AMT_THB);
        ////            param.Add("@COLLECT_REFUND", pexbcsave.PEXBC.COLLECT_REFUND);
        ////            param.Add("@USER_ID", pexbcsave.PEXBC.USER_ID);
        ////            param.Add("@IN_USE", pexbcsave.PEXBC.IN_USE);
        ////            param.Add("@AUTH_CODE", pexbcsave.PEXBC.AUTH_CODE);
        ////            param.Add("@GENACC_FLAG", pexbcsave.PEXBC.GENACC_FLAG);
        ////            param.Add("@VOUCH_ID", pexbcsave.PEXBC.VOUCH_ID);
        ////            param.Add("@APPVNO", pexbcsave.PEXBC.APPVNO);
        ////            param.Add("@FACNO", pexbcsave.PEXBC.FACNO);
        ////            param.Add("@AUTOOVERDUE", pexbcsave.PEXBC.AUTOOVERDUE);
        ////            param.Add("@LCOVERDUE", pexbcsave.PEXBC.LCOVERDUE);
        ////            param.Add("@OVESEQNO", pexbcsave.PEXBC.OVESEQNO);
        ////            param.Add("@INTFLAG", pexbcsave.PEXBC.INTFLAG);
        ////            param.Add("@IntRateCode", pexbcsave.PEXBC.IntRateCode);
        ////            param.Add("@CFRRate", pexbcsave.PEXBC.CFRRate);
        ////            param.Add("@INTCODE", pexbcsave.PEXBC.INTCODE);
        ////            param.Add("@OINTRATE", pexbcsave.PEXBC.OINTRATE);
        ////            param.Add("@OINTSPDRATE", pexbcsave.PEXBC.OINTSPDRATE);
        ////            param.Add("@OINTCURRATE", pexbcsave.PEXBC.OINTCURRATE);
        ////            param.Add("@OINTDAY", pexbcsave.PEXBC.OINTDAY);
        ////            param.Add("@OBASEDAY", pexbcsave.PEXBC.OBASEDAY);
        ////            param.Add("@BFINTAMT", pexbcsave.PEXBC.BFINTAMT);
        ////            param.Add("@SELLING_RATE", pexbcsave.PEXBC.SELLING_RATE);
        ////            param.Add("@BFINTTHB", pexbcsave.PEXBC.BFINTTHB);
        ////            param.Add("@INTBALANCE", pexbcsave.PEXBC.INTBALANCE);
        ////            param.Add("@PRNBALANCE", pexbcsave.PEXBC.PRNBALANCE);
        ////            param.Add("@LASTINTAMT", pexbcsave.PEXBC.LASTINTAMT);
        ////            param.Add("@DMS", pexbcsave.PEXBC.DMS);
        ////            param.Add("@LASTINTDATE", pexbcsave.PEXBC.LASTINTDATE);
        ////            param.Add("@PAYMENTTYPE", pexbcsave.PEXBC.PAYMENTTYPE);
        ////            param.Add("@CONFIRM_DATE", pexbcsave.PEXBC.CONFIRM_DATE);
        ////            param.Add("@TOTALACCRUAMT", pexbcsave.PEXBC.TOTALACCRUAMT);
        ////            param.Add("@TOTALACCRUBHT", pexbcsave.PEXBC.TOTALACCRUBHT);
        ////            param.Add("@ACCRUAMT", pexbcsave.PEXBC.ACCRUAMT);
        ////            param.Add("@ACCRUBHT", pexbcsave.PEXBC.ACCRUBHT);
        ////            param.Add("@DATELASTACCRU", pexbcsave.PEXBC.DATELASTACCRU);
        ////            param.Add("@PASTDUEDATE", pexbcsave.PEXBC.PASTDUEDATE);
        ////            param.Add("@PASTDUEFLAG", pexbcsave.PEXBC.PASTDUEFLAG);
        ////            param.Add("@TOTALSUSPAMT", pexbcsave.PEXBC.TOTALSUSPAMT);
        ////            param.Add("@TOTALSUSPBHT", pexbcsave.PEXBC.TOTALSUSPBHT);
        ////            param.Add("@SUSPAMT", pexbcsave.PEXBC.SUSPAMT);
        ////            param.Add("@SUSPBHT", pexbcsave.PEXBC.SUSPBHT);
        ////            param.Add("@CenterID", pexbcsave.PEXBC.CenterID);
        ////            param.Add("@BCPastDue", pexbcsave.PEXBC.BCPastDue);
        ////            param.Add("@DateStartAccru", pexbcsave.PEXBC.DateStartAccru);
        ////            param.Add("@DateToStop", pexbcsave.PEXBC.DateToStop);
        ////            param.Add("@ValueDate", pexbcsave.PEXBC.ValueDate);
        ////            param.Add("@FlagBack", pexbcsave.PEXBC.FlagBack);
        ////            param.Add("@NewAccruCcy", pexbcsave.PEXBC.NewAccruCcy);
        ////            param.Add("@NewAccruAmt", pexbcsave.PEXBC.NewAccruAmt);
        ////            param.Add("@AccruPending", pexbcsave.PEXBC.AccruPending);
        ////            param.Add("@LastAccruCcy", pexbcsave.PEXBC.LastAccruCcy);
        ////            param.Add("@LastAccruAmt", pexbcsave.PEXBC.LastAccruAmt);
        ////            param.Add("@DAccruAmt", pexbcsave.PEXBC.DAccruAmt);
        ////            param.Add("@CCS_ACCT", pexbcsave.PEXBC.CCS_ACCT);
        ////            param.Add("@CCS_LmType", pexbcsave.PEXBC.CCS_LmType);
        ////            param.Add("@CCS_CNUM", pexbcsave.PEXBC.CCS_CNUM);
        ////            param.Add("@CCS_CIFRef", pexbcsave.PEXBC.CCS_CIFRef);
        ////            param.Add("@ObjectType", pexbcsave.PEXBC.ObjectType);
        ////            param.Add("@UnderlyName", pexbcsave.PEXBC.UnderlyName);
        ////            param.Add("@BPOFlag", pexbcsave.PEXBC.BPOFlag);
        ////            param.Add("@Campaign_Code", pexbcsave.PEXBC.Campaign_Code);
        ////            param.Add("@Campaign_EffDate", pexbcsave.PEXBC.Campaign_EffDate);
        ////            param.Add("@PurposeCode", pexbcsave.PEXBC.PurposeCode);
        //////pExPayment
        ////            param.Add("@DOCNUMBER", pexbcsave.PEXPayment.DOCNUMBER);
        ////            param.Add("@PAY_TYPE", pexbcsave.PEXPayment.PAY_TYPE);
        ////            param.Add("@PAYMENT_DATE", pexbcsave.PEXPayment.PAYMENT_DATE);
        ////            param.Add("@AGENT_PAY_BY", pexbcsave.PEXPayment.AGENT_PAY_BY);
        ////            param.Add("@SETTLEMENT_CREDIT", pexbcsave.PEXPayment.SETTLEMENT_CREDIT);
        ////            param.Add("@MTFLAG", pexbcsave.PEXPayment.MTFLAG);
        ////            param.Add("@SIGHT_PAID_AMT", pexbcsave.PEXPayment.SIGHT_PAID_AMT);
        ////            param.Add("@SIGHT_PAID_RATE", pexbcsave.PEXPayment.SIGHT_PAID_RATE);
        ////            param.Add("@SIGHT_PAID_THB", pexbcsave.PEXPayment.SIGHT_PAID_THB);
        ////            param.Add("@SIGHT_FORWARD", pexbcsave.PEXPayment.SIGHT_FORWARD);
        ////            param.Add("@TERM_PAID_AMT", pexbcsave.PEXPayment.TERM_PAID_AMT);
        ////            param.Add("@TERM_PAID_RATE", pexbcsave.PEXPayment.TERM_PAID_RATE);
        ////            param.Add("@TERM_PAID_THB", pexbcsave.PEXPayment.TERM_PAID_THB);
        ////            param.Add("@TERM_FORWARD", pexbcsave.PEXPayment.TERM_FORWARD);
        ////            param.Add("@TOT_PRINC_PAID", pexbcsave.PEXPayment.TOT_PRINC_PAID);
        ////            param.Add("@Com_Lieu", pexbcsave.PEXPayment.Com_Lieu);
        ////            param.Add("@ComLieuRate", pexbcsave.PEXPayment.ComLieuRate);
        ////            param.Add("@fb_ccy", pexbcsave.PEXPayment.fb_ccy);
        ////            param.Add("@Agent_amt", pexbcsave.PEXPayment.Agent_amt);
        ////            param.Add("@Agent_rate", pexbcsave.PEXPayment.Agent_rate);
        ////            param.Add("@Agent_thb", pexbcsave.PEXPayment.Agent_thb);
        ////            param.Add("@over_paid_amt", pexbcsave.PEXPayment.over_paid_amt);
        ////            param.Add("@over_paid_rate", pexbcsave.PEXPayment.over_paid_rate);
        ////            param.Add("@over_paid_thb", pexbcsave.PEXPayment.over_paid_thb);
        ////            param.Add("@int_day", pexbcsave.PEXPayment.int_day);
        ////            param.Add("@int_paid_amt", pexbcsave.PEXPayment.int_paid_amt);
        ////            param.Add("@int_paid_rate", pexbcsave.PEXPayment.int_paid_rate);
        ////            param.Add("@int_exch_rate", pexbcsave.PEXPayment.int_exch_rate);
        ////            param.Add("@int_paid_thb", pexbcsave.PEXPayment.int_paid_thb);
        ////            param.Add("@prn_paid_thb", pexbcsave.PEXPayment.prn_paid_thb);
        ////            param.Add("@Charge_Ccy", pexbcsave.PEXPayment.Charge_Ccy);
        ////            param.Add("@Charge_Rate", pexbcsave.PEXPayment.Charge_Rate);
        ////            param.Add("@Charge_Thb", pexbcsave.PEXPayment.Charge_Thb);
        ////            param.Add("@TOTAL_DUE_TO_CUS", pexbcsave.PEXPayment.TOTAL_DUE_TO_CUS);
        ////            param.Add("@FcdAmt", pexbcsave.PEXPayment.FcdAmt);
        ////            param.Add("@FcdAcc", pexbcsave.PEXPayment.FcdAcc);
        ////            param.Add("@MTAmt", pexbcsave.PEXPayment.MTAmt);
        ////            param.Add("@Debit_credit_flag", pexbcsave.PEXPayment.Debit_credit_flag);
        ////            param.Add("@ACCOUNT_NO1", pexbcsave.PEXPayment.ACCOUNT_NO1);
        ////            param.Add("@ACCOUNT_NO2", pexbcsave.PEXPayment.ACCOUNT_NO2);
        ////            param.Add("@ACCOUNT_NO3", pexbcsave.PEXPayment.ACCOUNT_NO3);
        ////            param.Add("@AMT_DEBIT_AC1", pexbcsave.PEXPayment.AMT_DEBIT_AC1);
        ////            param.Add("@AMT_DEBIT_AC2", pexbcsave.PEXPayment.AMT_DEBIT_AC2);
        ////            param.Add("@AMT_DEBIT_AC3", pexbcsave.PEXPayment.AMT_DEBIT_AC3);
        ////            param.Add("@AMT_CREDIT_AC1", pexbcsave.PEXPayment.AMT_CREDIT_AC1);
        ////            param.Add("@AMT_CREDIT_AC2", pexbcsave.PEXPayment.AMT_CREDIT_AC2);
        ////            param.Add("@AMT_CREDIT_AC3", pexbcsave.PEXPayment.AMT_CREDIT_AC3);
        ////            param.Add("@CASH", pexbcsave.PEXPayment.CASH);
        ////            param.Add("@CHEQUE_AMT", pexbcsave.PEXPayment.CHEQUE_AMT);
        ////            param.Add("@CHEQUE_NO", pexbcsave.PEXPayment.CHEQUE_NO);
        ////            param.Add("@CHEQUE_BK_BRN", pexbcsave.PEXPayment.CHEQUE_BK_BRN);

        ////            param.Add("@PExBcRsp", dbType: DbType.Int32,
        ////                       direction: System.Data.ParameterDirection.Output,
        ////                       size: 12800);

        ////            param.Add("@PEXBCPEXPaymentRsp", dbType: DbType.String,
        ////                       direction: System.Data.ParameterDirection.Output,
        ////                       size: 5215585);

        ////            //param.Add("@Resp", dbType: DbType.Int32,
        ////            param.Add("@Resp", dbType: DbType.String,
        ////               direction: System.Data.ParameterDirection.Output,
        ////               size: 5215585);
        ////            try
        ////            {
        ////                var results = await _db.LoadData<PEXBCPEXPaymentRsp, dynamic>(
        ////                            storedProcedure: "usp_pEXBCPurchasePaymentSave",
        ////                            param);

        ////                var PExBcRsp = param.Get<dynamic>("@PExBcRsp");
        ////                var pexbcpexpaymentrsp = param.Get<dynamic>("@PEXBCPEXPaymentRsp");

        ////                //var resp = param.Get<int>("@Resp");
        ////                var resp = param.Get<string>("@Resp");
        ////                if (PExBcRsp == 1)
        ////                {
        ////                    return Ok(pexbcpexpaymentrsp);
        ////                }
        ////                else
        ////                {

        ////                    ReturnResponse response = new();
        ////                    response.StatusCode = "400";
        ////                    //response.Message = resp.ToString(); //= "EXPORT_BC_NO Insert Error";
        ////                    response.Message = "EXPORT B/C NO does not exit";
        ////                    return BadRequest(response);
        ////                }
        ////            }
        ////            catch (Exception ex)
        ////            {
        ////                return BadRequest(ex.Message);
        ////            }
        ////        }

        ////        [HttpPost("delete")]
        ////        public async Task<ActionResult<string>> EXBCAcceptTermDueDelete([FromBody] PEXBCPurchasePaymentDeleteReq pExBcPurchasePaymentDelete)
        ////        {
        ////            DynamicParameters param = new();
        ////            param.Add("@EXPORT_BC_NO", pExBcPurchasePaymentDelete.EXPORTT_BC_NO);
        ////            param.Add("@VOUCH_ID", pExBcPurchasePaymentDelete.VOUCH_ID);

        ////            //param.Add("@Resp", dbType: DbType.Int32,
        ////            param.Add("@Resp", dbType: DbType.String,
        ////                direction: System.Data.ParameterDirection.Output,
        ////                size: 5215585);
        ////            try
        ////            {
        ////                await _db.SaveData(
        ////                  storedProcedure: "usp_pEXBCPurchasePaymentDelete", param);
        ////                //var resp = param.Get<int>("@Resp");
        ////                var resp = param.Get<string>("@Resp");
        ////                if (resp == "1")
        ////                {

        ////                    ReturnResponse response = new();
        ////                    response.StatusCode = "200";
        ////                    response.Message = "Export B/C Number Deleted";
        ////                    return Ok(response);
        ////                }
        ////                else
        ////                {

        ////                    ReturnResponse response = new();
        ////                    response.StatusCode = "400";
        ////                    response.Message = "Export B/C NO Does Not Exist";
        ////                    //response.Message = resp.ToString();
        ////                    return BadRequest(response);
        ////                }
        ////            }
        ////            catch (Exception ex)
        ////            {
        ////                return BadRequest(ex.Message);
        ////            }

        ////        }

        ////        [HttpPost("release")]
        ////        public async Task<ActionResult<string>> PEXBCPurchasePaymentReleaseReq([FromBody] PEXBCPurchasePaymentReleaseReq PEXBCPurchasePaymentRelease)
        ////        {
        ////            DynamicParameters param = new();
        ////            param.Add("@CenterID", PEXBCPurchasePaymentRelease.CenterID);
        ////            param.Add("@EXPORT_BC_NO", PEXBCPurchasePaymentRelease.EXPORT_BC_NO);
        ////            param.Add("@EVENT_NO", PEXBCPurchasePaymentRelease.EVENT_NO);
        ////            param.Add("@USER_ID", PEXBCPurchasePaymentRelease.USER_ID);

        ////            //param.Add("@Resp", dbType: DbType.Int32,
        ////            param.Add("@Resp", dbType: DbType.String,
        ////                direction: System.Data.ParameterDirection.Output,
        ////                size: 5215585);
        ////            try
        ////            {
        ////                await _db.SaveData(
        ////                  storedProcedure: "usp_pEXBCPurchasePaymentRelease", param);
        ////                //var resp = param.Get<int>("@Resp");
        ////                var resp = param.Get<string>("@Resp");
        ////                if (resp == "1")
        ////                {

        ////                    ReturnResponse response = new();
        ////                    response.StatusCode = "200";
        ////                    response.Message = "Export B/C NO Release Complete";
        ////                    return Ok(response);
        ////                }
        ////                else
        ////                {

        ////                    ReturnResponse response = new();
        ////                    response.StatusCode = "400";
        ////                    //response.Message = "Export BC No Not Exist";
        ////                    response.Message = resp.ToString();
        ////                    return BadRequest(response);
        ////                }
        ////            }
        ////            catch (Exception ex)
        ////            {
        ////                return BadRequest(ex.Message);
        ////            }

        ////        }








    }
}
