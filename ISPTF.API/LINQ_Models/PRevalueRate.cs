using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PRevalueRate
    {
        public DateTime RevalDate { get; set; }
        public string RevalTime { get; set; }
        public string RevalCcy { get; set; }
        public double? RevalRate { get; set; }
        public double? RevalPack { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
