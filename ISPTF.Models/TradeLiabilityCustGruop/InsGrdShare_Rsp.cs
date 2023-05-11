//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCustGroup

{
    public class InsGrdShare_Rsp
    {
        public string? Customer { get; set; }
        public string? ShareCustomer { get; set; }
        public string? Share_Imp { get; set; }
        public string? Share_Exp { get; set; }
        public string? Share_Dlc { get; set; }
        public string? Share_Type { get; set; }
        public double? ShareLimit { get; set; }
    }
}
