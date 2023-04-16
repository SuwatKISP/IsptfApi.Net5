using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportLC.PaymentOverDue
{
    public class EXLCPaymentOverDueSelectResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXLCPEXPaymentRsp Data { get; set; }
    }
}
