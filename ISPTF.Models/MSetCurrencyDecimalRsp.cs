using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MSetCurrencyDecimalRsp
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string BaseDay { get; set; }
        public string HaveDecimal  { get; set; }
        public int RCount { get; set; }

    }
}
