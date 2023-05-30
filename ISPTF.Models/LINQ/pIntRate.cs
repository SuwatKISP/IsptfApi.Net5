using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pIntRate
    {
        public string IRate_Code { get; set; }
        public DateTime IRate_EffDate { get; set; }
        public string IRate_EffTime { get; set; }
        public double? IRate_Rate { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string Batch { get; set; }
    }
}
