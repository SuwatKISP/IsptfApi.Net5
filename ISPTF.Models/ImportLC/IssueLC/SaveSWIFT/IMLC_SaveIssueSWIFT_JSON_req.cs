using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveIssueSWIFT_JSON_req
    {
        public IMLC_SaveIssueSWIFT_pIMLC_req pIMLC { get; set; }
        public IMLC_SaveIssueSWIFT_pSWIMLC_req pSWIMLC { get; set; }
        public IMLC_SaveIssueSWIFT_pIMLCGoods_req pIMLCGoods { get; set; }
        public IMLC_SaveIssueSWIFT_pIMLCDocs_req pIMLCDocs { get; set; }
        public IMLC_SaveIssueSWIFT_pIMLCCond_req pIMLCCond { get; set; }
        public IMLC_SaveIssueSWIFT_pSWImpText_req pSWImpText { get; set; }
    }
}
