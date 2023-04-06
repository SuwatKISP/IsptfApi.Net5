//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class PCLogLmProduct
    {
        public string? LRecType { get; set; }
        public int? LLogSeq { get; set; }
        public string? LCust_Code { get; set; }
        public string? LFacility_No { get; set; }
        public int? LseqNo { get; set; }
        public string? LProd_Code { get; set; }
        public string? LProd_Limit { get; set; }
        public DateTime? LStartDate { get; set; }
        public DateTime? LExpiryDate { get; set; }
        public double? LProdAmount { get; set; }
        public string? LCCS_No { get; set; }
        public string? LCCS_Ref { get; set; }
        public string? LCCS_Limit { get; set; }


    }
}
