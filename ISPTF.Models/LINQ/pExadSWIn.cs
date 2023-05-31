using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pExadSWIn
    {
        public string SwifInID { get; set; }
        public DateTime? AdviseDate { get; set; }
        public string LCNo { get; set; }
        public string LCFlag { get; set; }
        public string LCCcy { get; set; }
        public double? LCAmt { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string ExpiryPlace { get; set; }
        public DateTime? ShipDate { get; set; }
        public string BenName { get; set; }
        public string Appicant { get; set; }
        public string IssueBank { get; set; }
        public string IssueName { get; set; }
        public string GoodsDesc { get; set; }
        public string RecStatus { get; set; }
        public string MTType { get; set; }
    }
}
