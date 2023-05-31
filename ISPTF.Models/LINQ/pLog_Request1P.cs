using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pLog_Request1P
    {
        public string TrType { get; set; }
        public string TrEvent { get; set; }
        public string TrRefSeq { get; set; }
        public DateTime TrRqDate { get; set; }
        public int TrRqSeq { get; set; }
        public string ACType { get; set; }
        public string ACNo { get; set; }
        public double ACAmt { get; set; }
    }
}
