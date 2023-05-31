using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pCLogLmCC
    {
        public string LRecType { get; set; }
        public int LLogSeq { get; set; }
        public string LCust_Code { get; set; }
        public string LFacility_No { get; set; }
        public int LseqNo { get; set; }
        public string LProd_Mod { get; set; }
        public string LProd_Ref { get; set; }
        public string LCCS_Ccy { get; set; }
        public string LCCS_DocStat { get; set; }
        public string LCCS_Stat { get; set; }
        public string LCCS_No { get; set; }
        public string LCCS_LmType { get; set; }
    }
}
