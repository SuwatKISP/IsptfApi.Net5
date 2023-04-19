using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PCustShare
    {
        public string CustCode { get; set; }
        public string FacilityNo { get; set; }
        public int Seqno { get; set; }
        public string ShareCust { get; set; }
        public string ShareImp { get; set; }
        public string ShareExp { get; set; }
        public string ShareDlc { get; set; }
        public string ShareLg { get; set; }
        public string ShareLimit { get; set; }
        public double? ShareCredit { get; set; }
        public double? ShareUsed { get; set; }
        public string ShareCcs { get; set; }
        public string ShareMode { get; set; }
        public string Status { get; set; }
    }
}
