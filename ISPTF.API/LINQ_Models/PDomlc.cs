using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PDomlc
    {
        public string Dlcnumber { get; set; }
        public string RecType { get; set; }
        public int Dlcseqno { get; set; }
        public string Dlcstatus { get; set; }
        public string EventMode { get; set; }
        public string Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventFlag { get; set; }
        public string RecStatus { get; set; }
        public string InUse { get; set; }
        public string Locode { get; set; }
        public string Aocode { get; set; }
        public int? AmendSeq { get; set; }
        public string AmendNo { get; set; }
        public string Dlcmove { get; set; }
        public string DlcrefNo { get; set; }
        public DateTime? DateIssue { get; set; }
        public string NoVary { get; set; }
        public string Dlcccy { get; set; }
        public double? Dlcamt { get; set; }
        public double? Dlcbal { get; set; }
        public double? DlcavalBal { get; set; }
        public double? Dlcnet { get; set; }
        public double? BillAmount { get; set; }
        public double? DlcpostAmt { get; set; }
        public double? AllowPlus { get; set; }
        public double? AllowMinus { get; set; }
        public string AmendFlag { get; set; }
        public double? AmendAmt { get; set; }
        public double? AmendPlus { get; set; }
        public double? AmendMinus { get; set; }
        public string DeplusFlag { get; set; }
        public double? PrevDlcamt { get; set; }
        public double? PrevDlcbal { get; set; }
        public double? PrevDlcavalBal { get; set; }
        public double? PrevDlcnet { get; set; }
        public DateTime? PrevDateExpiry { get; set; }
        public DateTime? DateExpiry { get; set; }
        public int? Lcdays { get; set; }
        public int? PrevLcdays { get; set; }
        public string TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string TenorTerm { get; set; }
        public string CustCode { get; set; }
        public string CustAddr { get; set; }
        public string BenCode { get; set; }
        public string BenInfo { get; set; }
        public string PrevBenCode { get; set; }
        public string PrevBenInfo { get; set; }
        public DateTime? DateLateShip { get; set; }
        public int? PresentDay { get; set; }
        public string TranShipment { get; set; }
        public string PartialShipment { get; set; }
        public string GoodsCode { get; set; }
        public string PurposeCode { get; set; }
        public string GoodsDesc { get; set; }
        public string SpecialInfo { get; set; }
        public string InvoiceInfo { get; set; }
        public double? ExchRate { get; set; }
        public double? CommLcrate { get; set; }
        public string TaxRefund { get; set; }
        public double? CableMail { get; set; }
        public double? PostageAmt { get; set; }
        public double? CommAmt { get; set; }
        public double? DutyStamp { get; set; }
        public double? PayableStamp { get; set; }
        public double? OthCharge { get; set; }
        public double? AmendAmtDec { get; set; }
        public double? AmendAmtInc { get; set; }
        public double? TaxAmt { get; set; }
        public string PayFlag { get; set; }
        public string PayMethod { get; set; }
        public string PayRemark { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string LastReceiptNo { get; set; }
        public string AppvNo { get; set; }
        public string TrappvNo { get; set; }
        public string FacNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string GenAccFlag { get; set; }
        public DateTime? DateGenAcc { get; set; }
        public string VoucherId { get; set; }
        public string Dms { get; set; }
        public string Allocation { get; set; }
        public string ShipmentFrom { get; set; }
        public string ShipmentTo { get; set; }
        public string CenterId { get; set; }
        public string CcsAcct { get; set; }
        public string CcsLmType { get; set; }
        public string CcsCnum { get; set; }
        public string CcsCifref { get; set; }
        public string Bpoflag { get; set; }
        public string CampaignCode { get; set; }
        public DateTime? CampaignEffDate { get; set; }
    }
}
