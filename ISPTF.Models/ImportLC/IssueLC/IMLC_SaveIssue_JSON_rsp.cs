using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveIssue_JSON_rsp
    {
        public Q_IMLC_IssueList_Select_pIMLC_rsp pIMLC { get; set; }
        public Q_IMLC_IssueList_Select_pPayment_rsp pPayment { get; set; }
        public Q_IMLC_IssueList_Select_pIMLCGoods_rsp pIMLCGoods { get; set; }
        public Q_IMLC_IssueList_Select_pIMLCDocs_rsp pIMLCDocs { get; set; }
        public Q_IMLC_IssueList_Select_pIMLCCond_rsp pIMLCCond { get; set; }
        public Q_IMLC_IssueList_Select_pSWIMLC_rsp pSWIMLC { get; set; }
    }
}
