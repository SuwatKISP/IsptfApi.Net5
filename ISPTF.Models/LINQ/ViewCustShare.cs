using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewCustShare
    {
        public string Cust_Code { get; set; }
        public string Facility_No { get; set; }
        public string Status { get; set; }
        public string RecStatus { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Limit_Code { get; set; }
        public int? Seq_No { get; set; }
        public string Facility_Type { get; set; }
        public string Revol_Flag { get; set; }
        public string Share_Flag { get; set; }
        public double? Credit_Amount { get; set; }
        public double? Credit_Share { get; set; }
        public double? Share_Amount { get; set; }
        public double? Susp_Amount { get; set; }
        public string Remark { get; set; }
        public string Share_Cust { get; set; }
        public string Share_Limit { get; set; }
        public double? Share_Credit { get; set; }
        public double? Share_Used { get; set; }
        public string Parent_Id { get; set; }
        public string Refer_Cust { get; set; }
        public string Refer_Facility { get; set; }
        public string Limit_IMEX { get; set; }
        public string Limit_IMLC { get; set; }
        public string Limit_IMTR { get; set; }
        public string Limit_EXLC { get; set; }
        public string Limit_EXBC { get; set; }
        public string Limit_EXPC { get; set; }
        public string Limit_DLC { get; set; }
        public string Limit_IMP { get; set; }
        public string Limit_EXP { get; set; }
        public string Share_CCS { get; set; }
    }
}
