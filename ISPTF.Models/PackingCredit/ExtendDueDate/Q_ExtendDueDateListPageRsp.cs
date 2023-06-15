using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.PackingCredit
{
    public class Q_ExtendDueDateListPageRsp

    {
        public int RCount { get; set; }
        public string? packing_no { get; set; }
        public string? pn_no { get; set; }
        public string? cust_name { get; set; }
        public string? doc_ccy { get; set; }
        public double? total_bal_ccy { get; set; }
        public string? event_type { get; set; }
        public string? record_type { get; set; }
        public string? rec_status { get; set; }
        public DateTime? event_date { get; set; }
        public string? cust_code { get; set; }

    }
}
