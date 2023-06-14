//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ShippingGuarantee
{
    public class PIMSG
    {
        public string? SGNumber { get; set; }
        public string? RecType { get; set; }
        public int? SGSeqno { get; set; }
        public string? SGStatus { get; set; }
        public string? RecStatus { get; set; }
        public string? SupStatus { get; set; }
        public string? EventMode { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? LOCode { get; set; }
        public string? AOCode { get; set; }
        public string? SGMode { get; set; }
        public string? SGType { get; set; }
        public string? ReferLC { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? CustCode { get; set; }
        public string? BenInfo { get; set; }
        public string? BLNumber { get; set; }
        public string? Shipping { get; set; }
        public string? Vessel { get; set; }
        public string? MasterAwb { get; set; }
        public string? HouseAwb { get; set; }
        public string? InvNumber { get; set; }
        public string? SGCcy { get; set; }
        public double? SGAmt { get; set; }
        public double? ExchRate { get; set; }
        public double? SGBaht { get; set; }
        public double? CommAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PenaltyAmt { get; set; }
        public double? RefundTax { get; set; }
        public string? RefundFlag { get; set; }
        public string? PayFlag { get; set; }
        public string? PayMethod { get; set; }
        public string? PayRelation { get; set; }
        public string? PayRemark { get; set; }
        public string? Allocation { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? AppvNo { get; set; }
        public string? FacNo { get; set; }
        public string? Remark { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string? AuthCode { get; set; }
        public string? GENACC_FLAG { get; set; }
        public string? VOUCHER_ID { get; set; }
        public string? InUse { get; set; }
        public string? CenterID { get; set; }
        public string? CCS_ACCT { get; set; }
        public string? CCS_LmType { get; set; }
        public string? CCS_CNUM { get; set; }
        public string? CCS_CIFRef { get; set; }
        public string? BPOFlag { get; set; }
        public string? Campaign_Code { get; set; }
        public DateTime? Campaign_EffDate { get; set; }

    }
}
