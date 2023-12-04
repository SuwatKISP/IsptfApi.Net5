using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_IssueDBE_NewSelect_JSON_rsp
    {
        public Q_DMLC_IssueDBE_NewSelect_pDOMLC_rsp pDOMLC { get; set; }
        public Q_DMLC_IssueDBE_NewSelect_SearchCust_rsp SearchCust { get; set; }
        public Q_DMLC_IssueDBE_NewSelect_SearchRate_rsp SearchRate { get; set; }
        public Q_DMLC_IssueDBE_NewSelect_DefaultRate_rsp DefaultRate { get; set; }
        public Q_DMLC_IssueDBE_NewSelect_CheckOverDrawn_rsp CheckOverDrawn { get; set; }
        public Q_DMLC_IssueDBE_NewSelect_OtherData_rsp OtherData { get; set; }
    }
}
