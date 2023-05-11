//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCustCancelReverse

{
    public class CustCancelReverseTNLiabAmtRsp
    {
        public string? Cust_Code { get; set; }
        public string? Facility_Type { get; set; }
        public double? TNLiabAmt { get; set; }
    }
}
