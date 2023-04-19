using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PLogErrorConnect1P
    {
        public string TrType { get; set; }
        public string TrEvent { get; set; }
        public string TrRefSeq { get; set; }
        public string Actype { get; set; }
        public string Acno { get; set; }
        public double? Acamt { get; set; }
        public DateTime? RqDate { get; set; }
        public string RqTime { get; set; }
        public int? RqSeq { get; set; }
        public string SumLog { get; set; }
        public string OnePreturn { get; set; }
        public int? Autoseq { get; set; }
        public string UserId { get; set; }
        public string ErrMsg { get; set; }
    }
}
