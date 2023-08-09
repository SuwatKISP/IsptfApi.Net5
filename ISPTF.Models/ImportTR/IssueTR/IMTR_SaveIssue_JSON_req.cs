using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveIssue_JSON_req
    {
        public IMTR_SaveIssue_pIMTR_req pIMTR {get; set;}
        public IMTR_Save_pPayment_req pPayment { get; set; }
    }
}
