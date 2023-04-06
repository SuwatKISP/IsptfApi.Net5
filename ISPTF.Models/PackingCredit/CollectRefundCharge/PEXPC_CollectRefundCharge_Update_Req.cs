//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PackingCredit
{
    public class PEXPC_CollectRefundCharge_Update_Req
    {
    public string? record_type { get; set; }
    public string? event_mode { get; set; }
    public string? Rec_status { get; set; }
    public string? event_type { get; set; }
    public DateTime? EVENT_DATE { get; set; }
    public string? BUSINESS_TYPE { get; set; }
    public double? duty_Stamp { get; set; }
    public double? comm_Other { get; set; }
    public double? comm_onTT { get; set; }
    public double? Com_Lieu { get; set; }
    public double? Comm_Certi { get; set; }
    public double? IntReceived { get; set; }
    public double? FrontFee { get; set; }
    public double? total_charge { get; set; }
    public double? total_credit_ac { get; set; }
    public string? method { get; set; }
    public string? remark { get; set; }
    public double? refund_tax_amt { get; set; }
    public double? TOTAL_AMOUNT { get; set; }
    public string? user_id { get; set; }
    public DateTime? update_date { get; set; }
    public string? RECEIVED_NO { get; set; }
    public string? pay_instruc { get; set; }
    public string? allocation { get; set; }
    public string? Centerid { get; set; }

}
}

//param.Add("@record_type, pExpccupdate.record_type);
//param.Add("@event_mode, pExpccupdate.event_mode);
//param.Add("@Rec_status, pExpccupdate.Rec_status);
//param.Add("@event_type, pExpccupdate.event_type);
//param.Add("@EVENT_DATE, pExpccupdate.EVENT_DATE);
//param.Add("@BUSINESS_TYPE, pExpccupdate.BUSINESS_TYPE);
//param.Add("@duty_Stamp, pExpccupdate.duty_Stamp);
//param.Add("@comm_Other, pExpccupdate.comm_Other);
//param.Add("@comm_onTT, pExpccupdate.comm_onTT);
//param.Add("@Com_Lieu, pExpccupdate.Com_Lieu);
//param.Add("@Comm_Certi, pExpccupdate.Comm_Certi);
//param.Add("@IntReceived, pExpccupdate.IntReceived);
//param.Add("@FrontFee, pExpccupdate.FrontFee);
//param.Add("@total_charge, pExpccupdate.total_charge);
//param.Add("@total_credit_ac, pExpccupdate.total_credit_ac);
//param.Add("@method, pExpccupdate.method);
//param.Add("@remark, pExpccupdate.remark);
//param.Add("@refund_tax_amt, pExpccupdate.refund_tax_amt);
//param.Add("@TOTAL_AMOUNT, pExpccupdate.TOTAL_AMOUNT);
//param.Add("@user_id, pExpccupdate.user_id);
//param.Add("@update_date, pExpccupdate.update_date);
//param.Add("@RECEIVED_NO, pExpccupdate.RECEIVED_NO);
//param.Add("@pay_instruc, pExpccupdate.pay_instruc);
//param.Add("@allocation, pExpccupdate.allocation);
//param.Add("@Centerid, pExpccupdate.Centerid);
