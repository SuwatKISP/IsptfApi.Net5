using System.Collections.Generic;

namespace ISPTF.Models.ImportLC
{
    public class Q_IMLC_AmendLC_Amount_NewPage_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_IMLC_AmendLC_Amount_NewPage_rsp> Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
    }
}
