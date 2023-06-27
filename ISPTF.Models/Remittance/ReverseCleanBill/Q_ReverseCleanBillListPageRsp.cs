using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Remittance
{
    public class Q_ReverseCleanBillListPageRsp
    {
        public int RCount { get; set; }
        public string? CLNumber { get; set; }
        public string? Event { get; set; }
        public string? CollectBank { get; set; }
        public string? CLCCY { get; set; }
        public double? CLCCYAmt { get; set; }
        public string? Rectype { get; set; }
        public string? RecStatus { get; set; }
        public int? Seqno { get; set; }
        public DateTime? EventDate { get; set; }
        public string? Cust_Name { get; set; }
        public string? Cust_Info { get; set; }
    }
}
