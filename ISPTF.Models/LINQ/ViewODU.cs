using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewODU
    {
        public string Cust_Code { get; set; }
        public string Facility_No { get; set; }
        public string Currency { get; set; }
        public double? IBLS_Amt { get; set; }
        public double? IBLT_Amt { get; set; }
        public double? IMTR_Amt { get; set; }
        public double? EXPC_Amt { get; set; }
        public double? XLCP_Amt { get; set; }
        public double? XBCP_Amt { get; set; }
    }
}
