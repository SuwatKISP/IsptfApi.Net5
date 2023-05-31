using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class mInRateCode
    {
        public string InRate_Code { get; set; }
        public string InRate_Name { get; set; }
        public string InRate_CcyFlag { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
    }
}
