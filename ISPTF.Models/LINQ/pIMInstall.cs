using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pIMInstall
    {
        public string DocNo { get; set; }
        public int EventNo { get; set; }
        public int Seqno { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? Term { get; set; }
        public double? DueAmt { get; set; }
        public double? FBInt { get; set; }
        public double? Engage { get; set; }
        public double? CalEngAmt { get; set; }
        public int? CalDay { get; set; }
    }
}
