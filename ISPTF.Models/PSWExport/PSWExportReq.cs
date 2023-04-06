using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PSWExport
{
    public class PSWExportReq : PSWExport
    {
        public string? TX30 { get; set; }
        public string? TX31C { get; set; }
        public string? TX799 { get; set; }
        public string? TX999 { get; set; }

    }
}
