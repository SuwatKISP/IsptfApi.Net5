using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class TmpAtsfile
    {
        public string DocMonth { get; set; }
        public string RecType { get; set; }
        public string EffDate { get; set; }
        public string CompAcc { get; set; }
        public string DataDate { get; set; }
        public string RecSeq { get; set; }
        public string BankCode { get; set; }
        public string BranchCode { get; set; }
        public string AccCode { get; set; }
        public string TranKind { get; set; }
        public string TranAmt { get; set; }
        public string ServType { get; set; }
        public string RecStatus { get; set; }
        public string ApplCode { get; set; }
        public string RefSender { get; set; }
        public string RefReceiver { get; set; }
        public string Filler { get; set; }
    }
}
