using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pCLogShare
    {
        public string LRecType { get; set; }
        public int LLogSeq { get; set; }
        public string LCust_Code { get; set; }
        public string LFacility_No { get; set; }
        public int LSeqNo { get; set; }
        public string LShare_Cust { get; set; }
        public string LShare_Imp { get; set; }
        public string LShare_Exp { get; set; }
        public string LShare_Dlc { get; set; }
        public string LShare_LG { get; set; }
        public string LShare_Limit { get; set; }
        public double? LShare_Credit { get; set; }
        public double? LShare_Used { get; set; }
        public string LShare_CCS { get; set; }
        public string LShare_Mode { get; set; }
        public string Status { get; set; }
    }
}
