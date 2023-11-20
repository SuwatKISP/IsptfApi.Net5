using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SavePaymentDBE_JSON_req
    {
        public DMLC_SavePaymentDBE_ListType_req ListType { get; set; }
        public Q_DMLC_PaymentDBE_Select_pDOMBE_rsp pDOMBE { get; set; }
        public Q_DMLC_PaymentDBE_Select_pIMPayment_rsp pIMPayment { get; set; }
        public Q_DMLC_PaymentDBE_Select_pPayment_rsp pPayment { get; set; }
        public Q_DMLC_PaymentDBE_Select_pSWImport_rsp pSWImport { get; set; }
    }
}
