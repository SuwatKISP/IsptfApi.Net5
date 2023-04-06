//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TrustReceipt
{
    public class PIMTR_CollectRefund_Changes_Update_Req
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
        public string? LCNumber { get; set; }
        public string? BLNumber { get; set; }
        public string? BLAdvice { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? DocCcy { get; set; }
        public string? TRCcy { get; set; }
        public double? TRAmount { get; set; }
        public double? FBCharge { get; set; }
        public double? FBInterest { get; set; }
        public double? PrevFBChrg { get; set; }
        public double? PrevFBint { get; set; }
        public double? OverdrawComm { get; set; }
        public double? exchrate { get; set; }
        public double? EngageComm { get; set; }
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
//param.Add("@LCNumber", pimtrupdate.LCNumber);
//param.Add("@BLNumber", pimtrupdate.BLNumber);
//param.Add("@BLAdvice", pimtrupdate.BLAdvice);
//param.Add("@CustCode", pimtrupdate.CustCode);
//param.Add("@CustAddr", pimtrupdate.CustAddr);
//param.Add("@DocCcy", pimtrupdate.DocCcy);
//param.Add("@TRCcy", pimtrupdate.TRCcy);
//param.Add("@TRAmount", pimtrupdate.TRAmount);
//param.Add("@FBCharge", pimtrupdate.FBCharge);
//param.Add("@FBInterest", pimtrupdate.FBInterest);
//param.Add("@PrevFBChrg", pimtrupdate.PrevFBChrg);
//param.Add("@PrevFBint", pimtrupdate.PrevFBint);
//param.Add("@OverdrawComm", pimtrupdate.OverdrawComm);
//param.Add("@exchrate", pimtrupdate.exchrate);
//param.Add("@EngageComm", pimtrupdate.EngageComm);
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
//param.Add("@Inuse", pimtrupdate.Inuse);

