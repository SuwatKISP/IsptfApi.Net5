using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pCustAppv
    {
        public string Appv_No { get; set; }
        public string RecStatus { get; set; }
        public string Appv_Status { get; set; }
        public DateTime? EntryDate { get; set; }
        public string Refer_Type { get; set; }
        public string Refer_DocNo { get; set; }
        public string Refer_RefNo { get; set; }
        public string Refer_Ccy { get; set; }
        public double? Refer_CcyAmt { get; set; }
        public double? Refer_ExchRate { get; set; }
        public double? Refer_BhtAmt { get; set; }
        public string Cust_Code { get; set; }
        public string Facility_Flag { get; set; }
        public string Facility_No { get; set; }
        public string Hold_Cust { get; set; }
        public string Hold_FacNo { get; set; }
        public double? Hold_Amt { get; set; }
        public double? Credit_Line { get; set; }
        public double? Liab_Amt { get; set; }
        public double? Appv_Amt { get; set; }
        public double? Share_Amt { get; set; }
        public double? Susp_Amt { get; set; }
        public double? TotCredit_Line { get; set; }
        public double? TotLiab_Amt { get; set; }
        public double? TotAppv_Amt { get; set; }
        public double? TotShare_Amt { get; set; }
        public double? TotSusp_Amt { get; set; }
        public string Comment { get; set; }
        public string Event { get; set; }
        public string Appv_Cancel { get; set; }
        public DateTime? Appv_CanDate { get; set; }
        public double? Reverse_Amt { get; set; }
        public string Share_Type { get; set; }
        public double? TxHold_Amt { get; set; }
        public double? TotHold_Amt { get; set; }
        public double? NonLine_Amt { get; set; }
        public double? TotNonLine_Amt { get; set; }
        public string Remark { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string CenterID { get; set; }
        public string Bank_Code { get; set; }
        public double? Over_Amt { get; set; }
        public double? Group_Amt { get; set; }
        public double? Available_Amt { get; set; }
        public double? TotOver_Amt { get; set; }
        public double? TotGroup_Amt { get; set; }
        public double? TAvailable_Amt { get; set; }
        public string Campaign_Code { get; set; }
        public DateTime? Campaign_EffDate { get; set; }
    }
}
