using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models
{
    public class EXLCIssueCollectResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public List<PDocRegister> Data { get; set; }
    }
}
