using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_ReleaseIssue_pIMLC_req
    {
        public string? LCNumber { get; set; }
        public string? RecType { get; set; }
        public int? LCSeqno { get; set; }
        public string? CenterID { get; set; }
        public DateTime? EventDate { get; set; }
        public string? UserCode { get; set; }
        public string? PayFlag { get; set; }
        public double? LCAmt { get; set; }
        public double? LCAvalBal { get; set; }
        public string? ConfirmRequest { get; set; }
}
}
