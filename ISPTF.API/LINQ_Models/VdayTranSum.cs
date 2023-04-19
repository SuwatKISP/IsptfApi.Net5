using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class VdayTranSum
    {
        public string Module { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double? Comm { get; set; }
        public double? Discount { get; set; }
        public double? IntDelay { get; set; }
    }
}
