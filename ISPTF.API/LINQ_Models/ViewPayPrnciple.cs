using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewPayPrnciple
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public int? Trseqno { get; set; }
        public string EventName { get; set; }
        public string Reference { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double? OriginalAmt { get; set; }
        public double BalanceAmt { get; set; }
        public DateTime? DueDate { get; set; }
        public string PayFlag { get; set; }
        public string CenterId { get; set; }
        public double? PayPrnAmt { get; set; }
        public double PayIntAmt { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string FlagDue { get; set; }
    }
}
