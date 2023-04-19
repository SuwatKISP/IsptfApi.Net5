using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PImsg
    {
        public string Sgnumber { get; set; }
        public string RecType { get; set; }
        public int Sgseqno { get; set; }
        public string Sgstatus { get; set; }
        public string RecStatus { get; set; }
        public string SupStatus { get; set; }
        public string EventMode { get; set; }
        public string Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string Locode { get; set; }
        public string Aocode { get; set; }
        public string Sgmode { get; set; }
        public string Sgtype { get; set; }
        public string ReferLc { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string CustCode { get; set; }
        public string BenInfo { get; set; }
        public string Blnumber { get; set; }
        public string Shipping { get; set; }
        public string Vessel { get; set; }
        public string MasterAwb { get; set; }
        public string HouseAwb { get; set; }
        public string InvNumber { get; set; }
        public string Sgccy { get; set; }
        public double Sgamt { get; set; }
        public double? ExchRate { get; set; }
        public double? Sgbaht { get; set; }
        public double? CommAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PenaltyAmt { get; set; }
        public double? RefundTax { get; set; }
        public string RefundFlag { get; set; }
        public string PayFlag { get; set; }
        public string PayMethod { get; set; }
        public string PayRelation { get; set; }
        public string PayRemark { get; set; }
        public string Allocation { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string LastReceiptNo { get; set; }
        public string AppvNo { get; set; }
        public string FacNo { get; set; }
        public string Remark { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string GenaccFlag { get; set; }
        public string VoucherId { get; set; }
        public string InUse { get; set; }
        public string CenterId { get; set; }
        public string CcsAcct { get; set; }
        public string CcsLmType { get; set; }
        public string CcsCnum { get; set; }
        public string CcsCifref { get; set; }
        public string Bpoflag { get; set; }
        public string CampaignCode { get; set; }
        public DateTime? CampaignEffDate { get; set; }
    }
}
