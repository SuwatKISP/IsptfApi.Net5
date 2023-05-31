using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pLog_QueryAC1P
    {
        public string ACType { get; set; }
        public string ACNo { get; set; }
        public string RqDSPHeader { get; set; }
        public string RqAPPHeader { get; set; }
        public string RqDetail { get; set; }
        public DateTime? RqDate { get; set; }
        public string RqTime { get; set; }
        public int? RqSeq { get; set; }
        public string RsMsg { get; set; }
        public DateTime? RsDate { get; set; }
        public string RsTime { get; set; }
        public string RsACName { get; set; }
        public double? RsACAvBal { get; set; }
        public string SumLog { get; set; }
        public string OnePReturn { get; set; }
    }
}
