using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pDOMLC
    {
        public string DLCNumber { get; set; }
        public string RecType { get; set; }
        public int DLCSeqno { get; set; }
        public string DLCStatus { get; set; }
        public string EventMode { get; set; }
        public string Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventFlag { get; set; }
        public string RecStatus { get; set; }
        public string InUse { get; set; }
        public string LOCode { get; set; }
        public string AOCode { get; set; }
        public int? AmendSeq { get; set; }
        public string AmendNo { get; set; }
        public string DLCMove { get; set; }
        public string DLCRefNo { get; set; }
        public DateTime? DateIssue { get; set; }
        public string NoVary { get; set; }
        public string DLCCcy { get; set; }
        public double? DLCAmt { get; set; }
        public double? DLCBal { get; set; }
        public double? DLCAvalBal { get; set; }
        public double? DLCNet { get; set; }
        public double? BillAmount { get; set; }
        public double? DLCPostAmt { get; set; }
        public double? AllowPlus { get; set; }
        public double? AllowMinus { get; set; }
        public string AmendFlag { get; set; }
        public double? AmendAmt { get; set; }
        public double? AmendPlus { get; set; }
        public double? AmendMinus { get; set; }
        public string DEPlus_flag { get; set; }
        public double? PrevDLCAmt { get; set; }
        public double? PrevDLCBal { get; set; }
        public double? PrevDLCAvalBal { get; set; }
        public double? PrevDLCNet { get; set; }
        public DateTime? PrevDateExpiry { get; set; }
        public DateTime? DateExpiry { get; set; }
        public int? LCDays { get; set; }
        public int? PrevLCDays { get; set; }
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
        public double? CommLCRate { get; set; }
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
        public string TRAppvNo { get; set; }
        public string FacNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string GenAccFlag { get; set; }
        public DateTime? DateGenAcc { get; set; }
        public string VoucherID { get; set; }
        public string DMS { get; set; }
        public string Allocation { get; set; }
        public string ShipmentFrom { get; set; }
        public string ShipmentTo { get; set; }
        public string CenterID { get; set; }
        public string CCS_ACCT { get; set; }
        public string CCS_LmType { get; set; }
        public string CCS_CNUM { get; set; }
        public string CCS_CIFRef { get; set; }
        public string BPOFlag { get; set; }
        public string Campaign_Code { get; set; }
        public DateTime? Campaign_EffDate { get; set; }
    }
}
