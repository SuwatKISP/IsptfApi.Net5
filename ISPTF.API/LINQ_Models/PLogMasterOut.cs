using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PLogMasterOut
    {
        public DateTime LogDate { get; set; }
        public string LogTime { get; set; }
        public string LogUser { get; set; }
        public string Module { get; set; }
        public string KeyNumber { get; set; }
        public string Reference { get; set; }
        public string LastEvent { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double? OriginalAmt { get; set; }
        public double? BalanceAmt { get; set; }
        public string FlagDue { get; set; }
        public DateTime? LastPayment { get; set; }
    }
}
