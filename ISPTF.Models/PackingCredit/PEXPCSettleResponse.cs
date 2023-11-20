using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPCSettleResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXPCSettleDataContainer Data { get; set; }
    }
}
