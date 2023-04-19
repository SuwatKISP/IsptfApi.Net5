using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PCustAppv
    {
        public string AppvNo { get; set; }
        public string RecStatus { get; set; }
        public string AppvStatus { get; set; }
        public DateTime? EntryDate { get; set; }
        public string ReferType { get; set; }
        public string ReferDocNo { get; set; }
        public string ReferRefNo { get; set; }
        public string ReferCcy { get; set; }
        public double? ReferCcyAmt { get; set; }
        public double? ReferExchRate { get; set; }
        public double? ReferBhtAmt { get; set; }
        public string CustCode { get; set; }
        public string FacilityFlag { get; set; }
        public string FacilityNo { get; set; }
        public string HoldCust { get; set; }
        public string HoldFacNo { get; set; }
        public double? HoldAmt { get; set; }
        public double? CreditLine { get; set; }
        public double? LiabAmt { get; set; }
        public double? AppvAmt { get; set; }
        public double? ShareAmt { get; set; }
        public double? SuspAmt { get; set; }
        public double? TotCreditLine { get; set; }
        public double? TotLiabAmt { get; set; }
        public double? TotAppvAmt { get; set; }
        public double? TotShareAmt { get; set; }
        public double? TotSuspAmt { get; set; }
        public string Comment { get; set; }
        public string Event { get; set; }
        public string AppvCancel { get; set; }
        public DateTime? AppvCanDate { get; set; }
        public double? ReverseAmt { get; set; }
        public string ShareType { get; set; }
        public double? TxHoldAmt { get; set; }
        public double? TotHoldAmt { get; set; }
        public double? NonLineAmt { get; set; }
        public double? TotNonLineAmt { get; set; }
        public string Remark { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string CenterId { get; set; }
        public string BankCode { get; set; }
        public double? OverAmt { get; set; }
        public double? GroupAmt { get; set; }
        public double? AvailableAmt { get; set; }
        public double? TotOverAmt { get; set; }
        public double? TotGroupAmt { get; set; }
        public double? TavailableAmt { get; set; }
        public string CampaignCode { get; set; }
        public DateTime? CampaignEffDate { get; set; }
    }
}
