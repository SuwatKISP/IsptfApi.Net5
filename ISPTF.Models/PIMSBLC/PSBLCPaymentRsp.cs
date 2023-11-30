using ISPTF.Models.PPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMSBLC
{
    public class PSBLCPaymentRsp
    {
        public PIMSBLC PIMSBLC { get; set; }
        public PPaymentRsp PPayment { get; set; }

    }
}
