//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class PDOMBE_IssueOverDueBills_Update_Req
    {
        public string? BENumber { get; set; }
        public string? RecType { get; set; }
        public int? BESeqno { get; set; }
        public string? BEStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? AutoOverdue { get; set; }
        public DateTime? OverDueDate { get; set; }
        public string? DLCNumber { get; set; }
        public string? DocCcy { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? beninfo { get; set; }
        public string? TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string? TenorTerm { get; set; }
        public string? BECcy { get; set; }
        public double? BEAmount { get; set; }
        public double? BEBalance { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? IntRateCode { get; set; }
        public double? intrate { get; set; }
        public double? IntSpread { get; set; }
        public string? IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? exchrate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public string? CenterID { get; set; }

    }
}

//param.Add("@BENumber", pimdombeupdate.BENumber);
//param.Add("@RecType", pimdombeupdate.RecType);
//param.Add("@BESeqno", pimdombeupdate.BESeqno);
//param.Add("@BEStatus", pimdombeupdate.BEStatus);
//param.Add("@RecStatus", pimdombeupdate.RecStatus);
//param.Add("@Event", pimdombeupdate.Event);
//param.Add("@EventDate", pimdombeupdate.EventDate);
//param.Add("@AutoOverdue", pimdombeupdate.AutoOverdue);
//param.Add("@OverDueDate", pimdombeupdate.OverDueDate);
//param.Add("@DLCNumber", pimdombeupdate.DLCNumber);
//param.Add("@DocCcy", pimdombeupdate.DocCcy);
//param.Add("@CustCode", pimdombeupdate.CustCode);
//param.Add("@CustAddr", pimdombeupdate.CustAddr);
//param.Add("@beninfo", pimdombeupdate.beninfo);
//param.Add("@TenorType", pimdombeupdate.TenorType);
//param.Add("@TenorDay", pimdombeupdate.TenorDay);
//param.Add("@TenorTerm", pimdombeupdate.TenorTerm);
//param.Add("@BECcy", pimdombeupdate.BECcy);
//param.Add("@BEAmount", pimdombeupdate.BEAmount);
//param.Add("@BEBalance", pimdombeupdate.BEBalance);
//param.Add("@StartDate", pimdombeupdate.StartDate);
//param.Add("@DueDate", pimdombeupdate.DueDate);
//param.Add("@IntRateCode", pimdombeupdate.IntRateCode);
//param.Add("@intrate", pimdombeupdate.intrate);
//param.Add("@IntSpread", pimdombeupdate.IntSpread);
//param.Add("@IntFlag", pimdombeupdate.IntFlag);
//param.Add("@IntBaseDay", pimdombeupdate.IntBaseDay);
//param.Add("@IntStartDate", pimdombeupdate.IntStartDate);
//param.Add("@LastIntDate", pimdombeupdate.LastIntDate);
//param.Add("@LastIntAmt", pimdombeupdate.LastIntAmt);
//param.Add("@exchrate", pimdombeupdate.exchrate);
//param.Add("@UpdateDate", pimdombeupdate.UpdateDate);
//param.Add("@UserCode", pimdombeupdate.UserCode);
//param.Add("@CenterID", pimdombeupdate.CenterID);
