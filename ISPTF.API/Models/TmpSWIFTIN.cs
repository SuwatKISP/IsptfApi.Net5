using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TmpSWIFTIN
    {
        public string FDUser { get; set; }
        public string FDFile { get; set; }
        public string FDMT { get; set; }
        public int? FDLine { get; set; }
        public string FDDetail { get; set; }
    }
}
