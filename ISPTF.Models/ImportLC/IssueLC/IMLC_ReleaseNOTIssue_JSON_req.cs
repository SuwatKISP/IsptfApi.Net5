using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_ReleaseNOTIssue_JSON_req
    {
        public IMLC_ReleaseIssue_ListType_req ListType { get; set; }
        public IMLC_ReleaseIssue_pIMLC_req pIMLC { get; set; }
        public IMLC_ReleaseIssue_pIMLCGoods_req pIMLCGoods { get; set; }
    }
}
