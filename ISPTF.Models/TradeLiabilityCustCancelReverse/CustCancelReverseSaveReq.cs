//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCustCancelReverse

{
    public class CustCancelReverseSaveReq
    {
        public string? Cancel_Flag { get; set; }
		public string? Cust_Code { get; set; }
		public string? CenterID { get; set; }
		public string? UserCode { get; set; }
		public string? Appv_No { get; set; }
		public string? Refer_Type { get; set; }
		public string? Refer_DocNo { get; set; }
		public string? Facility_No { get; set; }
		public string? Refer_Ccy { get; set; }
		public double? Refer_CcyAmt { get; set; }
		public string? Refer_RefNo { get; set; }
		public double? Credit_Line { get; set; }
		public double? Refer_BhtAmt { get; set; }
		public string? Facility_Flag { get; set; }
		public string? LbEvent { get; set; }
	}
}
