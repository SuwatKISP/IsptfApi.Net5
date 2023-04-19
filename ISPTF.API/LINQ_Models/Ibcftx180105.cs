using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class Ibcftx180105
    {
        public string System { get; set; }
        public string FiarrangementNo { get; set; }
        public string TransactionPurposeCode { get; set; }
        public string FxArrangementType { get; set; }
        public string FxtradingTransactionType { get; set; }
        public string TransactionDate { get; set; }
        public string KeyInTimestamp { get; set; }
        public string CentralId { get; set; }
        public string ExercisingInvolvedPartyBrNo { get; set; }
        public string ExercisingInvolvedPartyIbfindicator { get; set; }
        public string ExercisingInvolvedPartyName { get; set; }
        public string ExercisingInvolvedPartyBusinessType { get; set; }
        public string AccdlicenseScheme { get; set; }
        public string AccdcounterpartyType { get; set; }
        public string PaymentMethod { get; set; }
        public string FromTransactionType { get; set; }
        public string ToTransactionType { get; set; }
        public string InFlowTransactionPurpose { get; set; }
        public string OutflowTransactionPurpose { get; set; }
        public string OtherTransactionPurposeDesc { get; set; }
        public string ObjectiveType { get; set; }
        public string ExchangeRate { get; set; }
        public string BuyCurrencyId { get; set; }
        public string BuyAmount { get; set; }
        public string SellCurrencyId { get; set; }
        public string SellAmount { get; set; }
        public string NotionalCurrencyId { get; set; }
        public string NotionalAmount { get; set; }
        public string OutstandingNotionalCurrencyId { get; set; }
        public string OutstandingNotionalAmount { get; set; }
        public string ApprovalDocumentNumber { get; set; }
        public string ApprovalDocumentDate { get; set; }
        public string BotReferenceNumber { get; set; }
        public string FromToFicode { get; set; }
        public string FromToAccountNumber { get; set; }
        public string FromToRelatedTransactionDate { get; set; }
        public string BeneficiaryOrSenderName { get; set; }
        public string CountryIdOfBeneficiaryOrSender { get; set; }
        public string RelationshipWithBeneficiaryOrSender { get; set; }
        public string UnderlyingOwnerName { get; set; }
        public string RelatedInvolvedPartyName { get; set; }
        public string RelatedInvolvedPartyBusinessType { get; set; }
        public string RelationshipwithRelatedInvolvedPart { get; set; }
        public string NumberofShares { get; set; }
        public string ParvalueperShare { get; set; }
        public string YtdaccumulatedAmount { get; set; }
        public string ListedinMarketFlag { get; set; }
        public string InvestmentRepatriatedReason { get; set; }
        public string CustomerInvestmentType { get; set; }
        public string TermRange { get; set; }
        public string Term { get; set; }
        public string TermUnit { get; set; }
        public string InterestRateType { get; set; }
        public string InterestRate { get; set; }
        public string InterestRateMargin { get; set; }
        public string NumberofInstallments { get; set; }
        public string InstallmentTerm { get; set; }
        public string InstallmentTermUnit { get; set; }
        public string FirstInstallmentDate { get; set; }
        public string FirstDisbursementDate { get; set; }
        public string MaturityDate { get; set; }
        public string LoanDeclarationType { get; set; }
        public string RepaymentDueIndicator { get; set; }
        public string WholePartialRepaymentFlag { get; set; }
        public string DebtInstrumentIssuedDate { get; set; }
        public string DebtInstrumentIssuedAmount { get; set; }
        public string Description { get; set; }
        public string AsAtDate { get; set; }
        public string RunDate { get; set; }
        public string RunTime { get; set; }
        public string PeriodFlag { get; set; }
    }
}
