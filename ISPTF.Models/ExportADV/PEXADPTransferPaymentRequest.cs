using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportADV
{
    public class PEXADPTransferPaymentRequest
    {
        public pExad pExad { get; set; }
        public pTransfer pTransfer { get; set; }
        public pPayment pPayment { get; set; }
    }
}
