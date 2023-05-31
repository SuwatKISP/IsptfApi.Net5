using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pHeaderForex
    {
        public string ForexFileName { get; set; }
        public DateTime? ProcessDate { get; set; }
        public DateTime? FileCreateDate { get; set; }
        public string FileCreateTime { get; set; }
        public string SourceSystem { get; set; }
        public string TypeInformation { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
