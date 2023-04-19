using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MFcdRate
    {
        public string ExchCcy { get; set; }
        public string CreateTime { get; set; }
        public DateTime CreateDate { get; set; }
        public double? ExchFixed { get; set; }
        public int? FixMonth { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
