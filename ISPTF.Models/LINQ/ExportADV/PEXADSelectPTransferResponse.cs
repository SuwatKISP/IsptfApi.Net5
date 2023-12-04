using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportADV
{
    public class PEXADSelectPTransferResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXADSelectPTransferDataContainer Data { get; set; }
    }
}
