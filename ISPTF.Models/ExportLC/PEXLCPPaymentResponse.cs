using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class PEXLCPPaymentResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXLCPPaymentRsp Data { get; set; }
    }
}
