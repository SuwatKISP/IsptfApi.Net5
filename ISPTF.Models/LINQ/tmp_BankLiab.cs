using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class tmp_BankLiab
    {
        public string Appv_No { get; set; }
        public string Bank_Code { get; set; }
        public string Facility_No { get; set; }
        public string Limit_Code { get; set; }
        public double? Credit_Amount { get; set; }
        public double? Liab_Amount { get; set; }
        public double? NonLine_Amount { get; set; }
        public double? TotNonLine_Amt { get; set; }
        public string Status { get; set; }
    }
}
