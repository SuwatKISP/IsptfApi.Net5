//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PEXDoc;
using ISPTF.Models.PSWExport;

namespace ISPTF.Models.ExportBC
{
    public class PEXBC_PSWExport_PEXDOC_Req
    {
        public PEXBCReq PEXBC { get; set; }
        public PSWExportReq PSWEXPORT { get; set; }
        public PEXDOCReq[] PEXDOC { get; set; }
    }
}
