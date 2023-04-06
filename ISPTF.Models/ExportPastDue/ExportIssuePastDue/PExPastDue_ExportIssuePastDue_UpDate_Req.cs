//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportPastDue
{
    public class PExPastDue_ExportIssuePastDue_UpDate_Req
    {
        public string? FModule { get; set; }
        public string? Status { get; set; }
        public string? recstatus { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? LOCode { get; set; }
        public string? AOCode { get; set; }
        public string? RefLcNo { get; set; }
        public string? Invoice { get; set; }
        public string? IssBankID { get; set; }
        public string? AppName { get; set; }
        public string? DueStatus { get; set; }
        public DateTime? OverDueDate { get; set; }
        public DateTime? PastdueDate { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? TenorType { get; set; }
        public int? DueDay { get; set; }
        public string? DocCcy { get; set; }
        public double? DocAmount { get; set; }
        public double? DocBalance { get; set; }
        public double? exchrate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? DIntRateCode { get; set; }
        public double? Dintrate { get; set; }
        public double? DIntSpread { get; set; }
        public int? DIntBaseDay { get; set; }
        public string? IntRateCode { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public int? IntBaseDay { get; set; }
        public string? IntFlag { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? IntBalance { get; set; }
        public int? intDay { get; set; }
        public double? IntCcy { get; set; }
        public double? IntAmt { get; set; }
        public string? AppvNo { get; set; }
        public string? FacNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public double? AccruPending { get; set; }

    }
}

//param.Add("@FModule", pExPastDueupdate.FModule);
//param.Add("@Status", pExPastDueupdate.Status);
//param.Add("@recstatus", pExPastDueupdate.recstatus);
//param.Add("@Event", pExPastDueupdate.Event);
//param.Add("@EventDate", pExPastDueupdate.EventDate);
//param.Add("@LOCode", pExPastDueupdate.LOCode);
//param.Add("@AOCode", pExPastDueupdate.AOCode);
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
//param.Add("@DIntRateCode", pExPastDueupdate.DIntRateCode);
//param.Add("@Dintrate", pExPastDueupdate.Dintrate);
//param.Add("@DIntSpread", pExPastDueupdate.DIntSpread);
//param.Add("@DIntBaseDay", pExPastDueupdate.DIntBaseDay);
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
//param.Add("@AppvNo", pExPastDueupdate.AppvNo);
//param.Add("@FacNo", pExPastDueupdate.FacNo);
//param.Add("@UpdateDate", pExPastDueupdate.UpdateDate);
//param.Add("@UserCode", pExPastDueupdate.UserCode);
//param.Add("@AccruPending", pExPastDueupdate.AccruPending);
