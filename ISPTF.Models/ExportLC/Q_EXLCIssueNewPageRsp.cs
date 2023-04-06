using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.ExportLC
{
    public class Q_EXLCIssueNewPageRsp

    {
        public int RCount { get; set; }
        public string Reg_DocNo { get; set; }
        public string Cust_Name { get; set; }
        public string Reg_Ccy { get; set; }
        public string Reg_CcyAmt { get; set; }
        public string Reg_Amt { get; set; }
        public string Reg_Amt1 { get; set; }
        public string Claim_Type { get; set; }
        public string Event_Type { get; set; }
        public string Record_Type { get; set; }
        public string Rec_Status { get; set; }

    }
}
