using ISPTF.Models.ImportBL;
using ISPTF.Models.PIMBL;
using ISPTF.Models.PPayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBL
{
    public class PIMBLPPaymentRsp
    {
        public pIMBL PIMBL { get; set; }
        public PPaymentRsp PPayment { get; set; }
    }
}
