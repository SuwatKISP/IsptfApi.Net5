using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class vMonthAmort
    {
        public DateTime? EVENT_DATE { get; set; }
        public string Module { get; set; }
        public string EventName { get; set; }
        public string Reference { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string DRAFT_CCY { get; set; }
        public double? OriginalAmt { get; set; }
        public double BalanceAmt { get; set; }
        public DateTime? PURCH_DISC_DATE { get; set; }
        public DateTime? TERM_DUE_DATE { get; set; }
        public double DISCOUNT_RATE { get; set; }
        public int discount_day { get; set; }
        public double DISCOUNT_CCY { get; set; }
        public double discrate { get; set; }
        public double DISCOUNT_AMT { get; set; }
        public double TotalAccruAmt { get; set; }
        public double TotalAccruBht { get; set; }
        public double SuspAmt { get; set; }
        public string TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string TenorDesc { get; set; }
        public string UserCoede { get; set; }
        public string AuthCode { get; set; }
        public string Rec_Status { get; set; }
        public string CenterID { get; set; }
    }
}
