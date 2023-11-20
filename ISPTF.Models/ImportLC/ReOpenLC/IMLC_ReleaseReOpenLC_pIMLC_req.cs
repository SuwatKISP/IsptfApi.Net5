using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_ReleaseReOpenLC_pIMLC_req
    {
        public string? CenterID { get; set; }
        public string LCNumber { get; set; }
        public int? LCSeqno { get; set; }
        public string? UserCode { get; set; }
        public double? LCAvalBal { get; set; }

    }
}
