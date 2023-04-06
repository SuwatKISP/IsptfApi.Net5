//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeBankLimit

{
    public class PBankLimitReleaseReq
    {
        public string? Bank_Code { get; set; }
        public string? Facility_No { get; set; }
        public string? UserCode { get; set; }
    }
}
