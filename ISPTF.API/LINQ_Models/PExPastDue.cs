using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PExPastDue
    {
        public string CenterId { get; set; }
        public string Fmodule { get; set; }
        public string RefNumber { get; set; }
        public string DocNumber { get; set; }
        public string RecType { get; set; }
        public int EventNo { get; set; }
        public string Status { get; set; }
        public string RecStatus { get; set; }
        public string EventMode { get; set; }
        public string Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string Locode { get; set; }
        public string Aocode { get; set; }
        public string RefLcNo { get; set; }
        public string Invoice { get; set; }
        public string IssBankId { get; set; }
        public string AppName { get; set; }
        public DateTime? ValueDate { get; set; }
        public string DueStatus { get; set; }
        public DateTime? OverdueDate { get; set; }
        public DateTime? PastDueDate { get; set; }
        public string CustCode { get; set; }
        public string CustAddr { get; set; }
        public string TenorType { get; set; }
        public int? DueDay { get; set; }
        public string DocCcy { get; set; }
        public double? DocAmount { get; set; }
        public double? DocBalance { get; set; }
        public double? ExchRate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string DintRateCode { get; set; }
        public double? DintRate { get; set; }
        public double? DintSpread { get; set; }
        public int? DintBaseDay { get; set; }
        public string IntRateCode { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public int? IntBaseDay { get; set; }
        public string IntFlag { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? ExchBefore { get; set; }
        public double? IntBefore { get; set; }
        public double? IntBalance { get; set; }
        public int? IntDay { get; set; }
        public double? IntCcy { get; set; }
        public double? IntAmt { get; set; }
        public string TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public string PayFlag { get; set; }
        public string PayMethod { get; set; }
        public string Allocation { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string LastReceiptNo { get; set; }
        public string AppvNo { get; set; }
        public string FacNo { get; set; }
        public string PayType { get; set; }
        public double? PayAmount { get; set; }
        public double? PayInterest { get; set; }
        public double? NegoComm { get; set; }
        public double? TelexSwift { get; set; }
        public double? CourierPostage { get; set; }
        public double? StampFee { get; set; }
        public double? BeStamp { get; set; }
        public double? CommOther { get; set; }
        public double? HandingFee { get; set; }
        public double? DraftComm { get; set; }
        public double? TotalCharge { get; set; }
        public double? TotalAmount { get; set; }
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
        public string Dms { get; set; }
        public string InUse { get; set; }
        public string Narrative { get; set; }
        public string CcsAcct { get; set; }
        public string CcsLmType { get; set; }
        public string CcsCnum { get; set; }
        public string CcsCifref { get; set; }
        public string Bpoflag { get; set; }
        public string CampaignCode { get; set; }
        public DateTime? CampaignEffDate { get; set; }
    }
}
