using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewCustLiab
    {
        public string Cust_Code { get; set; }
        public string Facility_No { get; set; }
        public string Currency { get; set; }
        public double Liability { get; set; }
        public string Refer_Cust { get; set; }
        public string Refer_Facility { get; set; }
        public string Share_Flag { get; set; }
    }
}
