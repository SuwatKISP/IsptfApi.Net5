using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pDocRegInv2
    {
        public string Reg_Docno { get; set; }
        public int? Reg_Docseq { get; set; }
        public string CustCode { get; set; }
        public string InvNumber { get; set; }
        public double? InvAmount { get; set; }
        public double? InvUse { get; set; }
    }
}
