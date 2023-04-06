//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TrustReceipt
{
    public class PIMTR_Change_InterestRate_Update_Req
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
        public string? LCNumber { get; set; }
        public string? BLNumber { get; set; }
        public string? BLAdvice { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? TenorType { get; set; }
        public string? TRCcy { get; set; }
        public double? TRAmount { get; set; }
        public double? TRBalance { get; set; }
        public int? TRDay { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? SettleDate { get; set; }
        public string? SGNumber { get; set; }
        public string? IntRateCode { get; set; }
        public double? intrate { get; set; }
        public double? IntSpread { get; set; }
        public string? IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? IntBalance { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }

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
//param.Add("@AutoOverdue", pimtrupdate.AutoOverdue);
//param.Add("@LCNumber", pimtrupdate.LCNumber);
//param.Add("@BLNumber", pimtrupdate.BLNumber);
//param.Add("@BLAdvice", pimtrupdate.BLAdvice);
//param.Add("@CustCode", pimtrupdate.CustCode);
//param.Add("@CustAddr", pimtrupdate.CustAddr);
//param.Add("@TenorType", pimtrupdate.TenorType);
//param.Add("@TRCcy", pimtrupdate.TRCcy);
//param.Add("@TRAmount", pimtrupdate.TRAmount);
//param.Add("@TRBalance", pimtrupdate.TRBalance);
//param.Add("@TRDay", pimtrupdate.TRDay);
//param.Add("@StartDate", pimtrupdate.StartDate);
//param.Add("@DueDate", pimtrupdate.DueDate);
//param.Add("@SettleDate", pimtrupdate.SettleDate);
//param.Add("@SGNumber", pimtrupdate.SGNumber);
//param.Add("@IntRateCode", pimtrupdate.IntRateCode);
//param.Add("@intrate", pimtrupdate.intrate);
//param.Add("@IntSpread", pimtrupdate.IntSpread);
//param.Add("@IntFlag", pimtrupdate.IntFlag);
//param.Add("@IntBaseDay", pimtrupdate.IntBaseDay);
//param.Add("@IntStartDate", pimtrupdate.IntStartDate);
//param.Add("@LastIntDate", pimtrupdate.LastIntDate);
//param.Add("@LastIntAmt", pimtrupdate.LastIntAmt);
//param.Add("@IntBalance", pimtrupdate.IntBalance);
//param.Add("@UpdateDate", pimtrupdate.UpdateDate);
//param.Add("@UserCode", pimtrupdate.UserCode);

