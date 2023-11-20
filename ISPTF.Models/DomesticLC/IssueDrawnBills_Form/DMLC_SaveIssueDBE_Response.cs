using System.Collections.Generic;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SaveIssueDBE_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public DMLC_SaveIssueDBE_JSON_rsp Data { get; set; }
    }
}
