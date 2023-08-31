using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PEXDoc;
using ISPTF.Models.PSWExport;
namespace ISPTF.Models
{
    public class PEXLCSaveRequest
    {
        public pExlc PEXLC { get; set; }
        public PSWExportCoveringReq PSWEXPORT { get; set; }
        public PEXDOCReq[] PEXDOC { get; set; }

    }
}
