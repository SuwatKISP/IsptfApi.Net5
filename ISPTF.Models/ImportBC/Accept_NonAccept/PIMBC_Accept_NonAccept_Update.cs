//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBC
{
    public class PIMBC_Accept_NonAccept_Update_Req
    {
        public DateTime? AcceptDate { get; set; }
        public string? Acceptflag { get; set; }
        public double? BCAmount { get; set; }
        public double? BCBalance { get; set; }
        public string? BCCcy { get; set; }
        public string? BCNumber { get; set; }
        public int? BCSeqno { get; set; }
        public string? BCStatus { get; set; }
        public string? BCType { get; set; }
        public string? CenterID { get; set; }
        public string? CustAddr { get; set; }
        public string? CustCode { get; set; }
        public DateTime? DraftDate { get; set; }
        public string? DrawerInfo { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? MTNo { get; set; }
        public string? PayFlag { get; set; }
        public string? payremark { get; set; }
        public string? PayType { get; set; }
        public string? RecStatus { get; set; }
        public string? RecType { get; set; }
        public string? RemitAddr { get; set; }
        public string? RemitBank { get; set; }
        public string? RemitRefNo { get; set; }
        public string? SGNumber { get; set; }
        public string? SGNumber1 { get; set; }
        public int? TenorDay { get; set; }
        public string? ThirdAddr { get; set; }
        public string? ThirdBank { get; set; }
        public string? ThirdRefNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
    }
}

//param.Add("@AcceptDate", pimbcupdate.AcceptDate);
//param.Add("@Acceptflag", pimbcupdate.Acceptflag);
//param.Add("@BCAmount", pimbcupdate.BCAmount);
//param.Add("@BCBalance", pimbcupdate.BCBalance);
//param.Add("@BCCcy", pimbcupdate.BCCcy);
//param.Add("@BCNumber", pimbcupdate.BCNumber);
//param.Add("@BCSeqno", pimbcupdate.BCSeqno);
//param.Add("@BCStatus", pimbcupdate.BCStatus);
//param.Add("@BCType", pimbcupdate.BCType);
//param.Add("@CenterID", pimbcupdate.CenterID);
//param.Add("@CustAddr", pimbcupdate.CustAddr);
//param.Add("@CustCode", pimbcupdate.CustCode);
//param.Add("@DraftDate", pimbcupdate.DraftDate);
//param.Add("@DrawerInfo", pimbcupdate.DrawerInfo);
//param.Add("@DueDate", pimbcupdate.DueDate);
//param.Add("@Event", pimbcupdate.Event);
//param.Add("@EventDate", pimbcupdate.EventDate);
//param.Add("@MTNo", pimbcupdate.MTNo);
//param.Add("@PayFlag", pimbcupdate.PayFlag);
//param.Add("@payremark", pimbcupdate.payremark);
//param.Add("@PayType", pimbcupdate.PayType);
//param.Add("@RecStatus", pimbcupdate.RecStatus);
//param.Add("@RecType", pimbcupdate.RecType);
//param.Add("@RemitAddr", pimbcupdate.RemitAddr);
//param.Add("@RemitBank", pimbcupdate.RemitBank);
//param.Add("@RemitRefNo", pimbcupdate.RemitRefNo);
//param.Add("@SGNumber", pimbcupdate.SGNumber);
//param.Add("@SGNumber1", pimbcupdate.SGNumber1);
//param.Add("@TenorDay", pimbcupdate.TenorDay);
//param.Add("@ThirdAddr", pimbcupdate.ThirdAddr);
//param.Add("@ThirdBank", pimbcupdate.ThirdBank);
//param.Add("@ThirdRefNo", pimbcupdate.ThirdRefNo);
//param.Add("@UpdateDate", pimbcupdate.UpdateDate);
//param.Add("@UserCode", pimbcupdate.UserCode);


