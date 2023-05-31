using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class viewCustLm
    {
        public string Facility_No { get; set; }
        public string ISP_ccs_no { get; set; }
        public string ISP_related_ac { get; set; }
        public string Limit_Code { get; set; }
        public double? Credit_Amount { get; set; }
        public string Prod_Mod { get; set; }
        public string Prod_Ref { get; set; }
        public string CCS_Ccy { get; set; }
        public string CCS_Stat { get; set; }
        public string CCS_LmType { get; set; }
        public string Cust_Code { get; set; }
        public string Cust_CCID { get; set; }
        public string Cust_CIF { get; set; }
    }
}
