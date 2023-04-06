using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models;
using ISPTF.Models.ImportBC;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.ImportBC
{
    public class PIMBCPPaymentRsp2
    {
        public string VoucherID { get; set; }
        public PIMBCPPaymentRsp PIMBC { get; set; }
        //public PIMBCRsp PIMBC { get; set; }
        //public PPaymentRsp PPayment { get; set; }
    }
}
