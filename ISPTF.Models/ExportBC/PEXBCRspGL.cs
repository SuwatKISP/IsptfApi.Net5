using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCRspGL : PEXBC
    {
        public string VoucherID { get; set; }
        public PEXBCRsp PEXBC { get; set; }
    //    public PPaymentRsp PPayment{ get; set; }
    }
}
