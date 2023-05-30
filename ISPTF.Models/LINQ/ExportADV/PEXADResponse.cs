using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ISPTF.Models;

namespace ISPTF.Models.ExportADV
{
    public class PEXADResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXADDataContainer Data { get; set; }
    }
}
