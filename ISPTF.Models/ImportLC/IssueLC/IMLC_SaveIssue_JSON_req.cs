using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveIssue_JSON_req
    {
        public IMLC_SaveIssue_ListType_req ListType { get; set; }
        public IMLC_SaveIssue_pIMLC_req pIMLC { get; set; }
        public IMLC_SaveIssue_pIMLCGoods_req pIMLCGoods { get; set; }
        public IMLC_SaveIssue_pIMLCCond_req pIMLCCond { get; set; }
        public IMLC_SaveIssue_pIMLCDocs_req pIMLCDocs { get; set; }
        public IMLC_SaveIssue_pSWIMLC_req pSWIMLC { get; set; }
        public IMLC_SaveIssue_pPayment_req pPayment { get; set; }
    }
}
