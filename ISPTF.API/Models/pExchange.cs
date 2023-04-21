using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pExchange
    {
        public DateTime Exch_Date { get; set; }
        public string Exch_Time { get; set; }
        public string Exch_Ccy { get; set; }
        public int? Exch_Seqno { get; set; }
        public double? Exch_BNBuy { get; set; }
        public double? Exch_BNSell { get; set; }
        public double? Exch_TRate1 { get; set; }
        public double? Exch_TRate2 { get; set; }
        public double? Exch_TRate3 { get; set; }
        public double? Exch_Average { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
