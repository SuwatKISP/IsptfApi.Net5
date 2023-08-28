using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveTROverDue_JSON_req
    {
        public IMTR_SaveIssue_pIMTR_req pIMTR {get; set;}
        public IMTR_SaveChangeIntRate_pIMInterest_req pIMInterest { get; set; }

    }
}
