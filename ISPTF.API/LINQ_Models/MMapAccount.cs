using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class MMapAccount
    {
        public string MAccCode { get; set; }
        public string MAccNew { get; set; }
        public string MAccName { get; set; }
        public string MAccType { get; set; }
        public string MAccBuArea { get; set; }
        public string MAccCost { get; set; }
        public string MAccProfit { get; set; }
        public string MAccBsLine { get; set; }
        public string MAccCond { get; set; }
        public string MAccMod { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string GfmsMap { get; set; }
        public string GfmsAcc { get; set; }
        public string GfmsSubAcc { get; set; }
        public string GfmsProd { get; set; }
        public string GfmsBran { get; set; }
        public string GfmsSbu { get; set; }
    }
}
