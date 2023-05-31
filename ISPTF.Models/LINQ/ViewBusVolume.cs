using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewBusVolume
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public int? Seqno { get; set; }
        public string EventName { get; set; }
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
        public double? COMMLC { get; set; }
        public double? CABLE { get; set; }
        public double? PAYBLE { get; set; }
        public double? DUTY { get; set; }
        public double? COMMOTHER { get; set; }
        public double? OVERDRAW { get; set; }
        public double? ENGAGE { get; set; }
        public double? COMMLIEU { get; set; }
        public double COMMIBC { get; set; }
        public double PENALTY { get; set; }
        public double? COMMTRAN { get; set; }
        public double COMMAMEND { get; set; }
        public double COMMADVICE { get; set; }
        public double? POSTAGE { get; set; }
        public double COMMNEGO { get; set; }
        public double? TelexSwift { get; set; }
        public double? HandingFee { get; set; }
        public double? COMMCERTIFY { get; set; }
        public double TAXAMT { get; set; }
        public string collectrefund { get; set; }
        public string RecStatus { get; set; }
        public string RpReceiptNo { get; set; }
        public string PayFlag { get; set; }
        public string CenterID { get; set; }
        public double DISCOUNT { get; set; }
        public double IntDelay { get; set; }
        public string Allocation { get; set; }
        public string AmendFlag { get; set; }
        public double? AmendAmt { get; set; }
        public string TenorType { get; set; }
        public double? TenorDay { get; set; }
        public string TenorTerm { get; set; }
        public int? TENOR_TYPE { get; set; }
        public double Tolerence { get; set; }
        public string EventFlag { get; set; }
        public string Amend { get; set; }
        public double? IntRate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string Section { get; set; }
        public string remark { get; set; }
    }
}
