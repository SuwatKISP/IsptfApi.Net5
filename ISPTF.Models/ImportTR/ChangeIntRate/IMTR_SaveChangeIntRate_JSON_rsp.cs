using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveChangeIntRate_JSON_rsp
    {
        public Q_IMTR_Select_pIMTR_rsp pIMTR {get; set;}
        public Q_IMTR_Select_pIMInterest_rsp pIMInterest { get; set; }

    }
}
