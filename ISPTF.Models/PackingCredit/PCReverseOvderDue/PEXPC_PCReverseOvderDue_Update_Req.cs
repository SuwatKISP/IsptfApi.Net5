//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPC_PCReverseOvderDue_Update_Req
    {
        public string? record_type { get; set; }
        public string? event_mode { get; set; }
        public string? Rec_status { get; set; }
        public string? event_type { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string? BUSINESS_TYPE { get; set; }
        public DateTime? doc_expiry_date { get; set; }
        public DateTime? pc_start_date { get; set; }
        public DateTime? current_pc_due { get; set; }
        public DateTime? prev_start_date { get; set; }
        public double? tot_pc_day { get; set; }
        public DateTime? current_60_daydue { get; set; }
        public string? IntRateCode { get; set; }
        public int? IntBaseDay { get; set; }
        public double? pc_Int_Rate { get; set; }
        public double? spread_rate { get; set; }
        public double? current_intrate { get; set; }
        public string? CFRRate { get; set; }
        public double? interest_ccy2 { get; set; }
        public double? exch_rate2 { get; set; }
        public double? exch_rate3 { get; set; }
        public double? interest_thb1 { get; set; }
        public double? interest_thb2 { get; set; }
        public double? total_bal_thb { get; set; }
        public string? user_id { get; set; }
        public DateTime? update_date { get; set; }
        public string? RECEIVED_NO { get; set; }
        public double? principle_amt_ccy2 { get; set; }
        public double? principle_amt_thb1 { get; set; }
        public double? principle_amt_thb2 { get; set; }
        public string? pay_instruc { get; set; }
        public string? AutoOverdue { get; set; }
        public string? PCOVERDUE { get; set; }
        public DateTime? LastIntDate { get; set; }
        public DateTime? LastPayDate { get; set; }
        public string? IntFlag { get; set; }
        public string? OIntCode { get; set; }
        public double? ointrate { get; set; }
        public double? OINTSPDRATE { get; set; }
        public double? OINTCURRATE { get; set; }
        public int? oINTDAY { get; set; }
        public int? OBaseDay { get; set; }
        public string? Centerid { get; set; }
        public string? FlagBack { get; set; }


    }
}

//param.Add("@record_type, pExpccupdate.record_type);
//param.Add("@event_mode, pExpccupdate.event_mode);
//param.Add("@Rec_status, pExpccupdate.Rec_status);
//param.Add("@event_type, pExpccupdate.event_type);
//param.Add("@EVENT_DATE, pExpccupdate.EVENT_DATE);
//param.Add("@BUSINESS_TYPE, pExpccupdate.BUSINESS_TYPE);
//param.Add("@doc_expiry_date, pExpccupdate.doc_expiry_date);
//param.Add("@pc_start_date, pExpccupdate.pc_start_date);
//param.Add("@current_pc_due, pExpccupdate.current_pc_due);
//param.Add("@prev_start_date, pExpccupdate.prev_start_date);
//param.Add("@tot_pc_day, pExpccupdate.tot_pc_day);
//param.Add("@current_60_daydue, pExpccupdate.current_60_daydue);
//param.Add("@IntRateCode, pExpccupdate.IntRateCode);
//param.Add("@IntBaseDay, pExpccupdate.IntBaseDay);
//param.Add("@pc_Int_Rate, pExpccupdate.pc_Int_Rate);
//param.Add("@spread_rate, pExpccupdate.spread_rate);
//param.Add("@current_intrate, pExpccupdate.current_intrate);
//param.Add("@CFRRate, pExpccupdate.CFRRate);
//param.Add("@interest_ccy2, pExpccupdate.interest_ccy2);
//param.Add("@exch_rate2, pExpccupdate.exch_rate2);
//param.Add("@exch_rate3, pExpccupdate.exch_rate3);
//param.Add("@interest_thb1, pExpccupdate.interest_thb1);
//param.Add("@interest_thb2, pExpccupdate.interest_thb2);
//param.Add("@total_bal_thb, pExpccupdate.total_bal_thb);
//param.Add("@user_id, pExpccupdate.user_id);
//param.Add("@update_date, pExpccupdate.update_date);
//param.Add("@RECEIVED_NO, pExpccupdate.RECEIVED_NO);
//param.Add("@principle_amt_ccy2, pExpccupdate.principle_amt_ccy2);
//param.Add("@principle_amt_thb1, pExpccupdate.principle_amt_thb1);
//param.Add("@principle_amt_thb2, pExpccupdate.principle_amt_thb2);
//param.Add("@pay_instruc, pExpccupdate.pay_instruc);
//param.Add("@AutoOverdue, pExpccupdate.AutoOverdue);
//param.Add("@PCOVERDUE, pExpccupdate.PCOVERDUE);
//param.Add("@LastIntDate, pExpccupdate.LastIntDate);
//param.Add("@LastPayDate, pExpccupdate.LastPayDate);
//param.Add("@IntFlag, pExpccupdate.IntFlag);
//param.Add("@OIntCode, pExpccupdate.OIntCode);
//param.Add("@ointrate, pExpccupdate.ointrate);
//param.Add("@OINTSPDRATE, pExpccupdate.OINTSPDRATE);
//param.Add("@OINTCURRATE, pExpccupdate.OINTCURRATE);
//param.Add("@oINTDAY, pExpccupdate.oINTDAY);
//param.Add("@OBaseDay, pExpccupdate.OBaseDay);
//param.Add("@Centerid, pExpccupdate.Centerid);
//param.Add("@FlagBack, pExpccupdate.FlagBack);
