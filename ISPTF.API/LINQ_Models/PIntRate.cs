using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PIntRate
    {
        public string IrateCode { get; set; }
        public DateTime IrateEffDate { get; set; }
        public string IrateEffTime { get; set; }
        public double? IrateRate { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string Batch { get; set; }
    }
}
