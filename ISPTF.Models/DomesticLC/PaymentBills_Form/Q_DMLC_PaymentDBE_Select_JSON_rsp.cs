using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_PaymentDBE_Select_JSON_rsp
    {
        public Q_DMLC_PaymentDBE_Select_pDOMBE_rsp pDOMBE { get; set; }
        public Q_DMLC_PaymentDBE_Select_SearchCust_rsp SearchCust { get; set; }
        public Q_DMLC_PaymentDBE_Select_pIMPayment_rsp pIMPayment { get; set; }
        public Q_DMLC_PaymentDBE_Select_pPayment_rsp pPayment { get; set; }
        public Q_DMLC_PaymentDBE_Select_pDOMBEMaster_rsp pDOMBEMaster { get; set; }
        public Q_DMLC_PaymentDBE_Select_pSWImport_rsp pSWImport { get; set; }
        public Q_DMLC_PaymentDBE_Select_CustAcNo_rsp CustAcNo { get; set; }
        public Q_DMLC_PaymentDBE_Select_OtherData_rsp OtherData { get; set; }

    }
}
