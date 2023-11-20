using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_ReleaseCollectRefund_pIMLC_req 
    {
        public string? CenterID { get; set; }
        public string LCNumber { get; set; }
        public int? LCSeqno { get; set; }
        public string? UserCode { get; set; }
        public string? CollectRefund { get; set; }
        public string? LastReceiptNo { get; set; }
        public double? CommAmt { get; set; }
        public double? CableAmt { get; set; }
        public string? PostageAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? OtherAmt { get; set; }

    }
}
