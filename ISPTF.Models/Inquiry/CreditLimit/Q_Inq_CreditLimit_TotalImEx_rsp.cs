using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Inquiry
{
    public class Q_Inq_CreditLimit_TotalImEx_rsp
    {
        public double? TotImport { get; set; }
        public double? TotExport { get; set; }
        public double? TotBImport { get; set; }
        public double? TotBExport { get; set; }
    }
}
