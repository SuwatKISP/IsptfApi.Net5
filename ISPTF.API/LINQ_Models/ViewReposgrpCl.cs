using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewReposgrpCl
    {
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string Bd { get; set; }
        public string Facno { get; set; }
        public string LimitCode { get; set; }
        public string Module { get; set; }
        public double LimitAmt { get; set; }
        public double BalAmtThb { get; set; }
        public double ShareAmt { get; set; }
        public double HoldAmt { get; set; }
        public double AvlAmt { get; set; }
        public double? NetAvlAmt { get; set; }
        public string Flagdue { get; set; }
        public string FlagShare { get; set; }
    }
}
