using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.ImportLC
{
    public class Q_IMLC_IssueNew_Select_JSON_rsp
    {
        public Q_IMLC_IssueNew_Select_pDocregister_rsp pDocRegister { get; set; }
        public Q_IMLC_IssueNew_Select_CustDetail_rsp CustDetail { get; set; }
        public Q_IMLC_IssueNew_Select_GetSWIFTBank_rsp GetSWIFTBank { get; set; }
        public Q_IMLC_IssueNew_Select_DefaultCommRate_rsp DefaultCommRate { get; set;}
    }
}
