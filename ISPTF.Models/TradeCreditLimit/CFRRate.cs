//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class CFRRate
    {
        public string? CustCode { get; set; }
        public string? CurCode { get; set; }
        public string? prdcode { get; set; }
        public string? rate_type { get; set; }
        public string? sign { get; set; }
        public double? spread { get; set; }
        public string? Facility_No { get; set; }
        public string? remark { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime? InputDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Delete_Flag { get; set; }
        public string? ZZUser { get; set; }
        public DateTime? ZZStrdate { get; set; }
        public DateTime? ZZDate { get; set; }

    }
}
