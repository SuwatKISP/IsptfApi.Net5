using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveCollectRefund_JSON_req
    {
        public IMTR_SaveCollectRefund_ListType_req ListType { get; set; }
        public IMTR_SaveCollectRefund_pIMTR_req pIMTR { get; set; }
        public IMTR_SaveCollectRefund_pPayment_req pPayment { get; set; }
        //public IMTR_SaveRevAllPayment_pIMPayment_req pIMPayment { get; set; }

    }
}
