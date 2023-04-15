using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class EXLCAcceptTermDueListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCAcceptTermDueListPageRsp> Data { get; set; }
    }
}
