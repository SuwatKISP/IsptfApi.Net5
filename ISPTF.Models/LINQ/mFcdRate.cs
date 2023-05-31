using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mFcdRate
    {
        public string Exch_Ccy { get; set; }
        public string CreateTime { get; set; }
        public DateTime CreateDate { get; set; }
        public double? Exch_Fixed { get; set; }
        public int? FixMonth { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
