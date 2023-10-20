using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class Q_IMTR_ExtendDueDateSelect_JSON_rsp
    {
        public Q_IMTR_ExtendDueDateSelect_pIMTR_rsp pIMTR { get; set; }
        public Q_IMTR_ExtendDueDateSelect_SearchCust_rsp SearchCust { get; set; }
        public Q_IMTR_ExtendDueDateSelect_pIMTRMaster_rsp pIMTRMaster { get; set; }
        public Q_IMTR_ExtendDueDateSelect_pPayment_rsp pPayment { get; set; }
        public Q_IMTR_Select_DefaultRate_rsp DefaultRate { get; set; }
    }
}
