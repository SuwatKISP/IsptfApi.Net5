using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class EXLCIssuePurchaseNewListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCIssueNewPageRsp> Data { get; set; }
    }
}
