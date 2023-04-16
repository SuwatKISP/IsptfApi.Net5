using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportLC.PaymentOverDueWREF
{
    public class EXLCPaymentOverDueWREFSelectResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXLCPEXPaymentRsp Data { get; set; }
    }
}
