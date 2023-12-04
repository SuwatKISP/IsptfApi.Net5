using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SaveAcceptRefuseDisc_JSON_req
    {
        public DMLC_SaveAcceptRefuseDisc_ListType_req ListType { get; set; }
        public DMLC_SaveAcceptRefuseDisc_pDOMBE_req pDOMBE { get; set; }
    }
}
