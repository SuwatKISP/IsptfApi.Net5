using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models
{
    public class PEXLCPPaymentSaveRequest
    {
        public pExlc PEXLC { get; set; }
        public pPayment PPAYMENT { get; set; }
    }
}
