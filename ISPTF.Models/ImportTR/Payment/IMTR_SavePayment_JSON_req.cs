﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SavePayment_JSON_req
    {
        public IMTR_SavePayment_ListTypePay_req ListTypePay { get; set; }
        public IMTR_SavePayment_pIMTR_req pIMTR { get; set; }
        public IMTR_SavePayment_pPayment_req pPayment { get; set; }
        public IMTR_SavePayment_pIMPayment_req pIMPayment { get; set; }

    }
}
