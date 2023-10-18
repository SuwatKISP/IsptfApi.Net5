using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_Issue_Select_JSON_rsp
    {
        public Q_DMLC_Issue_Select_pDOMLC_rsp pDOMLC { get; set; }
        public Q_DMLC_Issue_Select_pPayment_rsp pPayment { get; set; }
        public Q_DMLC_IssueNew_Select_DefultCommRate_rsp DefaultCommRate { get; set; }
        public Q_DMLC_Issue_Select_SearchCust_rsp SearchCust { get; set; }
        public Q_DMLC_Issue_Select_ViewCreditLimit_rsp ViewCreditLimit { get; set; }
        public Q_DMLC_IssueNew_Select_GetExchangeRate_rsp GetExchangeRate { get; set; }
    }
}
