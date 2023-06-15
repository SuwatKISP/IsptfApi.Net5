using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.PackingCredit
{
    public class Q_IssuePCNewListPageRsp

    {
        public int RCount { get; set; }
        public string? Reg_Docno { get; set; }
        public string? Cust_Name { get; set; }
        public string? Reg_Ccy { get; set; }
        public double? Reg_CcyBal { get; set; }
        public double? Reg_BhtAmt { get; set; }
        public string? Cust_Code { get; set; }

    }
}
