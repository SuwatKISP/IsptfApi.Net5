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
    public class PEXBC_PSWExport_PEXDOC_Rsp
    {
        public PEXBCRsp PEXBC { get; set; }
        public PSWExportRsp PSWEXPORT { get; set; }
        public PEXDOCRsp[] PEXDOC { get; set; }
    }
}
