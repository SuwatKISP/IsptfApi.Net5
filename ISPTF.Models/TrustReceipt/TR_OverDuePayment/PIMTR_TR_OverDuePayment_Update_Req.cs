//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TrustReceipt
{
    public class PIMTR_TR_OverDuePayment_Update_Req
    {
        string? CenterID { get; set; }
        string? TRNumber { get; set; }
        string? RefNumber { get; set; }
        string? RecType { get; set; }
        int? TRSeqno { get; set; }
        string? TRStatus { get; set; }
        string? RecStatus { get; set; }
        string? Event { get; set; }
        string? TRDueStatus { get; set; }
        string? LCNumber { get; set; }
        string? BLNumber { get; set; }
        string? BLAdvice { get; set; }
        string? CustCode { get; set; }
        string? CustAddr { get; set; }
        double? BLIntAmt { get; set; }
        string? TenorType { get; set; }
        string? TRCcy { get; set; }
        double? TRAmount { get; set; }
        double? TRBalance { get; set; }
        double? TRProfit { get; set; }
        double? MidRate { get; set; }
        DateTime? StartDate { get; set; }
        DateTime? DueDate { get; set; }
        double? FBCharge { get; set; }
        double? FBInterest { get; set; }
        string? Goods { get; set; }
        string? SettleDate { get; set; }
        double? IntBefore { get; set; }
        double? exchBefore { get; set; }
        string? IntRateCode { get; set; }
        double? intrate { get; set; }
        double? IntSpread { get; set; }
        int? IntBaseDay { get; set; }
        DateTime? IntStartDate { get; set; }
        DateTime? LastIntDate { get; set; }
        double? LastIntAmt { get; set; }
        double? IntBalance { get; set; }
        double? OverdrawComm { get; set; }
        double? exchrate { get; set; }
        double? EngageComm { get; set; }
        double? CommFCD { get; set; }
        double? OpenAmt { get; set; }
        double? CableAmt { get; set; }
        double? PostageAmt { get; set; }
        double? DutyAmt { get; set; }
        double? PayableAmt { get; set; }
        double? IBCComm { get; set; }
        double? CommLieu { get; set; }
        double? CommTran { get; set; }
        double? CommExch { get; set; }
        double? CommCertify { get; set; }
        double? Discfee { get; set; }
        double? CommOther { get; set; }
        string? taxrefund { get; set; }
        double? TaxAmt { get; set; }
        string? CommDesc { get; set; }
        string? PayFlag { get; set; }
        string? PayMethod { get; set; }
        string? Allocation { get; set; }
        DateTime? DateLastPaid { get; set; }
        string? LastReceiptNo { get; set; }
        string? FCyReceiptNo { get; set; }
        string? PayType { get; set; }
        double? PayAmount { get; set; }
        double? PayInterest { get; set; }
        DateTime? UpdateDate { get; set; }
        string? UserCode { get; set; }
        DateTime? DateToStop { get; set; }
        DateTime? DateStartAccru { get; set; }
        DateTime? DateLastAccru { get; set; }
        double? LastAccruCcy { get; set; }
        double? LastAccruAmt { get; set; }
        double? AccruCcy { get; set; }
        double? AccruAmt { get; set; }
        double? DAccruAmt { get; set; }
        double? PAccruAmt { get; set; }
        double? AccruPending { get; set; }
        double? RevAccru { get; set; }
        string? Inuse { get; set; }

    }
}

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
//param.Add("@DateLastAccru", pimtrupdate.DateLastAccru);
//param.Add("@LastAccruCcy", pimtrupdate.LastAccruCcy);
//param.Add("@LastAccruAmt", pimtrupdate.LastAccruAmt);
//param.Add("@AccruCcy", pimtrupdate.AccruCcy);
//param.Add("@AccruAmt", pimtrupdate.AccruAmt);
//param.Add("@DAccruAmt", pimtrupdate.DAccruAmt);
//param.Add("@PAccruAmt", pimtrupdate.PAccruAmt);
//param.Add("@AccruPending", pimtrupdate.AccruPending);
//param.Add("@RevAccru", pimtrupdate.RevAccru);
//param.Add("@Inuse", pimtrupdate.Inuse);
