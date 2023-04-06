//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportPastDue
{
    public class PExPastDue_EditFlagPastDue_UpDate_Req
    {
        public string? CenterID { get; set; }
        public string? FModule { get; set; }
        public string? RefNumber { get; set; }
        public string? DocNumber { get; set; }
        public string? RecType { get; set; }
        public int? EventNo { get; set; }
        public string? Status { get; set; }
        public string? RecStatus { get; set; }
        public string? EventMode { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? LOCode { get; set; }
        public string? AOCode { get; set; }
        public string? RefLcNo { get; set; }
        public string? Invoice { get; set; }
        public string? IssBankID { get; set; }
        public string? AppName { get; set; }
        public DateTime? ValueDate { get; set; }
        public string? DueStatus { get; set; }
        public DateTime? OverdueDate { get; set; }
        public DateTime? PastDueDate { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? TenorType { get; set; }
        public int? DueDay { get; set; }
        public string? DocCcy { get; set; }
        public double? DocAmount { get; set; }
        public double? DocBalance { get; set; }
        public double? ExchRate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? DIntRateCode { get; set; }
        public double? DIntRate { get; set; }
        public double? DIntSpread { get; set; }
        public int? DIntBaseDay { get; set; }
        public string? IntRateCode { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public int? IntBaseDay { get; set; }
        public string? IntFlag { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? ExchBefore { get; set; }
        public double? IntBefore { get; set; }
        public double? IntBalance { get; set; }
        public int? IntDay { get; set; }
        public double? IntCcy { get; set; }
        public double? IntAmt { get; set; }
        public string? TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public string? PayFlag { get; set; }
        public string? PayMethod { get; set; }
        public string? Allocation { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? AppvNo { get; set; }
        public string? FacNo { get; set; }
        public string? PayType { get; set; }
        public double? PayAmount { get; set; }
        public double? PayInterest { get; set; }
        public double? NegoComm { get; set; }
        public double? TelexSwift { get; set; }
        public double? CourierPostage { get; set; }
        public double? StampFee { get; set; }
        public double? BeStamp { get; set; }
        public double? CommOTher { get; set; }
        public double? HandingFee { get; set; }
        public double? DraftComm { get; set; }
        public double? TotalCharge { get; set; }
        public double? TotalAmount { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string? AuthCode { get; set; }
        public string? GenAccFlag { get; set; }
        public string? VoucherID { get; set; }
        public DateTime? DateToStop { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public DateTime? DateLastAccru { get; set; }
        public double? LastAccruCcy { get; set; }
        public double? LastAccruAmt { get; set; }
        public double? NewAccruCcy { get; set; }
        public double? NewAccruAmt { get; set; }
        public double? AccruCcy { get; set; }
        public double? AccruAmt { get; set; }
        public double? DAccruAmt { get; set; }
        public double? PAccruAmt { get; set; }
        public double? AccruPending { get; set; }
        public double? RevAccru { get; set; }
        public string? DMS { get; set; }
        public string? InUse { get; set; }
        public string? Narrative { get; set; }
        public string? CCS_ACCT { get; set; }
        public string? CCS_LmType { get; set; }
        public string? CCS_CNUM { get; set; }
        public string? CCS_CIFRef { get; set; }
        public string? BPOFlag { get; set; }
        public string? Campaign_Code { get; set; }
        public DateTime? Campaign_EffDate { get; set; }

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
//param.Add("@IntSpread", pExPastDueupdate.IntSpread);
//param.Add("@IntRateCode", pExPastDueupdate.IntRateCode);
//param.Add("@IntRate", pExPastDueupdate.IntRate);
//param.Add("@IntBaseDay", pExPastDueupdate.IntBaseDay);
//param.Add("@IntFlag", pExPastDueupdate.IntFlag);
//param.Add("@LastIntDate", pExPastDueupdate.LastIntDate);
//param.Add("@LastIntAmt", pExPastDueupdate.LastIntAmt);
//param.Add("@IntBalance", pExPastDueupdate.IntBalance);
//param.Add("@intDay", pExPastDueupdate.intDay);
//param.Add("@IntCcy", pExPastDueupdate.IntCcy);
//param.Add("@IntAmt", pExPastDueupdate.IntAmt);
//param.Add("@PayFlag", pExPastDueupdate.PayFlag);
//param.Add("@PayMethod", pExPastDueupdate.PayMethod);
//param.Add("@UpdateDate", pExPastDueupdate.UpdateDate);
//param.Add("@UserCode", pExPastDueupdate.UserCode);
//param.Add("@DateStartAccru", pExPastDueupdate.DateStartAccru);
//param.Add("@DateLastAccru", pExPastDueupdate.DateLastAccru);
//param.Add("@LastAccruAmt", pExPastDueupdate.LastAccruAmt);
//param.Add("@AccruCcy", pExPastDueupdate.AccruCcy);
//param.Add("@AccruAmt", pExPastDueupdate.AccruAmt);
//param.Add("@DAccruAmt", pExPastDueupdate.DAccruAmt);
//param.Add("@PAccruAmt", pExPastDueupdate.PAccruAmt);
//param.Add("@AccruPending", pExPastDueupdate.AccruPending);
//param.Add("@RevAccru", pExPastDueupdate.RevAccru);
