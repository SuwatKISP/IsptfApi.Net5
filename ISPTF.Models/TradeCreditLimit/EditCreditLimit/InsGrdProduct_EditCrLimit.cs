//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class InsGrdProduct_EditCrLimit
    {
        public string? Product { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public double? ControlAmount { get; set; }
        public string? Prod_Code { get; set; }
        public string? Prod_Limit { get; set; }

    }
}
