using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pDetailForex
    {
        public string ForexFileName { get; set; }
        public string RecordType { get; set; }
        public string Bank { get; set; }
        public string Branch { get; set; }
        public string BaseCurrency { get; set; }
        public string QuoteCurrency { get; set; }
        public string TH_Description { get; set; }
        public string EN_Description { get; set; }
        public string EN_Short_Description { get; set; }
        public string Denomination { get; set; }
        public double? Buying_Bank_Note { get; set; }
        public double? Buying_Draft_Cheque { get; set; }
        public double? Buying_TT { get; set; }
        public double? Selling_OD { get; set; }
        public double? Selling_Cash { get; set; }
        public double? RoundOfDownload { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
