using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveTRPastDue_JSON_req
    {
        public IMTR_Save_ListType_req ListType { get; set; }
        public pIMTR pIMTR { get; set; }
        //public IMTR_SaveIssue_pIMTR_req pIMTR {get; set;}
        public IMTR_SaveTRPastDue_pIMInterest_req pIMInterest { get; set; }

    }
}
