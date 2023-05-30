using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TmpExchange
    {
        public DateTime? TExchDate { get; set; }
        public string TExchTime { get; set; }
        public string TExchCcy { get; set; }
        public double? TExchBNBuy { get; set; }
        public double? TExchBNSell { get; set; }
        public double? TExchTRate1 { get; set; }
        public double? TExchTRate2 { get; set; }
        public double? TExchTRate3 { get; set; }
    }
}
