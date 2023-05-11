//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeBankLimit

{
    public class InsGrdProductBK_EditCrLimitRsp
    {
        public string? Product { get; set; }
        public DateTime? LStartDate { get; set; }
        public DateTime? LExpiryDate { get; set; }
        public double? LProdAmount { get; set; }
        public string? LProd_Code { get; set; }
        public string? LProd_Limit { get; set; }

    }
}
