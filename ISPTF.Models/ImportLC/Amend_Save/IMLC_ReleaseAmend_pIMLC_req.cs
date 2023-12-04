﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_ReleaseAmend_pIMLC_req
    {
        public string? CenterID { get; set; }
        public string LCNumber { get; set; }
        public string? RecType { get; set; }
        public int? LCSeqno { get; set; }
        public DateTime? EventDate { get; set; }
        public string? UserCode { get; set; }
        public string? BPOFlag { get; set; }
        public string? PayFlag { get; set; }
        public double? CommAmt { get; set; }
        public double? CableAmt { get; set; }
        public string? PostageAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? OtherAmt { get; set; }
        public double? TaxAmt { get; set; }
        public string? LCRevolve { get; set; }
        public int? AmendSeq { get; set; }
        public string? LCSentBy { get; set; }
        public string? LCForm { get; set; }
        public DateTime? DateExpiry { get; set; }
        public DateTime? DateExpiryMax { get; set; }
        public string? PlaceExpiry { get; set; }
        public string? TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string? TenorTerm { get; set; }
        public string? MixPayment { get; set; }
        public string? Confirmation { get; set; }
        public string? Restricted { get; set; }
        public string? AvailWith { get; set; }
        public string? AvailBy { get; set; }
        public string? AvailCnty { get; set; }
        public string? Drawee { get; set; }
        public string? AdBankCode { get; set; }
        public string? ConfBankCode { get; set; }
        public string? BenInfo1 { get; set; }
        public string? BenInfo2 { get; set; }
        public string? BenInfo3 { get; set; }
        public string? BenInfo4 { get; set; }
        public string? BenCity { get; set; }
        public string? BenCnty { get; set; }
        public string? PrevBenInfo { get; set; }
        public string? AdThruBank { get; set; }
        public string? AdThruInfo1 { get; set; }
        public string? AdThruCity { get; set; }
        public string? AdThruCnty { get; set; }
        public string? OutsideCharge { get; set; }
        public string? ConfirmComm { get; set; }
        public string? Incoterms { get; set; }
        public string? ShipmentFrom { get; set; }
        public string? TransportTo { get; set; }
        public DateTime? DateLateShip { get; set; }
        public int? PresentDay { get; set; }
        public string? PresentPeriod { get; set; }
        public string? PartialShipment { get; set; }
        public string? Transhipment { get; set; }
        public string? TransportType { get; set; }
        public string? ShipPlace { get; set; }
        public string? GoodsCode { get; set; }
        public string? PurposeCode { get; set; }
        public string? ReimPay { get; set; }
        public string? ReimBank { get; set; }
        public string? ReimAddr { get; set; }
        public string? ReimMT740 { get; set; }
        public string? MT747_Flag { get; set; }
        public string? ReimCharge { get; set; }
        public string? ReimNote { get; set; }
        public string? Charge740 { get; set; }
        public string? Bank740 { get; set; }
        public string? Charge71B { get; set; }
        public string? BanktoBank72 { get; set; }
        public string? CommType { get; set; }
        public double? CommLCRate { get; set; }
        public int? PeriodComm { get; set; }
        public int? PeriodCommExt { get; set; }
        public string? TaxRefund { get; set; }
        public string? PayMethod { get; set; }
        public string? PayRemark { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public double? CommBenCCy { get; set; }
        public string? AmendFlag { get; set; }
        public double? PrevAmt { get; set; }
        public double? PrevNet { get; set; }
        public double? PrevLCBal { get; set; }
        public double? PrevLCAvalBal { get; set; }
        public DateTime? PrevDateExpiry { get; set; }
        public double? LCBal { get; set; }
        public double? AmendAmt { get; set; }
        public double? LCAvalBal { get; set; }
        public double? LCPostAmt { get; set; }
        public double? AmendAmtInc { get; set; }
        public double? AmendAmtDec { get; set; }
        public string? DePlus_Flag { get; set; }
        public double? AmendPlus { get; set; }
        public double? AmendMinus { get; set; }





        //public string? Event { get; set; }
        //public string? EventFlag { get; set; }
        //public string? LCStatus { get; set; }
        //public string? RecStatus { get; set; }
        //public string? LOCode { get; set; }
        //public string? AOCode { get; set; }
        //public string? AmendNo { get; set; }
        //public string? LCReferNo { get; set; }
        //public string? RequestCancel { get; set; }
        //public string? ConfirmRequest { get; set; }
        //public string? AmendStatus { get; set; }
        //public DateTime? DateIssue { get; set; }
        //public string? LCVary { get; set; }
        //public string? LCCcy { get; set; }
        //public double? LCAmt { get; set; }
        //public double? LCNet { get; set; }
        //public double? MarDeposit { get; set; }
        //public double? BillAmount { get; set; }
        //public double? ExchRate { get; set; }
        //public double? AllowPlus { get; set; }
        //public double? AllowMinus { get; set; }
        //public double? PrevPlus { get; set; }
        //public double? PrevMunus { get; set; }
        //public DateTime? PrevDateExpMax { get; set; }
        //public int? LCDays { get; set; }
        //public int? PrevLCDays { get; set; }
        //public string? DraftAt { get; set; }
        //
        //public string? CustCode { get; set; }
        //public string? CustAddr { get; set; }
        //public DateTime? DateMT740 { get; set; }
        //public double? MarginAmt { get; set; }
        //public string? CollectRefund { get; set; }
        //public string? Allocation { get; set; }
        //public string? LastReceiptNo { get; set; }
        //public string? AppvNo { get; set; }
        //public string? FacNo { get; set; }
        //public DateTime? UpdateDate { get; set; }
        //public DateTime? AuthDate { get; set; }
        //public string? AuthCode { get; set; }
        //public string? GenAccFlag { get; set; }
        //public string? VoucherID { get; set; }
        //public string? CCS_ACCT { get; set; }
        //public string? CCS_LmType { get; set; }
        //public string? CCS_CNUM { get; set; }
        //public string? CCS_CIFRef { get; set; }
        //public string? InUse { get; set; }
        //public string? ObjectType { get; set; }
        //public string? UnderlyName { get; set; }
        //public string? Campaign_Code { get; set; }
        //public DateTime? Campaign_EffDate { get; set; }

    }
}