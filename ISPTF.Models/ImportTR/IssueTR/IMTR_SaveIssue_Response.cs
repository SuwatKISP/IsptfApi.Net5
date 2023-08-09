using System.Collections.Generic;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveIssue_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public IMTR_SaveIssue_JSON_rsp Data { get; set; }
    }
}
