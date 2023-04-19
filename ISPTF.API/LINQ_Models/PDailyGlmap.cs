using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PDailyGlmap
    {
        public DateTime VouchDate { get; set; }
        public string VouchId { get; set; }
        public int TranSeq { get; set; }
        public string TranDocNo { get; set; }
        public int TranDocseq { get; set; }
        public string TranMod { get; set; }
        public string TranBsarea { get; set; }
        public string TranSapAcc { get; set; }
        public string TranCost { get; set; }
        public string TranProfit { get; set; }
        public string TranProd { get; set; }
        public string TranTerm { get; set; }
        public string TranBsline { get; set; }
        public string TranSale { get; set; }
        public string TranIndex2 { get; set; }
    }
}
