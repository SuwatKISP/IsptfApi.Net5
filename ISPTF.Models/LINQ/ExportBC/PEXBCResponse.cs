using ISPTF.Models.ExportBC;
using System.Collections.Generic;

namespace ISPTF.Models
{
    public class PEXBCResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXBCDataContainer Data { get; set; }
    }
}
