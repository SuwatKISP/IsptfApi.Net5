using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class SCL
    {
        public string RecordType { get; set; }
        public string SystemID { get; set; }
        public string InterfaceNumber { get; set; }
        public string ProcessingDate { get; set; }
        public string DataAsOfDate { get; set; }
        public string BankNumber { get; set; }
        public string Filler { get; set; }
        public string CountryCode { get; set; }
        public string CustNumber { get; set; }
        public string CustName { get; set; }
        public string ProcessStatus { get; set; }
        public string ProcessTime { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public string LimitNumber { get; set; }
        public string CurrencyCode { get; set; }
        public string LimitCode { get; set; }
        public string LimitName { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpiredDate { get; set; }
        public double? LimitAmount { get; set; }
        public double? LimitUtilisation { get; set; }
        public double? LimitAvailable { get; set; }
        public string LimitDescription { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public double? OutBalTHB { get; set; }
        public double? Share_Amount { get; set; }
        public double? Hold_Amount { get; set; }
    }
}
