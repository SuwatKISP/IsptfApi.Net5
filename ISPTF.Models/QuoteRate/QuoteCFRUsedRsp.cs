using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.QuoteRate
{
    public class QuoteCFRUsedRsp
    {
        public string? CustCode { get; set; }
        public string? Facility_No { get; set; }
        public string? CurCode { get; set; }
        public string? prdcode { get; set; }
        public string? CFR_1 { get; set; }
        public string? CFR_2 { get; set; }
        public double? CFR_3 { get; set; }
        public string? remark { get; set; }
        public string? TxnDate { get; set; }
        public int? TDay { get; set; }
        public double? CFR_Rate { get; set; }
        public double ? Quote_Rate { get; set; }
        public double? TPR { get; set; }
        public string? CCY_Flag { get; set; }
        public float? QuoteCost { get; set; }
        public float? QuoteSpread { get; set; }

    }
}
