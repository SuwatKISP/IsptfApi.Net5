using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveSWIFT_JSON_req
    {
        public IMTR_SaveSWIFT_SWIFTCutLine_req SWIFTCutLine { get; set; }
        public IMTR_SaveSWIFT_pIMTR_req pIMTR { get; set; }
        public IMTR_SaveSWIFT_pSWImport_req pSWImport { get; set; }
    }
}
