//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPC_ReversePC_Update_Req
    {
        public string? PACKING_NO { get; set; }
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
        public string? PackNote { get; set; }
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
        public string? PcIntType { get; set; }
        public DateTime? FixDate { get; set; }
        public string? partial_full_rate { get; set; }
        public double? prev_Contra_Bal { get; set; }
        public double? partial_amt_ccy1 { get; set; }
        public double? partial_amt_ccy2 { get; set; }
        public double? partial_amt_ccy3 { get; set; }
        public double? partial_amt_ccy4 { get; set; }
        public double? partial_amt_ccy5 { get; set; }
        public double? partial_amt_ccy6 { get; set; }
        public double? total_bal_ccy { get; set; }
        public double? exch_rate1 { get; set; }
        public double? exch_rate2 { get; set; }
        public double? exch_rate3 { get; set; }
        public double? exch_rate4 { get; set; }
        public double? exch_rate5 { get; set; }
        public double? exch_rate6 { get; set; }
        public double? partial_amt_thb1 { get; set; }
        public double? partial_amt_thb2 { get; set; }
        public double? partial_amt_thb3 { get; set; }
        public double? partial_amt_thb4 { get; set; }
        public double? partial_amt_thb5 { get; set; }
        public double? partial_amt_thb6 { get; set; }
        public double? total_bal_thb { get; set; }
        public string? forward_contract1 { get; set; }
        public string? forward_contract2 { get; set; }
        public string? forward_contract3 { get; set; }
        public string? forward_contract4 { get; set; }
        public string? forward_contract5 { get; set; }
        public string? forward_contract6 { get; set; }
        public double? duty_Stamp { get; set; }
        public double? comm_Other { get; set; }
        public double? comm_onTT { get; set; }
        public double? Comm_Certi { get; set; }
        public double? total_charge { get; set; }
        public double? total_credit_ac { get; set; }
        public string? method { get; set; }
        public string? remark { get; set; }
        public double? TOTAL_AMOUNT { get; set; }
        public string? user_id { get; set; }
        public DateTime? update_date { get; set; }
        public string? GENACC_FLAG { get; set; }
        public DateTime? GENACC_DATE { get; set; }
        public string? RECEIVED_NO { get; set; }
        public double? principle_amt_ccy1 { get; set; }
        public double? principle_amt_thb1 { get; set; }
        public string? pay_instruc { get; set; }
        public string? AutoOverdue { get; set; }
        public string? PCOVERDUE { get; set; }
        public DateTime? LastIntDate { get; set; }
        public DateTime? LastPayDate { get; set; }
        public DateTime? CalIntDate { get; set; }
        public string? IntFlag { get; set; }
        public double? BahtNet { get; set; }
        public string? allocation { get; set; }
        public string? Centerid { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public string? ObjectType { get; set; }
        public string? UnderlyName { get; set; }



    }
}

//param.Add("@PACKING_NO, pExpccupdate.PACKING_NO);                
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
//param.Add("@PackNote, pExpccupdate.PackNote);                    
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
//param.Add("@PcIntType, pExpccupdate.PcIntType);                  
//param.Add("@FixDate, pExpccupdate.FixDate);                      
//param.Add("@partial_full_rate, pExpccupdate.partial_full_rate);  
//param.Add("@prev_Contra_Bal, pExpccupdate.prev_Contra_Bal);      
//param.Add("@partial_amt_ccy1, pExpccupdate.partial_amt_ccy1);    
//param.Add("@partial_amt_ccy2, pExpccupdate.partial_amt_ccy2);    
//param.Add("@partial_amt_ccy3, pExpccupdate.partial_amt_ccy3);    
//param.Add("@partial_amt_ccy4, pExpccupdate.partial_amt_ccy4);    
//param.Add("@partial_amt_ccy5, pExpccupdate.partial_amt_ccy5);    
//param.Add("@partial_amt_ccy6, pExpccupdate.partial_amt_ccy6);    
//param.Add("@total_bal_ccy, pExpccupdate.total_bal_ccy);          
//param.Add("@exch_rate1, pExpccupdate.exch_rate1);                
//param.Add("@exch_rate2, pExpccupdate.exch_rate2);                
//param.Add("@exch_rate3, pExpccupdate.exch_rate3);                
//param.Add("@exch_rate4, pExpccupdate.exch_rate4);                
//param.Add("@exch_rate5, pExpccupdate.exch_rate5);                
//param.Add("@exch_rate6, pExpccupdate.exch_rate6);                
//param.Add("@partial_amt_thb1, pExpccupdate.partial_amt_thb1);    
//param.Add("@partial_amt_thb2, pExpccupdate.partial_amt_thb2);    
//param.Add("@partial_amt_thb3, pExpccupdate.partial_amt_thb3);    
//param.Add("@partial_amt_thb4, pExpccupdate.partial_amt_thb4);    
//param.Add("@partial_amt_thb5, pExpccupdate.partial_amt_thb5);    
//param.Add("@partial_amt_thb6, pExpccupdate.partial_amt_thb6);    
//param.Add("@total_bal_thb, pExpccupdate.total_bal_thb);          
//param.Add("@forward_contract1, pExpccupdate.forward_contract1);  
//param.Add("@forward_contract2, pExpccupdate.forward_contract2);  
//param.Add("@forward_contract3, pExpccupdate.forward_contract3);  
//param.Add("@forward_contract4, pExpccupdate.forward_contract4);  
//param.Add("@forward_contract5, pExpccupdate.forward_contract5);  
//param.Add("@forward_contract6, pExpccupdate.forward_contract6);  
//param.Add("@duty_Stamp, pExpccupdate.duty_Stamp);                
//param.Add("@comm_Other, pExpccupdate.comm_Other);                
//param.Add("@comm_onTT, pExpccupdate.comm_onTT);                  
//param.Add("@Comm_Certi, pExpccupdate.Comm_Certi);                
//param.Add("@total_charge, pExpccupdate.total_charge);            
//param.Add("@total_credit_ac, pExpccupdate.total_credit_ac);      
//param.Add("@method, pExpccupdate.method);                        
//param.Add("@remark, pExpccupdate.remark);                        
//param.Add("@TOTAL_AMOUNT, pExpccupdate.TOTAL_AMOUNT);            
//param.Add("@user_id, pExpccupdate.user_id);                      
//param.Add("@update_date, pExpccupdate.update_date);              
//param.Add("@GENACC_FLAG, pExpccupdate.GENACC_FLAG);              
//param.Add("@GENACC_DATE, pExpccupdate.GENACC_DATE);              
//param.Add("@RECEIVED_NO, pExpccupdate.RECEIVED_NO);              
//param.Add("@principle_amt_ccy1, pExpccupdate.principle_amt_ccy1);
//param.Add("@principle_amt_thb1, pExpccupdate.principle_amt_thb1);
//param.Add("@pay_instruc, pExpccupdate.pay_instruc);              
//param.Add("@AutoOverdue, pExpccupdate.AutoOverdue);              
//param.Add("@PCOVERDUE, pExpccupdate.PCOVERDUE);                  
//param.Add("@LastIntDate, pExpccupdate.LastIntDate);              
//param.Add("@LastPayDate, pExpccupdate.LastPayDate);              
//param.Add("@CalIntDate, pExpccupdate.CalIntDate);                
//param.Add("@IntFlag, pExpccupdate.IntFlag);                      
//param.Add("@BahtNet, pExpccupdate.BahtNet);                      
//param.Add("@allocation, pExpccupdate.allocation);                
//param.Add("@Centerid, pExpccupdate.Centerid);                    
//param.Add("@DateStartAccru, pExpccupdate.DateStartAccru);        
//param.Add("@ObjectType, pExpccupdate.ObjectType);                
//param.Add("@UnderlyName, pExpccupdate.UnderlyName);              