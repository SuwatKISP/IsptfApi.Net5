using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PEXPayment;

namespace ISPTF.Models.ExportLC
{
    public class PEXLCPEXPaymentRsp
    {
        public PEXLCRsp PEXLC { get; set; }
        public PEXPaymentRsp PEXPAYMENT{ get; set; }
    }
}
