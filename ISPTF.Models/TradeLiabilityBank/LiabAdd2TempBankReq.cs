//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityBank

{
    public class LiabAdd2TempBankReq
    {
        public string? Appv_No { get; set; }  
        public string? Bank_Code { get; set; }
        public string? Facility_No { get; set; }
        public string? Credit_Ccy { get; set; }
        public string? Status { get; set; }
        public string? Login { get; set; }
        public Double?TxCredit { get; set; }
    }
}
