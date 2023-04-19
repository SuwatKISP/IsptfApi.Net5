using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewMasterLoan
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public int Trseqno { get; set; }
        public string EventName { get; set; }
        public string Reference { get; set; }
        public string KeyNumber { get; set; }
        public string DocNo { get; set; }
        public string DocNo1 { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double? OriginalAmt { get; set; }
        public double BalanceAmt { get; set; }
        public DateTime? DueDate { get; set; }
        public string UserCode { get; set; }
        public string AuthCode { get; set; }
        public double Commlc { get; set; }
        public double Cable { get; set; }
        public double Payble { get; set; }
        public double Duty { get; set; }
        public double Commother { get; set; }
        public double Overdraw { get; set; }
        public double Engage { get; set; }
        public double Commlieu { get; set; }
        public double Commibc { get; set; }
        public double Penalty { get; set; }
        public double Commtran { get; set; }
        public int Commamend { get; set; }
        public int Commadvice { get; set; }
        public int Postage { get; set; }
        public int Commnego { get; set; }
        public int TelexSwift { get; set; }
        public double HandingFee { get; set; }
        public double Taxamt { get; set; }
        public string Collectrefund { get; set; }
        public string RecStatus { get; set; }
        public string TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string TenorTerm { get; set; }
        public int TenorType1 { get; set; }
        public string Centerid { get; set; }
        public string FlagDue { get; set; }
        public double? IntRate { get; set; }
        public double AccruCcy { get; set; }
        public double? TermDay { get; set; }
        public DateTime? LastPayment { get; set; }
        public string PayType { get; set; }
        public double? AccruPending { get; set; }
        public double? ExchRate { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public DateTime? PastDueDate { get; set; }
        public DateTime? OverdueDate { get; set; }
    }
}
