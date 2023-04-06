//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCust

{
    public class SumByRecStatusRsp
    {
        public double? SumCredit_Amount { get; set; }
        public double? LiabAmt { get; set; }
        public double? AppvAmt { get; set; }
        public double? BookAmt { get; set; }
        public double? SumShare_Amount { get; set; }
        public double? SumSusp_Amount { get; set; }
        public double? SumHold_Amount { get; set; }
        public double? SumOrigin_Amount { get; set; }
    }
}
