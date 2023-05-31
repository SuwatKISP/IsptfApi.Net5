using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mControl
    {
        public string CTL_Type { get; set; }
        public string CTL_Code { get; set; }
        public string CTL_ID { get; set; }
        public string CTL_Name { get; set; }
        public string CTL_Desc { get; set; }
        public string CTL_Note1 { get; set; }
        public string CTL_Note2 { get; set; }
        public double? CTL_Val1 { get; set; }
        public double? CTL_Val2 { get; set; }
        public int? CTL_Seq1 { get; set; }
        public int? CTL_Seq2 { get; set; }
    }
}
