using System.Collections.Generic;
using ISPTF.Models.PurchasePayment;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCPEXPaymentResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXBCPPaymentRsp Data { get; set; }
    }
}
