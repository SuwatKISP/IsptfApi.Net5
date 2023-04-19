using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewAremExchRate
    {
        public string RemRefNo { get; set; }
        public int SeqNo { get; set; }
        public double? RmCcyAmt { get; set; }
        public double? ExchRate { get; set; }
        public double? RmBhtAmt { get; set; }
        public string RmForward { get; set; }
        public string CenterId { get; set; }
    }
}
