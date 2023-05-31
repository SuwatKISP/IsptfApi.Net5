using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pDailyGLSum
    {
        public DateTime VouchDate { get; set; }
        public string TranIndex { get; set; }
        public string TranCcy { get; set; }
        public string TranBSArea { get; set; }
        public string TranProfit { get; set; }
        public string TranCost { get; set; }
        public string TranSapAcc { get; set; }
        public string TranProd { get; set; }
        public string TranTerm { get; set; }
        public string TranBSLine { get; set; }
        public string TranSale { get; set; }
        public string TranNature { get; set; }
        public double? SumCCY { get; set; }
        public double? SumTHB { get; set; }
        public string TranIndex2 { get; set; }
    }
}
