using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class TmpComm
    {
        public string Comm { get; set; }
        public DateTime? EventDate { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string Module { get; set; }
        public double? Amount { get; set; }
        public string Flag { get; set; }
    }
}
