using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.Inquiry
{
    public class Q_Inq_CreditLimit_SumAndTotal_rsp
    {
        public Q_Inq_CreditLimit_GetTotSum_rsp GetTOTSum { get; set; }
        public Q_Inq_CreditLimit_TotalImEx_rsp TOTImportExport { get; set; }
        public Q_Inq_CreditLimit_TotalLiabilityAll_rsp TOTLiability { get; set; }
    }
}
