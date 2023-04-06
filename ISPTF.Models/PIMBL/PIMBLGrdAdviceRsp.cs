using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMBL
{
    public class PIMBLGrdAdviceRsp
    {
        public string ADNumber { get; set; }
        public string BLCcy { get; set; }
        public double? BLAmount { get; set; }
        public string NegoRefno { get; set; }
        public DateTime EventDate { get; set; }
        public string AdviceResult { get; set; }
        public string CustCode { get; set; }
        public string LCNumber { get; set; }
        public string BLNumber { get; set; }
        public string RecStatus { get; set; }
        public string BLStatus { get; set; }
        public string RecType { get; set; }
    }
}
