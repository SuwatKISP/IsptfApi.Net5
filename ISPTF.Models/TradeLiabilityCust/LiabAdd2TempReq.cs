//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCust

{
    public class LiabAdd2TempReq
    {
        public string? Appv_No { get; set; }  
        public string? Cust_Code { get; set; }
        public string? Facility_No { get; set; }
        public string? Status { get; set; }
        public string? Login { get; set; }
        public Double?TxCredit { get; set; }
    }
}
