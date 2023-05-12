using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.ExportBC;
using ISPTF.Models.PEXPayment;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.PurchasePayment
{
    public class PEXBCPEXPaymentRsp
    {
        public PEXBCRsp PEXBC { get; set; }
        public PPaymentRsp PPAYMENT { get; set; }
        public PEXPaymentRsp PEXPAYMENT { get; set; }
    }
}
