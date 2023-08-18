using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class Q_IMLC_ReOpenLC_Select_LCAvalBal_rsp
    {
        public string? LCNumber { get; set; }
        public string? RecType { get; set; }
        public int? LCSeqno { get; set; }
        public string? Event { get; set; }
        public double? LCAvalBal { get; set; }

    }
}
