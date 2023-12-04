using ISPTF.Models.ImportTR;
using System.Collections.Generic;

namespace ISPTF.Models
{
    public class IMBLQueryListPageResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_IMBLQueryListPageRsp> Data { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public int TotalPage { get; set; }
    }
}
