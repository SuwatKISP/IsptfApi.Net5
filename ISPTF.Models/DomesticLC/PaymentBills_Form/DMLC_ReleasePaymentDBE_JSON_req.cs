using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_ReleasePaymentDBE_JSON_req
    {
        public DMLC_ReleasePaymentDBE_ListType_req ListType { get; set; }
        public DMLC_ReleasePaymentDBE_pDOMBE_req pDOMBE { get; set; }
        public DMLC_ReleasePaymentDBE_pIMPayment_req pIMPayment { get; set; }
    }
}
