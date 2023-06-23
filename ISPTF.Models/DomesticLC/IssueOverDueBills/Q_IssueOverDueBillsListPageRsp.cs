using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.DomesticLC
{
    public class Q_IssueOverDueBillsListPageRsp

    {
        public int RCount { get; set; }
        public string? BENumber { get; set; }
        public int? BESeqno { get; set; }
        public string? RecType { get; set; }
        public string? Event { get; set; }
        public string? CustCode { get; set; }
        public string? Cust_Name { get; set; }
        public string? DLCNumber { get; set; }
        public string? RecStatus { get; set; }
        public string? BECcy { get; set; }
        public string? DocCCy { get; set; }
        public double? BEBalance { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
