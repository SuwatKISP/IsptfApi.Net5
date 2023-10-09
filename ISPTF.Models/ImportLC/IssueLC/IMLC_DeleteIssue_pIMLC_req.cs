using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_DeleteIssue_pIMLC_req
    {
        public string? LCNumber { get; set; }
        public int? LCSeqno { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? UserCode { get; set; }
        public string? ConfirmRequest { get; set; }
}
}
