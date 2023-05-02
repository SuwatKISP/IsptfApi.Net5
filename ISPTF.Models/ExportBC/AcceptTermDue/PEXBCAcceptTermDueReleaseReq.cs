using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCAcceptTermDueReleaseReq
    {
        public string EXPORT_BC_NO { get; set; }
        public string EVENT_NO { get; set; }
        public string CenterID { get; set; }
        public string USER_ID { get; set; }
        public string VOUCH_ID { get; set; }

        public string PAYMENT_INSTRU { get; set; }
        public string CONFIRM_DATE { get; set; }
        public string TERM_START_DATE { get; set; }
        public string TERM_DUE_DATE { get; set; }
        public string PLUS_MINUS_DISC { get; set; }
        public string SEQ_ACCEPT_DUE { get; set; }
        public string DISC_DAYS_PLUS_MINUS { get; set; }
        public string REFUND_DISC_RECEIVE { get; set; }
        public string DISC_RECEIVE { get; set; }
        public string DRAFT_CCY { get; set; }
        public string RECEIVE_PAY_AMT { get; set; }
        public string EXCHANGE_RATE { get; set; }
        public string TOTAL_AMOUNT { get; set; }
        public string NARRATIVE { get; set; }
        public string CFRRate { get; set; }
        public string IntRateCode { get; set; }
        public string TENOR_OF_COLL { get; set; }
        public string TENOR_TYPE { get; set; }
        public string DISCOUNT_DAY { get; set; }
        public string CURRENT_DIS_RATE { get; set; }
        public string METHOD { get; set; }
    }
}
