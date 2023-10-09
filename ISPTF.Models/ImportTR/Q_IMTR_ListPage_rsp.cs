using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class Q_IMTR_ListPage_rsp
    {
        public int RCount { get; set; }
        public string? RefNumber { get; set; }
        public string? TRNumber { get; set; }
        public int? TRSeqno { get; set; }
        public string? RecType { get; set; }
        public string? Event { get; set; }
        public string? CustCode { get; set; }
        public string? Cust_Name { get; set; }
        public DateTime? EventDate { get; set; }
        public string? LCNumber { get; set; }
        public string? RecStatus { get; set; }
        public string? TRCcy { get; set; }
        public double? TRBalance { get; set; }
        public string? TRFlag { get; set; }


    }
}
