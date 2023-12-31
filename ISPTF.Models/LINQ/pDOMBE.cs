﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pDOMBE
    {
        public string BENumber { get; set; }
        public string RecType { get; set; }
        public int BESeqno { get; set; }
        public string BEStatus { get; set; }
        public string RecStatus { get; set; }
        public string EventMode { get; set; }
        public string Event { get; set; }
        public DateTime? EventDate { get; set; }
        public string EventFlag { get; set; }
        public string AutoOverDue { get; set; }
        public DateTime? OverdueDate { get; set; }
        public string BEOverDue { get; set; }
        public string DLCNumber { get; set; }
        public string DocCCy { get; set; }
        public double? DLCAmt { get; set; }
        public string CustCode { get; set; }
        public string CustAddr { get; set; }
        public string BenInfo { get; set; }
        public string BenCnty { get; set; }
        public string AdviceDisc { get; set; }
        public string AdviceResult { get; set; }
        public string ReferBE { get; set; }
        public string TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string TenorTerm { get; set; }
        public DateTime? NegoDate { get; set; }
        public DateTime? ValueDate { get; set; }
        public string BECcy { get; set; }
        public double? BEAmount { get; set; }
        public double? BEBalance { get; set; }
        public double? BEOverDrawn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? PrevDueDate { get; set; }
        public double? IntBefore { get; set; }
        public double? ExchBefore { get; set; }
        public string IntRateCode { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public string IntFlag { get; set; }
        public int? IntBaseDay { get; set; }
        public DateTime? IntStartDate { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? IntBalance { get; set; }
        public double? ExchRate { get; set; }
        public string ChkDeduct { get; set; }
        public double? OverAmt { get; set; }
        public double? NegoAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? PostageAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? CommOther { get; set; }
        public double? CommTran { get; set; }
        public double? CommCertify { get; set; }
        public double? CommEngage { get; set; }
        public double? Discfee { get; set; }
        public string TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public string CommDesc { get; set; }
        public string PaymentFlag { get; set; }
        public double? PayBalance { get; set; }
        public double? PayInterest { get; set; }
        public string PayFlag { get; set; }
        public string PayMethod { get; set; }
        public string Allocation { get; set; }
        public DateTime? DateLastPaid { get; set; }
        public string LastReceiptNo { get; set; }
        public string FCYReceiptNo { get; set; }
        public string AppvNo { get; set; }
        public string FacNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string GenAccFlag { get; set; }
        public DateTime? DateGenAc { get; set; }
        public string VoucherID { get; set; }
        public double? TotalAccruAmt { get; set; }
        public double? TotalAccruBht { get; set; }
        public double? AccruAmt { get; set; }
        public double? AccruBht { get; set; }
        public DateTime? DateLastAccru { get; set; }
        public DateTime? PastDueDate { get; set; }
        public string PastDueFlag { get; set; }
        public double? TotalSuspAmt { get; set; }
        public double? TotalSuspBht { get; set; }
        public double? SuspAmt { get; set; }
        public double? SuspBht { get; set; }
        public DateTime? DateToStop { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public double? LastAccruCcy { get; set; }
        public double? LastAccruAmt { get; set; }
        public double? NewAccruCcy { get; set; }
        public double? NewAccruAmt { get; set; }
        public double? AccruCCy { get; set; }
        public double? AccruAmt1 { get; set; }
        public double? DAccruAmt { get; set; }
        public double? PAccruAmt { get; set; }
        public double? AccruPending { get; set; }
        public string DMS { get; set; }
        public string Discrepancy { get; set; }
        public string Instruction { get; set; }
        public string TRFlag { get; set; }
        public string CenterID { get; set; }
        public string CCS_ACCT { get; set; }
        public string CCS_LmType { get; set; }
        public string CCS_CNUM { get; set; }
        public string CCS_CIFRef { get; set; }
        public string SwFlag { get; set; }
        public double? Pending_Payable { get; set; }
        public string BPOFlag { get; set; }
        public string Campaign_Code { get; set; }
        public DateTime? Campaign_EffDate { get; set; }
    }
}
