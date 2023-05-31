using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class vCommision
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public int Seqno { get; set; }
        public string EventName { get; set; }
        public string COLLECTION { get; set; }
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
        public double COMM { get; set; }
        public double CABLE { get; set; }
        public double? PAYBLE { get; set; }
        public double DUTY { get; set; }
        public double? COMMOTHER { get; set; }
        public double OVERDRAW { get; set; }
        public double? ENGAGE { get; set; }
        public double COMMLIEU { get; set; }
        public double COMMIBC { get; set; }
        public double PENALTY { get; set; }
        public double? COMMTRAN { get; set; }
        public double COMMAMEND { get; set; }
        public double COMMADVICE { get; set; }
        public double? POSTAGE { get; set; }
        public double COMMNEGO { get; set; }
        public double TelexSwift { get; set; }
        public double HandingFee { get; set; }
        public double? COMMBAHTNET { get; set; }
        public double TAXAMT { get; set; }
        public string collectrefund { get; set; }
        public string RecStatus { get; set; }
        public string RpReceiptNo { get; set; }
        public string PayFlag { get; set; }
        public string status { get; set; }
        public string CenterID { get; set; }
        public double? COMMCERTIFY { get; set; }
        public double? Discfee { get; set; }
    }
}
