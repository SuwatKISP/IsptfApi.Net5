//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeBankLimit

{
    public class PBankLimitRsp
    {
        public PBankLimit pbanklimit { get; set; }
        public PBankLmProduct[] pbanklmproduct { get; set; }
    }
}
