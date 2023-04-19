using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewLastExchRate
    {
        public string ExchCcy { get; set; }
        public DateTime? ExchDate { get; set; }
        public string ExchTime { get; set; }
    }
}
