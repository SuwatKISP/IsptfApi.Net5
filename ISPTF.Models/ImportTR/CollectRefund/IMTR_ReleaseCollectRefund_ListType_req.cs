using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_ReleaseCollectRefund_ListType_req
    {
        public string? OpCollect { get; set; }
        public double? txFBBaht { get; set;}
        public double? txDFBBaht1 { get; set;}
        public double? txFBIntBaht { get; set; }
        public double? txDFBIntBaht1 { get; set; }

    }
}
