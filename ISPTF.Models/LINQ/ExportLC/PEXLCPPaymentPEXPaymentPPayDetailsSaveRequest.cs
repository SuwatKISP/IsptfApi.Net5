using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class PEXLCPPaymentPEXPaymentPPayDetailsSaveRequest
    {
        public pExlc PEXLC { get; set; }
        public pPayment PPAYMENT { get; set; }
        public pExPayment PEXPAYMENT { get; set; }
     //   public pPayDetail[] PPAYDETAILS { get; set; }
    }
}
