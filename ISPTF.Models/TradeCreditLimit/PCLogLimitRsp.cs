//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class PCLogLimitRsp
    {
        public PCLogLimit pcloglimit { get; set; }
        public PCLogShare[] pclogshare { get; set; }
        public PCLogLmProduct[] pcloglmproduct { get; set; }
        public PCLogLmCCS[] pcloglmccs { get; set; }
        public CFRRateLog[] cfrratelog { get; set; }

    }
}
