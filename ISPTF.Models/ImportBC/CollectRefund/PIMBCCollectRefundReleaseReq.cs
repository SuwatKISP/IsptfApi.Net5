using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBC
{
    public class PIMBCCollectRefundReleaseReq
    {
        public string BCNumber { get; set; }
        public string BCSeqno { get; set; }
        public string CustCode { get; set; }
        public string PayMethod { get; set; }
        public string RpCustAc1 { get; set; }
        public double? RpCustAmt1 { get; set; }
        public string RpCustAc2 { get; set; }
        public double? RpCustAmt2 { get; set; }
        public string RpCustAc3 { get; set; }
        public double? RpCustAmt3 { get; set; }

    }
}
