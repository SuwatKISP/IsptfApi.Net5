using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewSubOutCust
    {
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string FacNo { get; set; }
        public string Ccy { get; set; }
        public string SubProduct { get; set; }
        public double? BalanceAmt { get; set; }
        public string FlagDue { get; set; }
    }
}
