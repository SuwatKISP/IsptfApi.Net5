using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MCustRate
    {
        public string DefCust { get; set; }
        public string DefMod { get; set; }
        public string DefExp { get; set; }
        public string DefType { get; set; }
        public double? DefRate { get; set; }
        public int? DefBase { get; set; }
        public double? DefMax { get; set; }
        public double? DefMin { get; set; }
        public string RecStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
