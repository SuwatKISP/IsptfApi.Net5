//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class InsGrdCCSRsp
    {
        public string Prod_Mod { get; set; }
        public string Prod_Ref  { get; set; }
        public string CCS_ccy { get; set; }
        public string CCSDOC { get; set; }
        public string CCS_NO { get; set; }
        public string CCS_LmType { get; set; }

    }
}
