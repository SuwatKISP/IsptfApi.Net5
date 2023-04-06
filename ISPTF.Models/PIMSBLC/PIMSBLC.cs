//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.PIMSBLC
{
    public class PIMSBLC
    {
        public string? SBLCNumber { get; set; }
        public string? RecType { get; set; }
        public int? SBLCSeqno { get; set; }
        public string? SBLCStatus { get; set; }
        public string? EventMode { get; set; }
        public string? Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string? EventFlag { get; set; }
        public string? RecStatus { get; set; }
        public string? InUse { get; set; }
        public string? LOCode { get; set; }
        public string? AOCode { get; set; }
        public int? AmendSeq { get; set; }
        public string? AmendNo { get; set; }
        public string? LGMODE { get; set; }
        public string? LGTYPE { get; set; }
        public string? SBLCRefNo { get; set; }
        public DateTime? DateIssue { get; set; }
        public string? SBLCCcy { get; set; }
        public double? SBLCAmt { get; set; }
        public double? SBLCBal { get; set; }
        public double? SBLCAvalBal { get; set; }
        public double? SBLCNet { get; set; }
        public double? LGTHBAmt { get; set; }
        public double? LGTHBBal { get; set; }
        public double? SBLCPostAmt { get; set; }
        public string? AmendFlag { get; set; }
        public double? AmendAmt { get; set; }
        public double? THBAmt { get; set; }
        public double? PrevSBLCAmt { get; set; }
        public double? PrevSBLCBal { get; set; }
        public double? PrevSBLCAvalBal { get; set; }
        public double? PrevSBLCNet { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? PastDueDate { get; set; }
        public string? DueStatus { get; set; }
        public DateTime? OverDueDate { get; set; }
        public string? ChkExpiry { get; set; }
        public DateTime? PrevDateExpiry { get; set; }
        public DateTime? DateExpiry { get; set; }
        public DateTime? DateClaimBefore { get; set; }
        public DateTime? DateStartBond { get; set; }
        public int? SBLCDays { get; set; }
        public int? PrevSBLCDays { get; set; }
        public string? CustCode { get; set; }
        public string? CustAddr { get; set; }
        public string? BenCode { get; set; }
        public string? BenInfo { get; set; }
        public string? PrevBenCode { get; set; }
        public string? PrevBenInfo { get; set; }
        public int? PrevTenorDay { get; set; }
        public int? TenorDay { get; set; }
        public string? TenorTerm { get; set; }
        public string? BankCode { get; set; }
        public string? BankName { get; set; }
        public string? BankDesc { get; set; }
        public string? Informations { get; set; }
        public string? InvoiceInfo { get; set; }
        public string? CommCollected { get; set; }
        public double? ExchRate { get; set; }
        public double? CommLCRate { get; set; }
        public string? TaxRefund { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? PaymentType { get; set; }
        public double? PrincipleAmt { get; set; }
        public double? IntAmt { get; set; }
        public DateTime? IntStartDate { get; set; }
        public string? IntRateCode { get; set; }
        public int? IntBaseDay { get; set; }
        public double? IntBalance { get; set; }
        public double? LastIntAmt { get; set; }
        public int? IntDay { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? CommAmt { get; set; }
        public double? DutyStamp { get; set; }
        public double? Payable { get; set; }
        public double? TelexCharge { get; set; }
        public double? OthCharge { get; set; }
        public double? TaxAmt { get; set; }
        public double? ClaimAmt { get; set; }
        public double? ClaimIntRate { get; set; }
        public string? PayFlag { get; set; }
        public string? PayMethod { get; set; }
        public string? PayRemark { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string? LastReceiptNo { get; set; }
        public string? AppvNo { get; set; }
        public string? TRAppvNo { get; set; }
        public string? FacNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string? AuthCode { get; set; }
        public string? GenAccFlag { get; set; }
        public DateTime? DateGenAcc { get; set; }
        public string? VoucherID { get; set; }
        public string? DMS { get; set; }
        public string? Allocation { get; set; }
        public string? CenterID { get; set; }
        public string? CCS_ACCT { get; set; }
        public string? CCS_LmType { get; set; }
        public string? CCS_CNUM { get; set; }
        public string? CCS_CIFRef { get; set; }
        public double? NewAccruCcy { get; set; }
        public double? NewAccruAmt { get; set; }
        public double? AccruCCy { get; set; }
        public double? AccruPending { get; set; }
        public DateTime? DateToStop { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public DateTime? DateLastAccru { get; set; }
        public double? LastAccruCcy { get; set; }
        public double? LastAccruAmt { get; set; }
        public double? AccruAmt { get; set; }
        public double? DAccruAmt { get; set; }
        public double? PAccruAmt { get; set; }
        public string? IntFlag { get; set; }
        public string? BPOFlag { get; set; }
        public string? Campaign_Code { get; set; }
        public DateTime? Campaign_EffDate { get; set; }

    }
}
