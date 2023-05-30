using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class tmp_ForwardCont
    {
        public DateTime? EventDate { get; set; }
        public string Refno { get; set; }
        public string ForwardNo { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string DocCcy { get; set; }
        public double? Amount { get; set; }
        public double? ExchRate { get; set; }
        public double? AmtTHB { get; set; }
        public string flag { get; set; }
    }
}
