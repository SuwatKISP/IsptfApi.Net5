﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models
{
    public class Q_EXBCQueryListPageRsp

    {
        public int RCount { get; set; }
        public string EVENT_MODE { get; set; }
        public string RECORD_TYPE { get; set; }
        public string REC_STATUS { get; set; }
        public int EVENT_NO { get; set; }
        public string EXPORT_BC_NO { get; set; }
        public string? BUSINESS_TYPE { get; set; }
        public string? EVENT_TYPE { get; set; }
        public DateTime EVENT_DATE { get; set; }
        public int? TENOR_OF_COLL { get; set; }
        public int? TENOR_TYPE { get; set; }
        public string? INVOICE { get; set; }
        public string? REFER_BC_NO { get; set; }
        public string? RELETE_PACK { get; set; }
        public string? DRAFT_CCY { get; set; }
        public double? DRAFT_AMT { get; set; }
        public double? SIGHT_AMT { get; set; }
        public double? TERM_AMT { get; set; }
        public string? GOOD_CODE { get; set; }
        public string? REL_CODE { get; set; }
        public int? CLAIM_TYPE { get; set; }
        public DateTime? SIGHT_START_DATE { get; set; }
        public DateTime? SIGHT_DUE_DATE { get; set; }
        public int? TENOR_DAY { get; set; }
        public string? TENOR_DAY_DESC { get; set; }
        public DateTime? TERM_START_DATE { get; set; }
        public DateTime? TERM_DUE_DATE { get; set; }
        public DateTime? PURCH_DISC_DATE { get; set; }
        public string? DRAWEE_INFO { get; set; }
        public string? CNTY_CODE { get; set; }
        public string? Cust_AO { get; set; }
        public string? Cust_LO { get; set; }
        public string? BENE_ID { get; set; }
        public string? BENE_INFO { get; set; }
        public string? ISSUE_BANK_ID { get; set; }
        public string? ISSUE_BANK_INFO { get; set; }
        public int? COLLECT_AGENT { get; set; }
        public string? AGENT_BANK_ID { get; set; }
        public string? AGENT_BANK_INFO { get; set; }
        public string? AGENT_BANK_REF { get; set; }
        public string? AGENT_BANK_NOSTRO { get; set; }
        public int? RESTRICT { get; set; }
        public string? RESTRICT_TO_BK_NAME { get; set; }
        public string? RESTRICT_TO_BK_ADDR1 { get; set; }
        public string? RESTRICT_TO_BK_ADDR2 { get; set; }
        public string? RESTRICT_TO_BK_ADDR3 { get; set; }
        public string? RESTRICT_REFER { get; set; }
        public string? RESTRICT_FR_BK_NAME { get; set; }
        public string? RESTRICT_FR_BK_ADDR1 { get; set; }
        public string? RESTRICT_FR_BK_ADDR2 { get; set; }
        public string? RESTRICT_FR_BK_ADDR3 { get; set; }
        public int? PARTIAL_FULL_RATE { get; set; }
        public int? INT_RATE_METHOD { get; set; }
        public int? TYPE_OF_ACCOUNT { get; set; }
        public string? CREDIT_CURRENCY { get; set; }
        public int? DISCOUNT_DAY { get; set; }
        public int? GRACE_PERIOD { get; set; }
        public int? DISC_BASE_DAY { get; set; }
        public int? BASE_DAY { get; set; }
        public double? DISCOUNT_RATE { get; set; }
        public double? INT_BASE_RATE { get; set; }
        public double? INT_SPREAD_RATE { get; set; }
        public double? CURRENT_DIS_RATE { get; set; }
        public double? CURRENT_INT_RATE { get; set; }
        public int? PAY_BY { get; set; }
        public double? NEGO_AMT { get; set; }
        public double? LESS_AGENT { get; set; }
        public double? PURCHASE_AMT { get; set; }
        public double? PURCHASE_RATE { get; set; }
        public double? TOTAL_NEGO_BALANCE { get; set; }
        public double? TOTAL_NEGO_BAL_THB { get; set; }
        public double? TOT_NEGO_AMT { get; set; }
        public double? TOT_NEGO_AMOUNT { get; set; }
        public double? BANK_CHARGE_AMT { get; set; }
        public double? NET_PROCEED_CLAIM { get; set; }
        public int? CLAIM_PAY_BY { get; set; }
        public string? ParTnor_Type1 { get; set; }
        public string? ParTnor_Type2 { get; set; }
        public string? ParTnor_Type3 { get; set; }
        public string? ParTnor_Type4 { get; set; }
        public string? ParTnor_Type5 { get; set; }
        public string? ParTnor_Type6 { get; set; }
        public double? PARTIAL_AMT1 { get; set; }
        public double? PARTIAL_AMT2 { get; set; }
        public double? PARTIAL_AMT3 { get; set; }
        public double? PARTIAL_AMT4 { get; set; }
        public double? PARTIAL_AMT5 { get; set; }
        public double? PARTIAL_AMT6 { get; set; }
        public double? PARTIAL_RATE1 { get; set; }
        public double? PARTIAL_RATE2 { get; set; }
        public double? PARTIAL_RATE3 { get; set; }
        public double? PARTIAL_RATE4 { get; set; }
        public double? PARTIAL_RATE5 { get; set; }
        public double? PARTIAL_RATE6 { get; set; }
        public double? PARTIAL_AMT1_THB { get; set; }
        public double? PARTIAL_AMT2_THB { get; set; }
        public double? PARTIAL_AMT3_THB { get; set; }
        public double? PARTIAL_AMT4_THB { get; set; }
        public double? PARTIAL_AMT5_THB { get; set; }
        public double? PARTIAL_AMT6_THB { get; set; }
        public string? FORWARD_CONRACT_NO { get; set; }
        public string? FORWARD_CONRACT_NO1 { get; set; }
        public string? FORWARD_CONRACT_NO2 { get; set; }
        public string? FORWARD_CONRACT_NO3 { get; set; }
        public string? FORWARD_CONRACT_NO4 { get; set; }
        public string? FORWARD_CONRACT_NO5 { get; set; }
        public string? FORWARD_CONRACT_NO6 { get; set; }
        public double? NEGO_COMM { get; set; }
        public double? TELEX_SWIFT { get; set; }
        public double? COURIER_POSTAGE { get; set; }
        public double? STAMP_FEE { get; set; }
        public double? BE_STAMP { get; set; }
        public double? COMM_OTHER { get; set; }
        public double? HANDING_FEE { get; set; }
        public double? DRAFTCOMM { get; set; }
        public double? INT_AMT_THB { get; set; }
        public double? COMMONTT { get; set; }
        public double? TOTAL_CHARGE { get; set; }
        public int? REFUND_TAX_YN { get; set; }
        public double? REFUND_TAX_AMT { get; set; }
        public double? DISCOUNT_CCY { get; set; }
        public double? DISCRATE { get; set; }
        public double? DISCOUNT_AMT { get; set; }
        public double? TOTAL_AMOUNT { get; set; }
        public string? PAYMENT_INSTRU { get; set; }
        public string? METHOD { get; set; }
        public string? ACBAHTNET { get; set; }
        public double? BAHTNET { get; set; }
        public string? RECEIVED_NO { get; set; }
        public string? ALLOCATION { get; set; }
        public string? NARRATIVE { get; set; }
        public int? SEQ_ACCEPT_DUE { get; set; }
        public DateTime? COMFIRM_DUE { get; set; }
        public string? PLUS_MINUS_DISC { get; set; }
        public int? DISC_DAYS_PLUS_MINUS { get; set; }
        public double? RECEIVE_PAY_AMT { get; set; }
        public double? EXCHANGE_RATE { get; set; }
        public double? REFUND_DISC_RECEIVE { get; set; }
        public double? DISC_RECEIVE { get; set; }
        public DateTime? LC_DATE { get; set; }
        public DateTime? COVERING_DATE { get; set; }
        public string? COVERING_FOR { get; set; }
        public string? ADVICE_ISSUE_BANK { get; set; }
        public string? ADVICE_FORMAT { get; set; }
        public string? REMIT_CLAIM_TYPE { get; set; }
        public string? REIMBURSE_BANK_ID { get; set; }
        public string? REIMBURSE_BANK_INFO { get; set; }
        public string? SWIFT_BANK { get; set; }
        public string? SWIFT_MAIL { get; set; }
        public string? CLAIM_FORMAT { get; set; }
        public DateTime? VALUE_DATE { get; set; }
        public string? THIRD_BANK_ID { get; set; }
        public string? THIRD_BANK_INFO { get; set; }
        public string? DISCREPANCY_TYPE { get; set; }
        public string? SWIFT_DISC { get; set; }
        public string? DOCUMENT_COPY { get; set; }
        public bool? SIGHT_BASIS { get; set; }
        public bool? ART44A { get; set; }
        public bool? ENDORSED { get; set; }
        public bool? MT750 { get; set; }
        public double? ADJ_TOT_NEGO_AMOUNT { get; set; }
        public double? ADJ_LESS_CHARGE_AMT { get; set; }
        public double? ADJUST_COVERING_AMT { get; set; }
        public string? ADJUST_TENOR { get; set; }
        public string? ADJUST_LC_REF { get; set; }
        public string? PAYMENT_INSTRC { get; set; }
        public string? TXTDOCUMENT { get; set; }
        public string? CHARGE_ACC { get; set; }
        public string? DRAFT { get; set; }
        public string? MT202 { get; set; }
        public string? FB_CURRENCY { get; set; }
        public double? FB_AMT { get; set; }
        public double? FB_RATE { get; set; }
        public double? FB_AMT_THB { get; set; }
        public string? COLLECT_REFUND { get; set; }
        public string? USER_ID { get; set; }
        public int? IN_USE { get; set; }
        //public DateTime? UPDATE_DATE { get; set; }
        public string? AUTH_CODE { get; set; }
        //public DateTime? AUTH_DATE { get; set; }
        public DateTime? GENACC_DATE { get; set; }
        public string? GENACC_FLAG { get; set; }
        public string? VOUCH_ID { get; set; }
        public string? APPVNO { get; set; }
        public string? FACNO { get; set; }
        public string? AUTOOVERDUE { get; set; }
        public string? LCOVERDUE { get; set; }
        public int? OVESEQNO { get; set; }
        public string? INTFLAG { get; set; }
        public string? IntRateCode { get; set; }
        public string? CFRRate { get; set; }
        public string? INTCODE { get; set; }
        public double? OINTRATE { get; set; }
        public double? OINTSPDRATE { get; set; }
        public double? OINTCURRATE { get; set; }
        public int? OINTDAY { get; set; }
        public int? OBASEDAY { get; set; }
        public double? BFINTAMT { get; set; }
        public double? SELLING_RATE { get; set; }
        public double? BFINTTHB { get; set; }
        public double? INTBALANCE { get; set; }
        public double? PRNBALANCE { get; set; }
        public double? LASTINTAMT { get; set; }
        public string? DMS { get; set; }
        public DateTime? LASTINTDATE { get; set; }
        public string? PAYMENTTYPE { get; set; }
        public DateTime? CONFIRM_DATE { get; set; }
        public double? TOTALACCRUAMT { get; set; }
        public double? TOTALACCRUBHT { get; set; }
        public double? ACCRUAMT { get; set; }
        public double? ACCRUBHT { get; set; }
        public DateTime? DATELASTACCRU { get; set; }
        public DateTime? PASTDUEDATE { get; set; }
        public string? PASTDUEFLAG { get; set; }
        public double? TOTALSUSPAMT { get; set; }
        public double? TOTALSUSPBHT { get; set; }
        public double? SUSPAMT { get; set; }
        public double? SUSPBHT { get; set; }
        public string? CenterID { get; set; }
        public string? BCPastDue { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public DateTime? DateToStop { get; set; }
        public DateTime? ValueDate { get; set; }
        public string? FlagBack { get; set; }
        public double? NewAccruCcy { get; set; }
        public double? NewAccruAmt { get; set; }
        public double? AccruPending { get; set; }
        public double? LastAccruCcy { get; set; }
        public double? LastAccruAmt { get; set; }
        public double? DAccruAmt { get; set; }
        public string? CCS_ACCT { get; set; }
        public string? CCS_LmType { get; set; }
        public string? CCS_CNUM { get; set; }
        public string? CCS_CIFRef { get; set; }
        public string? ObjectType { get; set; }
        public string? UnderlyName { get; set; }
        public string? BPOFlag { get; set; }
        public string? Campaign_Code { get; set; }
        public DateTime? Campaign_EffDate { get; set; }
        public string? PurposeCode { get; set; }
        public string? Cust_Name { get; set; }

    }
}