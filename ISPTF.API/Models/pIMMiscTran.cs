using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pIMMiscTran
    {
        public string Login { get; set; }
        public string RefNumber { get; set; }
        public int Seqno { get; set; }
        public string DocNumber { get; set; }
        public string RecStatus { get; set; }
        public string Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventFlag { get; set; }
        public DateTime? DocDate { get; set; }
        public string DocStatus { get; set; }
        public string CustCode { get; set; }
        public string Cust_Bran { get; set; }
        public string CustAddr { get; set; }
        public string DocCcy { get; set; }
        public double? DocBalance { get; set; }
        public double? DocCommCcy { get; set; }
        public double? DocFBCharge { get; set; }
        public double? DocFBInterest { get; set; }
        public string FBCcy { get; set; }
        public double? FBCharge { get; set; }
        public double? FBInterest { get; set; }
        public double? CommCCy { get; set; }
        public double? CommOther { get; set; }
        public double? MarginAmt { get; set; }
        public double? CableMail { get; set; }
        public double? ExchRate { get; set; }
        public string TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public string PayFlag { get; set; }
        public string PayMethod { get; set; }
        public string Allocation { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string LastReceiptNo { get; set; }
        public string FCDAcNo { get; set; }
        public string FCDReceiptNo { get; set; }
        public string Remark { get; set; }
        public string MTType { get; set; }
        public string ReimRefNo { get; set; }
        public string ReimBank { get; set; }
        public string IntermBank { get; set; }
        public string IntermAddr { get; set; }
        public string ChipInterm { get; set; }
        public string AcBank { get; set; }
        public string AcAddr { get; set; }
        public string ChipAcBank { get; set; }
        public string BenBank { get; set; }
        public string BenAddr { get; set; }
        public string ChipBenBank { get; set; }
        public string Tx79 { get; set; }
        public string Tx72 { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string GenAccFlag { get; set; }
        public DateTime? DateGenAc { get; set; }
        public string VoucherID { get; set; }
        public string DMS { get; set; }
        public string CenterID { get; set; }
        public string ProdCode { get; set; }
        public string ProdDesc { get; set; }
        public string InUse { get; set; }
        public string ChipBank54 { get; set; }
        public string ChipBank53 { get; set; }
        public string Bank52 { get; set; }
        public string Bank54 { get; set; }
        public string SwiftFile { get; set; }
    }
}
