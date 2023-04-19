using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PClogShare
    {
        public string LrecType { get; set; }
        public int LlogSeq { get; set; }
        public string LcustCode { get; set; }
        public string LfacilityNo { get; set; }
        public int LseqNo { get; set; }
        public string LshareCust { get; set; }
        public string LshareImp { get; set; }
        public string LshareExp { get; set; }
        public string LshareDlc { get; set; }
        public string LshareLg { get; set; }
        public string LshareLimit { get; set; }
        public double? LshareCredit { get; set; }
        public double? LshareUsed { get; set; }
        public string LshareCcs { get; set; }
        public string LshareMode { get; set; }
        public string Status { get; set; }
    }
}
