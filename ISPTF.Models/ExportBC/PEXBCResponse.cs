using System.Collections.Generic;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<PEXBCRsp> Data { get; set; }
    }
}
