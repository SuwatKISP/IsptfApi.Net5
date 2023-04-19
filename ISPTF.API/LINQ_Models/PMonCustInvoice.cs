using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PMonCustInvoice
    {
        public string DocMon { get; set; }
        public string DocMod { get; set; }
        public string KeyNumber { get; set; }
        public string DocNumer { get; set; }
        public string DocType { get; set; }
        public string CustCode { get; set; }
        public DateTime? DueDate { get; set; }
        public string Ccy { get; set; }
        public double? DocAmount { get; set; }
        public double? DocBalance { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Days { get; set; }
        public double? IntRate { get; set; }
        public double? IntAmt { get; set; }
        public string RptFlag { get; set; }
        public string IntFlag { get; set; }
        public DateTime? CalDate { get; set; }
        public DateTime? LastRunDate { get; set; }
    }
}
