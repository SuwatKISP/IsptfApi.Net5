using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class VMonthAmort
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public string EventName { get; set; }
        public string Reference { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string DraftCcy { get; set; }
        public double? OriginalAmt { get; set; }
        public double BalanceAmt { get; set; }
        public DateTime? PurchDiscDate { get; set; }
        public DateTime? TermDueDate { get; set; }
        public double DiscountRate { get; set; }
        public int DiscountDay { get; set; }
        public double DiscountCcy { get; set; }
        public double Discrate { get; set; }
        public double DiscountAmt { get; set; }
        public double? TotalAccruAmt { get; set; }
        public double TotalAccruBht { get; set; }
        public double SuspAmt { get; set; }
        public string TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string TenorDesc { get; set; }
        public string UserCoede { get; set; }
        public string AuthCode { get; set; }
        public string RecStatus { get; set; }
        public string CenterId { get; set; }
    }
}
