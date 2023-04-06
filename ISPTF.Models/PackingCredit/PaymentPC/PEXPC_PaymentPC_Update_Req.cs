//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPC_PaymentPC_Update_Req
    {
        public string? record_type { get; set; }
        public string? event_mode { get; set; }
        public string? Rec_status { get; set; }
        public string? event_type { get; set; }
        public DateTime? EVENT_DATE { get; set; }
        public string? BUSINESS_TYPE { get; set; }
        public string? cust_id { get; set; }
        public string? cust_info { get; set; }
        public string? cnty_code { get; set; }
        public string? applicant_name { get; set; }
        public string? good_code { get; set; }
        public string? rel_code { get; set; }
        public string? shipmentfr { get; set; }
        public string? shipmentto { get; set; }
        public string? good_desc { get; set; }
        public string? packing_for { get; set; }
        public string? pack_under { get; set; }
        public string? refer_lcno { get; set; }
        public string? doc_ccy { get; set; }
        public double? doc_amount { get; set; }
        public double? Rate { get; set; }
        public double? exch_rate { get; set; }
        public double? pack_ccy { get; set; }
        public double? pack_thb { get; set; }
        public string? pn_no { get; set; }
        public DateTime? doc_expiry_date { get; set; }
        public DateTime? pc_start_date { get; set; }
        public DateTime? current_pc_due { get; set; }
        public double? tot_pc_day { get; set; }
        public DateTime? current_60_daydue { get; set; }
        public double? pc_Int_Rate { get; set; }
        public double? spread_rate { get; set; }
        public double? current_intrate { get; set; }
        public string? PcIntType { get; set; }
        public DateTime? FixDate { get; set; }
        public int? PayNo { get; set; }
        public double? total_date { get; set; }
        public DateTime? ValueDate { get; set; }
        public double? prev_Contra_Bal { get; set; }
        public double? contra_bal { get; set; }
        public double? interest_ccy1 { get; set; }
        public double? interest_ccy2 { get; set; }
        public double? exch_rate1 { get; set; }
        public double? exch_rate2 { get; set; }
        public double? exch_rate3 { get; set; }
        public double? exch_rate5 { get; set; }
        public double? partial_amt_thb5 { get; set; }
        public double? interest_thb1 { get; set; }
        public double? interest_thb2 { get; set; }
        public double? PCProfit { get; set; }
        public double? MidRate { get; set; }
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
        public double? principle_amt_ccy1 { get; set; }
        public double? principle_amt_ccy2 { get; set; }
        public double? principle_amt_ccy4 { get; set; }
        public double? principle_amt_thb1 { get; set; }
        public double? principle_amt_thb2 { get; set; }
        public double? principle_amt_thb4 { get; set; }
        public double? deduct_export_thb { get; set; }
        public DateTime? contra_date { get; set; }
        public string? pay_instruc { get; set; }
        public DateTime? LastPayDate { get; set; }
        public DateTime? CalIntDate { get; set; }
        public double? BahtNet { get; set; }
        public string? FcdAcc { get; set; }
        public double? FcdAmt { get; set; }
        public string? allocation { get; set; }
        public string? Centerid { get; set; }
        public string? FlagBack { get; set; }
        public double? RevAccru { get; set; }
        public string? PurposeCode { get; set; }


    }
}

//param.Add("@record_type, pExpccupdate.record_type);
//param.Add("@event_mode, pExpccupdate.event_mode);
//param.Add("@Rec_status, pExpccupdate.Rec_status);
//param.Add("@event_type, pExpccupdate.event_type);
//param.Add("@EVENT_DATE, pExpccupdate.EVENT_DATE);
//param.Add("@BUSINESS_TYPE, pExpccupdate.BUSINESS_TYPE);
//param.Add("@cust_id, pExpccupdate.cust_id);
//param.Add("@cust_info, pExpccupdate.cust_info);
//param.Add("@cnty_code, pExpccupdate.cnty_code);
//param.Add("@applicant_name, pExpccupdate.applicant_name);
//param.Add("@good_code, pExpccupdate.good_code);
//param.Add("@rel_code, pExpccupdate.rel_code);
//param.Add("@shipmentfr, pExpccupdate.shipmentfr);
//param.Add("@shipmentto, pExpccupdate.shipmentto);
//param.Add("@good_desc, pExpccupdate.good_desc);
//param.Add("@packing_for, pExpccupdate.packing_for);
//param.Add("@pack_under, pExpccupdate.pack_under);
//param.Add("@refer_lcno, pExpccupdate.refer_lcno);
//param.Add("@doc_ccy, pExpccupdate.doc_ccy);
//param.Add("@doc_amount, pExpccupdate.doc_amount);
//param.Add("@Rate, pExpccupdate.Rate);
//param.Add("@exch_rate, pExpccupdate.exch_rate);
//param.Add("@pack_ccy, pExpccupdate.pack_ccy);
//param.Add("@pack_thb, pExpccupdate.pack_thb);
//param.Add("@pn_no, pExpccupdate.pn_no);
//param.Add("@doc_expiry_date, pExpccupdate.doc_expiry_date);
//param.Add("@pc_start_date, pExpccupdate.pc_start_date);
//param.Add("@current_pc_due, pExpccupdate.current_pc_due);
//param.Add("@tot_pc_day, pExpccupdate.tot_pc_day);
//param.Add("@current_60_daydue, pExpccupdate.current_60_daydue);
//param.Add("@pc_Int_Rate, pExpccupdate.pc_Int_Rate);
//param.Add("@spread_rate, pExpccupdate.spread_rate);
//param.Add("@current_intrate, pExpccupdate.current_intrate);
//param.Add("@PcIntType, pExpccupdate.PcIntType);
//param.Add("@FixDate, pExpccupdate.FixDate);
//param.Add("@PayNo, pExpccupdate.PayNo);
//param.Add("@total_date, pExpccupdate.total_date);
//param.Add("@ValueDate, pExpccupdate.ValueDate);
//param.Add("@prev_Contra_Bal, pExpccupdate.prev_Contra_Bal);
//param.Add("@contra_bal, pExpccupdate.contra_bal);
//param.Add("@interest_ccy1, pExpccupdate.interest_ccy1);
//param.Add("@interest_ccy2, pExpccupdate.interest_ccy2);
//param.Add("@exch_rate1, pExpccupdate.exch_rate1);
//param.Add("@exch_rate2, pExpccupdate.exch_rate2);
//param.Add("@exch_rate3, pExpccupdate.exch_rate3);
//param.Add("@exch_rate5, pExpccupdate.exch_rate5);
//param.Add("@partial_amt_thb5, pExpccupdate.partial_amt_thb5);
//param.Add("@interest_thb1, pExpccupdate.interest_thb1);
//param.Add("@interest_thb2, pExpccupdate.interest_thb2);
//param.Add("@PCProfit, pExpccupdate.PCProfit);
//param.Add("@MidRate, pExpccupdate.MidRate);
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
//param.Add("@principle_amt_ccy1, pExpccupdate.principle_amt_ccy1);
//param.Add("@principle_amt_ccy2, pExpccupdate.principle_amt_ccy2);
//param.Add("@principle_amt_ccy4, pExpccupdate.principle_amt_ccy4);
//param.Add("@principle_amt_thb1, pExpccupdate.principle_amt_thb1);
//param.Add("@principle_amt_thb2, pExpccupdate.principle_amt_thb2);
//param.Add("@principle_amt_thb4, pExpccupdate.principle_amt_thb4);
//param.Add("@deduct_export_thb, pExpccupdate.deduct_export_thb);
//param.Add("@contra_date, pExpccupdate.contra_date);
//param.Add("@pay_instruc, pExpccupdate.pay_instruc);
//param.Add("@LastPayDate, pExpccupdate.LastPayDate);
//param.Add("@CalIntDate, pExpccupdate.CalIntDate);
//param.Add("@BahtNet, pExpccupdate.BahtNet);
//param.Add("@FcdAcc, pExpccupdate.FcdAcc);
//param.Add("@FcdAmt, pExpccupdate.FcdAmt);
//param.Add("@allocation, pExpccupdate.allocation);
//param.Add("@Centerid, pExpccupdate.Centerid);
//param.Add("@FlagBack, pExpccupdate.FlagBack);
//param.Add("@RevAccru, pExpccupdate.RevAccru);
//param.Add("@PurposeCode, pExpccupdate.PurposeCode);
