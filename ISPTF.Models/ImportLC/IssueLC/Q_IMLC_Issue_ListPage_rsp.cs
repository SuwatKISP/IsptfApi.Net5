using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class Q_IMLC_Issue_ListPage_rsp
    {
        public int RCount { get; set; }
        public string? LCNumber { get; set; }
        public string? LCSeqno { get; set; }
        public string? Event { get; set; }
        public string? LCccy { get; set; }
        public double? LCAvalBal { get; set; }
        public string? CustCode { get; set; }
        public string? Cust_Name { get; set; }
        public DateTime? DateIssue { get; set; }
        public DateTime? EventDate { get; set; }
        public string? RecStatus { get; set; }
        public string? AppvNo { get; set; }
        public string? FacNo { get; set; }
    }
}
