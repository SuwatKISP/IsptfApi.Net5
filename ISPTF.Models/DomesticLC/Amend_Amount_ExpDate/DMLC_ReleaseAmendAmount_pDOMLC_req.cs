using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_ReleaseAmendAmount_pDOMLC_req
    {
        public string? DLCNumber { get; set; }
        public string? RecType { get; set; }
        public int? DLCSeqno { get; set; }
        public string? GoodsDesc { get; set; }
        public string? PayFlag { get; set; }
        public double? DLCAmt { get; set; }
        public double? DLCNet { get; set; }
        public double? DLCBal { get; set; }
        public double? DLCAvalBal { get; set; }
        public DateTime? DateExpiry { get; set; }
        public string? AmendFlag { get; set; }
        public double? AmendAmt { get; set; }
        public double? DLCPostAmt { get; set; }
        public double? AmendAmtInc { get; set; }
        public string? DEPlus_flag { get; set; }
        public double? AmendPlus { get; set; }
        public double? AmendMinus { get; set; }
        public DateTime? EventDate { get; set; }
        public int? AmendSeq { get; set; }
        public DateTime? DateIssue { get; set; }
        public string? TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string? TenorTerm { get; set; }
        public string? BenCode { get; set; }
        public string? BenInfo { get; set; }
        public string? PrevBenCode { get; set; }
        public string? PrevBenInfo { get; set; }
        public DateTime? DateLateShip { get; set; }
        public int? PresentDay { get; set; }
        public string? PartialShipment { get; set; }
        public string? TranShipment { get; set; }
        public string? GoodsCode { get; set; }
        public string? PurposeCode { get; set; }
        public double? CommLCRate { get; set; }
        public string? TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public string? PayMethod { get; set; }
        public double? CommAmt { get; set; }
        public double? DutyStamp { get; set; }
        public double? PayableStamp { get; set; }
        public double? OthCharge { get; set; }
        public string? UserCode { get; set; }
        public string? CenterID { get; set; }
    }
}
