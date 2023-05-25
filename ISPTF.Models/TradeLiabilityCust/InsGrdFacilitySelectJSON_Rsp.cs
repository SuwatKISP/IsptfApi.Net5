//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCust

{
    public class InsGrdFacilitySelectJSON_Rsp
    {
        public string? Cust_Code { get; set; }
        public string? Facility_No { get; set; }
        public string? limit_code { get; set; }
        public string? Limt_Name { get; set; }
        public string? TxStatus { get; set; }
        public double? TxLiab { get; set; }
        public double? TxAppv { get; set; }
        public double? TxNonLine { get; set; }
        public double? TxCredit { get; set; }
        public double? TxShare { get; set; }
        public double? TxNewAmt { get; set; }
        public double? TxHold { get; set; }
        public double? TxSusp { get; set; }
        public double? TxTotal { get; set; }
        public double? TxAvailable { get; set; }
        public double? TxOver { get; set; }
        public double? TxShCredit { get; set; }
        public double? TxGroup { get; set; }
        public DateTime? startdate { get; set; }
        public DateTime? expirydate { get; set; }
        public string? facility_type { get; set; }
        public string? refer_facility { get; set; }
        public string? refer_name { get; set; }
        public string? Revol_Flag { get; set; }
        public string? share_flag { get; set; }
        public string? TxRemark { get; set; }
        public string? Campaign_Code { get; set; }
        public DateTime? Campaign_EffDate { get; set; }
        public string? Warning { get; set; }
        public string? TxGpFlag { get; set; }
        public string? TxCustNo { get; set; }
        public string? TxNewFacNo { get; set; }
     //   public GetTotalSumJson_Rsp GetTotSum { get; set; }

    }
}
