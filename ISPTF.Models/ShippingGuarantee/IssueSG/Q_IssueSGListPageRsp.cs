using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.ShippingGuarantee
{
    public class Q_IssueSGListPageRsp

    {
        public int RCount { get; set; }
        public string? SGNumber { get; set; }
        public int? SGSeqno { get; set; }
        public string? RecType { get; set; }
        public string? Event { get; set; }
        public string? CustCode { get; set; }
        public string? Cust_Name { get; set; }
        public DateTime? EventDate { get; set; }
        public string? RecStatus { get; set; }
        public string? AppvNo { get; set; }
        public string? ReferLC { get; set; }
        public string? FacNo { get; set; }

    }
}
