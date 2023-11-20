using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_CollectRefundBE_Select_pDOMBEMaster_rsp
    {
        public string? BENumber { get; set; }
        public string? RecType { get; set; }
        public double? M_NegoAmt { get; set; }
        public double? M_OverAmt { get; set; }
        public double? M_CableAmt { get; set; }
        public double? M_DutyAmt { get; set; }
        public double? M_PayableAmt { get; set; }
        public double? M_CommOther { get; set; }
        public double? M_CommTran { get; set; }
        public double? M_CommCertify { get; set; }
        public double? M_CommEngage { get; set; }
        public double? M_Discfee { get; set; }

    }
}
