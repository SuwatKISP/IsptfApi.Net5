using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PExchange
    {
        public DateTime ExchDate { get; set; }
        public string ExchTime { get; set; }
        public string ExchCcy { get; set; }
        public int? ExchSeqno { get; set; }
        public double? ExchBnbuy { get; set; }
        public double? ExchBnsell { get; set; }
        public double? ExchTrate1 { get; set; }
        public double? ExchTrate2 { get; set; }
        public double? ExchTrate3 { get; set; }
        public double? ExchAverage { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
