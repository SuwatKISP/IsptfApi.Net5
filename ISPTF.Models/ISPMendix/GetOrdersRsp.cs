using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ISPMendix
{
    public class GetOrdersRsp
    {

        public class order
        {
            public string? order_id { get; set; }
            public string? service_code { get; set; }
            public double? amount { get; set; }
        }
        public class payer
        {
            public string? account_no { get; set; }
            public string? account_type { get; set; }
        }
        public class payee
        {
            public string? account_no { get; set; }
            public string? account_type { get; set; }

        }
        public class product_detail
        {
            public string? ref1 { get; set; }
            public string? ref3 { get; set; }
            public string? ref4 { get; set; }
            public string? ref5 { get; set; }

        }



    }
}
