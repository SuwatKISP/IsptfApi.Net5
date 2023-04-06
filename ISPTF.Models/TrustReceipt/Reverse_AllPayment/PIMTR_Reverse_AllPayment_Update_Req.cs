//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TrustReceipt
{
    public class PIMTR_Reverse_AllPayment_Update_Req
    {
        public string? CenterID { get; set; }
        public string? TRNumber { get; set; }
        public string? RefNumber { get; set; }
        public string? RecType { get; set; }
        public int? TRSeqno { get; set; }
        public string? TRStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? TRDueStatus { get; set; }
        public string? LCNumber { get; set; }
        public string? BLNumber { get; set; }
        public string? BLAdvice { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public double? BLIntAmt { get; set; }
        public string? TenorType { get; set; }
        public string? TRCcy { get; set; }
        public double? TRAmount { get; set; }
        public double? TRBalance { get; set; }
        public double? TRProfit { get; set; }
        public double? MidRate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public double? FBCharge { get; set; }
        public double? FBInterest { get; set; }
        public double? IntBefore { get; set; }
        public double? exchBefore { get; set; }
        public string? IntRateCode { get; set; }
        public double? intrate { get; set; }
        public double? IntSpread { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? IntBalance { get; set; }
        public double? OverdrawComm { get; set; }
        public double? exchrate { get; set; }
        public double? EngageComm { get; set; }
        public double? CommFCD { get; set; }
        public double? OpenAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? PostageAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? IBCComm { get; set; }
        public double? CommLieu { get; set; }
        public double? CommTran { get; set; }
        public double? CommExch { get; set; }
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
        public string? FCyReceiptNo { get; set; }
        public string? PayType { get; set; }
        public double? PayAmount { get; set; }
        public double? PayInterest { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public DateTime? DateToStop { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public double? AccruPending { get; set; }
        public string? Inuse { get; set; }

    }
}

//param.Add("@CenterID", pimtrupdate.CenterID);
//param.Add("@TRNumber", pimtrupdate.TRNumber);
//param.Add("@RefNumber", pimtrupdate.RefNumber);
//param.Add("@RecType", pimtrupdate.RecType);
//param.Add("@TRSeqno", pimtrupdate.TRSeqno);
//param.Add("@TRStatus", pimtrupdate.TRStatus);
//param.Add("@RecStatus", pimtrupdate.RecStatus);
//param.Add("@Event", pimtrupdate.Event);
//param.Add("@EventDate", pimtrupdate.EventDate);
//param.Add("@TRDueStatus", pimtrupdate.TRDueStatus);
//param.Add("@LCNumber", pimtrupdate.LCNumber);
//param.Add("@BLNumber", pimtrupdate.BLNumber);
//param.Add("@BLAdvice", pimtrupdate.BLAdvice);
//param.Add("@CustCode", pimtrupdate.CustCode);
//param.Add("@CustAddr", pimtrupdate.CustAddr);
//param.Add("@BLIntAmt", pimtrupdate.BLIntAmt);
//param.Add("@TenorType", pimtrupdate.TenorType);
//param.Add("@TRCcy", pimtrupdate.TRCcy);
//param.Add("@TRAmount", pimtrupdate.TRAmount);
//param.Add("@TRBalance", pimtrupdate.TRBalance);
//param.Add("@TRProfit", pimtrupdate.TRProfit);
//param.Add("@MidRate", pimtrupdate.MidRate);
//param.Add("@StartDate", pimtrupdate.StartDate);
//param.Add("@DueDate", pimtrupdate.DueDate);
//param.Add("@FBCharge", pimtrupdate.FBCharge);
//param.Add("@FBInterest", pimtrupdate.FBInterest);
//param.Add("@IntBefore", pimtrupdate.IntBefore);
//param.Add("@exchBefore", pimtrupdate.exchBefore);
//param.Add("@IntRateCode", pimtrupdate.IntRateCode);
//param.Add("@intrate", pimtrupdate.intrate);
//param.Add("@IntSpread", pimtrupdate.IntSpread);
//param.Add("@IntBaseDay", pimtrupdate.IntBaseDay);
//param.Add("@IntStartDate", pimtrupdate.IntStartDate);
//param.Add("@LastIntDate", pimtrupdate.LastIntDate);
//param.Add("@LastIntAmt", pimtrupdate.LastIntAmt);
//param.Add("@IntBalance", pimtrupdate.IntBalance);
//param.Add("@OverdrawComm", pimtrupdate.OverdrawComm);
//param.Add("@exchrate", pimtrupdate.exchrate);
//param.Add("@EngageComm", pimtrupdate.EngageComm);
//param.Add("@CommFCD", pimtrupdate.CommFCD);
//param.Add("@OpenAmt", pimtrupdate.OpenAmt);
//param.Add("@CableAmt", pimtrupdate.CableAmt);
//param.Add("@PostageAmt", pimtrupdate.PostageAmt);
//param.Add("@DutyAmt", pimtrupdate.DutyAmt);
//param.Add("@PayableAmt", pimtrupdate.PayableAmt);
//param.Add("@IBCComm", pimtrupdate.IBCComm);
//param.Add("@CommLieu", pimtrupdate.CommLieu);
//param.Add("@CommTran", pimtrupdate.CommTran);
//param.Add("@CommExch", pimtrupdate.CommExch);
//param.Add("@CommCertify", pimtrupdate.CommCertify);
//param.Add("@Discfee", pimtrupdate.Discfee);
//param.Add("@CommOther", pimtrupdate.CommOther);
//param.Add("@taxrefund", pimtrupdate.taxrefund);
//param.Add("@TaxAmt", pimtrupdate.TaxAmt);
//param.Add("@CommDesc", pimtrupdate.CommDesc);
//param.Add("@PayFlag", pimtrupdate.PayFlag);
//param.Add("@PayMethod", pimtrupdate.PayMethod);
//param.Add("@Allocation", pimtrupdate.Allocation);
//param.Add("@DateLastPaid", pimtrupdate.DateLastPaid);
//param.Add("@LastReceiptNo", pimtrupdate.LastReceiptNo);
//param.Add("@FCyReceiptNo", pimtrupdate.FCyReceiptNo);
//param.Add("@PayType", pimtrupdate.PayType);
//param.Add("@PayAmount", pimtrupdate.PayAmount);
//param.Add("@PayInterest", pimtrupdate.PayInterest);
//param.Add("@UpdateDate", pimtrupdate.UpdateDate);
//param.Add("@UserCode", pimtrupdate.UserCode);
//param.Add("@DateToStop", pimtrupdate.DateToStop);
//param.Add("@DateStartAccru", pimtrupdate.DateStartAccru);
//param.Add("@AccruPending", pimtrupdate.AccruPending);
//param.Add("@Inuse", pimtrupdate.Inuse);

