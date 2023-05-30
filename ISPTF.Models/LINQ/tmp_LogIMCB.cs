﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class tmp_LogIMCB
    {
        public string PostDate { get; set; }
        public string LogFileName { get; set; }
        public DateTime? LogDate { get; set; }
        public double? LogLength { get; set; }
        public int? LogSeq { get; set; }
        public string LogStatus { get; set; }
        public string UserId { get; set; }
    }
}
