using ISPTF.Models.ExportBC;
using System.Collections.Generic;

namespace ISPTF.Models
{
    public class PEXBCVouchIdResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXBCVouchIdDataContainer Data { get; set; }
    }
}
