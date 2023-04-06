//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPC_PaymentPCOverDue_Update_Req
    {
        public string? record_type { get; set; }
        public string? event_mode { get; set; }
        public string? Rec_status { get; set; }
        public string? event_type { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string? BUSINESS_TYPE { get; set; }
        public DateTime? ValueDate { get; set; }
        public double? interest_thb1 { get; set; }
        public double? interest_thb2 { get; set; }
        public double? total_bal_thb { get; set; }
        public double? duty_Stamp { get; set; }
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
        public double? principle_amt_thb1 { get; set; }
        public double? principle_amt_thb2 { get; set; }
        public double? principle_amt_thb3 { get; set; }
        public string? pay_instruc { get; set; }
        public string? PaymentType { get; set; }
        public string? AutoOverdue { get; set; }
        public string? PCOVERDUE { get; set; }
        public string? PCPASTDUE { get; set; }
        public int? OveSeqno { get; set; }
        public DateTime? LastIntDate { get; set; }
        public DateTime? LastPayDate { get; set; }
        public double? LastIntAmt { get; set; }
        public string? OIntCode { get; set; }
        public double? ointrate { get; set; }
        public double? OINTSPDRATE { get; set; }
        public double? OINTCURRATE { get; set; }
        public int? oINTDAY { get; set; }
        public int? OBaseDay { get; set; }
        public double? AccruCcy { get; set; }
        public double? AccruAmt { get; set; }
        public DateTime? DateLastAccru { get; set; }
        public DateTime? PastDueDate { get; set; }
        public string? allocation { get; set; }
        public string? Centerid { get; set; }
        public double? AccruPending { get; set; }
        public DateTime? DateToStop { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public double? LastAccruCcy { get; set; }
        public double? LastAccruAmt { get; set; }
        public double? DAccruAmt { get; set; }
        public double? PAccruAmt { get; set; }
        public double? RevAccru { get; set; }
        public double? RevAccruTax { get; set; }

    }
}

//param.Add("@record_type, pExpccupdate.record_type);
//param.Add("@event_mode, pExpccupdate.event_mode);
//param.Add("@Rec_status, pExpccupdate.Rec_status);
//param.Add("@event_type, pExpccupdate.event_type);
//param.Add("@EVENT_DATE, pExpccupdate.EVENT_DATE);
//param.Add("@BUSINESS_TYPE, pExpccupdate.BUSINESS_TYPE);
//param.Add("@ValueDate, pExpccupdate.ValueDate);
//param.Add("@interest_thb1, pExpccupdate.interest_thb1);
//param.Add("@interest_thb2, pExpccupdate.interest_thb2);
//param.Add("@total_bal_thb, pExpccupdate.total_bal_thb);
//param.Add("@duty_Stamp, pExpccupdate.duty_Stamp);
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
//param.Add("@principle_amt_thb1, pExpccupdate.principle_amt_thb1);
//param.Add("@principle_amt_thb2, pExpccupdate.principle_amt_thb2);
//param.Add("@principle_amt_thb3, pExpccupdate.principle_amt_thb3);
//param.Add("@pay_instruc, pExpccupdate.pay_instruc);
//param.Add("@PaymentType, pExpccupdate.PaymentType);
//param.Add("@AutoOverdue, pExpccupdate.AutoOverdue);
//param.Add("@PCOVERDUE, pExpccupdate.PCOVERDUE);
//param.Add("@PCPASTDUE, pExpccupdate.PCPASTDUE);
//param.Add("@OveSeqno, pExpccupdate.OveSeqno);
//param.Add("@LastIntDate, pExpccupdate.LastIntDate);
//param.Add("@LastPayDate, pExpccupdate.LastPayDate);
//param.Add("@LastIntAmt, pExpccupdate.LastIntAmt);
//param.Add("@OIntCode, pExpccupdate.OIntCode);
//param.Add("@ointrate, pExpccupdate.ointrate);
//param.Add("@OINTSPDRATE, pExpccupdate.OINTSPDRATE);
//param.Add("@OINTCURRATE, pExpccupdate.OINTCURRATE);
//param.Add("@oINTDAY, pExpccupdate.oINTDAY);
//param.Add("@OBaseDay, pExpccupdate.OBaseDay);
//param.Add("@AccruCcy, pExpccupdate.AccruCcy);
//param.Add("@AccruAmt, pExpccupdate.AccruAmt);
//param.Add("@DateLastAccru, pExpccupdate.DateLastAccru);
//param.Add("@PastDueDate, pExpccupdate.PastDueDate);
//param.Add("@allocation, pExpccupdate.allocation);
//param.Add("@Centerid, pExpccupdate.Centerid);
//param.Add("@AccruPending, pExpccupdate.AccruPending);
//param.Add("@DateToStop, pExpccupdate.DateToStop);
//param.Add("@DateStartAccru, pExpccupdate.DateStartAccru);
//param.Add("@LastAccruCcy, pExpccupdate.LastAccruCcy);
//param.Add("@LastAccruAmt, pExpccupdate.LastAccruAmt);
//param.Add("@DAccruAmt, pExpccupdate.DAccruAmt);
//param.Add("@PAccruAmt, pExpccupdate.PAccruAmt);
//param.Add("@RevAccru, pExpccupdate.RevAccru);
//param.Add("@RevAccruTax, pExpccupdate.RevAccruTax);
