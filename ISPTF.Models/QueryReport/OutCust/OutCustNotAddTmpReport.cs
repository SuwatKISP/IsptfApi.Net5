using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class OutCustNotAddTmpReport
    {
        public DateTime? DueDate { get; set; }
        public string? Module { get; set; }
         public string? Reference { get; set; }
        public string? KeyNumber { get; set; }
        public string? Cust_Name { get; set; }
        public string? Ccy { get; set; }
        public double? OriginalAmt { get; set; }
        public double? BalanceAmt { get; set; }
        public string? Cust_Code { get; set; }
    }
}
