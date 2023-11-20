using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_ReleaseAmend_JSON_req
    {
        public IMLC_ReleaseAmend_ListType_req ListType { get; set; }
        public IMLC_ReleaseAmend_pIMLC_req pIMLC { get; set; }
        public IMLC_ReleaseAmend_pIMLCGoods_req pIMLCGoods { get; set; }
        public IMLC_ReleaseAmend_pIMLCAmend_req pIMLCAmend { get; set; }

    }
}
