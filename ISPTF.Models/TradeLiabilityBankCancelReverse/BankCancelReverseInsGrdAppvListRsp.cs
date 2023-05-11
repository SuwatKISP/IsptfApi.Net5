//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityBankCancelReverse

{
    public class BankCancelReverseInsGrdAppvListRsp
    {
        public int? RCount { get; set; }
        public string? Appv_No { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? Refer_Type { get; set; }
        public string? Refer_Docno  { get; set; }
        public string? Refer_RefNo  { get; set; }
        public string? Refer_Ccy { get; set; }
        public double? Refer_CcyAmt { get; set; }
        public double? Refer_ExchRate { get; set; }
        public double? Refer_BhtAmt { get; set; }
        public string? Customer { get; set; }
        public string? Facility_Flag { get; set; }
        public string? Facility_No { get; set; }
        public double? Credit_Line { get; set; }
        public double? Liab_Amt { get; set; }
        public double? Appv_Amt { get; set; }
        public double? BookingAmt { get; set; }
        public double? Share_Amt { get; set; }
        public double? Susp_Amt { get; set; }
        public double? TotCredit_Line { get; set; }
        public double? TotLiab_Amt { get; set; }
        public double? TotAppv_Amt { get; set; }
        public double? TotalBookingAmt { get; set; }
        public double? TotShare_Amt { get; set; }
        public double? TotSusp_Amt { get; set; }
        public string? Comment { get; set; }
        public string? Event { get; set; }
        public string? Hold_Cust { get; set; }
        public string? Hold_Facno { get; set; }
        public double? Hold_Amt { get; set; }
        public double? TxHold_Amt { get; set; }
        public double? TotHold_Amt { get; set; }
        public double? Reverse_Amt { get; set; }
        public string? Bank_Code { get; set; }
        public string? Cust_Code { get; set; }
        public string? Cust_Name { get; set; }





    }
}
