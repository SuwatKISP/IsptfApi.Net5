using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewTRnostro
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public int TRSeqno { get; set; }
        public string EventName { get; set; }
        public string COLLECTION { get; set; }
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
        public int COMMCIC { get; set; }
        public int COMMCIP { get; set; }
        public double COMMLC { get; set; }
        public double CABLE { get; set; }
        public double PAYBLE { get; set; }
        public double DUTY { get; set; }
        public double COMMOTHER { get; set; }
        public double OVERDRAW { get; set; }
        public double ENGAGE { get; set; }
        public double COMMLIEU { get; set; }
        public double COMMIBC { get; set; }
        public int PENALTY { get; set; }
        public double COMMTRAN { get; set; }
        public int COMMAMEND { get; set; }
        public int COMMADVICE { get; set; }
        public int POSTAGE { get; set; }
        public int COMMNEGO { get; set; }
        public int TelexSwift { get; set; }
        public int HandingFee { get; set; }
        public int COMMCERTIFY { get; set; }
        public double TAXAMT { get; set; }
        public string collectrefund { get; set; }
        public string RecStatus { get; set; }
        public string LastReceiptNo { get; set; }
        public string PayFlag { get; set; }
        public string CenterID { get; set; }
        public int DISCOUNT { get; set; }
        public int IntDelay { get; set; }
        public string Allocation { get; set; }
        public string EventFlag { get; set; }
        public string Amend { get; set; }
        public double IntRate { get; set; }
        public double BalPD { get; set; }
        public string FlagDue { get; set; }
        public string BName { get; set; }
        public string BCnty { get; set; }
        public string DNumber { get; set; }
        public string ISS_BANK { get; set; }
        public string Corr_BANK { get; set; }
        public string Corr_Name { get; set; }
        public string Corr_Cnty { get; set; }
        public string TENOR_TYPE { get; set; }
        public string Increase_Amt { get; set; }
        public string Decrease_Amt { get; set; }
    }
}
