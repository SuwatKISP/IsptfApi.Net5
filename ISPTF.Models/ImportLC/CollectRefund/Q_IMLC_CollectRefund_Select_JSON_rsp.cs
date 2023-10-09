using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.ImportLC
{
    public class Q_IMLC_CollectRefund_Select_JSON_rsp
    {
        public Q_IMLC_CollectRefund_Select_pIMLC_rsp pIMLC { get; set; }
        public Q_IMLC_CollectRefund_Select_SearchCust_rsp SearchCust { get; set; }
        public Q_IMLC_CollectRefund_Select_SomeMasterData_rsp SomeMasterData { get; set; }
        public Q_IMLC_CollectRefund_Select_pPayment_rsp pPayment { get; set; }

    }
}
