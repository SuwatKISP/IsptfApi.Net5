using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mMapSaleUnit
    {
        public string mLo_Code { get; set; }
        public string mLo_SaleUnit { get; set; }
        public string mLo_SaleDesc { get; set; }
        public string mLo_BuArea { get; set; }
        public string mLo_Cost { get; set; }
        public string mLo_Profit { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
