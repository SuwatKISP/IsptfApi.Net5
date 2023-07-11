using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Inquiry
{
    public class Q_Inq_CreditLimit_TotalLiability_rsp
    {
        //public string? Cust_Code { get; set; }
        public double? TotOrigin { get; set; }
        public double? TotCredit { get; set; }
        public double? TotShare { get; set; }
        public double? TotHoldAmt { get; set; }
        public double? TotSusp { get; set; }
        public double? TotAvailable { get; set; }
        public double? TotGroup { get; set; }
    }
}
