using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewSubOutCust
    {
        public string Cust_Code { get; set; }
        public string Cust_Name { get; set; }
        public string FacNo { get; set; }
        public string Ccy { get; set; }
        public string SubProduct { get; set; }
        public double? BalanceAmt { get; set; }
        public string FlagDue { get; set; }
    }
}
