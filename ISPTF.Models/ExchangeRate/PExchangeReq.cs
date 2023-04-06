using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExchangeRate
{
    public class PExchangeReq
    {
        public DateTime? exch_Date { get; set; }
        public string? exch_Time { get; set; }
        public string? exch_Ccy { get; set; }


    }
}
