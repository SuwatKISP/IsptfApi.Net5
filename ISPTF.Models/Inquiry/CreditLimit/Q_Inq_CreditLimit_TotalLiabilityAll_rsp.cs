using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Inquiry
{
    public class Q_Inq_CreditLimit_TotalLiabilityAll_rsp
    {
        public double? TotOrigin { get; set; }
        public double? TotCredit { get; set; }
        public double? TotLiab { get; set; }
        public double? TotAppv { get; set; }
        public double? TotShare { get; set; }
        public double? TotHoldAmt { get; set; }
        public double? TotTotal { get; set; }
        public double? TotAvailable { get; set; }
        public double? TotOver { get; set; }
        public double? TotSusp { get; set; }
        public double? TotGroup { get; set; }
    }
}
