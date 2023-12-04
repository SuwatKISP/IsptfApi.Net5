using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_DeleteAmendAmount_JSON_req
    {
        public DMLC_DeleteAmendAmount_ListType_req ListType { get; set; }
        public DMLC_DeleteAmendAmount_pDOMLC_req pDOMLC { get; set; }
    }
}
