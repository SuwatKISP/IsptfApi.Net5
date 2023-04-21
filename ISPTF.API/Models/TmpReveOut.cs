using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TmpReveOut
    {
        public DateTime? TDate { get; set; }
        public string AccNo { get; set; }
        public double? DISCREC { get; set; }
        public double? COMMREC { get; set; }
        public double? MPRINC { get; set; }
        public double? MINTREC { get; set; }
        public double? MINTRECV { get; set; }
        public double? MINTSUSP { get; set; }
        public double? COMMFEE { get; set; }
        public double? PENAFEE { get; set; }
        public double? OTHERFEE { get; set; }
        public double? FORNTFEE { get; set; }
        public double? INSUFEE { get; set; }
    }
}
