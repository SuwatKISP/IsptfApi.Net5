using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pRefinance
    {
        public string CustCode { get; set; }
        public string DocNo { get; set; }
        public string ReFinance_Flag { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
