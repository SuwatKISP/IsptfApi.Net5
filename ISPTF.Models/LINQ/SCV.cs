using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class SCV
    {
        public string RecordType { get; set; }
        public string SystemID { get; set; }
        public string InterfaceNumber { get; set; }
        public string ProcessingDate { get; set; }
        public string DataAsOfDate { get; set; }
        public string EntityCode1P { get; set; }
        public string Filler { get; set; }
        public string CountryCode { get; set; }
        public string CustNumber { get; set; }
        public string CustName { get; set; }
        public string ProcessStatus { get; set; }
        public string ProcessTime { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        public string LimitNumber { get; set; }
        public double? ApprovedLimitAmount { get; set; }
        public string BookingBranchCode { get; set; }
        public string ReferenceNumber { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string ProductGroupCode { get; set; }
        public string ProductType { get; set; }
        public string CurrencyID { get; set; }
        public string DisbursementDate { get; set; }
        public string MaturityDate { get; set; }
        public double? DisbursementAmountLCY { get; set; }
        public double? OutstandingAmountLCY { get; set; }
        public double? RevalueRate { get; set; }
        public double? DisbursementAmountFCY { get; set; }
        public double? OutstandingAmountFCY { get; set; }
        public double? DeferredIncomeAmount { get; set; }
        public double? AccruedInterestAmount { get; set; }
        public double? SuspendedInterestAmount { get; set; }
        public double? AgingPricipleDay { get; set; }
        public double? AgingInterestDay { get; set; }
        public double? FeeCommissionAmountLTD { get; set; }
        public string StopAccruedFlag { get; set; }
        public string StopAccruedDate { get; set; }
        public double? DiscountRate { get; set; }
        public string BaseRate { get; set; }
        public double? ActualRate { get; set; }
        public string SpreadCode { get; set; }
        public double? SpreadRate { get; set; }
        public double? PaidP { get; set; }
        public double? PaidIntAccr { get; set; }
        public double? PaidIntIncome { get; set; }
        public double? PaidMemoAccr { get; set; }
        public double? PaidM { get; set; }
        public string BusinessSizeBOT { get; set; }
        public string BOTPurposecode { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreatetBy { get; set; }
        public string CustCode { get; set; }
        public string FacNo { get; set; }
        public string ISP_Module { get; set; }
        public string CCS_LmType { get; set; }
        public string IntRateCode { get; set; }
        public string FlagDue { get; set; }
        public int? Tenor_Type { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public DateTime? DueDate { get; set; }
        public string PayType { get; set; }
        public string Module { get; set; }
    }
}
