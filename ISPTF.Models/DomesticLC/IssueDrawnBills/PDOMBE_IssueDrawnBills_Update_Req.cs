//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class PDOMBE_IssueDrawnBills_Update_Req
    {
        public string? BENumber { get; set; }
        public string? RecType { get; set; }
        public int? BESeqno { get; set; }
        public string? BEStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
        public string? AutoOverdue { get; set; }
        public DateTime? DueDate { get; set; }
        public string? DLCNumber { get; set; }
        public string? DocCcy { get; set; }
        public double? DLCAmt { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? beninfo { get; set; }
        public string? BenCnty { get; set; }
        public string? AdviceDisc { get; set; }
        public string? AdviceResult { get; set; }
        public string? ReferBE { get; set; }
        public string? TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string? TenorTerm { get; set; }
        public DateTime? negodate { get; set; }
        public string? BECcy { get; set; }
        public double? BEAmount { get; set; }
        public double? BEBalance { get; set; }
        public double? BEOverDrawn { get; set; }
        public DateTime? StartDate { get; set; }
        public string? IntRateCode { get; set; }
        public double? intrate { get; set; }
        public double? IntSpread { get; set; }
        public string? IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? exchrate { get; set; }
        public double? OverAmt { get; set; }
        public double? NegoAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? CommOther { get; set; }
        public double? CommTran { get; set; }
        public double? CommCertify { get; set; }
        public double? CommEngage { get; set; }
        public double? Discfee { get; set; }
        public string? taxrefund { get; set; }
        public double? TaxAmt { get; set; }
        public string? CommDesc { get; set; }
        public string? PayFlag { get; set; }
        public string? paymethod { get; set; }
        public string? Allocation { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public string? Discrepancy { get; set; }
        public string? Instruction { get; set; }
        public string? TRFLag { get; set; }
        public string? CenterID { get; set; }
        public double? Pending_Payable { get; set; }

    }
}


//param.Add("@BENumber", pimdombeupdate.BENumber);
//param.Add("@RecType", pimdombeupdate.RecType);
//param.Add("@BESeqno", pimdombeupdate.BESeqno);
//param.Add("@BEStatus", pimdombeupdate.BEStatus);
//param.Add("@RecStatus", pimdombeupdate.RecStatus);
//param.Add("@Event", pimdombeupdate.Event);
//param.Add("@AutoOverdue", pimdombeupdate.AutoOverdue);
//param.Add("@DueDate", pimdombeupdate.DueDate);
//param.Add("@DLCNumber", pimdombeupdate.DLCNumber);
//param.Add("@DocCcy", pimdombeupdate.DocCcy);
//param.Add("@DLCAmt", pimdombeupdate.DLCAmt);
//param.Add("@CustCode", pimdombeupdate.CustCode);
//param.Add("@CustAddr", pimdombeupdate.CustAddr);
//param.Add("@beninfo", pimdombeupdate.beninfo);
//param.Add("@BenCnty", pimdombeupdate.BenCnty);
//param.Add("@AdviceDisc", pimdombeupdate.AdviceDisc);
//param.Add("@AdviceResult", pimdombeupdate.AdviceResult);
//param.Add("@ReferBE", pimdombeupdate.ReferBE);
//param.Add("@TenorType", pimdombeupdate.TenorType);
//param.Add("@TenorDay", pimdombeupdate.TenorDay);
//param.Add("@TenorTerm", pimdombeupdate.TenorTerm);
//param.Add("@negodate", pimdombeupdate.negodate);
//param.Add("@BECcy", pimdombeupdate.BECcy);
//param.Add("@BEAmount", pimdombeupdate.BEAmount);
//param.Add("@BEBalance", pimdombeupdate.BEBalance);
//param.Add("@BEOverDrawn", pimdombeupdate.BEOverDrawn);
//param.Add("@StartDate", pimdombeupdate.StartDate);
//param.Add("@IntRateCode", pimdombeupdate.IntRateCode);
//param.Add("@intrate", pimdombeupdate.intrate);
//param.Add("@IntSpread", pimdombeupdate.IntSpread);
//param.Add("@IntFlag", pimdombeupdate.IntFlag);
//param.Add("@IntBaseDay", pimdombeupdate.IntBaseDay);
//param.Add("@IntStartDate", pimdombeupdate.IntStartDate);
//param.Add("@LastIntDate", pimdombeupdate.LastIntDate);
//param.Add("@exchrate", pimdombeupdate.exchrate);
//param.Add("@OverAmt", pimdombeupdate.OverAmt);
//param.Add("@NegoAmt", pimdombeupdate.NegoAmt);
//param.Add("@CableAmt", pimdombeupdate.CableAmt);
//param.Add("@DutyAmt", pimdombeupdate.DutyAmt);
//param.Add("@PayableAmt", pimdombeupdate.PayableAmt);
//param.Add("@CommOther", pimdombeupdate.CommOther);
//param.Add("@CommTran", pimdombeupdate.CommTran);
//param.Add("@CommCertify", pimdombeupdate.CommCertify);
//param.Add("@CommEngage", pimdombeupdate.CommEngage);
//param.Add("@Discfee", pimdombeupdate.Discfee);
//param.Add("@taxrefund", pimdombeupdate.taxrefund);
//param.Add("@TaxAmt", pimdombeupdate.TaxAmt);
//param.Add("@CommDesc", pimdombeupdate.CommDesc);
//param.Add("@PayFlag", pimdombeupdate.PayFlag);
//param.Add("@paymethod", pimdombeupdate.paymethod);
//param.Add("@Allocation", pimdombeupdate.Allocation);
//param.Add("@DateLastPaid", pimdombeupdate.DateLastPaid);
//param.Add("@UpdateDate", pimdombeupdate.UpdateDate);
//param.Add("@UserCode", pimdombeupdate.UserCode);
//param.Add("@Discrepancy", pimdombeupdate.Discrepancy);
//param.Add("@Instruction", pimdombeupdate.Instruction);
//param.Add("@TRFLag", pimdombeupdate.TRFLag);
//param.Add("@CenterID", pimdombeupdate.CenterID);
//param.Add("@Pending_Payable", pimdombeupdate.Pending_Payable);
