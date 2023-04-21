using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pDailySapHead
    {
        public DateTime VouchDate { get; set; }
        public string TranIndex { get; set; }
        public string TranCcy { get; set; }
    }
}
