using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.ExportBC;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCPPaymentRspGL
    {
        public string VoucherID { get; set; }
        public PEXBCPPaymentRsp PEXBC { get; set; }
    //    public PPaymentRsp PPayment{ get; set; }
    }
}
