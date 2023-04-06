using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.LoginRegis
{
    public class Q_GetDocRegisterIssue
    {
        public string reg_docno { get; set; }
        public string reg_ccy { get; set; }
        public string reg_ccyamt { get; set; }
        public string reg_ccybal { get; set; }
        public string reg_exchrate { get; set; }
        public string reg_custcode { get; set; }
        public string cust_name { get; set; }
        public string reg_bankcode { get; set; }
        public string reg_appvno { get; set; }
        public string reg_plus { get; set; }
        public string reg_minux { get; set; }
        public string reg_doctype { get; set; }
        public string reg_refno { get; set; }
        public string reg_facilityno { get; set; }
        public string reg_reftype { get; set; }
        public string mode { get; set; }
    }
}
