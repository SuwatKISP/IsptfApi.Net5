using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveExtendDueDate_JSON_rsp
    {
        public IMTR_SaveIssue_pIMTR_req pIMTR {get; set;}
        public IMTR_Save_pPayment_req pPayment { get; set; }
        public Q_IMTR_Select_DefaultRate_rsp DefaultRate { get; set; }
    }
}
