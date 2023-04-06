//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TrustReceipt
{
    public class PIMTR_Reverse_TR_Update_Req
    {
        public string? CenterID { get; set; }
        public string? TRNumber { get; set; }
        public string? RefNumber { get; set; }
        public string? RecType { get; set; }
        public int? TRSeqno { get; set; }
        public string? TRStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? EventMode { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? ValueDate { get; set; }
        public string? EventFlag { get; set; }
        public string? AutoOverdue { get; set; }
        public string? TRDueStatus { get; set; }
        public string? TRCcyFlag { get; set; }
        public string? TRRate { get; set; }
        public string? LCNumber { get; set; }
        public string? BLNumber { get; set; }
        public string? BLAdvice { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? DocCcy { get; set; }
        public double? BLBalance { get; set; }
        public int? BLDay { get; set; }
        public int? TRTermDay { get; set; }
        public DateTime? BLIntStartDate { get; set; }
        public string? BLIntcode { get; set; }
        public double? BLIntRate { get; set; }
        public int? BLBase { get; set; }
        public double? BLInterest { get; set; }
        public double? BLExch { get; set; }
        public string? BLFwd { get; set; }
        public double? BLIntAmt { get; set; }
        public string? beninfo { get; set; }
        public string? TenorType { get; set; }
        public string? negobank { get; set; }
        public string? negorefno { get; set; }
        public string? ChipNego { get; set; }
        public string? TRCcy { get; set; }
        public double? TRAmount { get; set; }
        public double? TRBalance { get; set; }
        public double? TRProfit { get; set; }
        public double? MidRate { get; set; }
        public int? TRDay { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public double? FBCharge { get; set; }
        public double? FBInterest { get; set; }
        public double? FBEngage { get; set; }
        public string? Invoice { get; set; }
        public string? Goods { get; set; }
        public string? Relation { get; set; }
        public double? DeductSwift { get; set; }
        public double? DeductComm { get; set; }
        public double? DeductOther { get; set; }
        public string? SettleFlag { get; set; }
        public string? MTNego { get; set; }
        public string? ReimBank { get; set; }
        public string? SGNumber { get; set; }
        public double? SGAmount { get; set; }
        public double? DOAmount { get; set; }
        public string? IntPayType { get; set; }
        public string? IntFixdate { get; set; }
        public string? IntRateCode { get; set; }
        public double? intrate { get; set; }
        public double? IntSpread { get; set; }
        public string? IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public string? CFRRate { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? IntBalance { get; set; }
        public double? OverdrawComm { get; set; }
        public double? exchrate { get; set; }
        public double? EngageRate { get; set; }
        public double? EngageComm { get; set; }
        public double? OpenAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? PostageAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? IBCRate { get; set; }
        public double? IBCComm { get; set; }
        public double? CommLieu { get; set; }
        public double? CommTran { get; set; }
        public double? CommCertify { get; set; }
        public double? Discfee { get; set; }
        public double? CommOther { get; set; }
        public string? taxrefund { get; set; }
        public double? TaxAmt { get; set; }
        public string? CommDesc { get; set; }
        public string? PayFlag { get; set; }
        public string? PayMethod { get; set; }
        public string? Allocation { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? AppvNo { get; set; }
        public string? FacNo { get; set; }
        public string? FCyReceiptNo { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public string? tx72 { get; set; }
        public string? Tx59A { get; set; }
        public string? Tx59D { get; set; }
        public double? trccy1 { get; set; }
        public double? TRExch1 { get; set; }
        public double? TRAmt1 { get; set; }
        public double? TRCont1 { get; set; }
        public double? trccy2 { get; set; }
        public double? TRExch2 { get; set; }
        public double? tramt2 { get; set; }
        public string? TRCont2 { get; set; }
        public double? trccy3 { get; set; }
        public double? TRExch3 { get; set; }
        public double? tramt3 { get; set; }
        public string? TRCont3 { get; set; }
        public double? TRCcy4 { get; set; }
        public double? TRExch4 { get; set; }
        public double? tramt4 { get; set; }
        public string? TRCont4 { get; set; }
        public double? TRCcy5 { get; set; }
        public double? TRExch5 { get; set; }
        public double? TRAmt5 { get; set; }
        public string? TRCont5 { get; set; }
        public string? NegoTelex { get; set; }
        public string? Inuse { get; set; }
        public string? ObjectType { get; set; }
        public string? UnderlyName { get; set; }
        public string? BPOFlag { get; set; }

    }
}

//param.Add("@CenterID", pimtrupdate.CenterID);
//param.Add("@TRNumber", pimtrupdate.TRNumber);
//param.Add("@RefNumber", pimtrupdate.RefNumber);
//param.Add("@RecType", pimtrupdate.RecType);
//param.Add("@TRSeqno", pimtrupdate.TRSeqno);
//param.Add("@TRStatus", pimtrupdate.TRStatus);
//param.Add("@RecStatus", pimtrupdate.RecStatus);
//param.Add("@EventMode", pimtrupdate.EventMode);
//param.Add("@Event", pimtrupdate.Event);
//param.Add("@EventDate", pimtrupdate.EventDate);
//param.Add("@ValueDate", pimtrupdate.ValueDate);
//param.Add("@EventFlag", pimtrupdate.EventFlag);
//param.Add("@AutoOverdue", pimtrupdate.AutoOverdue);
//param.Add("@TRDueStatus", pimtrupdate.TRDueStatus);
//param.Add("@TRCcyFlag", pimtrupdate.TRCcyFlag);
//param.Add("@TRRate", pimtrupdate.TRRate);
//param.Add("@LCNumber", pimtrupdate.LCNumber);
//param.Add("@BLNumber", pimtrupdate.BLNumber);
//param.Add("@BLAdvice", pimtrupdate.BLAdvice);
//param.Add("@CustCode", pimtrupdate.CustCode);
//param.Add("@CustAddr", pimtrupdate.CustAddr);
//param.Add("@DocCcy", pimtrupdate.DocCcy);
//param.Add("@BLBalance", pimtrupdate.BLBalance);
//param.Add("@BLDay", pimtrupdate.BLDay);
//param.Add("@TRTermDay", pimtrupdate.TRTermDay);
//param.Add("@BLIntStartDate", pimtrupdate.BLIntStartDate);
//param.Add("@BLIntcode", pimtrupdate.BLIntcode);
//param.Add("@BLIntRate", pimtrupdate.BLIntRate);
//param.Add("@BLBase", pimtrupdate.BLBase);
//param.Add("@BLInterest", pimtrupdate.BLInterest);
//param.Add("@BLExch", pimtrupdate.BLExch);
//param.Add("@BLFwd", pimtrupdate.BLFwd);
//param.Add("@BLIntAmt", pimtrupdate.BLIntAmt);
//param.Add("@beninfo", pimtrupdate.beninfo);
//param.Add("@TenorType", pimtrupdate.TenorType);
//param.Add("@negobank", pimtrupdate.negobank);
//param.Add("@negorefno", pimtrupdate.negorefno);
//param.Add("@ChipNego", pimtrupdate.ChipNego);
//param.Add("@TRCcy", pimtrupdate.TRCcy);
//param.Add("@TRAmount", pimtrupdate.TRAmount);
//param.Add("@TRBalance", pimtrupdate.TRBalance);
//param.Add("@TRProfit", pimtrupdate.TRProfit);
//param.Add("@MidRate", pimtrupdate.MidRate);
//param.Add("@TRDay", pimtrupdate.TRDay);
//param.Add("@StartDate", pimtrupdate.StartDate);
//param.Add("@DueDate", pimtrupdate.DueDate);
//param.Add("@FBCharge", pimtrupdate.FBCharge);
//param.Add("@FBInterest", pimtrupdate.FBInterest);
//param.Add("@FBEngage", pimtrupdate.FBEngage);
//param.Add("@Invoice", pimtrupdate.Invoice);
//param.Add("@Goods", pimtrupdate.Goods);
//param.Add("@Relation", pimtrupdate.Relation);
//param.Add("@DeductSwift", pimtrupdate.DeductSwift);
//param.Add("@DeductComm", pimtrupdate.DeductComm);
//param.Add("@DeductOther", pimtrupdate.DeductOther);
//param.Add("@SettleFlag", pimtrupdate.SettleFlag);
//param.Add("@MTNego", pimtrupdate.MTNego);
//param.Add("@ReimBank", pimtrupdate.ReimBank);
//param.Add("@SGNumber", pimtrupdate.SGNumber);
//param.Add("@SGAmount", pimtrupdate.SGAmount);
//param.Add("@DOAmount", pimtrupdate.DOAmount);
//param.Add("@IntPayType", pimtrupdate.IntPayType);
//param.Add("@IntFixdate", pimtrupdate.IntFixdate);
//param.Add("@IntRateCode", pimtrupdate.IntRateCode);
//param.Add("@intrate", pimtrupdate.intrate);
//param.Add("@IntSpread", pimtrupdate.IntSpread);
//param.Add("@IntFlag", pimtrupdate.IntFlag);
//param.Add("@IntBaseDay", pimtrupdate.IntBaseDay);
//param.Add("@CFRRate", pimtrupdate.CFRRate);
//param.Add("@IntStartDate", pimtrupdate.IntStartDate);
//param.Add("@LastIntDate", pimtrupdate.LastIntDate);
//param.Add("@IntBalance", pimtrupdate.IntBalance);
//param.Add("@OverdrawComm", pimtrupdate.OverdrawComm);
//param.Add("@exchrate", pimtrupdate.exchrate);
//param.Add("@EngageRate", pimtrupdate.EngageRate);
//param.Add("@EngageComm", pimtrupdate.EngageComm);
//param.Add("@OpenAmt", pimtrupdate.OpenAmt);
//param.Add("@CableAmt", pimtrupdate.CableAmt);
//param.Add("@PostageAmt", pimtrupdate.PostageAmt);
//param.Add("@DutyAmt", pimtrupdate.DutyAmt);
//param.Add("@PayableAmt", pimtrupdate.PayableAmt);
//param.Add("@IBCRate", pimtrupdate.IBCRate);
//param.Add("@IBCComm", pimtrupdate.IBCComm);
//param.Add("@CommLieu", pimtrupdate.CommLieu);
//param.Add("@CommTran", pimtrupdate.CommTran);
//param.Add("@CommCertify", pimtrupdate.CommCertify);
//param.Add("@Discfee", pimtrupdate.Discfee);
//param.Add("@CommOther", pimtrupdate.CommOther);
//param.Add("@taxrefund", pimtrupdate.taxrefund);
//param.Add("@TaxAmt", pimtrupdate.TaxAmt);
//param.Add("@CommDesc", pimtrupdate.CommDesc);
//param.Add("@PayFlag", pimtrupdate.PayFlag);
//param.Add("@PayMethod ", pimtrupdate.PayMethod);
//param.Add("@Allocation", pimtrupdate.Allocation);
//param.Add("@DateLastPaid", pimtrupdate.DateLastPaid);
//param.Add("@LastReceiptNo", pimtrupdate.LastReceiptNo);
//param.Add("@AppvNo", pimtrupdate.AppvNo);
//param.Add("@FacNo", pimtrupdate.FacNo);
//param.Add("@FCyReceiptNo", pimtrupdate.FCyReceiptNo);
//param.Add("@DateStartAccru", pimtrupdate.DateStartAccru);
//param.Add("@tx72", pimtrupdate.tx72);
//param.Add("@Tx59A", pimtrupdate.Tx59A);
//param.Add("@Tx59D", pimtrupdate.Tx59D);
//param.Add("@trccy1", pimtrupdate.trccy1);
//param.Add("@TRExch1", pimtrupdate.TRExch1);
//param.Add("@TRAmt1", pimtrupdate.TRAmt1);
//param.Add("@TRCont1", pimtrupdate.TRCont1);
//param.Add("@trccy2 ", pimtrupdate.trccy2);
//param.Add("@TRExch2", pimtrupdate.TRExch2);
//param.Add("@tramt2", pimtrupdate.tramt2);
//param.Add("@TRCont2", pimtrupdate.TRCont2);
//param.Add("@trccy3", pimtrupdate.trccy3);
//param.Add("@TRExch3", pimtrupdate.TRExch3);
//param.Add("@tramt3", pimtrupdate.tramt3);
//param.Add("@TRCont3", pimtrupdate.TRCont3);
//param.Add("@TRCcy4", pimtrupdate.TRCcy4);
//param.Add("@TRExch4", pimtrupdate.TRExch4);
//param.Add("@tramt4", pimtrupdate.tramt4);
//param.Add("@TRCont4", pimtrupdate.TRCont4);
//param.Add("@TRCcy5", pimtrupdate.TRCcy5);
//param.Add("@TRExch5", pimtrupdate.TRExch5);
//param.Add("@TRAmt5", pimtrupdate.TRAmt5);
//param.Add("@TRCont5", pimtrupdate.TRCont5);
//param.Add("@NegoTelex", pimtrupdate.NegoTelex);
//param.Add("@Inuse", pimtrupdate.Inuse);
//param.Add("@ObjectType", pimtrupdate.ObjectType);
//param.Add("@UnderlyName", pimtrupdate.UnderlyName);
//param.Add("@BPOFlag", pimtrupdate.BPOFlag);

