﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pMonAccrued
    {
        public string Login { get; set; }
        public string DocNo { get; set; }
        public string DocMode { get; set; }
        public int Seqno { get; set; }
        public string DocNumber { get; set; }
        public string DocRefer { get; set; }
        public string DocCust { get; set; }
        public DateTime? CalDate { get; set; }
        public DateTime? IntFrom { get; set; }
        public DateTime? IntTo { get; set; }
        public int? IntDay { get; set; }
        public string IntCode { get; set; }
        public double? Spread { get; set; }
        public double? IntRate { get; set; }
        public double? CurIntRate { get; set; }
        public int? BaseDay { get; set; }
        public string Ccy { get; set; }
        public double? BalCcy { get; set; }
        public double? IntCCy { get; set; }
        public double? IntAmt { get; set; }
        public double? IntExchRate { get; set; }
        public double? PrevIntCcy { get; set; }
        public double? PrevIntBht { get; set; }
        public string GenAccFlag { get; set; }
        public string CenterID { get; set; }
        public double? AccruPending { get; set; }
        public string DocBank { get; set; }
        public string BankType { get; set; }
    }
}
