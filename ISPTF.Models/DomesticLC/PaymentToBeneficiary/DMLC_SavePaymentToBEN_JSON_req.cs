using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SavePaymentToBEN_JSON_req
    {
        public DMLC_SavePaymentToBEN_ListType_req ListType { get; set; }
        public DMLC_SavePaymentToBEN_pDOMBE_req pDOMBE { get; set; }
        public DMLC_SavePaymentToBEN_pPayment_req pPayment { get; set; }
    }
}
