using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewQuoteRate
    {
        public DateTime? EventDate { get; set; }
        public string RegFunct { get; set; }
        public string Module { get; set; }
        public string EventName { get; set; }
        public int? Seqno { get; set; }
        public string Keynumber { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double? OriginalAmt { get; set; }
        public double? BalanceAmt { get; set; }
        public string Tenor { get; set; }
        public string UserCode { get; set; }
        public string AuthCode { get; set; }
    }
}
