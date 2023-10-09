using ISPTF.Models.LoginRegis;
using System.Collections.Generic;

namespace ISPTF.Models.PackingCredit
{
    public class EXPCIssuePCNewSelectResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public List<PDocRegister> Data { get; set; }
    }
}
