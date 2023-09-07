//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class CFRRateLog
    {
        public string? LCustCode { get; set; }
        public string? LCurCode { get; set; }
        public string? Lprdcode { get; set; }
        public string? Lrate_type { get; set; }
        public string? Lsign { get; set; }
        public double? Lspread { get; set; }
        public string? LFacility_No { get; set; }
        public string? Lremark { get; set; }
        public DateTime? LApproveDate { get; set; }
        public DateTime? LInputDate { get; set; }
        public DateTime? LExpiryDate { get; set; }
        public string? LDelete_Flag { get; set; }
        public string? LZZUser { get; set; }
        public DateTime? LZZStrdate { get; set; }
        public DateTime? LZZDate { get; set; }

    }
}
