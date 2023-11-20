using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_ReleaseRevAllPayment_pIMTR_req
    {
        public string RefNumber { get; set; }
        public string RecType { get; set; }
        public int TRSeqno { get; set; }
        public string TRNumber { get; set; }
        public string? UserCode { get; set; }
        public DateTime? LastIntDate { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public double? IntBalance { get; set; }
        public double? TRBalance { get; set; }
        public double? AccruPending { get; set; }
        public string? TRDueStatus { get; set; }
        public string? PayFlag { get; set; }
        

    }
}
