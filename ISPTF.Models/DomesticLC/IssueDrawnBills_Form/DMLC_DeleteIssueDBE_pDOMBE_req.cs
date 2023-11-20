using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_DeleteIssueDBE_pDOMBE_req
    {
        public string? BENumber { get; set; }
        public string? RecType { get; set; }
        public int? BESeqno { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
        public string? DLCNumber { get; set; }
        public string? CustCode { get; set; }
        public string? BECcy { get; set; }
        public double? BEAmount { get; set; }
        public string? UserCode { get; set; }
    }
}

