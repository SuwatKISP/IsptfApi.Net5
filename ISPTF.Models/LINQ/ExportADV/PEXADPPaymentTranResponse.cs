using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models.ExportADV;

namespace ISPTF.Models.ExportADV
{
    public class PEXADPPaymentTranResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXADPPaymentTranDataContainer Data { get; set; }
    }
}
