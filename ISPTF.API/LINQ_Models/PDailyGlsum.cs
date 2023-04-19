using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PDailyGlsum
    {
        public DateTime VouchDate { get; set; }
        public string TranIndex { get; set; }
        public string TranCcy { get; set; }
        public string TranBsarea { get; set; }
        public string TranProfit { get; set; }
        public string TranCost { get; set; }
        public string TranSapAcc { get; set; }
        public string TranProd { get; set; }
        public string TranTerm { get; set; }
        public string TranBsline { get; set; }
        public string TranSale { get; set; }
        public string TranNature { get; set; }
        public double? SumCcy { get; set; }
        public double? SumThb { get; set; }
        public string TranIndex2 { get; set; }
    }
}
