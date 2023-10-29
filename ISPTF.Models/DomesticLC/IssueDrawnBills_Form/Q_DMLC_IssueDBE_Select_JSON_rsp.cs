using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_IssueDBE_Select_JSON_rsp
    {
        public Q_DMLC_IssueDBE_Select_pDOMBE_rsp pDOMBE { get; set; }
        public Q_DMLC_IssueDBE_Select_SearchCust_rsp SearchCust { get; set; }
        public Q_DMLC_IssueDBE_Select_pIMBLDocs_rsp pIMBLDocs { get; set; }
        public Q_DMLC_IssueDBE_Select_pPayment_rsp pPayment { get; set; }
        public Q_DMLC_IssueDBE_Select_IssueExpiry_rsp IssueExpiry { get; set; }
    }
}
