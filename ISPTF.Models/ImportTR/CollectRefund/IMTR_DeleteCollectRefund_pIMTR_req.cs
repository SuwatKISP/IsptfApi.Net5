using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_DeleteCollectRefund_pIMTR_req
    {
        public string RefNumber { get; set; }
        public int TRSeqno { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? UserCode { get; set; }
     }
}
