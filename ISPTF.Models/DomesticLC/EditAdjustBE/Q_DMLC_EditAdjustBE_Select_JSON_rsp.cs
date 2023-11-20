using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_EditAdjustBE_Select_JSON_rsp
    {
        public Q_DMLC_EditAdjustBE_Select_pDOMBE_rsp pDOMBE { get; set; }
        public Q_DMLC_EditAdjustBE_Select_pDOMBEMaster_rsp pDOMBEMaster { get; set; }
        public Q_DMLC_EditAdjustBE_Select_txSeq_rsp txSeq { get; set; }
    }
}
