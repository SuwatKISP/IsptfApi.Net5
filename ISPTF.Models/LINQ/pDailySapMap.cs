using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pDailySapMap
    {
        public DateTime VouchDate { get; set; }
        public int RecNo { get; set; }
        public string TranIndex { get; set; }
        public string TranCcy { get; set; }
        public string TranExch { get; set; }
        public string TranBSArea { get; set; }
        public string TranProfit { get; set; }
        public string TranCost { get; set; }
        public string TranAccount { get; set; }
        public string TranProd { get; set; }
        public string TranTerm { get; set; }
        public string TranBSLine { get; set; }
        public string TranSale { get; set; }
        public string TranNature { get; set; }
        public double? TranAmt { get; set; }
        public double? TranTHB { get; set; }
        public string TranBatch { get; set; }
    }
}
