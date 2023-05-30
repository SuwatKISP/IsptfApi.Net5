using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models.ExportADV;

namespace ISPTF.Models.ExportADV
{
    public class PEXADPPaymentResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXADPPaymentDataContainer Data { get; set; }
    }
}
