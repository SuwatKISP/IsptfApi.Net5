//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class PIMTRMaster
    {
        public string? RefNumber { get; set; }
        public string? RecType { get; set; }
        public string? TRCcy { get; set; }
        public double? TRBalance { get; set; }
        public double? PayAmount { get; set; }
        public string? IntFlag { get; set; }
        public double? IntBalance { get; set; }
        public string? IntRateCode { get; set; }
        public int? IntBaseDay { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public string? CFRRate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? TRDueStatus { get; set; }
        public string? AutoOverDue { get; set; }
        public double? AccruCCy { get; set; }
        public double? AccruAmt { get; set; }
        public double? AccruPending { get; set; }

    }
}

//public string? TRNumber { get; set; }
//public int? TRSeqno { get; set; }
//public string? TRStatus { get; set; }
//public string? RecStatus { get; set; }
//public string? EventMode { get; set; }
//public string? Event { get; set; }
//public DateTime? EventDate { get; set; }
//public string? LOCode { get; set; }
//public string? AOCode { get; set; }
//public DateTime? ValueDate { get; set; }
//public string? EventFlag { get; set; }
//public DateTime? OverdueDate { get; set; }
//public DateTime? PastDueDate { get; set; }
//public string? TRCCyFlag { get; set; }
//public string? TRRate { get; set; }
//public string? LCNumber { get; set; }
//public string? BLNumber { get; set; }
//public string? BLAdvice { get; set; }
//public string? CustCode { get; set; }
//public string? CustAddr { get; set; }
//public string? DocCCy { get; set; }
//public double? BLBalance { get; set; }
//public int? BLDay { get; set; }
//public int? TRTermDay { get; set; }
//public DateTime? BLIntStartDate { get; set; }
//public string? BLIntCode { get; set; }
//public double? BLIntRate { get; set; }
//public int? BLBase { get; set; }
//public double? BLInterest { get; set; }
//public double? BLExch { get; set; }
//public string? BLFwd { get; set; }
//public double? BLIntAmt { get; set; }
//public string? BenName { get; set; }
//public string? BenInfo { get; set; }
//public string? BenCnty { get; set; }
//public string? TenorType { get; set; }
//public string? NegoBank { get; set; }
//public string? NegoCnty { get; set; }
//public string? NegoRefno { get; set; }
//public string? ChipNego { get; set; }
//public DateTime? IntStartDate { get; set; }
//public DateTime? LastIntDate { get; set; }
//public double? LastIntAmt { get; set; }
//public double? TRAmount { get; set; }

//public double? TRProfit { get; set; }
//public double? MidRate { get; set; }
//public int? TRDay { get; set; }
//public DateTime? StartDate { get; set; }

//public DateTime? PrevDueDate { get; set; }
//public string? FBCcy { get; set; }
//
//
//public double? FBEngage { get; set; }
//public double? PrevFBChrg { get; set; }
//public double? PrevFBInt { get; set; }
//public double? PrevFBEng { get; set; }
//public string? Invoice { get; set; }
//public string? Goods { get; set; }
//public string? Relation { get; set; }
//public double? DeductSwift { get; set; }
//public double? DeductComm { get; set; }
//public double? DeductOther { get; set; }
//public string? SettleFlag { get; set; }
//public string? SettleDate { get; set; }
//public string? MTNego { get; set; }
//public string? MTType { get; set; }
//public string? ReimBank { get; set; }
//public string? SGNumber { get; set; }
//public string? SGNumber1 { get; set; }
//public double? SGAmount { get; set; }
//public double? DOAmount { get; set; }
//public string? IntermBank { get; set; }
//public string? ChipInterm { get; set; }
//public string? IntermAddr { get; set; }
//public string? AcBank { get; set; }
//public string? ChipAcBank { get; set; }
//public string? AcAddr { get; set; }
//public double? IntBefore { get; set; }
//public double? ExchBefore { get; set; }
//public string? IntPayType { get; set; }
//public string? IntFixDate { get; set; }
//
//public double? ExchRate { get; set; }
//public double? EngageRate { get; set; }
//
//public double? CommFCD { get; set; }
//
//
//public double? PostageAmt { get; set; }
//
//
//public double? IBCRate { get; set; }
//
//
//
//public double? CommExch { get; set; }
//
//
//
//public string? TaxRefund { get; set; }
//public double? TaxAmt { get; set; }
//public string? CommDesc { get; set; }
//public string? PayFlag { get; set; }
//public string? PayMethod { get; set; }
//public string? Allocation { get; set; }
//public DateTime? DateLastPaid { get; set; }
//public string? LastReceiptNo { get; set; }
//public string? AppvNo { get; set; }
//public string? FacNo { get; set; }
//public string? FCyPayFlag { get; set; }
//public string? FCyAcNo { get; set; }
//public string? FCyReceiptNo { get; set; }
//public string? PayType { get; set; }

//public double? PayInterest { get; set; }
//public DateTime? UpdateDate { get; set; }
//public string? UserCode { get; set; }
//public DateTime? AuthDate { get; set; }
//public string? AuthCode { get; set; }
//public string? GenAccFlag { get; set; }
//public string? VoucherID { get; set; }
//
//public DateTime? DateStartAccru { get; set; }
//public DateTime? DateLastAccru { get; set; }
//public double? LastAccruCcy { get; set; }
//public double? LastAccruAmt { get; set; }
//public double? NewAccruCcy { get; set; }
//public double? NewAccruAmt { get; set; }


//public double? DAccruAmt { get; set; }
//public double? PAccruAmt { get; set; }

//public double? RevAccru { get; set; }
//public double? RevAccruTax { get; set; }
//public string? DMS { get; set; }
//public string? Tx72 { get; set; }
//public string? Tx23E { get; set; }
//public string? Tx71A { get; set; }
//public string? Tx26 { get; set; }
//public string? Tx59A { get; set; }
//public string? Tx59D { get; set; }
//public string? Tx59Cnty { get; set; }
//public double? TRCcy1 { get; set; }
//public double? TRExch1 { get; set; }
//public double? TRAmt1 { get; set; }
//public double? TRCont1 { get; set; }
//public double? TRCcy2 { get; set; }
//public double? TRExch2 { get; set; }
//public double? TRAmt2 { get; set; }
//public string? TRCont2 { get; set; }
//public double? TRCcy3 { get; set; }
//public double? TRExch3 { get; set; }
//public double? TRAmt3 { get; set; }
//public string? TRCont3 { get; set; }
//public double? TRCcy4 { get; set; }
//public double? TRExch4 { get; set; }
//public double? TRAmt4 { get; set; }
//public string? TRCont4 { get; set; }
//public double? TRCcy5 { get; set; }
//public double? TRExch5 { get; set; }
//public double? TRAmt5 { get; set; }
//public string? TRCont5 { get; set; }
//public string? NostACInfo { get; set; }
//public string? Nego799 { get; set; }
//public string? Nego999 { get; set; }
//public string? NegoTelex { get; set; }
//public string? CCS_ACCT { get; set; }
//public string? CCS_LmType { get; set; }
//public string? CCS_CNUM { get; set; }
//public string? CCS_CIFRef { get; set; }
//public string? TRFLAG { get; set; }
//public string? InUse { get; set; }
//public string? ObjectType { get; set; }
//public string? UnderlyName { get; set; }
//public string? BPOFlag { get; set; }
//public string? Campaign_Code { get; set; }
//public DateTime? Campaign_EffDate { get; set; }
//public string? PurposeCode { get; set; }
