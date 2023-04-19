using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class TmpBankLiabCust
    {
        public string DocNumber { get; set; }
        public string Product { get; set; }
        public string BankCode { get; set; }
        public string FacilityNo { get; set; }
        public string CustCode { get; set; }
        public string LiabCcy { get; set; }
        public double? LiabBal { get; set; }
        public string UserId { get; set; }
        public double? ExchRate { get; set; }
    }
}
