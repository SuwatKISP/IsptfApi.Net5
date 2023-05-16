using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;

namespace ISPTF.Models.ExportBC
{
    public class Q_EXBCNewPageRsp

    {
        public int RCount { get; set; }
        public string Reg_DocNo { get; set; }
        public string Cust_Name { get; set; }
        public string Reg_Ccy { get; set; }
        public string Reg_Ccyamt { get; set; }
        public string Reg_Amt { get; set; }
        public string Reg_Amt1 { get; set; }
        public string ClaimType { get; set; }
        public string Event_Type { get; set; }
        public string Record_Type { get; set; }
        public string Rec_Status { get; set; }
        public DateTime EVENT_DATE { get; set; }
    }
}
