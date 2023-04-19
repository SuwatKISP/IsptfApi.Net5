using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewFcdAccount
    {
        public string FcdAccNo { get; set; }
        public string TranDoc { get; set; }
        public int TranSeqNo { get; set; }
        public string TranCode { get; set; }
        public string TranDept { get; set; }
        public string RecStatus { get; set; }
        public string RefAccount { get; set; }
        public DateTime? EventDate { get; set; }
        public double? FcdBalance { get; set; }
        public double? FcdAmt { get; set; }
        public string FcdCcy { get; set; }
        public double? ExchRate { get; set; }
        public double? FcdInterest { get; set; }
        public double? IntRate { get; set; }
        public string Paytype { get; set; }
        public string TranFmethod { get; set; }
        public double? TranFcdAmt { get; set; }
        public double? TranFcashAmt { get; set; }
        public double? TranChquAmt { get; set; }
        public double? TranDrAmt { get; set; }
        public string Remark { get; set; }
        public string Allocation { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string CenterId { get; set; }
        public DateTime FcdEntryDate { get; set; }
        public string TranFcdStatus { get; set; }
        public double? PrevFcdBal { get; set; }
        public string ReceiptNo { get; set; }
        public string LastReceiptNo { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public double? MaintenAmt { get; set; }
        public double? IntAmt { get; set; }
        public double? ProfitAmt { get; set; }
        public double? CommFcd { get; set; }
        public double? CommOther { get; set; }
        public double? CommBnet { get; set; }
        public double? CommCertify { get; set; }
        public string TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public string PayFlag { get; set; }
        public string VoucherId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string FcdAccType { get; set; }
        public int? FcdAccTerm { get; set; }
        public string FcdAccName { get; set; }
        public DateTime? OpenDate { get; set; }
        public string FcdCcyName { get; set; }
        public string FcdStatus { get; set; }
        public double? Thbbal { get; set; }
        public double? PrevBal { get; set; }
        public string HoldFlag { get; set; }
        public double Expr1 { get; set; }
        public DateTime? DueDate { get; set; }
        public string FcdSavFlag { get; set; }
        public double? IntSpread { get; set; }
        public double? FixBalance { get; set; }
        public string TranFflag { get; set; }
        public double? FixAvalBal { get; set; }
        public double? BalanceMacc { get; set; }
        public DateTime? Maturity { get; set; }
        public int? Term { get; set; }
        public string Expr2 { get; set; }
        public int? BaseDay { get; set; }
        public int? TranTerm { get; set; }
    }
}
