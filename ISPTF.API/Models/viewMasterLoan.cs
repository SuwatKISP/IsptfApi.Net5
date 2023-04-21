using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class viewMasterLoan
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public int TRSeqno { get; set; }
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
        public double COMMLC { get; set; }
        public double CABLE { get; set; }
        public double PAYBLE { get; set; }
        public double DUTY { get; set; }
        public double COMMOTHER { get; set; }
        public double OVERDRAW { get; set; }
        public double ENGAGE { get; set; }
        public double COMMLIEU { get; set; }
        public double COMMIBC { get; set; }
        public double PENALTY { get; set; }
        public double COMMTRAN { get; set; }
        public int COMMAMEND { get; set; }
        public int COMMADVICE { get; set; }
        public int POSTAGE { get; set; }
        public int COMMNEGO { get; set; }
        public int TelexSwift { get; set; }
        public double HandingFee { get; set; }
        public double TAXAMT { get; set; }
        public string collectrefund { get; set; }
        public string RecStatus { get; set; }
        public string TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string TenorTerm { get; set; }
        public int TENOR_TYPE { get; set; }
        public string CENTERID { get; set; }
        public string FlagDue { get; set; }
        public double? intRate { get; set; }
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
