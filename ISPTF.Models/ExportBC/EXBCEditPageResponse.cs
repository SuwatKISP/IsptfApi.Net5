using System.Collections.Generic;

namespace ISPTF.Models.ExportBC
{
    public class EXBCEditPageResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXBCEditPageRsp> Data { get; set; }
        public int Page { get; set; }
        public int Total { get; set; }
        public int TotalPage { get; set; }
    }
}
