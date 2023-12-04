using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_IssueOverDueBills_Select_JSON_rsp
    {
        public Q_DMLC_IssueOverDueBills_Select_pDOMBE_rsp pDOMBE { get; set; }
        public Q_DMLC_IssueOverDueBills_Select_pDOMBEMaster_rsp pDOMBEMaster { get; set; }
        public Q_DMLC_IssueOverDueBills_Select_pIMInterest_rsp pIMInterest { get; set; }
        public Q_DMLC_IssueOverDueBills_Select_SearchCust_rsp SearchCust { get; set; }
        public Q_DMLC_IssueOverDueBills_Select_OtherData_rsp OtherData { get; set; }
    }
}
