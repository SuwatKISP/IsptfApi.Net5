using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pBLogLmProduct
    {
        public string LRecType { get; set; }
        public int LLogSeq { get; set; }
        public string LBank_Code { get; set; }
        public string LFacility_No { get; set; }
        public int LseqNo { get; set; }
        public string LProd_Code { get; set; }
        public string LProd_Limit { get; set; }
        public DateTime? LStartDate { get; set; }
        public DateTime? LExpiryDate { get; set; }
        public double? LProdAmount { get; set; }
        public string LCCS_No { get; set; }
        public string LCCS_Ref { get; set; }
        public string LCCS_Limit { get; set; }
    }
}
