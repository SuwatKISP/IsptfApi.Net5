//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPC_SettlementTrans_Update_Req
    {
        public string? record_type { get; set; }
        public string? Rec_status { get; set; }
        public string? event_type { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string? BUSINESS_TYPE { get; set; }
        public double? pc_Int_Rate { get; set; }
        public double? spread_rate { get; set; }
        public double? current_intrate { get; set; }
        public double? prev_Contra_Bal { get; set; }
        public double? contra_bal { get; set; }
        public double? handling_Fee { get; set; }
        public double? comm_Other { get; set; }
        public double? Com_Lieu { get; set; }
        public double? total_charge { get; set; }
        public double? total_credit_ac { get; set; }
        public string? method { get; set; }
        public string? remark { get; set; }
        public string? TaxRefund { get; set; }
        public double? refund_tax_amt { get; set; }
        public double? TOTAL_AMOUNT { get; set; }
        public string? user_id { get; set; }
        public DateTime? update_date { get; set; }
        public string? RECEIVED_NO { get; set; }
        public double? deduct_export_thb { get; set; }
        public DateTime? contra_date { get; set; }
        public string? pay_instruc { get; set; }
        public string? allocation { get; set; }
        public string? Centerid { get; set; }
        public string? OrderFlag { get; set; }
        public string? ReceivePayBy { get; set; }
        public string? ApproveBorad { get; set; }


    }
}

//param.Add("@record_type, pExpccupdate.record_type);
//param.Add("@Rec_status, pExpccupdate.Rec_status);
//param.Add("@event_type, pExpccupdate.event_type);
//param.Add("@EVENT_DATE, pExpccupdate.EVENT_DATE);
//param.Add("@BUSINESS_TYPE, pExpccupdate.BUSINESS_TYPE);
//param.Add("@pc_Int_Rate, pExpccupdate.pc_Int_Rate);
//param.Add("@spread_rate, pExpccupdate.spread_rate);
//param.Add("@current_intrate, pExpccupdate.current_intrate);
//param.Add("@prev_Contra_Bal, pExpccupdate.prev_Contra_Bal);
//param.Add("@contra_bal, pExpccupdate.contra_bal);
//param.Add("@handling_Fee, pExpccupdate.handling_Fee);
//param.Add("@comm_Other, pExpccupdate.comm_Other);
//param.Add("@Com_Lieu, pExpccupdate.Com_Lieu);
//param.Add("@total_charge, pExpccupdate.total_charge);
//param.Add("@total_credit_ac, pExpccupdate.total_credit_ac);
//param.Add("@method, pExpccupdate.method);
//param.Add("@remark, pExpccupdate.remark);
//param.Add("@TaxRefund, pExpccupdate.TaxRefund);
//param.Add("@refund_tax_amt, pExpccupdate.refund_tax_amt);
//param.Add("@TOTAL_AMOUNT, pExpccupdate.TOTAL_AMOUNT);
//param.Add("@user_id, pExpccupdate.user_id);
//param.Add("@update_date, pExpccupdate.update_date);
//param.Add("@RECEIVED_NO, pExpccupdate.RECEIVED_NO);
//param.Add("@deduct_export_thb, pExpccupdate.deduct_export_thb);
//param.Add("@contra_date, pExpccupdate.contra_date);
//param.Add("@pay_instruc, pExpccupdate.pay_instruc);
//param.Add("@allocation, pExpccupdate.allocation);
//param.Add("@Centerid, pExpccupdate.Centerid);
//param.Add("@OrderFlag, pExpccupdate.OrderFlag);
//param.Add("@ReceivePayBy, pExpccupdate.ReceivePayBy);
//param.Add("@ApproveBorad, pExpccupdate.ApproveBorad);
