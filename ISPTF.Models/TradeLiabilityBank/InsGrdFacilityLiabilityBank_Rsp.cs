//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityBank

{
    public class InsGrdFacilityLiabilityBank_Rsp
    {
        public string? Facility_No { get; set; }
        public string? Limit_Code { get; set; }
        public double? Credit_Amount { get; set; }
        public double? Available_Amt { get; set; }
        public double? Origin_Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Facility_Type { get; set; }
        public string? Revol_Flag { get; set; }
        public double? Hold_Amount { get; set; }
        public string? AutoRec { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }
        public string? UsingRec { get; set; }
        public int? Seq_No { get; set; }


    }
}
