using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBL
{
    public class IMBLCollectRefundListRsp
    {
        public int? RCount { get; set; }
        public string? ADNumber { get; set; }
        public string? BLNumber { get; set; }
        public int? BLSeqno { get; set; }
        public string? RecType { get; set; }
        public string? Event { get; set; }
        public string? CustCode { get; set; }
        public string? Cust_Name { get; set; }
        public DateTime? EventDate { get; set; }
        public string? LCNumber { get; set; }
        public string? RecStatus { get; set; }
        public string? BLCcy { get; set; }
        public double? BLAmount { get; set; }

    }
}
