using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewISPTFL
    {
        public string module { get; set; }
        public string cust_code { get; set; }
        public string cust_ISP { get; set; }
        public string cust_TFL { get; set; }
        public string Cust_Name { get; set; }
        public string keynumber { get; set; }
        public string Ref_TFL { get; set; }
        public string ccy_ISP { get; set; }
        public string ccy_TFL { get; set; }
        public string CCS_ISP { get; set; }
        public string CCS_TFL { get; set; }
        public string CCS_related_TFL { get; set; }
        public double? LM_amt_ISP { get; set; }
        public decimal LM_amt_TFL { get; set; }
        public double bal_ISP { get; set; }
        public decimal? bal_TFL { get; set; }
    }
}
