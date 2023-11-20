using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_AcceptRefuseDisc_Select_JSON_rsp
    {
        public Q_DMLC_AcceptRefuseDisc_Select_pDOMBE_rsp pDOMBE { get; set; }
        public Q_DMLC_AcceptRefuseDisc_Select_IssueExpiryM_rsp IssueExpiryM { get; set; }
        public Q_DMLC_AcceptRefuseDisc_Select_txSeq_rsp txSeq { get; set; }
    }
}
