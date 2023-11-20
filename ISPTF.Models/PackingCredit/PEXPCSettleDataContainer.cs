using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPCSettleDataContainer
    {
        public pExpc PEXPC { get; set; }
        public pPayment PPAYMENT { get; set; }
        public pExpcOrder[] PEXPCORDER { get; set; }
    }
}
