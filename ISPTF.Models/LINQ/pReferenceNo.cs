using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pReferenceNo
    {
        public string pRefTrans { get; set; }
        public string pRefBran { get; set; }
        public string pRefYear { get; set; }
        public string pRefPrefix { get; set; }
        public int? pRefSeq { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string UserCode { get; set; }
        public bool? InUse { get; set; }
    }
}
