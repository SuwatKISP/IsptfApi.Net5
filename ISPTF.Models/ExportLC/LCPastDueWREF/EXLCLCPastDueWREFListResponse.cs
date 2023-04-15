using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class EXLCLCPastDueWREFListResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<Q_EXLCLCPastDueWREFEditPageRsp> Data { get; set; }
    }
}
