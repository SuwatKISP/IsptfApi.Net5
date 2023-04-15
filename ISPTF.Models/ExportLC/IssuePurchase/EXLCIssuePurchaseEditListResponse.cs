using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class EXLCIssuePurchaseEditListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCIssueEditPageRsp> Data { get; set; }
    }
}