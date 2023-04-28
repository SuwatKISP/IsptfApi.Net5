using System.Collections.Generic;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCAdviceDiscrepancyUpdateResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<PEXBCAdviceDiscrepancyUpdReq> Data { get; set; }
    }
}
