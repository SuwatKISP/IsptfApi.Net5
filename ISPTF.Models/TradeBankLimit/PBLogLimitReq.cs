//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeBankLimit

{
    public class PBLogLimitReq
    {
        public PBLogLimit pbloglimit { get; set; }
        public PBLogLmProduct[] pbloglmproduct { get; set; }
    }
}
