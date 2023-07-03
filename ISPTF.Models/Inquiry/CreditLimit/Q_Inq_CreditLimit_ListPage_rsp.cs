using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Inquiry
{
    public class Q_Inq_CreditLimit_ListPage_rsp
    {
        public int RCount { get; set; }
        public string? Facility_No { get; set; }
        public string? Limit_Code { get; set; }
        public double? Credit_Amount { get; set; }
        public double? Available_Amt { get; set; }
        public double? Origin_Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Facility_Type { get; set; }
        public string? Refer_Cust { get; set; }
        public string? Refer_Facility { get; set; }
        public string? Revol_Flag { get; set; }
        public string? Share_Flag { get; set; }
        public double? Credit_Share { get; set; }
        public double? Share_Amount { get; set; }
        public double? Hold_Amount { get; set; }
        public string? Condition { get; set; }
        public string? Remark { get; set; }
        public string? Block_Code { get; set; }
        public string? CCS_No { get; set; }
        public string? CFRRate { get; set; }
        public double? CFRSpread { get; set; }
        public string? Cust_Code { get; set; }

    }
}
