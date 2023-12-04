using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class Q_IMLC_CollectRefund_Select_SomeMasterData_rsp
    {
        public string? LCNumber { get; set; }
        public string? RecType { get; set; }
        public double? CommAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? OtherAmt { get; set; }
        public double? PostageAmt { get; set; }

    }
}
