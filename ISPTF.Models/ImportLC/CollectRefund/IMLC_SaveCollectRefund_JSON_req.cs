using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveCollectRefund_JSON_req
    {
        public IMLC_SaveCollectRefund_pIMLC_req pIMLC { get; set; }
        public IMLC_SaveCollectRefund_pPayment_req pPayment { get; set; }
    }
}
