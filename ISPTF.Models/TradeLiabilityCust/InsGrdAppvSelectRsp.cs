//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCust

{
    public class InsGrdAppvSelectRsp
    {
        public FacilityReq Facility { get; set; }
        public CustApproveReq CustApprove { get; set; }

    }

    public class FacilityReq
    {
        public string? TxStatus { get; set; }
        public string? Limit_code { get; set; }
        public string? limit_name { get; set; }
        public string? Startdate { get; set; }
        public string? Expirydate { get; set; }
        public string? Facility_type { get; set; }
        public string? Refer_facility { get; set; }
        public string? Refer_Cust { get; set; }
        public string? Refer_name { get; set; }
        public string? TxRevol { get; set; }
        public double? TxShGroup { get; set; }
        public string? Remark { get; set; }
    }
    public class CustApproveReq
    {
        public string? Appv_No { get; set; }
        public string? Facility_No { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? Refer_DocNo { get; set; }
        public string? Refer_Ccy { get; set; }
        public double? Refer_CcyAmt { get; set; }
        public double? Refer_ExchRate { get; set; }
        public double? Refer_BhtAmt { get; set; }
        public double? TxPlus { get; set; }
        public string? Refer_RefNo { get; set; }
        public string? LbLogin { get; set; }
        public string? Facility_Flag { get; set; }
        public string? Campaign_Code { get; set; }
        public DateTime? Campaign_EffDate { get; set; }
        public double? TxCredit { get; set; }
        public double? TxAvailable { get; set; }
        public double? TxHold { get; set; }
        public double? TxOver { get; set; }
        public double? TxLiab { get; set; }
        public double? TxAppv { get; set; }
        public double? TxTotal { get; set; }
        public double? TxNewAmt { get; set; }
        public double? TxShare { get; set; }
        public double? TxGroup { get; set; }
        public double? TotOrigin { get; set; }
        public double? TotCredit { get; set; }
        public double? TotAvailable { get; set; }
        public double? TotOver { get; set; }
        public double? TotSusp { get; set; }
        public double? TotLiab { get; set; }
        public double? TotAppv { get; set; }
        public double? TotTotal { get; set; }
        public double? TotNewAmt { get; set; }
        public double? TotHold { get; set; }
        public double? TotShare { get; set; }
        public double? TxTotGrp { get; set; }
        public double? TxtAvaAmt { get; set; }
        public string? Comment { get; set; }
        public string? Event { get; set; }
        public string? ACCESS_ID { get; set; }
        public string? Trade_ref_Number { get; set; }
        public string? Edition_Number { get; set; }
        public string? NoteAppv { get; set; }
    }
}
