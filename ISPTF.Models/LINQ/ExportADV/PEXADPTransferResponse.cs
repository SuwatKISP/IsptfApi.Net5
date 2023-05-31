using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportADV
{
    public class PEXADPTransferResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXADPTransferDataContainer Data { get; set; }
    }
}
