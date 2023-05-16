using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCPurchasePaymentReleaseReq
    {
        public string? EXPORT_BC_NO { get; set; }
        public int? EVENT_NO { get; set; }
        public string? @CenterID { get; set; }
        public string? USER_ID { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string? BENE_ID { get; set; }
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
        public double? PARTIAL_AMT1_THB { get; set; }
        public double? PARTIAL_AMT2_THB { get; set; }
        public double? PARTIAL_AMT3_THB { get; set; }
        public double? PARTIAL_AMT4_THB { get; set; }
        public double? PARTIAL_AMT5_THB { get; set; }
        public double? PARTIAL_AMT6_THB { get; set; }
        public int? PARTIAL_FULL_RATE { get; set; }
        public int? TENOR_OF_COLL { get; set; }
        public string? INVOICE { get; set; }
        public string? VOUCH_ID { get; set; }
        public string? RELETE_PACK { get; set; }
        public string? PurposeCode { get; set; }
        public double? TOT_NEGO_AMT { get; set; }
        public double? TOTAL_NEGO_BALANCE { get; set; }
        public double? TOTAL_NEGO_BAL_THB { get; set; }
        public double? NEGO_COMM { get; set; }
        public double? TELEX_SWIFT { get; set; }
        public double? COURIER_POSTAGE { get; set; }
        public double? STAMP_FEE { get; set; }
        public double? BE_STAMP { get; set; }
        public double? COMM_OTHER { get; set; }
        public double? HANDING_FEE { get; set; }
        public double? DRAFTCOMM { get; set; }
        public double? TOTAL_CHARGE { get; set; }
        public int? REFUND_TAX_YN { get; set; }
        public double? REFUND_TAX_AMT { get; set; }
        public double? TOTAL_AMOUNT { get; set; }
        public string? PAYMENT_INSTRU { get; set; }
        public string? METHOD { get; set; }
        public double? DISCOUNT_CCY { get; set; }
        public double? DISCRATE { get; set; }
        public double? DISCOUNT_AMT { get; set; }
        public DateTime? ValueDate { get; set; }
        public string? DRAFT_CCY { get; set; }
        public double? CURRENT_INT_RATE { get; set; }
        public int? BASE_DAY { get; set; }
        public DateTime? SIGHT_START_DATE { get; set; }
        public DateTime? TERM_DUE_DATE { get; set; }
        public double? SIGHT_PAID_AMT { get; set; }
        public double? TERM_PAID_AMT { get; set; }
        public int? SETTLEMENT_CREDIT { get; set; }
        public double? SIGHT_PAID_THB { get; set; }
        public double? TERM_PAID_THB { get; set; }
        public double? NEGO_AMT { get; set; }
        public double? LESS_AGENT { get; set; }
        public double? TOT_NEGO_AMOUNT { get; set; }
        public double? NET_PROCEED_CLAIM { get; set; }
        public double? BANK_CHARGE_AMT { get; set; }
        public string? PaymentType { get; set; }
        public int? int_day { get; set; }
        public DateTime? PAYMENT_DATE { get; set; }
        public double? int_paid_amt { get; set; }
        public double? int_paid_thb { get; set; }
        public double? int_exch_rate { get; set; }

    }
}
