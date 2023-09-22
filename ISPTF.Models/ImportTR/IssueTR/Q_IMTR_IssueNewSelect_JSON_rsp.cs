using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class Q_IMTR_IssueNewSelect_JSON_rsp
    {
        public Q_IMTR_IssueNewSelect_pDocRegister_rsp pDocRegister { get; set; }
        public Q_IMTR_IssueNewSelect_pIMBL_rsp pIMBL { get; set; }
        public Q_IMTR_IssueNewSelect_pIMBC_rsp pIMBC { get; set; }
        public Q_IMTR_IssueNewSelect_pDOMBE_rsp pDOMBE { get; set; }
        public Q_IMTR_IssueNewSelect_EntryDate_rsp EntryDate { get; set; }
        public Q_IMTR_IssueNewSelect_SearchCust_rsp SearchCust { get; set; }
        public Q_IMTR_IssueNewSelect_SearchRate_rsp SearchRate { get; set; }
        public Q_IMTR_IssueNewSelect_TxBank1_rsp TxBank1 { get; set; }
        public Q_IMTR_IssueNewSelect_TxReimBank_rsp TxReimBank { get; set; }
        public Q_IMTR_IssueNewSelect_MidRate_rsp GetMidExChange { get; set; }
        public Q_IMTR_IssueNewSelect_DefaultData_rsp DefaultData { get; set; }
    }
}
