//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMBL
{
    public class PIMBL_EditAdjust_Update_Req
    {
        public string? BLNumber { get; set; }
        public string? AdNumber { get; set; }
        public string? RecType { get; set; }
        public int? BLSeqno { get; set; }
        public string? BLStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
        public DateTime? eventdate { get; set; }
        public string? EventFlag { get; set; }
        public string? AutoOverdue { get; set; }
        public string? LCNumber { get; set; }
        public string? DocCcy { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? beninfo { get; set; }
        public string? TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string? TenorTerm { get; set; }
        public string? negobank { get; set; }
        public string? negocnty { get; set; }
        public string? negorefno { get; set; }
        public string? BLCcy { get; set; }
        public double? blAmount { get; set; }
        public double? blbalance { get; set; }
        public string? SGNumber { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PrevDueDate { get; set; }
        public string? IntRateCode { get; set; }
        public double? intrate { get; set; }
        public double? IntSpread { get; set; }
        public string? IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string? AuthCode { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public string? CenterID { get; set; }


    }
}

//param.Add("@BLNumber", pimblupdate.BLNumber);
//param.Add("@AdNumber", pimblupdate.AdNumber);
//param.Add("@RecType", pimblupdate.RecType);
//param.Add("@BLSeqno", pimblupdate.BLSeqno);
//param.Add("@BLStatus", pimblupdate.BLStatus);
//param.Add("@RecStatus", pimblupdate.RecStatus);
//param.Add("@Event", pimblupdate.Event);
//param.Add("@eventdate", pimblupdate.eventdate);
//param.Add("@EventFlag", pimblupdate.EventFlag);
//param.Add("@AutoOverdue", pimblupdate.AutoOverdue);
//param.Add("@LCNumber", pimblupdate.LCNumber);
//param.Add("@DocCcy", pimblupdate.DocCcy);
//param.Add("@CustCode", pimblupdate.CustCode);
//param.Add("@CustAddr", pimblupdate.CustAddr);
//param.Add("@beninfo", pimblupdate.beninfo);
//param.Add("@TenorType", pimblupdate.TenorType);
//param.Add("@TenorDay", pimblupdate.TenorDay);
//param.Add("@TenorTerm", pimblupdate.TenorTerm);
//param.Add("@negobank", pimblupdate.negobank);
//param.Add("@negocnty", pimblupdate.negocnty);
//param.Add("@negorefno", pimblupdate.negorefno);
//param.Add("@BLCcy", pimblupdate.BLCcy);
//param.Add("@blAmount", pimblupdate.blAmount);
//param.Add("@blbalance", pimblupdate.blbalance);
//param.Add("@SGNumber", pimblupdate.SGNumber);
//param.Add("@StartDate", pimblupdate.StartDate);
//param.Add("@DueDate", pimblupdate.DueDate);
//param.Add("@PrevDueDate", pimblupdate.PrevDueDate);
//param.Add("@IntRateCode", pimblupdate.IntRateCode);
//param.Add("@intrate", pimblupdate.intrate);
//param.Add("@IntSpread", pimblupdate.IntSpread);
//param.Add("@IntFlag", pimblupdate.IntFlag);
//param.Add("@IntBaseDay", pimblupdate.IntBaseDay);
//param.Add("@IntStartDate", pimblupdate.IntStartDate);
//param.Add("@LastIntDate", pimblupdate.LastIntDate);
//param.Add("@UpdateDate", pimblupdate.UpdateDate);
//param.Add("@UserCode", pimblupdate.UserCode);
//param.Add("@AuthDate", pimblupdate.AuthDate);
//param.Add("@AuthCode", pimblupdate.AuthCode);
//param.Add("@DateStartAccru", pimblupdate.DateStartAccru);
//param.Add("@CenterID", pimblupdate.CenterID);
