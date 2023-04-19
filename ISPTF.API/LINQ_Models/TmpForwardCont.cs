using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class TmpForwardCont
    {
        public DateTime? EventDate { get; set; }
        public string Refno { get; set; }
        public string ForwardNo { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string DocCcy { get; set; }
        public double? Amount { get; set; }
        public double? ExchRate { get; set; }
        public double? AmtThb { get; set; }
        public string Flag { get; set; }
    }
}
