using System.Collections.Generic;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveSWIFT_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public IMTR_SaveSWIFT_JSON_rsp Data { get; set; }
    }
}
