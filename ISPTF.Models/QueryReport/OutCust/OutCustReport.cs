using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class OutCustReport
    {
        public DateTime? EventDate { get; set; }
        public string? Module { get; set; }
        public DateTime? DueDate { get; set; }
        public string? ReferNo { get; set; }
        public string? KeyNumber { get; set; }
        public string? Docno { get; set; }
        public string? Docno1 { get; set; }
        public string? CustCode { get; set; }
        public string? DocCcy { get; set; }
        public double? OriginalAmt { get; set; }
        public double? BalanceAmt { get; set; }
        public double? InterestAmt { get; set; }
        public string? CenterID { get; set; }

    }
}
