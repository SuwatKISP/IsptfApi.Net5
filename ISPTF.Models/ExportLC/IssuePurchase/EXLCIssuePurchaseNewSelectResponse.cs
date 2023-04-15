using ISPTF.Models.LoginRegis;
using System.Collections.Generic;

namespace ISPTF.Models.ExportLC
{
    public class EXLCIssuePurchaseNewSelectResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<PDocRegister> Data { get; set; }
    }
}
