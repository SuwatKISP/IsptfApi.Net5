using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class VCommision
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public int? Seqno { get; set; }
        public string EventName { get; set; }
        public string Collection { get; set; }
        public string Reference { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string Ccy { get; set; }
        public double? OriginalAmt { get; set; }
        public double? BalanceAmt { get; set; }
        public DateTime? DueDate { get; set; }
        public string UserCode { get; set; }
        public string AuthCode { get; set; }
        public double Comm { get; set; }
        public double Cable { get; set; }
        public double? Payble { get; set; }
        public double Duty { get; set; }
        public double? Commother { get; set; }
        public double Overdraw { get; set; }
        public double? Engage { get; set; }
        public double Commlieu { get; set; }
        public double Commibc { get; set; }
        public double Penalty { get; set; }
        public double? Commtran { get; set; }
        public double Commamend { get; set; }
        public double Commadvice { get; set; }
        public double? Postage { get; set; }
        public double Commnego { get; set; }
        public double TelexSwift { get; set; }
        public double HandingFee { get; set; }
        public double? Commbahtnet { get; set; }
        public double Taxamt { get; set; }
        public string Collectrefund { get; set; }
        public string RecStatus { get; set; }
        public string RpReceiptNo { get; set; }
        public string PayFlag { get; set; }
        public string Status { get; set; }
        public string CenterId { get; set; }
        public double? Commcertify { get; set; }
        public double? Discfee { get; set; }
    }
}
