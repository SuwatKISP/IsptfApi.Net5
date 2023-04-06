using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExchangeRate
{
    public class PExchange
    {
        public DateTime? exch_Date { get; set; }
        public string? exch_Time { get; set; }
        public string? exch_Ccy { get; set; }
        public double? exch_BNBuy { get; set; }
        public double? exch_BNSell { get; set; }
        public double? exch_TRate1 { get; set; }
        public double? exch_TRate2 { get; set; }
        public double? exch_TRate3 { get; set; }
        public string? recStatus { get; set; }
        public string? UserCode { get; set; }
        //public string UpdateDate { get; set; }
        //public string AuthDate { get; set; }
        public string? authCode { get; set; }

    }
}
