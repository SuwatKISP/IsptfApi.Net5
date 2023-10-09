using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.QuoteRate
{
    public class FTPRateDeleteReq
    {
        public DateTime? RateDate { get; set; }
        public string? Rate_Type { get; set; }
        public string? CurCode { get; set; }
        public string? TermType { get; set; }

    }
}
