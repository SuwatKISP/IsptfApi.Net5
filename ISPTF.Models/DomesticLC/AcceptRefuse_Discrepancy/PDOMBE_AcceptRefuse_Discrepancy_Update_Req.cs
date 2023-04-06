//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class PDOMBE_AcceptRefuse_Discrepancy_Update_Req
    {
        public string? BENumber { get; set; }
        public string? RecType { get; set; }
        public int? BESeqno { get; set; }
        public string? BEStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
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
        public DateTime? DueDate { get; set; }
        public string? IntRateCode { get; set; }
        public double? intrate { get; set; }
        public double? IntSpread { get; set; }
        //public string? IntRateCode { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public string? Discrepancy { get; set; }
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
//param.Add("@DueDate", pimdombeupdate.DueDate);
//param.Add("@IntRateCode", pimdombeupdate.IntRateCode);
//param.Add("@intrate", pimdombeupdate.intrate);
//param.Add("@IntSpread", pimdombeupdate.IntSpread);
//param.Add("@IntRateCode", pimdombeupdate.IntRateCode);
//param.Add("@IntBaseDay", pimdombeupdate.IntBaseDay);
//param.Add("@IntStartDate", pimdombeupdate.IntStartDate);
//param.Add("@LastIntDate", pimdombeupdate.LastIntDate);
//param.Add("@UpdateDate", pimdombeupdate.UpdateDate);
//param.Add("@UserCode", pimdombeupdate.UserCode);
//param.Add("@Discrepancy", pimdombeupdate.Discrepancy);
//param.Add("@CenterID", pimdombeupdate.CenterID);
