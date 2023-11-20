using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_IssueNew_Select_JSON_rsp
    {
        public Q_DMLC_IssueNew_Select_pDocRegister_rsp pDocRegister { get; set; }
        public Q_DMLC_IssueNew_Select_DefultCommRate_rsp DefaultCommRate { get; set; }
        public Q_DMLC_IssueNew_Select_GetNewRecord_rsp GetNewRecord { get; set; }
        public Q_DMLC_IssueNew_Select_GetExchangeRate_rsp GetExchangeRate { get; set; }
    }
}
