using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class tmp_BankLiabCust
    {
        public string DocNumber { get; set; }
        public string Product { get; set; }
        public string Bank_Code { get; set; }
        public string Facility_No { get; set; }
        public string Cust_Code { get; set; }
        public string LiabCcy { get; set; }
        public double? LiabBal { get; set; }
        public string UserID { get; set; }
        public double? ExchRate { get; set; }
    }
}
