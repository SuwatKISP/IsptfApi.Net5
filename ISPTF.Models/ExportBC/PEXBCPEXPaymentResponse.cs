using System.Collections.Generic;
using ISPTF.Models.PurchasePayment;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCPEXPaymentResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<PEXBCPEXPaymentRsp> Data { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public int TotalPage { get; set; }
    }
}
