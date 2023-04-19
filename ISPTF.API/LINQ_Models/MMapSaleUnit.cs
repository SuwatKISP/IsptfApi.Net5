using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MMapSaleUnit
    {
        public string MLoCode { get; set; }
        public string MLoSaleUnit { get; set; }
        public string MLoSaleDesc { get; set; }
        public string MLoBuArea { get; set; }
        public string MLoCost { get; set; }
        public string MLoProfit { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
