//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeBankLimit

{
    public class InsGrdPendingBKRsp
    {
        public int? RCount { get; set; }
        public string? BankCode { get; set; }
        public string? Facility_No { get; set; }
        public string? Limit_Code { get; set; }
        public double? Credit_Amount { get; set; }
        public string? Credit_Ccy { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Facility_Type  { get; set; }
        public string? Revol_Flag { get; set; }
        public string? Condition { get; set; }
        //public string? RecStatus { get; set; }
        public string? Remark { get; set; }
        public string? CCS_No { get; set; }
        public string? Cnty_Code { get; set; }
        public string? Bank_Code { get; set; }
        public string? Bank_Name { get; set; }
    }
}
