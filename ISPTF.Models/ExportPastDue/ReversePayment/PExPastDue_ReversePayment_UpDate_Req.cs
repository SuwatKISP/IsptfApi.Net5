//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportPastDue
{
    public class PExPastDue__ReversePayment_UpDate_Req
    {
        public string? PayType { get; set; }
        public double? PayAmount { get; set; }
        public double? PayInterest { get; set; }
        public double? NegoComm { get; set; }
        public double? StampFee { get; set; }
        public double? HandingFee { get; set; }
        public double? Totalcharge { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public DateTime? DateLastAccru { get; set; }
        public double? LastAccruCcy { get; set; }
        public double? LastAccruAmt { get; set; }
        public double? AccruCcy { get; set; }
        public double? AccruAmt { get; set; }
        public double? DAccruAmt { get; set; }
        public double? PAccruAmt { get; set; }
        public double? AccruPending { get; set; }
        public double? RevAccru { get; set; }
        public string? NARRATIVE { get; set; }

    }
}

//param.Add("@Status", pExPastDueupdate.Status);
//param.Add("@recstatus", pExPastDueupdate.recstatus);
//param.Add("@Event", pExPastDueupdate.Event);
//param.Add("@EventDate", pExPastDueupdate.EventDate);
//param.Add("@RefLcNo", pExPastDueupdate.RefLcNo);
//param.Add("@Invoice", pExPastDueupdate.Invoice);
//param.Add("@IssBankID", pExPastDueupdate.IssBankID);
//param.Add("@AppName", pExPastDueupdate.AppName);
//param.Add("@ValueDate", pExPastDueupdate.ValueDate);
//param.Add("@DueStatus", pExPastDueupdate.DueStatus);
//param.Add("@OverDueDate", pExPastDueupdate.OverDueDate);
//param.Add("@PastdueDate", pExPastDueupdate.PastdueDate);
//param.Add("@CustCode", pExPastDueupdate.CustCode);
//param.Add("@CustAddr", pExPastDueupdate.CustAddr);
//param.Add("@TenorType", pExPastDueupdate.TenorType);
//param.Add("@DueDay", pExPastDueupdate.DueDay);
//param.Add("@DocCcy", pExPastDueupdate.DocCcy);
//param.Add("@DocAmount", pExPastDueupdate.DocAmount);
//param.Add("@DocBalance", pExPastDueupdate.DocBalance);
//param.Add("@exchrate", pExPastDueupdate.exchrate);
//param.Add("@StartDate", pExPastDueupdate.StartDate);
//param.Add("@DueDate", pExPastDueupdate.DueDate);
//param.Add("@IntRateCode", pExPastDueupdate.IntRateCode);
//param.Add("@IntRate", pExPastDueupdate.IntRate);
//param.Add("@IntSpread", pExPastDueupdate.IntSpread);
//param.Add("@IntBaseDay", pExPastDueupdate.IntBaseDay);
//param.Add("@IntFlag", pExPastDueupdate.IntFlag);
//param.Add("@LastIntDate", pExPastDueupdate.LastIntDate);
//param.Add("@LastIntAmt", pExPastDueupdate.LastIntAmt);
//param.Add("@IntBalance", pExPastDueupdate.IntBalance);
//param.Add("@intDay", pExPastDueupdate.intDay);
//param.Add("@IntCcy", pExPastDueupdate.IntCcy);
//param.Add("@IntAmt", pExPastDueupdate.IntAmt);
//param.Add("@TaxRefund", pExPastDueupdate.TaxRefund);
//param.Add("@TaxAmt", pExPastDueupdate.TaxAmt);
//param.Add("@PayFlag", pExPastDueupdate.PayFlag);
//param.Add("@PayMethod", pExPastDueupdate.PayMethod);
//param.Add("@allocation", pExPastDueupdate.allocation);
//param.Add("@LastReceiptNo", pExPastDueupdate.LastReceiptNo);
//param.Add("@PayType", pExPastDueupdate.PayType);
//param.Add("@PayAmount", pExPastDueupdate.PayAmount);
//param.Add("@PayInterest", pExPastDueupdate.PayInterest);
//param.Add("@NegoComm", pExPastDueupdate.NegoComm);
//param.Add("@StampFee", pExPastDueupdate.StampFee);
//param.Add("@HandingFee", pExPastDueupdate.HandingFee);
//param.Add("@Totalcharge", pExPastDueupdate.Totalcharge);
//param.Add("@TotalAmount", pExPastDueupdate.TotalAmount);
//param.Add("@UpdateDate", pExPastDueupdate.UpdateDate);
//param.Add("@UserCode", pExPastDueupdate.UserCode);
//param.Add("@DateStartAccru", pExPastDueupdate.DateStartAccru);
//param.Add("@DateLastAccru", pExPastDueupdate.DateLastAccru);
//param.Add("@LastAccruCcy", pExPastDueupdate.LastAccruCcy);
//param.Add("@LastAccruAmt", pExPastDueupdate.LastAccruAmt);
//param.Add("@AccruCcy", pExPastDueupdate.AccruCcy);
//param.Add("@AccruAmt", pExPastDueupdate.AccruAmt);
//param.Add("@DAccruAmt", pExPastDueupdate.DAccruAmt);
//param.Add("@PAccruAmt", pExPastDueupdate.PAccruAmt);
//param.Add("@AccruPending", pExPastDueupdate.AccruPending);
//param.Add("@RevAccru", pExPastDueupdate.RevAccru);
//param.Add("@NARRATIVE", pExPastDueupdate.NARRATIVE);
