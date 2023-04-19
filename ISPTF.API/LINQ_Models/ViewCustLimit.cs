using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewCustLimit
    {
        public string CustCode { get; set; }
        public string FacilityNo { get; set; }
        public int? SeqNo { get; set; }
        public string Status { get; set; }
        public string RecStatus { get; set; }
        public string LimitImex { get; set; }
        public string LimitImlc { get; set; }
        public string LimitImtr { get; set; }
        public string LimitExlc { get; set; }
        public string LimitExbc { get; set; }
        public string LimitExpc { get; set; }
        public string LimitDlc { get; set; }
        public string LimitImp { get; set; }
        public string LimitExp { get; set; }
        public string CcsNo { get; set; }
        public string ClmsFlag { get; set; }
    }
}
