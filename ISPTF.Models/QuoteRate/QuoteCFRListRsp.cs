using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.QuoteRate
{
    public class QuoteCFRListRsp
    {
        public string? CustCode { get; set; }
        public string? Facility_No { get; set; }
        public string? CurCode { get; set; }
        public string? prdcode { get; set; }
        public string? rate_type { get; set; }
        public string? sign { get; set; }
        public double? spread { get; set; }
        public string? remark { get; set; }
        public DateTime? ApproveDate { get; set; }
        public string? Delete_Flag { get; set; }
        public string? ZZUser { get; set; }
        // for count Record
        public int rCount { get; set; }

    }
}
