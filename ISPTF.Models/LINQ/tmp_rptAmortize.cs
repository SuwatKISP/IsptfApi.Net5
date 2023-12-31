﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class tmp_rptAmortize
    {
        public string Module { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string DocCcy { get; set; }
        public double? OriginalAmt { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public double? DiscountRate { get; set; }
        public int? DiscountDay { get; set; }
        public double? DiscountCcy { get; set; }
        public double? AccruCcy { get; set; }
        public string BankCode { get; set; }
        public string WithOutFlag { get; set; }
        public string WithOutType { get; set; }
        public string Wref_Bank_ID { get; set; }
        public double? AccruAmt { get; set; }
    }
}
