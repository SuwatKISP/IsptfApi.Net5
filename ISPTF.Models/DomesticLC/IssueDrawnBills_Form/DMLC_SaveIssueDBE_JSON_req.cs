using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SaveIssueDBE_JSON_req
    {
        public DMLC_SaveIssueDBE_ListType_req ListType { get; set; }
        public DMLC_SaveIssueDBE_pDOMBE_req pDOMBE { get; set; }
        public DMLC_SaveIssueDBE_pPayment_req pPayment { get; set; }
        public DMLC_SaveIssueDBE_pIMBLDocs_req[] pIMBLDocs { get; set; }
    }
}
