using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PRemCleanBillCcy
    {
        public string Clnumber { get; set; }
        public string RecType { get; set; }
        public int SeqNo { get; set; }
        public string BranCode { get; set; }
        public DateTime? Cicdate { get; set; }
        public int? ItemNo { get; set; }
        public double? CcyAmt { get; set; }
        public double? ExchRate { get; set; }
        public double? Clbcomm { get; set; }
        public double? BhtAmt { get; set; }
        public string Description { get; set; }
    }
}
