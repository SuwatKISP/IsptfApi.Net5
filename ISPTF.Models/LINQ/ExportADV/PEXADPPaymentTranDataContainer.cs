using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportADV
{
    public class PEXADPPaymentTranDataContainer
    {
        public pExad PEXAD { get; set; }
        public pTransfer PTRANSFER { get; set; }
        public pPayment PPAYMENT { get; set; }
    }
}
