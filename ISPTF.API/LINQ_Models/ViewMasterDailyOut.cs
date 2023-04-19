using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewMasterDailyOut
    {
        public string OutsDate { get; set; }
        public string Module { get; set; }
        public string KeyNumber { get; set; }
        public string Reference { get; set; }
        public string SubProduct { get; set; }
        public string LastEvent { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double? OriginalAmt { get; set; }
        public double? BalanceAmt { get; set; }
        public string TenorType { get; set; }
        public string TenorDay { get; set; }
        public string TenorType1 { get; set; }
        public string FlagDue { get; set; }
        public double? IntRate { get; set; }
        public double? AccruCcy { get; set; }
        public DateTime? LastPayment { get; set; }
        public DateTime? PastDueDate { get; set; }
        public DateTime? OverdueDate { get; set; }
        public double? RevAccru { get; set; }
        public double? AccruPending { get; set; }
        public string WithOutFlag { get; set; }
        public string WithOutType { get; set; }
        public string Sbucode { get; set; }
        public string ProdCode { get; set; }
        public string Rccode { get; set; }
        public string Rmcode { get; set; }
        public string LiabType { get; set; }
        public string GfmsaccOuts { get; set; }
        public string GfmsaccInt { get; set; }
        public string Gfmsbran { get; set; }
        public string Gfbcouts { get; set; }
        public string Gfbcint { get; set; }
    }
}
