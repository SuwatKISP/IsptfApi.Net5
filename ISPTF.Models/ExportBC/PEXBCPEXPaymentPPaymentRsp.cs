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
    public class PEXBCPEXPaymentPPaymentRsp
    {
        public PEXBCRsp PEXBC { get; set; }
        public PEXPaymentRsp PEXPayment { get; set; }
        public PPaymentRsp PPayment { get; set; }
    }
}
