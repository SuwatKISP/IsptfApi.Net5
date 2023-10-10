using System.Collections.Generic;

namespace ISPTF.Models
{
    public class EXLCQueryListPageResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCQueryListPageRsp> Data { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public int TotalPage { get; set; }
    }
}
