using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PHoliday
    {
        public string HolYear { get; set; }
        public DateTime HolDate { get; set; }
        public string HolDesc { get; set; }
        public string HolRecStat { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
    }
}
