//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class InsGrdFacility_EditCrLimit_Rsp
    {
        public string? Facility_No { get; set; }
        public string? Limit_Code { get; set; }
        public double? Credit_Amount { get; set; }
        public string? Credit_Ccy { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Facility_Type  { get; set; }
        public string? Revol_Flag { get; set; }
        public string? Share_Flag { get; set; }
        public double? Credit_Share { get; set; }
        public string? Remark { get; set; }
        public string? RecStatus { get; set; }
        public string? UsingRec { get; set; }
        public string? Refer_Cust { get; set; }
        public string? Refer_Facility { get; set; }
        public string? Block_Code { get; set; }
        public DateTime? BlockDate { get; set; }
        public string? Share_Type { get; set; }
        public double? Origin_Amount { get; set; }
        public string? CCS_NO { get; set; }
        public string? Condition { get; set; }
        public double? Hold_Amount { get; set; }
        public string? CFRRate { get; set; }
        public string? CFRSpread  { get; set; }
        public string? Status { get; set; }
        public string? Campaign_Code { get; set; }
        public DateTime? Effective_Date { get; set; }

    }
}
