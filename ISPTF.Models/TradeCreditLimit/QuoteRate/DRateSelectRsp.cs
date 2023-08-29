using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit.QuoteRate
{
    public class DRateSelectRsp
    {
        public string? R_date { get; set; }
        public string? RateMLR { get; set; }
        public string? RateMOR { get; set; }
        public string? RateSIBOR1 { get; set; }
        public string? RateSIBOR3 { get; set; }
        public string? RateSIBOR6 { get; set; }
        public string? RateSIBOR9 { get; set; }
        public string? RateLIBOR1 { get; set; }
        public string? RateLIBOR3 { get; set; }
        public string? RateLIBOR6 { get; set; }
        public string? RateLIBOR9 { get; set; }
        public string? Rate_ALCO { get; set; }
        public DateTime? Time_Stamp { get; set; }
        public string? User_T { get; set; }

    }
}
