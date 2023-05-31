using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class VIEW_OSbyCC
    {
        public string CUSTCODE { get; set; }
        public string FLAGDUE { get; set; }
        public string FACNO { get; set; }
        public string CCS_ACCT { get; set; }
        public string CCS_LMTYPE { get; set; }
        public string MODULE { get; set; }
        public string CCY { get; set; }
        public double? BAL_AMT { get; set; }
        public double? Rate_MidRate { get; set; }
        public double? OUTSTD_AMT_THB { get; set; }
    }
}
