using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveAmend_ListType_req
    {
        public string? ListType {get; set;}
        public string? LoadLC { get; set; }
        public int? TxAmendSeq { get; set; }
        public string? LbAmdType { get; set; }
        public int? LbPeriod { get; set; }
    }
}
