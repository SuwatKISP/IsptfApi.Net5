using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PFcdDayBalance
    {
        public string FcdAccNo { get; set; }
        public DateTime TranDate { get; set; }
        public DateTime EffectDate { get; set; }
        public double? FcdBalance { get; set; }
        public string CustCode { get; set; }
        public string FcdCcy { get; set; }
        public string FcdAccType { get; set; }
    }
}
