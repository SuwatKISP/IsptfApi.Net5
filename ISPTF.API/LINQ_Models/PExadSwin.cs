using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PExadSwin
    {
        public string SwifInId { get; set; }
        public DateTime? AdviseDate { get; set; }
        public string Lcno { get; set; }
        public string Lcflag { get; set; }
        public string Lcccy { get; set; }
        public double? Lcamt { get; set; }
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
        public string Mttype { get; set; }
    }
}
