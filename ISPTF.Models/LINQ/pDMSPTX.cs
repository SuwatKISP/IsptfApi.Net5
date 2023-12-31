﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pDMSPTX
    {
        public string EventType { get; set; }
        public string NostroAcc { get; set; }
        public string Product { get; set; }
        public string Keynumber { get; set; }
        public int? TXSeq { get; set; }
        public string System { get; set; }
        public string RecpPayTrnType { get; set; }
        public string RecpPayTrnCode { get; set; }
        public string RecpPayTrnItmType { get; set; }
        public string RecpPayTrnItmDesc { get; set; }
        public string RecpPayTrnDate { get; set; }
        public string InvolPartyID { get; set; }
        public string InvolPartyName { get; set; }
        public string CntryIDOfInvolParty { get; set; }
        public string PaymentMethod { get; set; }
        public string CurrencyId { get; set; }
        public double? TrnAmtInCcy { get; set; }
        public string DebtInstrumentType { get; set; }
        public string ISINCode { get; set; }
        public string DebtInstrumentName { get; set; }
        public string IssuerorInvestedOrganizationName { get; set; }
        public string CountryIdofIssuerorInvestedOrganization { get; set; }
        public string IssueDate { get; set; }
        public string MaturityDate { get; set; }
        public string OriginalTerm { get; set; }
        public string OriginalTermUnit { get; set; }
        public string CouponRate { get; set; }
        public string IntentionCountryId { get; set; }
        public string UnitofTransaction { get; set; }
        public string SellForeignCurSecTransAmtinBahtEqui { get; set; }
        public string DefaultedBillPurchaseDate { get; set; }
        public string AsAtDate { get; set; }
        public string RunDate { get; set; }
        public string RunTime_U { get; set; }
        public string PeriodFlag { get; set; }
    }
}
