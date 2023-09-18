using System.Collections.Generic;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveNOTIssue_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public IMLC_SaveNOTIssue_JSON_rsp Data { get; set; }
    }
}
