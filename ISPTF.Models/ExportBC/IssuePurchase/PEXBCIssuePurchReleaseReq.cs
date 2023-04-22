using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCIssuePurchReleaseReq
    {
        public string CENTER_ID { get; set; }
        public string EXPORT_BC_NO { get; set; }
        public string RELEASE_ACTION { get; set; }
        public string METHOD { get; set; }
        public string PAYMENT_INSTRU { get; set; }
        public string EVENT_DATE { get; set; }
        public int CLAIM_TYPE { get; set; }
        public string REFER_BC_NO  { get; set; }
    }
}
