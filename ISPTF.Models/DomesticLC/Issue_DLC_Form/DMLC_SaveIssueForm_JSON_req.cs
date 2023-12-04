using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SaveIssueForm_JSON_req
    {
        public DMLC_SaveIssueForm_ListType_req ListType { get; set; }
        public DMLC_SaveIssueForm_pDOMLC_req pDOMLC { get; set; }
        public DMLC_SaveIssueForm_pPayment_req pPayment { get; set; }
    }
}
