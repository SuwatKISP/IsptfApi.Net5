using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_ReleaseReverseTR_pIMTR_req
    {
        public string RefNumber { get; set; }
        public string RecType { get; set; }
        public int TRSeqno { get; set; }
        public string TRNumber { get; set; }
        public string? UserCode { get; set; }
        public double? BLInterest { get; set; }
        public string? TRCCyFlag { get; set; }
        public double? BLIntAmt { get; set; }
        public string? PayFlag { get; set; }
        public double? ExchRate { get; set; }
        public double? FBCharge { get; set; }
        public double? FBInterest { get; set; }
    }
}
