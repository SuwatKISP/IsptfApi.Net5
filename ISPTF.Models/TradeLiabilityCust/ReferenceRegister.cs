//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCust

{
    public class ReferenceRegister
    {
        public string? Reg_Docno { get; set; }
        public string? Reg_CustCode { get; set; }
        public string? Reg_Ccy { get; set; }
        public double? Reg_CcyAmt { get; set; }
        public double? Reg_ExchRate { get; set; }
        public double? Reg_BhtAmt { get; set; }
        public double? Reg_Plus { get; set; }
        public string? Reg_RefNo { get; set; }
        public string? Reg_Login { get; set; }
    }
}
