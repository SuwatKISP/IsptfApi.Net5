//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBC
{
    public class PIMBC_Edit_AdjustBC_Update_Req
    {
        public double? AmendAmt { get; set; }
        public string? AmendFlag { get; set; }
        public string? AutoOverdue { get; set; }
        public double? BCBalance { get; set; }
        public string? BCCcy { get; set; }
        public string? BCNumber { get; set; }
        public int? BCSeqno { get; set; }
        public string? BCStatus { get; set; }
        public string? BCType { get; set; }
        public string? CenterID { get; set; }
        public string? CustAddr { get; set; }
        public string? CustCode { get; set; }
        public string? DrawerInfo { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? EventFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public double? intrate { get; set; }
        public string? IntRateCode { get; set; }
        public double? IntSpread { get; set; }
        public DateTime? IntStartDate { get; set; }
        public string? RecStatus { get; set; }
        public string? RecType { get; set; }
        public string? SGNumber { get; set; }
        public string? SGNumber1 { get; set; }
        public DateTime? StartDate { get; set; }
        public int? TenorDay { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }


    }
}

//param.Add("@AmendAmt", pimbcupdate.AmendAmt);
//param.Add("@AmendFlag", pimbcupdate.AmendFlag);
//param.Add("@AutoOverdue", pimbcupdate.AutoOverdue);
//param.Add("@BCBalance", pimbcupdate.BCBalance);
//param.Add("@BCCcy", pimbcupdate.BCCcy);
//param.Add("@BCNumber", pimbcupdate.BCNumber);
//param.Add("@BCSeqno", pimbcupdate.BCSeqno);
//param.Add("@BCStatus", pimbcupdate.BCStatus);
//param.Add("@BCType", pimbcupdate.BCType);
//param.Add("@CenterID", pimbcupdate.CenterID);
//param.Add("@CustAddr", pimbcupdate.CustAddr);
//param.Add("@CustCode", pimbcupdate.CustCode);
//param.Add("@DrawerInfo", pimbcupdate.DrawerInfo);
//param.Add("@DueDate", pimbcupdate.DueDate);
//param.Add("@Event", pimbcupdate.Event);
//param.Add("@EventDate", pimbcupdate.EventDate);
//param.Add("@EventFlag", pimbcupdate.EventFlag);
//param.Add("@IntBaseDay", pimbcupdate.IntBaseDay);
//param.Add("@intrate", pimbcupdate.intrate);
//param.Add("@IntRateCode", pimbcupdate.IntRateCode);
//param.Add("@IntSpread", pimbcupdate.IntSpread);
//param.Add("@IntStartDate", pimbcupdate.IntStartDate);
//param.Add("@RecStatus", pimbcupdate.RecStatus);
//param.Add("@RecType", pimbcupdate.RecType);
//param.Add("@SGNumber", pimbcupdate.SGNumber);
//param.Add("@SGNumber1", pimbcupdate.SGNumber1);
//param.Add("@StartDate", pimbcupdate.StartDate);
//param.Add("@TenorDay", pimbcupdate.TenorDay);
//param.Add("@UpdateDate", pimbcupdate.UpdateDate);
//param.Add("@UserCode", pimbcupdate.UserCode);


