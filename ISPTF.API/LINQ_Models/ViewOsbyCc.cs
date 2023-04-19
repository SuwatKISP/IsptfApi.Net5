using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewOsbyCc
    {
        public string Custcode { get; set; }
        public string Flagdue { get; set; }
        public string Facno { get; set; }
        public string CcsAcct { get; set; }
        public string CcsLmtype { get; set; }
        public string Module { get; set; }
        public string Ccy { get; set; }
        public double? BalAmt { get; set; }
        public double? RateMidRate { get; set; }
        public double? OutstdAmtThb { get; set; }
    }
}
