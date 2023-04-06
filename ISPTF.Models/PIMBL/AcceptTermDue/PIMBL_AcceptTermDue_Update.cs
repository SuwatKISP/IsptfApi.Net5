//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMBL
{
    public class PIMBL_AcceptTermDue_Update_Req
    {
        public string? BLNumber { get; set; }
        public string? AdNumber { get; set; }
        public string? RecType { get; set; }
        public int? BLSeqno { get; set; }
        public string? BLStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
        public DateTime? eventdate { get; set; }
        public string? AdviceDisc { get; set; }
        public string? LCNumber { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? beninfo { get; set; }
        public string? Bencnty { get; set; }
        public string? TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string? TenorTerm { get; set; }
        public string? negobank { get; set; }
        public string? negoaddr { get; set; }
        public string? negocity { get; set; }
        public string? negocnty { get; set; }
        public string? negorefno { get; set; }
        public DateTime? NegoDate { get; set; }
        public string? RemitFlag { get; set; }
        public double? LCBal { get; set; }
        public string? BLCcy { get; set; }
        public double? blAmount { get; set; }
        public string? fbccy { get; set; }
        public double? FBCharge { get; set; }
        public double? FBInterest { get; set; }
        public string? MTNo { get; set; }
        public string? ReimBank { get; set; }
        public string? deductccy { get; set; }
        public double? DeductDisc { get; set; }
        public double? DeductSwift { get; set; }
        public double? DeductComm { get; set; }
        public double? DeductOther { get; set; }
        public double? OverdrawComm { get; set; }
        public double? EngageComm { get; set; }
        public double? OpenAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public string? TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public string? CommDesc { get; set; }
        public string? Allocation { get; set; }
        public string? CenterID { get; set; }
        public string? InUse { get; set; }


    }
}

//param.Add("@BLNumber", pimblupdate.BLNumber);
//param.Add("@AdNumber", pimblupdate.AdNumber);
//param.Add("@RecType", pimblupdate.RecType);
//param.Add("@BLSeqno", pimblupdate.BLSeqno);
//param.Add("@BLStatus", pimblupdate.BLStatus);
//param.Add("@RecStatus", pimblupdate.RecStatus);
//param.Add("@Event", pimblupdate.Event);
//param.Add("@eventdate", pimblupdate.eventdate);
//param.Add("@AdviceDisc", pimblupdate.AdviceDisc);
//param.Add("@LCNumber", pimblupdate.LCNumber);
//param.Add("@CustCode", pimblupdate.CustCode);
//param.Add("@CustAddr", pimblupdate.CustAddr);
//param.Add("@beninfo", pimblupdate.beninfo);
//param.Add("@Bencnty", pimblupdate.Bencnty);
//param.Add("@TenorType", pimblupdate.TenorType);
//param.Add("@TenorDay", pimblupdate.TenorDay);
//param.Add("@TenorTerm", pimblupdate.TenorTerm);
//param.Add("@negobank", pimblupdate.negobank);
//param.Add("@negoaddr", pimblupdate.negoaddr);
//param.Add("@negocity", pimblupdate.negocity);
//param.Add("@negocnty", pimblupdate.negocnty);
//param.Add("@negorefno", pimblupdate.negorefno);
//param.Add("@NegoDate", pimblupdate.NegoDate);
//param.Add("@RemitFlag", pimblupdate.RemitFlag);
//param.Add("@LCBal", pimblupdate.LCBal);
//param.Add("@BLCcy", pimblupdate.BLCcy);
//param.Add("@blAmount", pimblupdate.blAmount);
//param.Add("@fbccy", pimblupdate.fbccy);
//param.Add("@FBCharge", pimblupdate.FBCharge);
//param.Add("@FBInterest", pimblupdate.FBInterest);
//param.Add("@MTNo", pimblupdate.MTNo);
//param.Add("@ReimBank", pimblupdate.ReimBank);
//param.Add("@deductccy", pimblupdate.deductccy);
//param.Add("@DeductDisc", pimblupdate.DeductDisc);
//param.Add("@DeductSwift", pimblupdate.DeductSwift);
//param.Add("@DeductComm", pimblupdate.DeductComm);
//param.Add("@DeductOther", pimblupdate.DeductOther);
//param.Add("@OverdrawComm", pimblupdate.OverdrawComm);
//param.Add("@EngageComm", pimblupdate.EngageComm);
//param.Add("@OpenAmt", pimblupdate.OpenAmt);
//param.Add("@CableAmt", pimblupdate.CableAmt);
//param.Add("@DutyAmt", pimblupdate.DutyAmt);
//param.Add("@PayableAmt", pimblupdate.PayableAmt);
//param.Add("@TaxRefund", pimblupdate.TaxRefund);
//param.Add("@TaxAmt", pimblupdate.TaxAmt);
//param.Add("@CommDesc", pimblupdate.CommDesc);
//param.Add("@Allocation", pimblupdate.Allocation);
//param.Add("@CenterID", pimblupdate.CenterID);
//param.Add("@InUse", pimblupdate.InUse);


