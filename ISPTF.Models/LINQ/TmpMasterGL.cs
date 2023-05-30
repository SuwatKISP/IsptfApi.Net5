using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TmpMasterGL
    {
        public string Module { get; set; }
        public string EventMode { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string TenorType { get; set; }
        public string CCS_ACCT { get; set; }
        public string FacNo { get; set; }
        public string FlagDue { get; set; }
        public string Ccy { get; set; }
        public double? RevAccru { get; set; }
    }
}
