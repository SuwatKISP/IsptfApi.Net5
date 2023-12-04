using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SaveIssueOverDueBills_JSON_req
    {
        public DMLC_SaveIssueOverDueBills_ListType_req ListType { get; set; }
        public DMLC_SaveIssueOverDueBills_pDOMBE_req pDOMBE { get; set; }
    }
}
