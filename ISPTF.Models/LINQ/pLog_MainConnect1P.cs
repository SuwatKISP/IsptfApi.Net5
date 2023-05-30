using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pLog_MainConnect1P
    {
        public string TrType { get; set; }
        public string TrEvent { get; set; }
        public string TrRefSeq { get; set; }
        public string ACType { get; set; }
        public string ACNo { get; set; }
        public double? ACAmt { get; set; }
        public DateTime? RqDate { get; set; }
        public string RqTime { get; set; }
        public int? RqSeq { get; set; }
        public DateTime? RsDate { get; set; }
        public string RsTime { get; set; }
        public string SumLog { get; set; }
        public string OnePReturn { get; set; }
        public int? autoseq { get; set; }
        public string UserID { get; set; }
        public string AcName { get; set; }
    }
}
