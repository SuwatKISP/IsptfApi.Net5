using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Inquiry
{
    public class Q_Inq_CreditLimit_GetDetailbyFac_DetailAndTotal_rsp
    {
        public Q_Inq_CreditLimit_GetDetailbyFac_rsp SumByProduct { get; set; }
        public Q_Inq_CreditLimit_GetDetailbyFac_Total_rsp TOTImportExport { get; set; }
        public Q_Inq_CreditLimit_GetDetailbyFac_TotalLiability_rsp TOTLiability { get; set; }
    }
}
