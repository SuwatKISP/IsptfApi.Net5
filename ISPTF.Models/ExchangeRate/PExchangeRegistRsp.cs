using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExchangeRate
{
    public class PExchangeRegistRsp
    {
        public string? exch_Ccy { get; set; }
        public string? mDate { get; set; }
        public string? mTime { get; set; }
        public double? exch_TRate1 { get; set; }
        public double? exch_TRate2 { get; set; }
        public double? exch_TRate3 { get; set; }
        public double? exch_Average { get; set; }

    }
}
