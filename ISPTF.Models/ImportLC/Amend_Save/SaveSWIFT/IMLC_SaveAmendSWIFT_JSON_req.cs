using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveAmendSWIFT_JSON_req
    {
        public IMLC_SaveAmendSWIFT_pIMLC_req pIMLC { get; set; }
        public IMLC_SaveAmendSWIFT_pSWIMLC_req pSWIMLC { get; set; }
        public IMLC_SaveAmendSWIFT_pIMLCGoods_req pIMLCGoods { get; set; }
        public IMLC_SaveAmendSWIFT_pIMLCDocs_req pIMLCDocs { get; set; }
        public IMLC_SaveAmendSWIFT_pIMLCCond_req pIMLCCond { get; set; }
        public IMLC_SaveAmendSWIFT_pSWImpText_req pSWImpText { get; set; }
    }
}
