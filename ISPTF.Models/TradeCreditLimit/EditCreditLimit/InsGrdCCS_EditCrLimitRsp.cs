//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class InsGrdCCS_EditCrLimitRsp
    {
        public string Module { get; set; }
        public string DocRefNo  { get; set; }
        public string CCY { get; set; }
        public string DocStatus { get; set; }
        public string CCSNumber { get; set; }
        public string CCSLmType { get; set; }

    }
}
