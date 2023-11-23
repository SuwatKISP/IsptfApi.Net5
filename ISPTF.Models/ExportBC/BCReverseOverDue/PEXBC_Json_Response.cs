using ISPTF.Models.ExportBC;
using System.Collections.Generic;
using ISPTF.Models.PurchasePayment;

namespace ISPTF.Models
{
    public class PEXBC_Json_Response
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public PEXBC_JSON Data { get; set; }
    }
}
