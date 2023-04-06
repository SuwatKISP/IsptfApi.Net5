using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.ExportLC
{
    public class PEXLCPPaymentRsp
    {
        public PEXLCRsp PEXLC { get; set; }
        public PPaymentRsp PPAYMENT{ get; set; }
    }
}
