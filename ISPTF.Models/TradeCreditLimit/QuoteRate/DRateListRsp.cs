using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit.QuoteRate
{
    public class DRateListRsp
    {
        public string? R_date { get; set; }
        public string? RateMLR { get; set; }
        public string? RateMOR { get; set; }
        public string? RateSIBOR1 { get; set; }
        public string? RateLIBOR1 { get; set; }
        public string? Rate_ALCO { get; set; }
        public DateTime? Time_Stamp { get; set; }
        public string? User_T { get; set; }
    }
}
