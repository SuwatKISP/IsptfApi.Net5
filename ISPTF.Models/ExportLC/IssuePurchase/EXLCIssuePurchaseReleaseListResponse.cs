using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class EXLCIssuePurchaseReleaseListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCIssueEditPageRsp> Data { get; set; }
    }
}
