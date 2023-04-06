//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPC_ReversePayment_Update_Req
    {
        public string? record_type { get; set; }
        public int? event_no { get; set; }
        public string? Rec_status { get; set; }
        public string? event_type { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string? BUSINESS_TYPE { get; set; }
        public double? prev_Contra_Bal { get; set; }
        public double? interest_ccy1 { get; set; }
        public double? interest_thb1 { get; set; }
        public string? user_id { get; set; }
        public DateTime? update_date { get; set; }
        public string? AUTH_CODE { get; set; }
        public DateTime? AUTH_DATE { get; set; }
        public string? VOUCH_ID { get; set; }
        public DateTime? LastPayDate { get; set; }
        public DateTime? PastDueDate { get; set; }
        public double? AccruPending { get; set; }
        public DateTime? DateStartAccru { get; set; }

    }
}

//param.Add("@record_type , pExpccupdate.record_type);
//param.Add("@event_no , pExpccupdate.event_no);
//param.Add("@Rec_status , pExpccupdate.Rec_status);
//param.Add("@event_type , pExpccupdate.event_type);
//param.Add("@EVENT_DATE , pExpccupdate.EVENT_DATE);
//param.Add("@BUSINESS_TYPE , pExpccupdate.BUSINESS_TYPE);
//param.Add("@prev_Contra_Bal , pExpccupdate.prev_Contra_Bal);
//param.Add("@interest_ccy1 , pExpccupdate.interest_ccy1);
//param.Add("@interest_thb1 , pExpccupdate.interest_thb1);
//param.Add("@user_id , pExpccupdate.user_id);
//param.Add("@update_date , pExpccupdate.update_date);
//param.Add("@AUTH_CODE , pExpccupdate.AUTH_CODE);
//param.Add("@AUTH_DATE , pExpccupdate.AUTH_DATE);
//param.Add("@VOUCH_ID , pExpccupdate.VOUCH_ID);
//param.Add("@LastPayDate , pExpccupdate.LastPayDate);
//param.Add("@PastDueDate , pExpccupdate.PastDueDate);
//param.Add("@AccruPending , pExpccupdate.AccruPending);
//param.Add("@DateStartAccru , pExpccupdate.DateStartAccru);
