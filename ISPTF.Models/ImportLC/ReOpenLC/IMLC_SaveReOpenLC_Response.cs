using System.Collections.Generic;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveReOpenLC_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public IMLC_SaveReOpenLC_JSON_rsp Data { get; set; }
    }
}
