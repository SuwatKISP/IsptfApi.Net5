using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MInRateCode
    {
        public string InRateCode { get; set; }
        public string InRateName { get; set; }
        public string InRateCcyFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
