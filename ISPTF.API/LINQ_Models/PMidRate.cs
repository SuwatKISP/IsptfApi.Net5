using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PMidRate
    {
        public DateTime RateDate { get; set; }
        public string RateTime { get; set; }
        public string RateCcy { get; set; }
        public double? RateMidRate { get; set; }
        public double? RateReuter { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
