using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCCollectRefundReleaseReq
    {
        public string? EXPORT_BC_NO { get; set; }
        public string? BENE_ID { get; set; }
        public string? USER_ID { get; set; }
        public string? CenterID { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string? VOUCH_ID { get; set; }
        public string? PAYMENT_INSTRU { get; set; }
        public string? CHARGE_ACC { get; set; }
        public string? DRAFT { get; set; }
        public string? MT202 { get; set; }
        public string? FB_CURRENCY { get; set; }
        public double? FB_AMT { get; set; }
        public double? FB_RATE { get; set; }
        public double? FB_AMT_THB { get; set; }
        public double? NEGO_COMM { get; set; }
        public double? TELEX_SWIFT { get; set; }
        public double? COURIER_POSTAGE { get; set; }
        public double? STAMP_FEE { get; set; }
        public double? COMMONTT { get; set; }
        public double? COMM_OTHER { get; set; }
        public double? HANDING_FEE { get; set; }
        public double? INT_AMT_THB { get; set; }
        public double? TOTAL_CHARGE { get; set; }
        public int? REFUND_TAX_YN { get; set; }
        public double? REFUND_TAX_AMT { get; set; }
        public double? TOTAL_AMOUNT { get; set; }
        public string? COLLECT_REFUND { get; set; }
        public string? METHOD { get; set; }
        public string? NARRATIVE { get; set; }
    }
}
