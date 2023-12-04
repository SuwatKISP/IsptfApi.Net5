﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models
{
    public class Q_EXADQueryListPageRsp

    {
        public int RCount { get; set; }
        public string EVENT_MODE { get; set; }
        public string RECORD_TYPE { get; set; }
        public string REC_STATUS { get; set; }
        public string EXPORT_ADVICE_NO { get; set; }
        public string EVENT_TYPE { get; set; }
        public int EVENT_NO { get; set; }
        public string BUSINESS_TYPE { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string TRANSACTION_TYPE { get; set; }
        public string LC_TYPE { get; set; }
        public string LC_NO { get; set; }
        public string ADVICE_METHOD { get; set; }
        public DateTime? ADVISING_DATE { get; set; }
        public string TENOR_TYPE { get; set; }
        public int? TENOR_DAY { get; set; }
        public string TENOR_DES { get; set; }
        public string TRANFLAG { get; set; }
        public string LC_CURRENCY { get; set; }
        public double? LC_AMOUNT { get; set; }
        public string LC_BAL_CCY { get; set; }
        public double? LC_BAL_AMT { get; set; }
        public DateTime? LC_ISSUE_DATE { get; set; }
        public DateTime? EXPIRY_DATE { get; set; }
        public string PLACE_OF_EXPIRY { get; set; }
        public string BENEFICIARY_ID { get; set; }
        public string BENEFICIARY_INFO { get; set; }
        public string APPLICANT_NAME { get; set; }
        public string APPLICANT_ADDRESS { get; set; }
        public string SENDING_BANK_REF { get; set; }
        public string SENDING_BANK_ID { get; set; }
        public string SENDING_BANK_INFO { get; set; }
        public string ADVISE_THRU_THRU_BK_ID { get; set; }
        public string ADVISE_THRU_THRU_BK_NAME { get; set; }
        public string ADVISE_THRU_CITY { get; set; }
        public string ADVISE_THRU_COUNTRY_CODE { get; set; }
        public string ADVISE_THRU_ADDRESS { get; set; }
        public string ISSUE_BANK_ID { get; set; }
        public string ISSUE_BANK_NAME { get; set; }
        public string ISSUE_BANK_CITY { get; set; }
        public string CHARGE_FOR_ID { get; set; }
        public string CHARGE_FOR_INFO { get; set; }
        public string CONFIRMATION { get; set; }
        public double? DRAFT_TERNOR_DAY { get; set; }
        public string DRAFT_AT { get; set; }
        public DateTime? SHIPMENT_DATE { get; set; }
        public string COUNTRY_CODE { get; set; }
        public string COUNTRY_NAME { get; set; }
        public DateTime? PREV_EXPIRY { get; set; }
        public DateTime? AMEND_DATE { get; set; }
        public int? AMEND_NO { get; set; }
        public string FLAG_TRANSFER { get; set; }
        public DateTime? TRANSFER_DATE { get; set; }
        public string TRANSFER_ID { get; set; }
        public string TRANSFER_INFO { get; set; }
        public double? TRANSFER_AMOUNT { get; set; }
        public double? TRANSFER_AMT_CANCEL { get; set; }
        public double? TRANSFER_COM_RATE { get; set; }
        public DateTime? TRANSFER_EXPIRY_DATE { get; set; }
        public DateTime? TRANSFER_SHIPMENT_DATE { get; set; }
        public string TYPE_OF_CHARGE_TRANSFER { get; set; }
        public string REASON_OF_CANCEL { get; set; }
        public string COLLECT_TYPE { get; set; }
        public string CHARGE_FOR { get; set; }
        public double? AMEND_COM { get; set; }
        public double? AMENDTRN_COM { get; set; }
        public double? ADVICE_COM { get; set; }
        public double? TRANSFER_COM { get; set; }
        public double? CABLE_COM { get; set; }
        public double? POSTAGE { get; set; }
        public double? CONFIRM_COM { get; set; }
        public double? OTHER_CHARGE { get; set; }
        public double? UNAMEND_COM { get; set; }
        public double? UNAMENDTRN_COM { get; set; }
        public double? UNADVICE_COM { get; set; }
        public double? UNTRANSFER_COM { get; set; }
        public double? UNCABLE_COM { get; set; }
        public double? UNPOSTAGE { get; set; }
        public double? UNCONFIRM_COM { get; set; }
        public double? UNOTHER_CHARGE { get; set; }
        public double? TOTAL_CHARGE { get; set; }
        public double? REFUND_TAX { get; set; }
        public double? TOTAL_AMOUNT { get; set; }
        public string PAYMENT_INSTRU { get; set; }
        public string METHOD { get; set; }
        public string RECEIPT_NO { get; set; }
        public string REIM_BK_ID { get; set; }
        public string REIM_BK_NAME { get; set; }
        public string NOSTRO { get; set; }
        public DateTime? CLAIM_DATE { get; set; }
        public string CLAIM_REC_TPYE { get; set; }
        public string CLAIM_CCY { get; set; }
        public double? CLAIM_ADV_COM { get; set; }
        public double? CLAIM_AMEND_COM { get; set; }
        public double? CLAIM_CABLE_CHARGE { get; set; }
        public double? CLAIM_DUTY_STAMP { get; set; }
        public double? CLAIM_OTHER_CHARGE { get; set; }
        public double? ISSUE_CCYAMT { get; set; }
        public double? EXCH_RATE { get; set; }
        public double? REC_ADV_COM { get; set; }
        public double? REC_AMEND_COM { get; set; }
        public double? REC_DUTY_STAMP { get; set; }
        public double? REC_CABLE_CHARGE { get; set; }
        public double? REC_OTHER_CHARGE { get; set; }
        public string USER_ID { get; set; }
        public DateTime? UPDATE_DATE { get; set; }
        public string AUTH_CODE { get; set; }
        public DateTime? AUTH_DATE { get; set; }
        public string VOUCH_ID { get; set; }
        public string subStation_doc { get; set; }
        public string IN_USE { get; set; }
        public string PAY_REC_TYPE { get; set; }
        public string PAY_REFUND { get; set; }
        public string GENACC_FLAG { get; set; }
        public DateTime? GENACC_DATE { get; set; }
        public double? INCREASE_AMT { get; set; }
        public double? DECREASE_AMT { get; set; }
        public string ALLOCATION { get; set; }
        public double? TRANSFER_RATE { get; set; }
        public string Description { get; set; }
        public string REMARK { get; set; }
        public string CenterID { get; set; }
        public string CCS_ACCT { get; set; }
        public string CCS_LmType { get; set; }
        public string CCS_CNUM { get; set; }
        public string CCS_CIFRef { get; set; }
        public string SwiftMT { get; set; }
        public string SwifInID { get; set; }
        public string BPOFlag { get; set; }
        public string Campaign_Code { get; set; }
        public DateTime? Campaign_EffDate { get; set; }
        public string Bank_Code { get; set; }
        public string FacNo { get; set; }
        public string ConfirmRefer { get; set; }
        public string ConfirmType { get; set; }
        public double? ConfirmAmt { get; set; }
        public string AutoOverDue { get; set; }
        public string ConfirmFlag { get; set; }
        public DateTime? ClaimDate { get; set; }
        public DateTime? PastDueDate { get; set; }
        public string IntRateCode { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public string IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? IntBalance { get; set; }
        public DateTime? DateToStop { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public DateTime? DateLastAccru { get; set; }
        public double? LastAccruCcy { get; set; }
        public double? LastAccruAmt { get; set; }
        public double? NewAccruCcy { get; set; }
        public double? NewAccruAmt { get; set; }
        public double? AccruCCy { get; set; }
        public double? AccruAmt { get; set; }
        public double? DAccruAmt { get; set; }
        public double? PAccruAmt { get; set; }
        public double? AccruPending { get; set; }
        public double? RevAccru { get; set; }
        public double? RevAccruTax { get; set; }
        public DateTime? ValueDate { get; set; }
        public string PaymentType { get; set; }
        public double? PayPrnAmt { get; set; }
        public double? PayIntAmt { get; set; }
        public string AdviceOther { get; set; }
        public string NostroBank { get; set; }
        public string? Cust_Name { get; set; }

    }
}