using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class MControl
    {
        public string CtlType { get; set; }
        public string CtlCode { get; set; }
        public string CtlId { get; set; }
        public string CtlName { get; set; }
        public string CtlDesc { get; set; }
        public string CtlNote1 { get; set; }
        public string CtlNote2 { get; set; }
        public double? CtlVal1 { get; set; }
        public double? CtlVal2 { get; set; }
        public int? CtlSeq1 { get; set; }
        public int? CtlSeq2 { get; set; }
    }
}
