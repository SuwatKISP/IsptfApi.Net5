using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.ExportBC;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCPPaymentRsp
    {
        public PEXBCRsp PEXBC { get; set; }
        public PPaymentRsp PPayment{ get; set; }

    }
}
