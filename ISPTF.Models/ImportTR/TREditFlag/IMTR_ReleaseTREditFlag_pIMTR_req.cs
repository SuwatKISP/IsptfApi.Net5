using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_ReleaseTREditFlag_pIMTR_req
    {
        public string? RefNumber { get; set; }
        public string? RecType { get; set; }
        public int? TRSeqno { get; set; }
        public string? CenterID { get; set; }
        public string? UserCode { get; set; }
        public DateTime? IntStartDate { get; set; }
        public string? IntPayType { get; set; }
        public string? IntRateCode { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public string? AutoOverDue { get; set; }
        public string? NegoTelex { get; set; }
        public string? IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? DueDate { get; set; }

    }
}
