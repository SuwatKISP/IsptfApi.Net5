using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewLastExchRate
    {
        public string ExchCcy { get; set; }
        public DateTime? ExchDate { get; set; }
        public string ExchTime { get; set; }
    }
}
