//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCustGroup

{
    public class Group_Rsp
    {
        public string? Customer { get; set; }
        public string? Facility_No { get; set; }
        public string? Share_Imp { get; set; }
        public string? Share_Exp { get; set; }
        public string? Share_Dlc { get; set; }
        public string? Share_LG { get; set; }
        public double? Share_Credit { get; set; }
        public string? Share_Mode { get; set; }
        public double? Share_Used { get; set; }
        public string? Share_Limit { get; set; }
        public string? Cust_Code { get; set; }
        public string? Cust_Name { get; set; }
    }
}
