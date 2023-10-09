using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_ReleaseSetATSFwdRate_pIMTR_req
    {
        public string? RefNumber { get; set; }
        public string? RecType { get; set; }
        public int? TRSeqno { get; set; }
        public string? UserCode { get; set; }
        public double? ExchRate { get; set; }
        public string? CFRRate { get; set; }
        public DateTime? SettleDate { get; set; }

    }
}
