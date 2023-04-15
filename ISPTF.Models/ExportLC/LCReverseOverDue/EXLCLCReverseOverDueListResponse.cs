using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class EXLCLCReverseOverDueListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCLCReverseOverDueListPageRsp> Data { get; set; }
    }
}
