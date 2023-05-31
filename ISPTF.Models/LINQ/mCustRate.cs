using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mCustRate
    {
        public string Def_Cust { get; set; }
        public string Def_Mod { get; set; }
        public string Def_Exp { get; set; }
        public string Def_Type { get; set; }
        public double? Def_Rate { get; set; }
        public int? Def_Base { get; set; }
        public double? Def_Max { get; set; }
        public double? Def_Min { get; set; }
        public string RecStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
