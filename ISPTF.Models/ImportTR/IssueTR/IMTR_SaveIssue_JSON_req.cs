﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveIssue_JSON_req
    {
        public IMTR_SaveIssue_ListType_req ListType { get; set; }
        public pIMTR pIMTR { get; set; }
        //public IMTR_SaveIssue_pIMTR_req pIMTR {get; set;}
        public IMTR_Save_pPayment_req pPayment { get; set; }
        public IMTR_SaveIssue_pSWImport_req pSWImport { get; set; }
    }
}
