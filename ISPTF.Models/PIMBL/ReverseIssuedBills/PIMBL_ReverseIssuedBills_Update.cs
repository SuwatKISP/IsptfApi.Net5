//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMBL
{
    public class PIMBL_ReverseIssuedBills_Update_Req
    {
        public string? BLNumber { get; set; }
        public string? AdNumber { get; set; }
        public string? RecType { get; set; }
        public int? BLSeqno { get; set; }
        public string? RecStatus { get; set; }
        public string? EventMode { get; set; }
        public string? Event { get; set; }
        public DateTime? eventdate { get; set; }
        public string? LOCode { get; set; }
        public string? AOCode { get; set; }
        public string? AutoOverdue { get; set; }
        public string? AdviceDisc { get; set; }
        public string? LCNumber { get; set; }
        public string? DocCcy { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? beninfo { get; set; }
        public string? Bencnty { get; set; }
        public string? TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string? TenorTerm { get; set; }
        public double? CommBenCcy { get; set; }
        public DateTime? ValueDate { get; set; }
        public string? negoaddr { get; set; }
        public string? negocity { get; set; }
        public string? negocnty { get; set; }
        public string? ChipNego { get; set; }
        public string? negorefno { get; set; }
        public string? NegoACNo { get; set; }
        public DateTime? NegoDate { get; set; }
        //public DateTime? ValueDate { get; set; }
        public string? goodsflag { get; set; }
        public double? LCBal { get; set; }
        public double? LCAmt { get; set; }
        public string? BLCcy { get; set; }
        public double? blAmount { get; set; }
        public double? blbalance { get; set; }
        public string? fbccy { get; set; }
        public double? FBCharge { get; set; }
        public double? FBInterest { get; set; }
        public string? Discrepancy { get; set; }
        public string? LC740 { get; set; }
        public string? MT999 { get; set; }
        public string? MT799 { get; set; }
        public string? MTtelex { get; set; }
        public string? MTNo { get; set; }
        public string? ReimBank { get; set; }
        public double? DeductDisc { get; set; }
        public double? DeductSwift { get; set; }
        public double? DeductComm { get; set; }
        public double? DeductOther { get; set; }
        public string? issueadvice { get; set; }
        public string? SGNumber { get; set; }
        public string? SGNumber1 { get; set; }
        public string? SGNumber2 { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? SettleFlag { get; set; }
        public string? IntRateCode { get; set; }
        public double? intrate { get; set; }
        public double? IntSpread { get; set; }
        public string? IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? overdrawamt { get; set; }
        public double? overdrawrate { get; set; }
        public double? OverdrawComm { get; set; }
        public double? exchrate { get; set; }
        public double? EngageRate { get; set; }
        public double? EngageComm { get; set; }
        public double? FBChargeTHB { get; set; }
        public double? FBInterestTHB { get; set; }
        public double? OpenAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? PostageAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? CommOther { get; set; }
        public string? TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public string? CommDesc { get; set; }
        public string? Allocation { get; set; }
        public string? FacNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public string? CenterID { get; set; }
        public string? Instruction { get; set; }
        public string? InUse { get; set; }
        public string? ObjectType { get; set; }
        public string? UnderlyName { get; set; }
        public string? BPOFlag { get; set; }
        public double? Pending_Payable { get; set; }

    }
}

//param.Add("@BLNumber", pimblupdate.BLNumber);
//param.Add("@AdNumber", pimblupdate.AdNumber);
//param.Add("@RecType", pimblupdate.RecType);
//param.Add("@BLSeqno", pimblupdate.BLSeqno);
//param.Add("@RecStatus", pimblupdate.RecStatus);
//param.Add("@EventMode", pimblupdate.EventMode);
//param.Add("@Event", pimblupdate.Event);
//param.Add("@eventdate", pimblupdate.eventdate);
//param.Add("@LOCode", pimblupdate.LOCode);
//param.Add("@AOCode", pimblupdate.AOCode);
//param.Add("@AutoOverdue", pimblupdate.AutoOverdue);
//param.Add("@AdviceDisc", pimblupdate.AdviceDisc);
//param.Add("@LCNumber", pimblupdate.LCNumber);
//param.Add("@DocCcy", pimblupdate.DocCcy);
//param.Add("@CustCode", pimblupdate.CustCode);
//param.Add("@CustAddr", pimblupdate.CustAddr);
//param.Add("@beninfo", pimblupdate.beninfo);
//param.Add("@Bencnty", pimblupdate.Bencnty);
//param.Add("@TenorType", pimblupdate.TenorType);
//param.Add("@TenorDay", pimblupdate.TenorDay);
//param.Add("@TenorTerm", pimblupdate.TenorTerm);
//param.Add("@CommBenCcy", pimblupdate.CommBenCcy);
//param.Add("@ValueDate", pimblupdate.ValueDate);
//param.Add("@negoaddr", pimblupdate.negoaddr);
//param.Add("@negocity", pimblupdate.negocity);
//param.Add("@negocnty", pimblupdate.negocnty);
//param.Add("@ChipNego", pimblupdate.ChipNego);
//param.Add("@negorefno", pimblupdate.negorefno);
//param.Add("@NegoACNo", pimblupdate.NegoACNo);
//param.Add("@NegoDate", pimblupdate.NegoDate);
//param.Add("@ValueDate", pimblupdate.ValueDate);
//param.Add("@goodsflag", pimblupdate.goodsflag);
//param.Add("@LCBal", pimblupdate.LCBal);
//param.Add("@LCAmt", pimblupdate.LCAmt);
//param.Add("@BLCcy", pimblupdate.BLCcy);
//param.Add("@blAmount", pimblupdate.blAmount);
//param.Add("@blbalance", pimblupdate.blbalance);
//param.Add("@fbccy", pimblupdate.fbccy);
//param.Add("@FBCharge", pimblupdate.FBCharge);
//param.Add("@FBInterest", pimblupdate.FBInterest);
//param.Add("@Discrepancy", pimblupdate.Discrepancy);
//param.Add("@LC740", pimblupdate.LC740);
//param.Add("@MT999", pimblupdate.MT999);
//param.Add("@MT799", pimblupdate.MT799);
//param.Add("@MTtelex", pimblupdate.MTtelex);
//param.Add("@MTNo", pimblupdate.MTNo);
//param.Add("@ReimBank", pimblupdate.ReimBank);
//param.Add("@DeductDisc", pimblupdate.DeductDisc);
//param.Add("@DeductSwift", pimblupdate.DeductSwift);
//param.Add("@DeductComm", pimblupdate.DeductComm);
//param.Add("@DeductOther", pimblupdate.DeductOther);
//param.Add("@issueadvice", pimblupdate.issueadvice);
//param.Add("@SGNumber", pimblupdate.SGNumber);
//param.Add("@SGNumber1", pimblupdate.SGNumber1);
//param.Add("@SGNumber2", pimblupdate.SGNumber2);
//param.Add("@StartDate", pimblupdate.StartDate);
//param.Add("@DueDate", pimblupdate.DueDate);
//param.Add("@SettleFlag", pimblupdate.SettleFlag);
//param.Add("@IntRateCode", pimblupdate.IntRateCode);
//param.Add("@intrate", pimblupdate.intrate);
//param.Add("@IntSpread", pimblupdate.IntSpread);
//param.Add("@IntFlag", pimblupdate.IntFlag);
//param.Add("@IntBaseDay", pimblupdate.IntBaseDay);
//param.Add("@IntStartDate", pimblupdate.IntStartDate);
//param.Add("@LastIntDate", pimblupdate.LastIntDate);
//param.Add("@overdrawamt", pimblupdate.overdrawamt);
//param.Add("@overdrawrate", pimblupdate.overdrawrate);
//param.Add("@OverdrawComm", pimblupdate.OverdrawComm);
//param.Add("@exchrate", pimblupdate.exchrate);
//param.Add("@EngageRate", pimblupdate.EngageRate);
//param.Add("@EngageComm", pimblupdate.EngageComm);
//param.Add("@FBChargeTHB", pimblupdate.FBChargeTHB);
//param.Add("@FBInterestTHB", pimblupdate.FBInterestTHB);
//param.Add("@OpenAmt", pimblupdate.OpenAmt);
//param.Add("@CableAmt", pimblupdate.CableAmt);
//param.Add("@PostageAmt", pimblupdate.PostageAmt);
//param.Add("@DutyAmt", pimblupdate.DutyAmt);
//param.Add("@PayableAmt", pimblupdate.PayableAmt);
//param.Add("@CommOther", pimblupdate.CommOther);
//param.Add("@TaxRefund", pimblupdate.TaxRefund);
//param.Add("@TaxAmt", pimblupdate.TaxAmt);
//param.Add("@CommDesc", pimblupdate.CommDesc);
//param.Add("@Allocation", pimblupdate.Allocation);
//param.Add("@FacNo", pimblupdate.FacNo);
//param.Add("@UpdateDate", pimblupdate.UpdateDate);
//param.Add("@UserCode", pimblupdate.UserCode);
//param.Add("@CenterID", pimblupdate.CenterID);
//param.Add("@Instruction", pimblupdate.Instruction);
//param.Add("@InUse", pimblupdate.InUse);
//param.Add("@ObjectType", pimblupdate.ObjectType);
//param.Add("@UnderlyName", pimblupdate.UnderlyName);
//param.Add("@BPOFlag", pimblupdate.BPOFlag);
//param.Add("@Pending_Payable", pimblupdate.Pending_Payable);
