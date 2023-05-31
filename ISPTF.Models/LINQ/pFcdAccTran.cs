using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pFcdAccTran
    {
        public string FcdAccNo { get; set; }
        public DateTime FcdEntryDate { get; set; }
        public int TranSeqNo { get; set; }
        public string TranDoc { get; set; }
        public string RefTranDoc { get; set; }
        public string TranCode { get; set; }
        public string TranDept { get; set; }
        public string RecStatus { get; set; }
        public string TranFcdStatus { get; set; }
        public string FlagReverse { get; set; }
        public string RefAccount { get; set; }
        public string FcdCross { get; set; }
        public DateTime? EventDate { get; set; }
        public double? FcdBalance { get; set; }
        public double? PrevFcdBal { get; set; }
        public double? FcdAmt { get; set; }
        public double? HoldAmt { get; set; }
        public string CustCode { get; set; }
        public string FcdCcy { get; set; }
        public double? ExchRate { get; set; }
        public double? FcdInterest { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public string TranFDepos { get; set; }
        public string TranFTel { get; set; }
        public string Mixpayment { get; set; }
        public string Paytype { get; set; }
        public string TranFMethod { get; set; }
        public double? TranFcdAmt { get; set; }
        public double? TranFCashAmt { get; set; }
        public double? TranChquAmt { get; set; }
        public double? TranDrAmt { get; set; }
        public string Remark { get; set; }
        public string Allocation { get; set; }
        public string ForwardNo { get; set; }
        public string RelateCode { get; set; }
        public string GoodsCode { get; set; }
        public string PurposeCode { get; set; }
        public string ChqNo { get; set; }
        public string ChqBank { get; set; }
        public string ChqBran { get; set; }
        public double? ExchRate2 { get; set; }
        public double? THBBal { get; set; }
        public double? CurrentAmt { get; set; }
        public string AccNo1 { get; set; }
        public string AccNo2 { get; set; }
        public string AccNo3 { get; set; }
        public double? AccAmt1 { get; set; }
        public double? AccAmt2 { get; set; }
        public double? AccAmt3 { get; set; }
        public string ReceiptNo { get; set; }
        public string LastReceiptNo { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public double? MaintenAmt { get; set; }
        public double? IntAmt { get; set; }
        public double? ProfitAmt { get; set; }
        public double? CommFCD { get; set; }
        public double? CommOther { get; set; }
        public double? CommBnet { get; set; }
        public double? CommCertify { get; set; }
        public string TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public string PayFlag { get; set; }
        public int? FcdAccTerm { get; set; }
        public DateTime? DueDate { get; set; }
        public string VoucherID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string CenterID { get; set; }
    }
}
