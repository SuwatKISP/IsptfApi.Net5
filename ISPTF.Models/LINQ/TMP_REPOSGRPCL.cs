using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TMP_REPOSGRPCL
    {
        public string CUST_CODE { get; set; }
        public string CUST_NAME { get; set; }
        public string BD { get; set; }
        public string FACNO { get; set; }
        public string LIMIT_CODE { get; set; }
        public string MODULE { get; set; }
        public double LIMIT_AMT { get; set; }
        public double? BAL_AMT_THB { get; set; }
        public double SHARE_AMT { get; set; }
        public double HOLD_AMT { get; set; }
        public double AVL_AMT { get; set; }
        public double? NET_AVL_AMT { get; set; }
        public string FLAGDUE { get; set; }
        public string FLAG_SHARE { get; set; }
        public string UPDATE_DATE { get; set; }
        public string USERCODE { get; set; }
    }
}
