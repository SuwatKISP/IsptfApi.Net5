using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TMP_VolCorrBank
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
        public double? Rate_MidRate { get; set; }
        public double? BalanceAmt { get; set; }
        public string BName { get; set; }
        public string BCnty { get; set; }
        public string BCnty_Name { get; set; }
        public string Corr_Bank { get; set; }
        public string Corr_BankName { get; set; }
        public string Corr_BankCnty { get; set; }
        public string Corr_CntyName { get; set; }
        public string MT103 { get; set; }
        public string MT202 { get; set; }
        public string BhtNet { get; set; }
        public string RepType { get; set; }
        public DateTime? SaveDate { get; set; }
    }
}
