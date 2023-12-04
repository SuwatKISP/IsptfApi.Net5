using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_DeleteAmendAmount_pDOMLC_req
    {
        public string? DLCNumber { get; set; }
        public int? DLCSeqno { get; set; }
        public string? UserCode { get; set; }
        public string? CenterID { get; set; }
    }
}
