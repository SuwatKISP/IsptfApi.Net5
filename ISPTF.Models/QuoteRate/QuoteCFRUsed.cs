using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.QuoteRate
{
    public class QuoteCFRUsed
    {
        public string? CustCode { get; set; }
        public string? Facility_No { get; set; }
        public string? CurCode { get; set; }
        public double? CFR_Rate { get; set; }
        public double? TPR { get; set; }        
        public double ? Quote_Rate { get; set; }
        public float? QuoteCost { get; set; }
        public float? QuoteSpread { get; set; }

    }
}
