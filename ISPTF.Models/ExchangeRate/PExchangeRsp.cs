using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExchangeRate
{
    public class PExchangeRsp
    {
        public DateTime? exch_Date { get; set; }
        public string? exch_Time { get; set; }
        public string? exch_Ccy { get; set; }
        public string? Ccy_Name { get; set; }
        public int? exch_Seqno { get; set; }
        public double? exch_BNBuy { get; set; }
        public double? exch_BNSell { get; set; }
        public double? exch_TRate1 { get; set; }
        public double? exch_TRate2 { get; set; }
        public double? exch_TRate3 { get; set; }
        public double? exch_Average { get; set; }
        public double? recStatus { get; set; }
        public double? UpdateDate { get; set; }
        public int? RCount { get; set; }

    }
}
