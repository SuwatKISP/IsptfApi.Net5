using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PDailySapHead
    {
        public DateTime VouchDate { get; set; }
        public string TranIndex { get; set; }
        public string TranCcy { get; set; }
    }
}
