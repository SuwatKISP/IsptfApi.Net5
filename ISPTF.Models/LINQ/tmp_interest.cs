using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class tmp_interest
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public DateTime? DueDate { get; set; }
        public string ReferNo { get; set; }
        public string KeyNumber { get; set; }
        public string DocNo { get; set; }
        public string DocNo1 { get; set; }
        public string CustCode { get; set; }
        public string DocCcy { get; set; }
        public double? OriginalAmt { get; set; }
        public double? BalanceAmt { get; set; }
        public double? InterestAmt { get; set; }
        public string CenterID { get; set; }
    }
}
