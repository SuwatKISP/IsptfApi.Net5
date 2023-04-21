using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class VIEW_ShowOSbyCC
    {
        public string Cust_CIF { get; set; }
        public string TITL { get; set; }
        public string CNAME { get; set; }
        public string CUSTCODE { get; set; }
        public string FLAGDUE { get; set; }
        public string FACNO { get; set; }
        public string CCS_ACCT { get; set; }
        public string CCS_LMTYPE { get; set; }
        public string MODULE { get; set; }
        public double? OUTSTD_AMT_THB { get; set; }
    }
}
