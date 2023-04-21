using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class tUnUseAcc
    {
        public string pRefTrans { get; set; }
        public string pRefYear { get; set; }
        public string acctno { get; set; }
        public bool? inUse { get; set; }
    }
}
