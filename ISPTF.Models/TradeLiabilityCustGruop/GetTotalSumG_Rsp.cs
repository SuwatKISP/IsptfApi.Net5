//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCustGroup

{
    public class GetTotalSumG_Rsp
    {
        public double? TotOrigin { get; set;}
        public double? TotCredit { get; set; }
        public double? TotAvailable { get; set; }
        public double? TotOver { get; set; }
        public double? TotLiab { get; set; }
        public double? TotAppv { get; set; }
        public double? TotTotal { get; set; }
        public double? TotNewAmt { get; set; }
        public double? TotHold { get; set; }
        public double? TotShare { get; set; }
        public double? TotSusp { get; set; }

    }
}
