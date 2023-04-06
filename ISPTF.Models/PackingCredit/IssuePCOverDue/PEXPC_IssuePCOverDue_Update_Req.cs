//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPC_IssuePCOverDue_Update_Req
    {
        public string? PACKING_NO { get; set; }
        public string? record_type { get; set; }
        public int? event_no { get; set; }
        public string? event_mode { get; set; }
        public string? Rec_status { get; set; }
        public string? event_type { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string? BUSINESS_TYPE { get; set; }
        public int? PayNo { get; set; }
        public double? interest_ccy1 { get; set; }
        public double? interest_ccy2 { get; set; }
        public double? exch_rate2 { get; set; }
        public double? exch_rate3 { get; set; }
        public double? interest_thb1 { get; set; }
        public double? interest_thb2 { get; set; }
        public double? total_bal_thb { get; set; }
        public double? PCProfit { get; set; }
        public double? MidRate { get; set; }
        public string? remark { get; set; }
        public string? user_id { get; set; }
        public DateTime? update_date { get; set; }
        public string? RECEIVED_NO { get; set; }
        public double? principle_amt_ccy1 { get; set; }
        public double? principle_amt_ccy2 { get; set; }
        public double? principle_amt_thb1 { get; set; }
        public double? principle_amt_thb2 { get; set; }
        public string? pay_instruc { get; set; }
        public string? AutoOverdue { get; set; }
        public string? PCOVERDUE { get; set; }
        public DateTime? LastIntDate { get; set; }
        public DateTime? LastPayDate { get; set; }
        public DateTime? CalIntDate { get; set; }
        public string? IntFlag { get; set; }
        public string? OIntCode { get; set; }
        public double? ointrate { get; set; }
        public double? OINTSPDRATE { get; set; }
        public double? OINTCURRATE { get; set; }
        public int? oINTDAY { get; set; }
        public int? OBaseDay { get; set; }
        public DateTime? VALUE_DATE { get; set; }
        public string? Centerid { get; set; }

    }
}

//param.Add("@PACKING_NO, pExpccupdate.PACKING_NO);
//param.Add("@record_type, pExpccupdate.record_type);
//param.Add("@event_no, pExpccupdate.event_no);
//param.Add("@event_mode, pExpccupdate.event_mode);
//param.Add("@Rec_status, pExpccupdate.Rec_status);
//param.Add("@event_type, pExpccupdate.event_type);
//param.Add("@EVENT_DATE, pExpccupdate.EVENT_DATE);
//param.Add("@BUSINESS_TYPE, pExpccupdate.BUSINESS_TYPE);
//param.Add("@PayNo, pExpccupdate.PayNo);
//param.Add("@interest_ccy1, pExpccupdate.interest_ccy1);
//param.Add("@interest_ccy2, pExpccupdate.interest_ccy2);
//param.Add("@exch_rate2, pExpccupdate.exch_rate2);
//param.Add("@exch_rate3, pExpccupdate.exch_rate3);
//param.Add("@interest_thb1, pExpccupdate.interest_thb1);
//param.Add("@interest_thb2, pExpccupdate.interest_thb2);
//param.Add("@total_bal_thb, pExpccupdate.total_bal_thb);
//param.Add("@PCProfit, pExpccupdate.PCProfit);
//param.Add("@MidRate, pExpccupdate.MidRate);
//param.Add("@remark, pExpccupdate.remark);
//param.Add("@user_id, pExpccupdate.user_id);
//param.Add("@update_date, pExpccupdate.update_date);
//param.Add("@RECEIVED_NO, pExpccupdate.RECEIVED_NO);
//param.Add("@principle_amt_ccy1, pExpccupdate.principle_amt_ccy1);
//param.Add("@principle_amt_ccy2, pExpccupdate.principle_amt_ccy2);
//param.Add("@principle_amt_thb1, pExpccupdate.principle_amt_thb1);
//param.Add("@principle_amt_thb2, pExpccupdate.principle_amt_thb2);
//param.Add("@pay_instruc, pExpccupdate.pay_instruc);
//param.Add("@AutoOverdue, pExpccupdate.AutoOverdue);
//param.Add("@PCOVERDUE, pExpccupdate.PCOVERDUE);
//param.Add("@LastIntDate, pExpccupdate.LastIntDate);
//param.Add("@LastPayDate, pExpccupdate.LastPayDate);
//param.Add("@CalIntDate, pExpccupdate.CalIntDate);
//param.Add("@IntFlag, pExpccupdate.IntFlag);
//param.Add("@OIntCode, pExpccupdate.OIntCode);
//param.Add("@ointrate, pExpccupdate.ointrate);
//param.Add("@OINTSPDRATE, pExpccupdate.OINTSPDRATE);
//param.Add("@OINTCURRATE, pExpccupdate.OINTCURRATE);
//param.Add("@oINTDAY, pExpccupdate.oINTDAY);
//param.Add("@OBaseDay, pExpccupdate.OBaseDay);
//param.Add("@VALUE_DATE, pExpccupdate.VALUE_DATE);
//param.Add("@Centerid, pExpccupdate.Centerid);
