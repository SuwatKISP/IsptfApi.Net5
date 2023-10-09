//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class PCustLimitRsp 
    {
        public PCustLimit pcustlimit { get; set; }
        public PCustShare[] pcustshare { get; set; }
        public PCustLmProduct[] pcustlmproduct { get; set; }
        public PCustLmCCS[] pcustlmccs { get; set; }
        public CFRRate[] cfrrate { get; set; }
    }
}
