using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.DomesticLC
{
    public class Q_IssueDrawnBillsNewListPageRsp

    {
        public int RCount { get; set; }
        public string? DLCNumber { get; set; }
        public string? DLCCcy { get; set; }
        public double? DLCBal { get; set; }
        public string? CustCode { get; set; }
        public string? Cust_Name { get; set; }
        public string? BenInfo { get; set; }
        public DateTime? EventDate { get; set; }
    }
}
