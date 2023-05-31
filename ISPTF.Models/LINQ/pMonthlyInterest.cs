using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pMonthlyInterest
    {
        public string DocMonth { get; set; }
        public int DocSeq { get; set; }
        public string CenterID { get; set; }
        public string Login { get; set; }
        public string DocNumber { get; set; }
        public string DocRefer { get; set; }
        public string DocCust { get; set; }
        public string DocCcy { get; set; }
        public double? DocBalance { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CalDate { get; set; }
        public DateTime? IntFrom { get; set; }
        public DateTime? IntTo { get; set; }
        public int? IntDay { get; set; }
        public string IntCode { get; set; }
        public double? IntRate { get; set; }
        public double? Spread { get; set; }
        public double? CurIntRate { get; set; }
        public int? BaseDay { get; set; }
        public double? IntCCy { get; set; }
        public double? IntTHB { get; set; }
        public double? IntExchRate { get; set; }
        public string DebitACC { get; set; }
        public string SendFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpFlag { get; set; }
        public string UpReceipt { get; set; }
        public string BatchType { get; set; }
        public string ATSCode { get; set; }
        public DateTime? ATSDate { get; set; }
        public int? RoundNo { get; set; }
    }
}
