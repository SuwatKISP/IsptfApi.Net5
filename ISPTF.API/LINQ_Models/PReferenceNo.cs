using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PReferenceNo
    {
        public string PRefTrans { get; set; }
        public string PRefBran { get; set; }
        public string PRefYear { get; set; }
        public string PRefPrefix { get; set; }
        public int? PRefSeq { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string UserCode { get; set; }
        public bool? InUse { get; set; }
    }
}
