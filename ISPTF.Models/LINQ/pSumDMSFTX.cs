using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pSumDMSFTX
    {
        public string EventType { get; set; }
        public string Product { get; set; }
        public string Keynumber { get; set; }
        public string TXSeq { get; set; }
        public string System { get; set; }
        public string FIArrangementNo { get; set; }
        public string TXPurposeCode { get; set; }
        public string FXArrangeType { get; set; }
        public string FXTradingTXType { get; set; }
        public string TXDate { get; set; }
        public string CentralID { get; set; }
        public string CustCode { get; set; }
        public string ExcInvPartyBrNo { get; set; }
        public string ExcInvPartyIBFInd { get; set; }
        public string ExcInvPartyName { get; set; }
        public string ExcInvPartyBusType { get; set; }
        public string PaymentMeth { get; set; }
        public string FromTXType { get; set; }
        public string ToTXType { get; set; }
        public string InFlowTXPurpose { get; set; }
        public string OutFlowTXPurpose { get; set; }
        public string OthTXPurposeDesc { get; set; }
        public double? ExchRate { get; set; }
        public string BuyCurID { get; set; }
        public double? BuyAmt { get; set; }
        public string SellCurID { get; set; }
        public double? SellAmt { get; set; }
        public string NotionalCurID { get; set; }
        public double? NotionalAmt { get; set; }
        public string OutsNotCurID { get; set; }
        public double? OutsNotAmt { get; set; }
        public string AppvDocNo { get; set; }
        public string AppvDocDate { get; set; }
        public string FromToFICode { get; set; }
        public string FromToAccNo { get; set; }
        public string FromToRelTXDate { get; set; }
        public string BenName { get; set; }
        public string BenCnty { get; set; }
        public string RelationwithBen { get; set; }
        public string RelInvPartyName { get; set; }
        public string RelInvPartyBusType { get; set; }
        public string RelationRelInvParty { get; set; }
        public string NoofShare { get; set; }
        public string ParValue { get; set; }
        public double? YTDAccumAmt { get; set; }
        public string ListinMarketFlag { get; set; }
        public string InvestReason { get; set; }
        public string CustInvestType { get; set; }
        public string TermRange { get; set; }
        public int? Term { get; set; }
        public int? TermUnit { get; set; }
        public string IntRateType { get; set; }
        public double? IntRate { get; set; }
        public double? IntRateMargin { get; set; }
        public string NoofInstall { get; set; }
        public int? InstallTerm { get; set; }
        public string InstallTermUnit { get; set; }
        public string FirstInstallDate { get; set; }
        public string FirstDisburDate { get; set; }
        public string MaturityDate { get; set; }
        public string LoanDecType { get; set; }
        public string RePayDueIndicator { get; set; }
        public string WholePartRepayFlag { get; set; }
        public string DebtInstruIssueDate { get; set; }
        public double? DebtInstruIssueAmt { get; set; }
        public string AsAtDate { get; set; }
        public string RunDate { get; set; }
        public string RunTime { get; set; }
        public string PeriodFlag { get; set; }
        public string CancelationReasonType { get; set; }
        public string BotReferenceNumber { get; set; }
        public string UnderlyingOwnerName { get; set; }
        public string Description { get; set; }
        public string ObjectiveType { get; set; }
        public string KeyInTimestamp { get; set; }
        public string ACCDLicenseScheme { get; set; }
        public string ACCDCounterpartyType { get; set; }
        public string PreviousArrangementNumber { get; set; }
        public string PreviousArrangementFICode { get; set; }
        public string SetUpReasonType { get; set; }
        public string CancellationReasonType { get; set; }
    }
}
