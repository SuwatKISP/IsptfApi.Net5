using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class TmpExchange
    {
        public DateTime? TexchDate { get; set; }
        public string TexchTime { get; set; }
        public string TexchCcy { get; set; }
        public double? TexchBnbuy { get; set; }
        public double? TexchBnsell { get; set; }
        public double? TexchTrate1 { get; set; }
        public double? TexchTrate2 { get; set; }
        public double? TexchTrate3 { get; set; }
    }
}
