using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewTrnostro
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public int Trseqno { get; set; }
        public string EventName { get; set; }
        public string Collection { get; set; }
        public string Reference { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string Ccy { get; set; }
        public double OriginalAmt { get; set; }
        public double BalanceAmt { get; set; }
        public DateTime? DueDate { get; set; }
        public string UserCode { get; set; }
        public string AuthCode { get; set; }
        public int Commcic { get; set; }
        public int Commcip { get; set; }
        public double Commlc { get; set; }
        public double Cable { get; set; }
        public double Payble { get; set; }
        public double Duty { get; set; }
        public double Commother { get; set; }
        public double Overdraw { get; set; }
        public double Engage { get; set; }
        public double Commlieu { get; set; }
        public double Commibc { get; set; }
        public int Penalty { get; set; }
        public double Commtran { get; set; }
        public int Commamend { get; set; }
        public int Commadvice { get; set; }
        public int Postage { get; set; }
        public int Commnego { get; set; }
        public int TelexSwift { get; set; }
        public int HandingFee { get; set; }
        public int Commcertify { get; set; }
        public double Taxamt { get; set; }
        public string Collectrefund { get; set; }
        public string RecStatus { get; set; }
        public string LastReceiptNo { get; set; }
        public string PayFlag { get; set; }
        public string CenterId { get; set; }
        public int Discount { get; set; }
        public int IntDelay { get; set; }
        public string Allocation { get; set; }
        public string EventFlag { get; set; }
        public string Amend { get; set; }
        public double? IntRate { get; set; }
        public double? BalPd { get; set; }
        public string FlagDue { get; set; }
        public string Bname { get; set; }
        public string Bcnty { get; set; }
        public string Dnumber { get; set; }
        public string IssBank { get; set; }
        public string CorrBank { get; set; }
        public string CorrName { get; set; }
        public string CorrCnty { get; set; }
        public string TenorType { get; set; }
        public string IncreaseAmt { get; set; }
        public string DecreaseAmt { get; set; }
    }
}
