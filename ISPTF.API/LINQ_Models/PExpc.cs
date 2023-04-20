﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PExpc
    {
        public string PackingNo { get; set; }
        public string RecordType { get; set; }
        public int EventNo { get; set; }
        public string EventMode { get; set; }
        public string RecStatus { get; set; }
        public string EventType { get; set; }
        public DateTime? EventDate { get; set; }
        public string BusinessType { get; set; }
        public string CustId { get; set; }
        public string CustInfo { get; set; }
        public string CntyCode { get; set; }
        public string ApplicantName { get; set; }
        public string GoodCode { get; set; }
        public string RelCode { get; set; }
        public string ShipmentFr { get; set; }
        public string ShipmentTo { get; set; }
        public double? PrincipleAmtThb5 { get; set; }
        public string GoodDesc { get; set; }
        public string PackingFor { get; set; }
        public string PackUnder { get; set; }
        public string ReferLcno { get; set; }
        public string DocCcy { get; set; }
        public double? DocAmount { get; set; }
        public double? Rate { get; set; }
        public double? ExchRate { get; set; }
        public double? PackCcy { get; set; }
        public double? PackThb { get; set; }
        public string PnNo { get; set; }
        public string NewPnNo { get; set; }
        public string PackNote { get; set; }
        public DateTime? DocExpiryDate { get; set; }
        public DateTime? PcStartDate { get; set; }
        public DateTime? CurrentPcDue { get; set; }
        public DateTime? PrevStartDate { get; set; }
        public double? TotPcDay { get; set; }
        public DateTime? Current60Daydue { get; set; }
        public string IntRateCode { get; set; }
        public int? IntBaseDay { get; set; }
        public double? PcIntRate { get; set; }
        public double? SpreadRate { get; set; }
        public double? CurrentIntrate { get; set; }
        public string Cfrrate { get; set; }
        public string PcIntType { get; set; }
        public DateTime? FixDate { get; set; }
        public string PartialFullRate { get; set; }
        public int? DueNo { get; set; }
        public int? PayNo { get; set; }
        public double? TotalDate { get; set; }
        public DateTime? ValueDate { get; set; }
        public double? PrevContraBal { get; set; }
        public double? ContraBal { get; set; }
        public double? PartialAmtCcy1 { get; set; }
        public double? PartialAmtCcy2 { get; set; }
        public double? PartialAmtCcy3 { get; set; }
        public double? PartialAmtCcy4 { get; set; }
        public double? PartialAmtCcy5 { get; set; }
        public double? PartialAmtCcy6 { get; set; }
        public double? PartialAmtCcy7 { get; set; }
        public double? PartialAmtCcy8 { get; set; }
        public double? PartialAmtCcy9 { get; set; }
        public double? InterestCcy1 { get; set; }
        public double? InterestCcy2 { get; set; }
        public double? TotalBalCcy { get; set; }
        public double? ExchRate1 { get; set; }
        public double? ExchRate2 { get; set; }
        public double? ExchRate3 { get; set; }
        public double? ExchRate4 { get; set; }
        public double? ExchRate5 { get; set; }
        public double? ExchRate6 { get; set; }
        public double? ExchRate7 { get; set; }
        public double? ExchRate8 { get; set; }
        public double? ExchRate9 { get; set; }
        public double? PartialAmtThb1 { get; set; }
        public double? PartialAmtThb2 { get; set; }
        public double? PartialAmtThb3 { get; set; }
        public double? PartialAmtThb4 { get; set; }
        public double? PartialAmtThb5 { get; set; }
        public double? PartialAmtThb6 { get; set; }
        public double? PartialAmtThb7 { get; set; }
        public double? PartialAmtThb8 { get; set; }
        public double? PartialAmtThb9 { get; set; }
        public double? InterestThb1 { get; set; }
        public double? InterestThb2 { get; set; }
        public double? TotalBalThb { get; set; }
        public string ForwardContract1 { get; set; }
        public string ForwardContract2 { get; set; }
        public string ForwardContract3 { get; set; }
        public string ForwardContract4 { get; set; }
        public string ForwardContract5 { get; set; }
        public string ForwardContract6 { get; set; }
        public string ForwardContract7 { get; set; }
        public string ForwardContract8 { get; set; }
        public string ForwardContract9 { get; set; }
        public double? Pcprofit { get; set; }
        public double? MidRate { get; set; }
        public double? DutyStamp { get; set; }
        public double? HandlingFee { get; set; }
        public double? CommOther { get; set; }
        public double? CommOnTt { get; set; }
        public double? PenaltyAmt { get; set; }
        public double? ComLieu { get; set; }
        public double? CommCerti { get; set; }
        public double? IntReceived { get; set; }
        public double? FrontFee { get; set; }
        public double? TotalCharge { get; set; }
        public double? TotalCreditAc { get; set; }
        public string Method { get; set; }
        public string Remark { get; set; }
        public string TaxRefund { get; set; }
        public double? RefundTaxAmt { get; set; }
        public double? TotalAmount { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string AuthCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string VouchId { get; set; }
        public string PayRecType { get; set; }
        public string GenaccFlag { get; set; }
        public DateTime? GenaccDate { get; set; }
        public string ReceivedNo { get; set; }
        public double? PrincipleAmtCcy1 { get; set; }
        public double? PrincipleAmtCcy2 { get; set; }
        public double? PrincipleAmtCcy3 { get; set; }
        public double? PrincipleAmtCcy4 { get; set; }
        public double? PrincipleAmtThb1 { get; set; }
        public double? PrincipleAmtThb2 { get; set; }
        public double? PrincipleAmtThb3 { get; set; }
        public double? PrincipleAmtThb4 { get; set; }
        public double? DeductExportThb { get; set; }
        public DateTime? ContraDate { get; set; }
        public string PayMethod { get; set; }
        public string PayInstruc { get; set; }
        public double? PrePackCcy { get; set; }
        public double? PrePackThb { get; set; }
        public double? Refundtax { get; set; }
        public string PaymentType { get; set; }
        public int? OtherNo { get; set; }
        public string AutoOverdue { get; set; }
        public string Pcoverdue { get; set; }
        public string PcpastDue { get; set; }
        public int? OveSeqno { get; set; }
        public DateTime? LastIntDate { get; set; }
        public DateTime? LastPayDate { get; set; }
        public DateTime? CalIntDate { get; set; }
        public string IntFlag { get; set; }
        public double? IntBalance { get; set; }
        public double? PrnBalance { get; set; }
        public double? LastIntAmt { get; set; }
        public double? LastPrnthb { get; set; }
        public double? BahtNet { get; set; }
        public string AcBahtnet { get; set; }
        public string FcdAcc { get; set; }
        public double? FcdAmt { get; set; }
        public string InUse { get; set; }
        public string AppvNo { get; set; }
        public string Facno { get; set; }
        public int? AmendNo { get; set; }
        public string FlagAmend { get; set; }
        public string Ointcode { get; set; }
        public double? Ointrate { get; set; }
        public double? Ointspdrate { get; set; }
        public double? Ointcurrate { get; set; }
        public int? Ointday { get; set; }
        public int? Obaseday { get; set; }
        public DateTime? ValueDate1 { get; set; }
        public double? TotalAccruAmt { get; set; }
        public double? TotalAccruBht { get; set; }
        public double? AccruCcy { get; set; }
        public double? AccruAmt { get; set; }
        public DateTime? DateLastAccru { get; set; }
        public DateTime? PastDueDate { get; set; }
        public string PastDueFlag { get; set; }
        public double? TotalSuspAmt { get; set; }
        public double? TotalSuspBht { get; set; }
        public double? SuspAmt { get; set; }
        public double? SuspBht { get; set; }
        public string Dms { get; set; }
        public string Allocation { get; set; }
        public string CenterId { get; set; }
        public string FlagSettle { get; set; }
        public string FlagBack { get; set; }
        public double? NewAccruCcy { get; set; }
        public double? NewAccruAmt { get; set; }
        public double? AccruPending { get; set; }
        public DateTime? DateToStop { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public double? LastAccruCcy { get; set; }
        public double? LastAccruAmt { get; set; }
        public double? DaccruAmt { get; set; }
        public double? PaccruAmt { get; set; }
        public double? RevAccru { get; set; }
        public double? RevAccruTax { get; set; }
        public string CcsAcct { get; set; }
        public string CcsLmType { get; set; }
        public string CcsCnum { get; set; }
        public string CcsCifref { get; set; }
        public string ObjectType { get; set; }
        public string UnderlyName { get; set; }
        public string Bpoflag { get; set; }
        public string CampaignCode { get; set; }
        public DateTime? CampaignEffDate { get; set; }
        public string OrderFlag { get; set; }
        public string ReceivePayBy { get; set; }
        public string ApproveBorad { get; set; }
        public string PurposeCode { get; set; }
    }
}