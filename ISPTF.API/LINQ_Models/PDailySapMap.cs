using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PDailySapMap
    {
        public DateTime VouchDate { get; set; }
        public int RecNo { get; set; }
        public string TranIndex { get; set; }
        public string TranCcy { get; set; }
        public string TranExch { get; set; }
        public string TranBsarea { get; set; }
        public string TranProfit { get; set; }
        public string TranCost { get; set; }
        public string TranAccount { get; set; }
        public string TranProd { get; set; }
        public string TranTerm { get; set; }
        public string TranBsline { get; set; }
        public string TranSale { get; set; }
        public string TranNature { get; set; }
        public double? TranAmt { get; set; }
        public double? TranThb { get; set; }
        public string TranBatch { get; set; }
    }
}
