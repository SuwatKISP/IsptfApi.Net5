using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Inquiry
{
    public class Q_Inq_CreditLimit_DetailNoneLine_DetailAndTotal_rsp
    {
        public Q_Inq_CreditLimit_DetailNoneLine_rsp SumByProduct { get; set; }
        public Q_Inq_CreditLimit_DetailNoneLine_Total_rsp TOTImportExport { get; set; }
    }
}
