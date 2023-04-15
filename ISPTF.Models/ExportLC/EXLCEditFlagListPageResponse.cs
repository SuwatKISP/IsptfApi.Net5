using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class EXLCEditFlagListPageResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCEditFlagListPageRsp> Data { get; set; }
    }
}
