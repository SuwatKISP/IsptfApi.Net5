using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PExinterest
    {
        public string Login { get; set; }
        public string Event { get; set; }
        public string DocNo { get; set; }
        public int EventNo { get; set; }
        public int Seqno { get; set; }
        public DateTime? CalDate { get; set; }
        public DateTime? IntFrom { get; set; }
        public DateTime? IntTo { get; set; }
        public int? IntDay { get; set; }
        public string IntCode { get; set; }
        public double? Spread { get; set; }
        public double? IntRate { get; set; }
        public double? CurIntRate { get; set; }
        public int? BaseDay { get; set; }
        public string Ccy { get; set; }
        public double? BalCcy { get; set; }
        public double? IntCcy { get; set; }
        public double? IntAmt { get; set; }
        public double? IntExchRate { get; set; }
        public string CenterId { get; set; }
    }
}
