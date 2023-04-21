using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class tmp_Comm
    {
        public string Comm { get; set; }
        public DateTime? EventDate { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string Module { get; set; }
        public double? Amount { get; set; }
        public string flag { get; set; }
    }
}
