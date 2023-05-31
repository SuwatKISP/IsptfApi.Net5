using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TmpCCSMaster
    {
        public DateTime TDate { get; set; }
        public string TModule { get; set; }
        public string TKeyNumber { get; set; }
        public string TCustCode { get; set; }
        public string TCcy { get; set; }
        public double? TCredit { get; set; }
        public double? TBalance { get; set; }
        public string TFacNo { get; set; }
        public double? TInterest { get; set; }
        public string TAccNo { get; set; }
        public string TCRType { get; set; }
    }
}
