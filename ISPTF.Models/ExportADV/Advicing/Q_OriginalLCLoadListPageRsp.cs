using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.ExportADV
{
    public class Q_OriginalLCLoadListPageRsp

    {
        public int RCount { get; set; }
        public string? SwifInID { get; set; }
        public string? MTType { get; set; }
        public DateTime? AdviseDate { get; set; }
        public string? LCNo { get; set; }
        public string? LCFlag { get; set; }
        public string? LCCcy { get; set; }
        public double? LCAmt { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? ExpiryPlace { get; set; }
        public DateTime? ShipDate { get; set; }
        public string? BenName { get; set; }
        public string? Appicant { get; set; }
        public string? IssueBank { get; set; }
        public string? IssueName { get; set; }
        public string? GoodsDesc { get; set; }
        public string? RecStatus { get; set; }

    }
}
