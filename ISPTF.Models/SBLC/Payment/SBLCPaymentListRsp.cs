using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.SBLC
{
    public class SBLCPaymentListRsp
    {
        public int? RCount { get; set; }
        public string? SBLCNumber { get; set; }
        public int? SBLCSeqno { get; set; }
        public string? RecType { get; set; }
        public string? Event { get; set; }
        public string? CustCode { get; set; }
        public string? Cust_Name { get; set; }
        public DateTime? EventDate { get; set; }
        public string? RecStatus { get; set; }
        public string? SBLCCcy { get; set; }
        public double? SBLCBal { get; set; }

    }
}
