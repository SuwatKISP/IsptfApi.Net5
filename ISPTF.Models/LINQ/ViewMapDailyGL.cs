using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewMapDailyGL
    {
        public DateTime VouchDate { get; set; }
        public string VouchID { get; set; }
        public int TranSeq { get; set; }
        public string TranDocNo { get; set; }
        public int TranDocseq { get; set; }
        public string TranAccount { get; set; }
        public string TranCcy { get; set; }
        public string TranNature { get; set; }
        public double? TranAmount { get; set; }
        public double? TranExch { get; set; }
        public string TranDesc { get; set; }
        public string TranRef { get; set; }
        public string TranMod { get; set; }
        public string TranEvent { get; set; }
        public string TranBran { get; set; }
        public string TranDept { get; set; }
        public string TranCenter { get; set; }
        public string TranStatus { get; set; }
        public string TranAllocate { get; set; }
        public string CustCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public string SendFlag { get; set; }
        public string TranCond { get; set; }
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
