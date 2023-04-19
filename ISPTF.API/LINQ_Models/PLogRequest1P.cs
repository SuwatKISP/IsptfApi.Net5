using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PLogRequest1P
    {
        public string TrType { get; set; }
        public string TrEvent { get; set; }
        public string TrRefSeq { get; set; }
        public DateTime TrRqDate { get; set; }
        public int TrRqSeq { get; set; }
        public string Actype { get; set; }
        public string Acno { get; set; }
        public double Acamt { get; set; }
    }
}
