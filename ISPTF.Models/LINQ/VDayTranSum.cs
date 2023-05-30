using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class VDayTranSum
    {
        public string Module { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double? COMM { get; set; }
        public double? DISCOUNT { get; set; }
        public double? IntDelay { get; set; }
    }
}
