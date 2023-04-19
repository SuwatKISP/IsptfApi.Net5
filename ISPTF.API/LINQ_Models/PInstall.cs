using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PInstall
    {
        public string LcNo { get; set; }
        public int SeqNo { get; set; }
        public DateTime? DueDate { get; set; }
        public double? Amt { get; set; }
    }
}
