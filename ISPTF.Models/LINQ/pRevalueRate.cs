using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pRevalueRate
    {
        public DateTime Reval_Date { get; set; }
        public string Reval_Time { get; set; }
        public string Reval_Ccy { get; set; }
        public double? Reval_Rate { get; set; }
        public double? Reval_Pack { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
