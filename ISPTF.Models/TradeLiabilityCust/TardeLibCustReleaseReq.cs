//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCust

{
    public class TardeLibCustReleaseReq
    {
        public string? Appv_No { get; set; }  
        public string? Cust_Code { get; set; }
        public string? Facility_No { get; set; }
        public string? Facility_Type { get; set; }
        public string? Refer_DocNo { get; set; }
        public string? Revol_Flag { get; set; }
        public string? Event { get; set; }
        public string? UserCode { get; set; }
    }
}
