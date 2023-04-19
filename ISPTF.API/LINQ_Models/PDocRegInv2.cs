using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PDocRegInv2
    {
        public string RegDocno { get; set; }
        public int? RegDocseq { get; set; }
        public string CustCode { get; set; }
        public string InvNumber { get; set; }
        public double? InvAmount { get; set; }
        public double? InvUse { get; set; }
    }
}
