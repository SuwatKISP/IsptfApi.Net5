using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TmpDMSPTX
    {
        public DateTime? TDate { get; set; }
        public string TAccount { get; set; }
        public string TNature { get; set; }
        public string TCcy { get; set; }
        public double? TAmount { get; set; }
        public string TDocNo { get; set; }
        public string TDesc { get; set; }
        public string TMod { get; set; }
        public string TEvent { get; set; }
        public string TDept { get; set; }
    }
}
