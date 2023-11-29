using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SaveAmendAmount_JSON_req
    {
        public DMLC_SaveAmendAmount_ListType_req ListType { get; set; }
        public DMLC_SaveAmendAmount_pDOMLC_req pDOMLC { get; set; }
        public DMLC_SaveAmendAmount_pPayment_req pPayment { get; set; }
    }
}
