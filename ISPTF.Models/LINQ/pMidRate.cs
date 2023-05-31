using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pMidRate
    {
        public DateTime Rate_Date { get; set; }
        public string Rate_Time { get; set; }
        public string Rate_Ccy { get; set; }
        public double? Rate_MidRate { get; set; }
        public double? Rate_Reuter { get; set; }
        public string RecStatus { get; set; }
        public string UserCode { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
