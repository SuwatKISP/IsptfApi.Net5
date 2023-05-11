//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCust

{
    public class UpdateUsingReq
    {
        public string? Using_Type { get; set; }
        public string? @Cust_Code { get; set; }
        public string? @Facility_No { get; set; }
        public string? @UsingRec { get; set; }

    }
}
