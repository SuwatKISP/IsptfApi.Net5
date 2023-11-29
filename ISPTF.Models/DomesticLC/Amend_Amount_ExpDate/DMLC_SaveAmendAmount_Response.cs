using System.Collections.Generic;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SaveAmendAmount_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public DMLC_SaveAmendAmount_JSON_rsp Data { get; set; }
    }
}
