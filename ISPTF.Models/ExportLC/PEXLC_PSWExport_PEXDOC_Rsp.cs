//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PEXDoc;
using ISPTF.Models.PSWExport;

namespace ISPTF.Models.ExportLC
{
    public class PEXLC_PSWExport_PEXDOC_Rsp
    {
        public PEXLCRsp PEXLC { get; set; }
        public PSWExportRsp PSWEXPORT { get; set; }
        public PEXDOCRsp[] PEXDOC { get; set; }
    }
}
