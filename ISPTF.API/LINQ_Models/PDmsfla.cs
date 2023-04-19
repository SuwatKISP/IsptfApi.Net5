using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PDmsfla
    {
        public string EventType { get; set; }
        public string Product { get; set; }
        public string Keynumber { get; set; }
        public string Txseq { get; set; }
        public string System { get; set; }
        public string FiarrangementNo { get; set; }
        public string PrevArrangeNum { get; set; }
        public string LoanType { get; set; }
        public string CreditType { get; set; }
        public string CentralId { get; set; }
        public string PrimaryInvoBrnNum { get; set; }
        public string PrimaryInvoIbf { get; set; }
        public string ArrangeContDate { get; set; }
        public string ArrangeTermType { get; set; }
        public string ArrangeTerm { get; set; }
        public string ArrangeTermUnit { get; set; }
        public string EffectiveDate { get; set; }
        public string MaturityDate { get; set; }
        public string ExtendedFlag { get; set; }
        public string Description { get; set; }
        public string FirstRepaymentDate { get; set; }
        public int? NumOfPrnRepay { get; set; }
        public int? PrnRepayTerm { get; set; }
        public string PrnRepayTermUnit { get; set; }
        public int? NumOfIntRepay { get; set; }
        public string IntRepayTerm { get; set; }
        public string IntRepayTermUnit { get; set; }
        public string FirstDisburseDate { get; set; }
        public int? NumOfDisburse { get; set; }
        public string IntRateType { get; set; }
        public double? IntRate { get; set; }
        public double? IntRateMargin { get; set; }
        public string ContractCcyId { get; set; }
        public double? ContractAmt { get; set; }
        public string LoanPutOptExDate { get; set; }
        public double? LoanPutOpAmt { get; set; }
        public string LoanCallOptExDate { get; set; }
        public string LoanCallOptExAmt { get; set; }
        public string PutOpWholeFlag { get; set; }
        public string CallOpWholeFlag { get; set; }
        public string RelInvoPartyName { get; set; }
        public string AsAtDate { get; set; }
        public string RunDate { get; set; }
        public string RunTime { get; set; }
        public string PeriodFlag { get; set; }
        public string AccdlicenseScheme { get; set; }
        public string AccdcounterpartyType { get; set; }
        public string DataProviderBranchNumber { get; set; }
    }
}
