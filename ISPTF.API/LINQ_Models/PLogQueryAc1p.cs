using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PLogQueryAc1p
    {
        public string Actype { get; set; }
        public string Acno { get; set; }
        public string RqDspheader { get; set; }
        public string RqAppheader { get; set; }
        public string RqDetail { get; set; }
        public DateTime? RqDate { get; set; }
        public string RqTime { get; set; }
        public int? RqSeq { get; set; }
        public string RsMsg { get; set; }
        public DateTime? RsDate { get; set; }
        public string RsTime { get; set; }
        public string RsAcname { get; set; }
        public double? RsAcavBal { get; set; }
        public string SumLog { get; set; }
        public string OnePreturn { get; set; }
    }
}
