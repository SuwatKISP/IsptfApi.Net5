using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PFcdIntRate
    {
        public string ExchCcy { get; set; }
        public string CreateTime { get; set; }
        public DateTime TranDate { get; set; }
        public double? ExchCa { get; set; }
        public double? ExchSa { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
