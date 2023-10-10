using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveAmend_JSON_req
    {
        public IMLC_SaveAmend_ListType_req ListType { get; set; }
        public IMLC_SaveAmend_pIMLC_req pIMLC { get; set; }
        public IMLC_SaveAmend_pIMLCGoods_req pIMLCGoods { get; set; }
        public IMLC_SaveAmend_pIMLCCond_req pIMLCCond { get; set; }
        public IMLC_SaveAmend_pIMLCDocs_req pIMLCDocs { get; set; }
        public IMLC_SaveAmend_pSWIMLC_req pSWIMLC { get; set; }
        public IMLC_SaveAmend_pPayment_req pPayment { get; set; }
    }
}
