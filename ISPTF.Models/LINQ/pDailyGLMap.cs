using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pDailyGLMap
    {
        public DateTime VouchDate { get; set; }
        public string VouchID { get; set; }
        public int TranSeq { get; set; }
        public string TranDocNo { get; set; }
        public int TranDocseq { get; set; }
        public string TranMod { get; set; }
        public string TranBSArea { get; set; }
        public string TranSapAcc { get; set; }
        public string TranCost { get; set; }
        public string TranProfit { get; set; }
        public string TranProd { get; set; }
        public string TranTerm { get; set; }
        public string TranBSLine { get; set; }
        public string TranSale { get; set; }
        public string TranIndex2 { get; set; }
    }
}
