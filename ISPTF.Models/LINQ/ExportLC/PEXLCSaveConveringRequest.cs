using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PEXDoc;
using ISPTF.Models.PSWExport;
namespace ISPTF.Models
{
    public class PEXLCSaveCoveringRequest
    {
        public pExlc PEXLC { get; set; }
        public pSWExport PSWEXPORT { get; set; }
        public pExdoc[] PEXDOC { get; set; }
    }
}
