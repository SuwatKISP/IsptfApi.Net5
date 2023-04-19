using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class Holiday
    {
        public string HolYear { get; set; }
        public string HolDate { get; set; }
        public string HolDesc { get; set; }
        public string HolRecStat { get; set; }
        public string UpdateDate { get; set; }
        public string UserCode { get; set; }
        public string AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
