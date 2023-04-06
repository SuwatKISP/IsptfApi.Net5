//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportBC
{
    public class PIMBC_IssueIMBC_Update_Req
    {
        public string? Document { get; set; }
        public string? Allocation { get; set; }
        public string? AutoOverdue { get; set; }
        public double? BCAmount { get; set; }
        public double? BCBalance { get; set; }
        public string? BCCcy { get; set; }
        public string? BCNumber { get; set; }
        public int? BCSeqno { get; set; }
        public string? BCStatus { get; set; }
        public string? BCType { get; set; }
        public string? BLNumber { get; set; }
        public double? CableAmt { get; set; }
        public string? CenterID { get; set; }
        public double? CommLieu { get; set; }
        public double? CommOther { get; set; }
        public string? CustAddr { get; set; }
        public string? CustCode { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public DateTime? DraftDate { get; set; }
        public string? DrawerCit { get; set; }
        public string? DrawerCnty { get; set; }
        public string? DrawerInfo { get; set; }
        public string? DrawerName { get; set; }
        public DateTime? DueDat { get; set; }
        public double? DutyAmt { get; set; }
        public double? EngageComm { get; set; }
        public double? EngageRate { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public double? exchrate { get; set; }
        public string? FacNo { get; set; }
        public double? FBCharge { get; set; }
        public double? FBInterest { get; set; }
        public string? Goods { get; set; }
        public string? GoodsDesc { get; set; }
        public double? IBCComm { get; set; }
        public double? IBCComRate { get; set; }
        public int? IntBaseDay { get; set; }
        public double? intrate { get; set; }
        public string? IntRateCode { get; set; }
        public double? IntSpread { get; set; }
        public DateTime? IntStartDate { get; set; }
        public string? Inuse { get; set; }
        public string? InvNumber { get; set; }
        public DateTime? LastIntDate { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? MTNo { get; set; }
        public string? ObjectType { get; set; }
        public string? PayFlag { get; set; }
        public string? payremark { get; set; }
        public double? PostageAmt { get; set; }
        public string? RecStatu { get; set; }
        public string? RecType { get; set; }
        public string? RemitAddr { get; set; }
        public string? RemitBank { get; set; }
        public string? RemitRefNo { get; set; }
        public double? SGAmt { get; set; }
        public string? SGNumber { get; set; }
        public string? SGNumber1 { get; set; }
        public string? SGNumber2 { get; set; }
        public string? SGNumber3 { get; set; }
        public string? SGNumber4 { get; set; }
        public DateTime? StartDate { get; set; }
        public double? TaxAmt { get; set; }
        public int? TenorDay { get; set; }
        public string? TenorTerm { get; set; }
        public string? ThirdAddr { get; set; }
        public string? ThirdBank { get; set; }
        public string? ThirdRefNo { get; set; }
        public string? TransFrom { get; set; }
        public string? Tx79 { get; set; }
        public string? UnderlyName { get; set; }
    }
}

//param.Add("@Document", pimbcupdate.Document);
//param.Add("@Allocation", pimbcupdate.Allocation);
//param.Add("@AutoOverdue", pimbcupdate.AutoOverdue);
//param.Add("@BCAmount", pimbcupdate.BCAmount);
//param.Add("@BCBalance", pimbcupdate.BCBalance);
//param.Add("@BCCcy", pimbcupdate.BCCcy);
//param.Add("@BCNumber", pimbcupdate.BCNumber);
//param.Add("@BCSeqno", pimbcupdate.BCSeqno);
//param.Add("@BCStatus", pimbcupdate.BCStatus);
//param.Add("@BCType", pimbcupdate.BCType);
//param.Add("@BLNumber", pimbcupdate.BLNumber);
//param.Add("@CableAmt", pimbcupdate.CableAmt);
//param.Add("@CenterID", pimbcupdate.CenterID);
//param.Add("@CommLieu", pimbcupdate.CommLieu);
//param.Add("@CommOther", pimbcupdate.CommOther);
//param.Add("@CustAddr", pimbcupdate.CustAddr);
//param.Add("@CustCode", pimbcupdate.CustCode);
//param.Add("@DateLastPaid", pimbcupdate.DateLastPaid);
//param.Add("@DraftDate", pimbcupdate.DraftDate);
//param.Add("@DrawerCit", pimbcupdate.DrawerCit);
//param.Add("@DrawerCnty", pimbcupdate.DrawerCnty);
//param.Add("@DrawerInfo", pimbcupdate.DrawerInfo);
//param.Add("@DrawerName", pimbcupdate.DrawerName);
//param.Add("@DueDat", pimbcupdate.DueDat);
//param.Add("@DutyAmt", pimbcupdate.DutyAmt);
//param.Add("@EngageComm", pimbcupdate.EngageComm);
//param.Add("@EngageRate", pimbcupdate.EngageRate);
//param.Add("@Event", pimbcupdate.Event);
//param.Add("@EventDate", pimbcupdate.EventDate);
//param.Add("@exchrate", pimbcupdate.exchrate);
//param.Add("@FacNo", pimbcupdate.FacNo);
//param.Add("@FBCharge", pimbcupdate.FBCharge);
//param.Add("@FBInterest", pimbcupdate.FBInterest);
//param.Add("@Goods", pimbcupdate.Goods);
//param.Add("@GoodsDesc", pimbcupdate.GoodsDesc);
//param.Add("@IBCComm", pimbcupdate.IBCComm);
//param.Add("@IBCComRate", pimbcupdate.IBCComRate);
//param.Add("@IntBaseDay", pimbcupdate.IntBaseDay);
//param.Add("@intrate", pimbcupdate.intrate);
//param.Add("@IntRateCode", pimbcupdate.IntRateCode);
//param.Add("@IntSpread", pimbcupdate.IntSpread);
//param.Add("@IntStartDate", pimbcupdate.IntStartDate);
//param.Add("@Inuse", pimbcupdate.Inuse);
//param.Add("@InvNumber", pimbcupdate.InvNumber);
//param.Add("@LastIntDate", pimbcupdate.LastIntDate);
//param.Add("@LastReceiptNo", pimbcupdate.LastReceiptNo);
//param.Add("@MTNo", pimbcupdate.MTNo);
//param.Add("@ObjectType", pimbcupdate.ObjectType);
//param.Add("@PayFlag", pimbcupdate.PayFlag);
//param.Add("@payremark", pimbcupdate.payremark);
//param.Add("@PostageAmt", pimbcupdate.PostageAmt);
//param.Add("@RecStatu", pimbcupdate.RecStatu);
//param.Add("@RecType", pimbcupdate.RecType);
//param.Add("@RemitAddr", pimbcupdate.RemitAddr);
//param.Add("@RemitBank", pimbcupdate.RemitBank);
//param.Add("@RemitRefNo", pimbcupdate.RemitRefNo);
//param.Add("@SGAmt", pimbcupdate.SGAmt);
//param.Add("@SGNumber", pimbcupdate.SGNumber);
//param.Add("@SGNumber1", pimbcupdate.SGNumber1);
//param.Add("@SGNumber2", pimbcupdate.SGNumber2);
//param.Add("@SGNumber3", pimbcupdate.SGNumber3);
//param.Add("@SGNumber4", pimbcupdate.SGNumber4);
//param.Add("@StartDate", pimbcupdate.StartDate);
//param.Add("@TaxAmt", pimbcupdate.TaxAmt);
//param.Add("@TenorDay", pimbcupdate.TenorDay);
//param.Add("@TenorTerm", pimbcupdate.TenorTerm);
//param.Add("@ThirdAddr", pimbcupdate.ThirdAddr);
//param.Add("@ThirdBank", pimbcupdate.ThirdBank);
//param.Add("@ThirdRefNo", pimbcupdate.ThirdRefNo);
//param.Add("@TransFrom", pimbcupdate.TransFrom);
//param.Add("@Tx79", pimbcupdate.Tx79);
//param.Add("@UnderlyName", pimbcupdate.UnderlyName);

