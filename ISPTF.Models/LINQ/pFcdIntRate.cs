using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pFcdIntRate
    {
        public string Exch_Ccy { get; set; }
        public string CreateTime { get; set; }
        public DateTime TranDate { get; set; }
        public double? Exch_CA { get; set; }
        public double? Exch_SA { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
