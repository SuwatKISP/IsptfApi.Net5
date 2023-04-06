//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityBank

{
    public class TardeLibBankReleaseReq
    {
        public string? Appv_No { get; set; }  
        public string? Bank_Code { get; set; }
        public string? Facility_No { get; set; }
        public string? Credit_Ccy { get; set; }
        public string? Facility_Type { get; set; }
        public string? Refer_DocNo { get; set; }
        public string? Revol_Flag { get; set; }
        public string? Event { get; set; }
        public string? UserCode { get; set; }
    }
}
