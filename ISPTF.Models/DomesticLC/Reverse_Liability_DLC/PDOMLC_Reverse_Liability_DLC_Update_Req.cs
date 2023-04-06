//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class PDOMLC_Reverse_Liability_DLC_Update_Req
    {
        public string? DLCNumber { get; set; }
        public string? RecType { get; set; }
        public int? DLCSeqno { get; set; }
        public string? DLCStatus { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? RecStatus { get; set; }
        public string? InUse { get; set; }
        public int? AmendSeq { get; set; }
        public DateTime? DateIssue { get; set; }
        public string? NoVary { get; set; }
        public string? DLCCcy { get; set; }
        public double? DLCAmt { get; set; }
        public double? DLCBal { get; set; }
        public double? DLCAvalBal { get; set; }
        public double? BillAmount { get; set; }
        public double? DLCPostAmt { get; set; }
        public double? AllowPlus { get; set; }
        public double? AllowMinus { get; set; }
        public double? PrevDLCAmt { get; set; }
        public double? PrevDLCBal { get; set; }
        public double? PrevDLCNet { get; set; }
        public DateTime? PrevDateExpiry { get; set; }
        public DateTime? DateExpiry { get; set; }
        public int? LcDays { get; set; }
        public int? PrevLCDays { get; set; }
        public string? TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string? TenorTerm { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? benCode { get; set; }
        public string? beninfo { get; set; }
        public string? PrevBenCode { get; set; }
        public string? PrevBenInfo { get; set; }
        public DateTime? datelateship { get; set; }
        public int? PresentDay { get; set; }
        public string? TranShipment { get; set; }
        public string? PartialShipment { get; set; }
        public string? GoodsCode { get; set; }
        public string? PurposeCode { get; set; }
        public string? GoodsDesc { get; set; }
        public string? SpecialInfo { get; set; }
        public string? InvoiceInfo { get; set; }
        public double? exchrate { get; set; }
        public double? CommLCRate { get; set; }
        public string? taxrefund { get; set; }
        public double? CableMail { get; set; }
        public double? CommAmt { get; set; }
        public double? DutyStamp { get; set; }
        public double? PayableStamp { get; set; }
        public double? OthCharge { get; set; }
        public double? TaxAmt { get; set; }
        public string? PayFlag { get; set; }
        public string? paymethod { get; set; }
        public string? PayRemark { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? appvno { get; set; }
        public string? FacNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public string? GenAccFlag { get; set; }
        public string? Allocation { get; set; }
        public string? ShipmentFrom { get; set; }
        public string? ShipmentTo { get; set; }
        public string? CenterID { get; set; }


    }
}

//param.Add("@DLCNumber", pimdomlcpdate.DLCNumber);
//param.Add("@RecType", pimdomlcpdate.RecType);
//param.Add("@DLCSeqno", pimdomlcpdate.DLCSeqno);
//param.Add("@DLCStatus", pimdomlcpdate.DLCStatus);
//param.Add("@Event", pimdomlcpdate.Event);
//param.Add("@EventDate", pimdomlcpdate.EventDate);
//param.Add("@RecStatus", pimdomlcpdate.RecStatus);
//param.Add("@InUse", pimdomlcpdate.InUse);
//param.Add("@AmendSeq", pimdomlcpdate.AmendSeq);
//param.Add("@DateIssue", pimdomlcpdate.DateIssue);
//param.Add("@NoVary", pimdomlcpdate.NoVary);
//param.Add("@DLCCcy", pimdomlcpdate.DLCCcy);
//param.Add("@DLCAmt", pimdomlcpdate.DLCAmt);
//param.Add("@DLCBal", pimdomlcpdate.DLCBal);
//param.Add("@DLCAvalBal", pimdomlcpdate.DLCAvalBal);
//param.Add("@BillAmount", pimdomlcpdate.BillAmount);
//param.Add("@DLCPostAmt", pimdomlcpdate.DLCPostAmt);
//param.Add("@AllowPlus", pimdomlcpdate.AllowPlus);
//param.Add("@AllowMinus", pimdomlcpdate.AllowMinus);
//param.Add("@PrevDLCAmt", pimdomlcpdate.PrevDLCAmt);
//param.Add("@PrevDLCBal", pimdomlcpdate.PrevDLCBal);
//param.Add("@PrevDLCNet", pimdomlcpdate.PrevDLCNet);
//param.Add("@PrevDateExpiry", pimdomlcpdate.PrevDateExpiry);
//param.Add("@DateExpiry", pimdomlcpdate.DateExpiry);
//param.Add("@LcDays", pimdomlcpdate.LcDays);
//param.Add("@PrevLCDays", pimdomlcpdate.PrevLCDays);
//param.Add("@TenorType", pimdomlcpdate.TenorType);
//param.Add("@TenorDay", pimdomlcpdate.TenorDay);
//param.Add("@TenorTerm", pimdomlcpdate.TenorTerm);
//param.Add("@CustCode", pimdomlcpdate.CustCode);
//param.Add("@CustAddr", pimdomlcpdate.CustAddr);
//param.Add("@benCode", pimdomlcpdate.benCode);
//param.Add("@beninfo", pimdomlcpdate.beninfo);
//param.Add("@PrevBenCode", pimdomlcpdate.PrevBenCode);
//param.Add("@PrevBenInfo", pimdomlcpdate.PrevBenInfo);
//param.Add("@datelateship", pimdomlcpdate.datelateship);
//param.Add("@PresentDay", pimdomlcpdate.PresentDay);
//param.Add("@TranShipment", pimdomlcpdate.TranShipment);
//param.Add("@PartialShipment", pimdomlcpdate.PartialShipment);
//param.Add("@GoodsCode", pimdomlcpdate.GoodsCode);
//param.Add("@PurposeCode", pimdomlcpdate.PurposeCode);
//param.Add("@GoodsDesc", pimdomlcpdate.GoodsDesc);
//param.Add("@SpecialInfo", pimdomlcpdate.SpecialInfo);
//param.Add("@InvoiceInfo", pimdomlcpdate.InvoiceInfo);
//param.Add("@exchrate", pimdomlcpdate.exchrate);
//param.Add("@CommLCRate", pimdomlcpdate.CommLCRate);
//param.Add("@taxrefund", pimdomlcpdate.taxrefund);
//param.Add("@CableMail", pimdomlcpdate.CableMail);
//param.Add("@CommAmt", pimdomlcpdate.CommAmt);
//param.Add("@DutyStamp", pimdomlcpdate.DutyStamp);
//param.Add("@PayableStamp", pimdomlcpdate.PayableStamp);
//param.Add("@OthCharge", pimdomlcpdate.OthCharge);
//param.Add("@TaxAmt", pimdomlcpdate.TaxAmt);
//param.Add("@PayFlag", pimdomlcpdate.PayFlag);
//param.Add("@paymethod", pimdomlcpdate.paymethod);
//param.Add("@PayRemark", pimdomlcpdate.PayRemark);
//param.Add("@DateLastPaid", pimdomlcpdate.DateLastPaid);
//param.Add("@LastReceiptNo", pimdomlcpdate.LastReceiptNo);
//param.Add("@appvno", pimdomlcpdate.appvno);
//param.Add("@FacNo", pimdomlcpdate.FacNo);
//param.Add("@UpdateDate", pimdomlcpdate.UpdateDate);
//param.Add("@UserCode", pimdomlcpdate.UserCode);
//param.Add("@GenAccFlag", pimdomlcpdate.GenAccFlag);
//param.Add("@Allocation", pimdomlcpdate.Allocation);
//param.Add("@ShipmentFrom", pimdomlcpdate.ShipmentFrom);
//param.Add("@ShipmentTo", pimdomlcpdate.ShipmentTo);
//param.Add("@CenterID", pimdomlcpdate.CenterID);

