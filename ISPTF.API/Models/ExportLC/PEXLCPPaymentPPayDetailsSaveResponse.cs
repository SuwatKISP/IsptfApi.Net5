using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.PPayment;

namespace ISPTF.Models
{
    public class PEXLCPPaymentPPayDetailsSaveResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXLCPPaymentPPayDetailDataContainer Data { get; set; }
    }
}
