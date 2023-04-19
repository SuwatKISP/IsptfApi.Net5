using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PImpastDue
    {
        public string CenterId { get; set; }
        public string DocModule { get; set; }
        public string DocNumber { get; set; }
        public string RecType { get; set; }
        public int DocSeqno { get; set; }
        public string DocStatus { get; set; }
        public string RecStatus { get; set; }
        public string EventMode { get; set; }
        public string Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventFlag { get; set; }
        public string Locode { get; set; }
        public string Aocode { get; set; }
        public DateTime? OverdueDate { get; set; }
        public DateTime? PastDueDate { get; set; }
        public string CustCode { get; set; }
        public string CustAddr { get; set; }
        public string DocCcy { get; set; }
        public double? DocAmount { get; set; }
        public double? DocBalance { get; set; }
        public string Lcnumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string IntRateCode { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public string IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? IntBalance { get; set; }
        public double? OpenAmt { get; set; }
        public double? CommDlc { get; set; }
        public double? CableAmt { get; set; }
        public double? PostageAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? CommOther { get; set; }
        public string TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public string CommDesc { get; set; }
        public string PayFlag { get; set; }
        public string PayMethod { get; set; }
        public string Allocation { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PayType { get; set; }
        public double? PayAmount { get; set; }
        public double? PayInterest { get; set; }
        public string PayRemark { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string LastReceiptNo { get; set; }
        public string FacNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string GenAccFlag { get; set; }
        public string VoucherId { get; set; }
        public DateTime? DateToStop { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public DateTime? DateLastAccru { get; set; }
        public double? LastAccruCcy { get; set; }
        public double? LastAccruAmt { get; set; }
        public double? NewAccruCcy { get; set; }
        public double? NewAccruAmt { get; set; }
        public double? AccruCcy { get; set; }
        public double? AccruAmt { get; set; }
        public double? DaccruAmt { get; set; }
        public double? PaccruAmt { get; set; }
        public double? AccruPending { get; set; }
        public double? RevAccru { get; set; }
        public double? RevAccruTax { get; set; }
        public string Dms { get; set; }
        public string CcsAcct { get; set; }
        public string CcsLmType { get; set; }
        public string CcsCnum { get; set; }
        public string CcsCifref { get; set; }
        public string InUse { get; set; }
        public string Bpoflag { get; set; }
        public string CampaignCode { get; set; }
        public DateTime? CampaignEffDate { get; set; }
    }
}
