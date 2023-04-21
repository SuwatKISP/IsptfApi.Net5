using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pInstall
    {
        public string LC_NO { get; set; }
        public int SEQ_NO { get; set; }
        public DateTime? DUE_DATE { get; set; }
        public double? AMT { get; set; }
    }
}
