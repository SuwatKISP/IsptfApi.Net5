using ISPTF.Models.ExportLC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class PEXLCSaveResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXLCDataContainer Data { get; set; }
    }
}
