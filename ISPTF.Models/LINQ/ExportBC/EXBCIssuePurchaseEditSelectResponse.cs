using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISPTF.Models.ExportBC
{
    public class EXBCIssuePurchaseEditSelectResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public EXBCPaymentResponse Data { get; set; }
    }
}
