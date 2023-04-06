//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class InsGrdShare_EditCrLimitRsp
    {
        public string? ShareCustomer { get; set; }
        public string? IMP { get; set; }
        public string? EXP { get; set; }
        public string? DLC { get; set; }
        public string? LG { get; set; }
        public double? SharingLimit { get; set; }
        public string? CCSNo  { get; set; }
        public string? ShareUsed { get; set; }
        public string? ShareCust_Code { get; set; }
        public string? ShareCust_Name { get; set; }

    }
}
