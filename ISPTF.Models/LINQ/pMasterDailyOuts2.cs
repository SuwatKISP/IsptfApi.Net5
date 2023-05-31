using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pMasterDailyOuts2
    {
        public string OutsDate { get; set; }
        public string Module { get; set; }
        public string KeyNumber { get; set; }
        public string Reference { get; set; }
        public string SubProduct { get; set; }
        public string LastEvent { get; set; }
        public string CustCode { get; set; }
        public string CCy { get; set; }
        public double? OriginalAmt { get; set; }
        public double? BalanceAmt { get; set; }
        public string TenorType { get; set; }
        public string TenorDay { get; set; }
        public string TENOR_TYPE { get; set; }
        public string FlagDue { get; set; }
        public double? intRate { get; set; }
        public double? AccruCcy { get; set; }
        public DateTime? LastPayment { get; set; }
        public DateTime? PastDueDate { get; set; }
        public DateTime? OverdueDate { get; set; }
        public double? RevAccru { get; set; }
        public double? AccruPending { get; set; }
        public string WithOutFlag { get; set; }
        public string WithOutType { get; set; }
        public string SBUCode { get; set; }
        public string ProdCode { get; set; }
        public string RCCode { get; set; }
        public string RMCode { get; set; }
        public string LiabType { get; set; }
        public string GFMSAccOuts { get; set; }
        public string GFMSAccInt { get; set; }
        public string GFMSBran { get; set; }
        public string GFBCOuts { get; set; }
        public string GFBCInt { get; set; }
    }
}
