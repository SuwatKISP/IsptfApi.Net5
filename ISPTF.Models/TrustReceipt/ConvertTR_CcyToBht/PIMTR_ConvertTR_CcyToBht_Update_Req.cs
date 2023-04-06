//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TrustReceipt
{
    public class PIMTR_ConvertTR_CcyToBht_Update_Req
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
        public string? AutoOverdue { get; set; }
        public string? TRCcyFlag { get; set; }
        public string? TRRate { get; set; }
        public string? LCNumber { get; set; }
        public string? BLNumber { get; set; }
        public string? BLAdvice { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? DocCcy { get; set; }
        public double? BLBalance { get; set; }
        public double? BLExch { get; set; }
        public string? BLFwd { get; set; }
        public double? BLIntAmt { get; set; }
        public string? TenorType { get; set; }
        public string? TRCcy { get; set; }
        public double? TRAmount { get; set; }
        public double? TRBalance { get; set; }
        public double? TRProfit { get; set; }
        public double? MidRate { get; set; }
        public int? TRDay { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Goods { get; set; }
        public string? SGNumber { get; set; }
        public string? IntRateCode { get; set; }
        public double? intrate { get; set; }
        public double? IntSpread { get; set; }
        public string? IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public string? CFRRate { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? IntBalance { get; set; }
        public double? exchrate { get; set; }
        public double? PayAmount { get; set; }
        public double? PayInterest { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public string? DMS { get; set; }
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

    }
}

//param.Add("@CenterID", pimtrupdate.CenterID);
//param.Add("@TRNumber", pimtrupdate.TRNumber);
//param.Add("@RefNumber", pimtrupdate.RefNumber);
//param.Add("@RecType", pimtrupdate.RecType);
//param.Add("@TRSeqno", pimtrupdate.TRSeqno);
//param.Add("@TRStatus ", pimtrupdate.TRStatus);
//param.Add("@RecStatus", pimtrupdate.RecStatus);
//param.Add("@Event", pimtrupdate.Event);
//param.Add("@EventDate", pimtrupdate.EventDate);
//param.Add("@AutoOverdue", pimtrupdate.AutoOverdue);
//param.Add("@TRCcyFlag", pimtrupdate.TRCcyFlag);
//param.Add("@TRRate", pimtrupdate.TRRate);
//param.Add("@LCNumber", pimtrupdate.LCNumber);
//param.Add("@BLNumber", pimtrupdate.BLNumber);
//param.Add("@BLAdvice", pimtrupdate.BLAdvice);
//param.Add("@CustCode", pimtrupdate.CustCode);
//param.Add("@CustAddr", pimtrupdate.CustAddr);
//param.Add("@DocCcy", pimtrupdate.DocCcy);
//param.Add("@BLBalance", pimtrupdate.BLBalance);
//param.Add("@BLExch", pimtrupdate.BLExch);
//param.Add("@BLFwd", pimtrupdate.BLFwd);
//param.Add("@BLIntAmt", pimtrupdate.BLIntAmt);
//param.Add("@TenorType", pimtrupdate.TenorType);
//param.Add("@TRCcy", pimtrupdate.TRCcy);
//param.Add("@TRAmount", pimtrupdate.TRAmount);
//param.Add("@TRBalance", pimtrupdate.TRBalance);
//param.Add("@TRProfit", pimtrupdate.TRProfit);
//param.Add("@MidRate", pimtrupdate.MidRate);
//param.Add("@TRDay", pimtrupdate.TRDay);
//param.Add("@StartDate", pimtrupdate.StartDate);
//param.Add("@DueDate", pimtrupdate.DueDate);
//param.Add("@Goods", pimtrupdate.Goods);
//param.Add("@SGNumber", pimtrupdate.SGNumber);
//param.Add("@IntRateCode", pimtrupdate.IntRateCode);
//param.Add("@intrate", pimtrupdate.intrate);
//param.Add("@IntSpread", pimtrupdate.IntSpread);
//param.Add("@IntFlag", pimtrupdate.IntFlag);
//param.Add("@IntBaseDay", pimtrupdate.IntBaseDay);
//param.Add("@CFRRate", pimtrupdate.CFRRate);
//param.Add("@IntStartDate", pimtrupdate.IntStartDate);
//param.Add("@LastIntDate", pimtrupdate.LastIntDate);
//param.Add("@LastIntAmt", pimtrupdate.LastIntAmt);
//param.Add("@IntBalance", pimtrupdate.IntBalance);
//param.Add("@exchrate", pimtrupdate.exchrate);
//param.Add("@PayAmount", pimtrupdate.PayAmount);
//param.Add("@PayInterest", pimtrupdate.PayInterest);
//param.Add("@UpdateDate", pimtrupdate.UpdateDate);
//param.Add("@UserCode", pimtrupdate.UserCode);
//param.Add("@DMS ", pimtrupdate.DMS);
//param.Add("@trccy1", pimtrupdate.trccy1);
//param.Add("@TRExch1", pimtrupdate.TRExch1);
//param.Add("@TRAmt1", pimtrupdate.TRAmt1);
//param.Add("@TRCont1", pimtrupdate.TRCont1);
//param.Add("@trccy2", pimtrupdate.trccy2);
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

