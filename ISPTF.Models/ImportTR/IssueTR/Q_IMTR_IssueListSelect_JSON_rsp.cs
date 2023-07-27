using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class Q_IMTR_IssueListSelect_JSON_rsp
    {
        public Q_IMTR_IssueListSelect_pIMTR_rsp pIMTR { get; set; }
        public Q_IMTR_IssueListSelect_pIMInterest_rsp pIMInterest { get; set; }
        public Q_IMTR_IssueListSelect_pPayment_rsp pPayment { get; set; }
        public Q_IMTR_IssueListSelect_pSWImport_rsp pSWImport { get; set; }
        public Q_IMTR_IssueListSelect_IMBLFBChargeInterest_rsp IMBLFBChargeInterest { get; set; }
        public Q_IMTR_IssueNewSelect_SearchCust_rsp SearchCust { get; set; }
        public Q_IMTR_IssueNewSelect_SearchRate_rsp SearchRate { get; set; }
        public Q_IMTR_IssueNewSelect_TxBank1_rsp TxBank1 { get; set; }
        public Q_IMTR_IssueNewSelect_TxReimBank_rsp TxReimBank { get; set; }
    }
}
