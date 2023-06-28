using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Remittance
{
    public class Q_RefundTaxListPageRsp
    {
        public int RCount { get; set; }
        public string? RefNumber { get; set; }
        public int? Seqno { get; set; }
        public string? ReimRefNo { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public DateTime? EventDate { get; set; }
        public double? TaxAmt { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
    }
}
