using ISPTF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class EXBCPaymentResponse
    {
        public pExbc PEXBC { get; set; }
        public pPayment PPAYMENT { get; set; }
    }
}
