using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pLog_ImportCB
    {
        public string PostDate { get; set; }
        public string LogFileName { get; set; }
        public DateTime? LogDate { get; set; }
        public double? LogLength { get; set; }
        public int? LogSeq { get; set; }
        public string LogStatus { get; set; }
        public string LogRerun { get; set; }
        public string LogReUser { get; set; }
        public DateTime? LogReDate { get; set; }
    }
}
