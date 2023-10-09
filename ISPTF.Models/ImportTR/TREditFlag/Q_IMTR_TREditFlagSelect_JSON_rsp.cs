using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class Q_IMTR_TREditFlagSelect_JSON_rsp
    {
        public Q_IMTR_Select_pIMTR_rsp pIMTR { get; set; }
        public Q_IMTR_Select_SearchCust_rsp SearchCust { get; set; }
        public Q_IMTR_TREditFlagSelect_pIMTREditFlag_rsp PIMTREditFlag { get; set; }
    }
}
