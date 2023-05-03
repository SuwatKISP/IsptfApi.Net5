using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCCollectRefundReleaseReq
    {
        public string EXPORT_BC_NO { get; set; }
        public string BENE_ID { get; set; }
        public string USER_ID { get; set; }
        public string CenterID { get; set; }
        public string EVENT_DATE { get; set; }
        public string VOUCH_ID { get; set; }
        public string PAYMENT_INSTRU { get; set; }
        public string CHARGE_ACC { get; set; }
        public string DRAFT { get; set; }
        public string MT202 { get; set; }
        public string FB_CURRENCY { get; set; }
        public string FB_AMT { get; set; }
        public string FB_RATE { get; set; }
        public string FB_AMT_THB { get; set; }
        public string NEGO_COMM { get; set; }
        public string TELEX_SWIFT { get; set; }
        public string COURIER_POSTAGE { get; set; }
        public string STAMP_FEE { get; set; }
        public string COMMONTT { get; set; }
        public string COMM_OTHER { get; set; }
        public string HANDING_FEE { get; set; }
        public string INT_AMT_THB { get; set; }
        public string TOTAL_CHARGE { get; set; }
        public string REFUND_TAX_YN { get; set; }
        public string REFUND_TAX_AMT { get; set; }
        public string TOTAL_AMOUNT { get; set; }
        public string COLLECT_REFUND { get; set; }
        public string METHOD { get; set; }
        public string NARRATIVE { get; set; }
    }
}
