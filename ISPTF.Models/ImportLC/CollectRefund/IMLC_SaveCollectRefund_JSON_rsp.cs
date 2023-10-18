using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveCollectRefund_JSON_rsp
    {
        public Q_IMLC_CollectRefund_Select_pIMLC_rsp pIMLC { get; set; }
        public Q_IMLC_CollectRefund_Select_pPayment_rsp pPayment { get; set; }
    }
}
