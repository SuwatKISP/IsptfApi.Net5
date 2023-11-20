using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_ReleaseIssueForm_JSON_req
    {
        public DMLC_ReleaseIssueForm_ListType_req ListType { get; set; }
        public DMLC_ReleaseIssueForm_pDOMLC_req pDOMLC { get; set; }
        public DMLC_ReleaseIssueForm_UpdateAmend_req UpdateAmend { get; set; }
    }
}
