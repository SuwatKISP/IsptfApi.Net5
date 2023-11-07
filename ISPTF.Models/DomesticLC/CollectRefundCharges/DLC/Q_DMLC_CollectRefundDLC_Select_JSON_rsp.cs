using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_CollectRefundDLC_Select_JSON_rsp
    {
        public Q_DMLC_CollectRefundDLC_Select_pDOMLC_rsp pDOMLC { get; set; }
        public Q_DMLC_CollectRefundDLC_Select_pPayment_rsp pPayment { get; set; }
        public Q_DMLC_CollectRefundDLC_Select_SearchCust_rsp SearchCust { get; set; }
        public Q_DMLC_CollectRefundDLC_Select_pDOMLCMaster_rsp pDOMLCMaster { get; set; }
        public Q_DMLC_CollectRefundDLC_Select_txSeq_rsp txSeq { get; set; }
    }
}
