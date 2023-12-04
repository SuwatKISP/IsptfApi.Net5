using ISPTF.Models.ExportBC;
using System.Collections.Generic;
using ISPTF.Models.PurchasePayment;

namespace ISPTF.Models.ExportBC
{
    public class PEXBCResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXBCDataContainer Data { get; set; }
    }
}
