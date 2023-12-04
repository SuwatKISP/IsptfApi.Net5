using ISPTF.Models.ImportBC;
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
    public class PIMBLPPaymentRsp2
    {
        public string VoucherID { get; set; }
        public PIMBLPPaymentRsp PIMBL { get; set; }
    }
}
