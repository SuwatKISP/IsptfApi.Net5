using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class EXLCPaymentPastDueWREFListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCPaymentPastDueWREFListPageRsp> Data { get; set; }
    }
}
