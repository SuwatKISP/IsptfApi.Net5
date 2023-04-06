using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.ExportBC
{
    public class Q_EXBCIssueNewPageRsp

    {
        public int rCount { get; set; }
        public string reg_DocNo { get; set; }
        public string cust_Name { get; set; }
        public string reg_Ccy { get; set; }
        public string reg_ccyamt { get; set; }
        public string reg_amt { get; set; }
        public string reg_amt1 { get; set; }
        public string claimType { get; set; }
        public string event_Type { get; set; }
        public string record_type { get; set; }
        public string rec_Status { get; set; }

    }
}
