using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class TmpLiability
    {
        public string AppvNo { get; set; }
        public string CustCode { get; set; }
        public string FacilityNo { get; set; }
        public string LimitCode { get; set; }
        public double? CreditAmount { get; set; }
        public double? LiabAmount { get; set; }
        public double? NonLineAmount { get; set; }
        public double? TotNonLineAmt { get; set; }
        public string Status { get; set; }
        public double? GroupAmt { get; set; }
    }
}
