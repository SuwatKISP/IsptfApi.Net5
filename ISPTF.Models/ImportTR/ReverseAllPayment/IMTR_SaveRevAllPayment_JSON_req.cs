using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveRevAllPayment_JSON_req
    {
        public IMTR_SaveRevAllPayment_ListTypePay_req ListTypePay { get; set; }
        public IMTR_SaveRevAllPayment_pIMTR_req pIMTR { get; set; }
        public IMTR_SaveRevAllPayment_pPayment_req pPayment { get; set; }
        public IMTR_SaveRevAllPayment_pIMPayment_req pIMPayment { get; set; }

    }
}
