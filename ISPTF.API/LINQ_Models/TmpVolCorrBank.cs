using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class TmpVolCorrBank
    {
        public string Sec { get; set; }
        public string EventName { get; set; }
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public string SubModule { get; set; }
        public string SubName { get; set; }
        public string Reference { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string Ccy { get; set; }
        public double? RateMidRate { get; set; }
        public double? BalanceAmt { get; set; }
        public string Bname { get; set; }
        public string Bcnty { get; set; }
        public string BcntyName { get; set; }
        public string CorrBank { get; set; }
        public string CorrBankName { get; set; }
        public string CorrBankCnty { get; set; }
        public string CorrCntyName { get; set; }
        public string Mt103 { get; set; }
        public string Mt202 { get; set; }
        public string BhtNet { get; set; }
        public string RepType { get; set; }
        public DateTime? SaveDate { get; set; }
    }
}
