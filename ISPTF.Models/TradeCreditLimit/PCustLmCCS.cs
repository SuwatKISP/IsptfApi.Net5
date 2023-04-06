//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class PCustLmCCS
    {
        public string? Cust_Code { get; set; }
        public string? Facility_No { get; set; }
        public int? SeqNo { get; set; }
        public string? Prod_Mod { get; set; }
        public string? Prod_Ref { get; set; }
        public string? CCS_Ccy { get; set; }
        public string? CCS_DocStat { get; set; }
        public string? CCS_Stat { get; set; }
        public string? CCS_No { get; set; }
        public string? CCS_LmType { get; set; }

    }
}
