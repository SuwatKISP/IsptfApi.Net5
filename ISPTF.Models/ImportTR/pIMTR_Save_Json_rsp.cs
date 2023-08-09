using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.ImportTR
{
    public class pIMTR_Save_Json_rsp
    {
        public pIMTR pIMTR { get; set; }
        public pIMInterest pIMInterest { get; set; }
        public pPayment pPayment { get; set; }
        public pSWImport pSWImport { get; set; }
    }
}
