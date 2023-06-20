using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPCPPaymentResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXPCPPaymentDataContainer Data { get; set; }
    }
}
