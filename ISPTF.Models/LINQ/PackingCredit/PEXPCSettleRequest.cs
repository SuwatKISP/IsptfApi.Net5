using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPCSettleRequest
    {
        public pExpc pExpc { get; set; }
        public pPayment pPayment { get; set; }
        public pExpcOrder[] pExpcOrder { get; set; }
    }
}
