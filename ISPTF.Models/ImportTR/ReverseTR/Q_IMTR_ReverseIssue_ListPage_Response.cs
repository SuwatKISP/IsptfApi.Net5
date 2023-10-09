using System.Collections.Generic;

namespace ISPTF.Models.ImportTR
{
    public class Q_IMTR_ReverseIssue_ListPage_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_IMTR_ReverseIssue_ListPage_rsp> Data { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public int TotalPage { get; set; }
    }
}
