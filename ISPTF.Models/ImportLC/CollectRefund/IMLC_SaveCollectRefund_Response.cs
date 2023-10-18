using System.Collections.Generic;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveCollectRefund_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public IMLC_SaveCollectRefund_JSON_rsp Data { get; set; }
    }
}
