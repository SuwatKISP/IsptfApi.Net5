using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class TmpCcsmaster
    {
        public DateTime Tdate { get; set; }
        public string Tmodule { get; set; }
        public string TkeyNumber { get; set; }
        public string TcustCode { get; set; }
        public string Tccy { get; set; }
        public double? Tcredit { get; set; }
        public double? Tbalance { get; set; }
        public string TfacNo { get; set; }
        public double? Tinterest { get; set; }
        public string TaccNo { get; set; }
        public string Tcrtype { get; set; }
    }
}
