using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_ReleasePaymentToBEN_JSON_req
    {
        public DMLC_ReleasePaymentToBEN_ListType_req ListType { get; set; }
        public DMLC_ReleasePaymentToBEN_pDOMBE_req pDOMBE { get; set; }
    }
}
