﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class vMonAccured
    {
        public string CenterID { get; set; }
        public string Login { get; set; }
        public string DocMode { get; set; }
        public DateTime? CalDate { get; set; }
        public string Ccy { get; set; }
        public double? BalCcy { get; set; }
        public double? IntCCy { get; set; }
        public double? IntAmt { get; set; }
        public double? PrevIntCcy { get; set; }
        public double? PrevIntBht { get; set; }
        public string DocNumber { get; set; }
        public double? IntExchRate { get; set; }
        public string DocCust { get; set; }
        public string DocRefer { get; set; }
        public string DocBank { get; set; }
        public string BankType { get; set; }
    }
}
