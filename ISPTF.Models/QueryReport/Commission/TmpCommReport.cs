using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class TmpCommReport
    {
        public string? Comm { get; set; }
        public DateTime? EventDate { get; set; }
        public string? CustCode { get; set; }
        public string? CustName { get; set; }
        public string? Module { get; set; }
        public double? Amount { get; set; }
        public string? flag { get; set; }

    }
}
