using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_DeleteRevAllPayment_pIMTR_req
    {
        public string RefNumber { get; set; }
        public int TRSeqno { get; set; }
        public string TRNumber { get; set; }
        public string? UserCode { get; set; }
        public DateTime? EventDate { get; set; }
        public string? TRDueStatus { get; set; }
        public string? PayFlag { get; set; }
    }
}
