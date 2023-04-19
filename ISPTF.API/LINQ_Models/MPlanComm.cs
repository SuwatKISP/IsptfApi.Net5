using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MPlanComm
    {
        public string ComType { get; set; }
        public int ComSeq { get; set; }
        public double? ComMin { get; set; }
        public double? ComMax { get; set; }
        public double? ComRate { get; set; }
    }
}
