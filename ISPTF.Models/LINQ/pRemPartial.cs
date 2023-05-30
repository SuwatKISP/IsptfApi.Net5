using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pRemPartial
    {
        public string RemRefNo { get; set; }
        public int SeqNo { get; set; }
        public double? RmCcyAmt { get; set; }
        public double? ExchRate { get; set; }
        public double? RmBhtAmt { get; set; }
        public string RmForward { get; set; }
        public string CenterID { get; set; }
    }
}
