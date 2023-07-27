using System.Collections.Generic;

namespace ISPTF.Models.ImportTR
{
    public class Q_IMTR_Issue_ListSelect_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public Q_IMTR_IssueListSelect_JSON_rsp Data { get; set; }
        //public int Total { get; set; }
        //public int Page { get; set; }
        //public int TotalPage { get; set; }
    }
}
