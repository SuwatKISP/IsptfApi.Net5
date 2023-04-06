//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TrustReceipt
{
    public class PIMTR_TR_EditFlag_Update_Req
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
        public string? EventFlag { get; set; }
        public string? AutoOverdue { get; set; }
        public DateTime? PastDueDate { get; set; }
        public string? LCNumber { get; set; }
        public string? BLNumber { get; set; }
        public string? BLAdvice { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? DocCcy { get; set; }
        public string? TRCcy { get; set; }
        public double? TRBalance { get; set; }
        public int? TRDay { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? SGNumber { get; set; }
        public string? IntPayType { get; set; }
        public string? IntFixdate { get; set; }
        public string? IntRateCode { get; set; }
        public double? intrate { get; set; }
        public double? IntSpread { get; set; }
        public string? IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string? AuthCode { get; set; }
        public DateTime? DateToStop { get; set; }
        public string? NegoTelex { get; set; }

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
//param.Add("@EventFlag", pimtrupdate.EventFlag);
//param.Add("@AutoOverdue", pimtrupdate.AutoOverdue);
//param.Add("@PastDueDate", pimtrupdate.PastDueDate);
//param.Add("@LCNumber", pimtrupdate.LCNumber);
//param.Add("@BLNumber", pimtrupdate.BLNumber);
//param.Add("@BLAdvice", pimtrupdate.BLAdvice);
//param.Add("@CustCode", pimtrupdate.CustCode);
//param.Add("@CustAddr", pimtrupdate.CustAddr);
//param.Add("@DocCcy", pimtrupdate.DocCcy);
//param.Add("@TRCcy", pimtrupdate.TRCcy);
//param.Add("@TRBalance", pimtrupdate.TRBalance);
//param.Add("@TRDay", pimtrupdate.TRDay);
//param.Add("@StartDate", pimtrupdate.StartDate);
//param.Add("@DueDate", pimtrupdate.DueDate);
//param.Add("@SGNumber", pimtrupdate.SGNumber);
//param.Add("@IntPayType", pimtrupdate.IntPayType);
//param.Add("@IntFixdate", pimtrupdate.IntFixdate);
//param.Add("@IntRateCode", pimtrupdate.IntRateCode);
//param.Add("@intrate", pimtrupdate.intrate);
//param.Add("@IntSpread", pimtrupdate.IntSpread);
//param.Add("@IntFlag", pimtrupdate.IntFlag);
//param.Add("@IntBaseDay", pimtrupdate.IntBaseDay);
//param.Add("@IntStartDate", pimtrupdate.IntStartDate);
//param.Add("@UpdateDate", pimtrupdate.UpdateDate);
//param.Add("@UserCode", pimtrupdate.UserCode);
//param.Add("@AuthDate", pimtrupdate.AuthDate);
//param.Add("@AuthCode", pimtrupdate.AuthCode);
//param.Add("@DateToStop", pimtrupdate.DateToStop);
//param.Add("@NegoTelex", pimtrupdate.NegoTelex);

