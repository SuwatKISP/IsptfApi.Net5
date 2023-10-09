using System.Collections.Generic;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SavePayment_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public IMTR_SavePayment_JSON_rsp Data { get; set; }
    }
}
