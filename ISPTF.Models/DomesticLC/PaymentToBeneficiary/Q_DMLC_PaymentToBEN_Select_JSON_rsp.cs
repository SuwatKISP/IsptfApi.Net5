using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_PaymentToBEN_Select_JSON_rsp
    {
        public Q_DMLC_PaymentToBEN_Select_pDOMBE_rsp pDOMBE { get; set; }
        public Q_DMLC_PaymentToBEN_Select_pPayment_rsp pPayment { get; set; }
        public Q_DMLC_PaymentToBEN_Select_SeqBenNew_rsp SeqBenNew { get; set; }
    }
}
