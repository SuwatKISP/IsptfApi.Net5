using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class MBranch
    {
        public string BranCode { get; set; }
        public string BranName { get; set; }
        public string ProvCode { get; set; }
        public string BranGl { get; set; }
        public string BranBa { get; set; }
        public string BranCost { get; set; }
        public string BranProfit { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string OnePuse { get; set; }
    }
}
