using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models.ExportADV;

namespace ISPTF.Models.ExportADV
{
    public class PEXADPPaymentORIResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXADPPaymentDataORIContainer Data { get; set; }
    }
}
