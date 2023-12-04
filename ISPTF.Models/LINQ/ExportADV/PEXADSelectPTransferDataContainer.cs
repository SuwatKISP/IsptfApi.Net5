using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportADV
{
    public class PEXADSelectPTransferDataContainer
    {
        public pTransfer PTRANSFER { get; set; }
        public pPayment PPAYMENT { get; set; }
        public string ADVICE_Type { get; set; }

    }
}
