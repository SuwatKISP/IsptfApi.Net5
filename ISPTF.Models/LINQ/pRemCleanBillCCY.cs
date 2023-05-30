using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pRemCleanBillCCY
    {
        public string CLNumber { get; set; }
        public string RecType { get; set; }
        public int SeqNo { get; set; }
        public string BranCode { get; set; }
        public DateTime? CICDate { get; set; }
        public int? ItemNo { get; set; }
        public double? CcyAmt { get; set; }
        public double? ExchRate { get; set; }
        public double? CLBComm { get; set; }
        public double? BhtAmt { get; set; }
        public string Description { get; set; }
    }
}
