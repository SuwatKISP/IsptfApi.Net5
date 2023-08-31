using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.QuoteRate
{
    public class QuoteINTSaveRsp
    {
        public string? Txn_ID { get; set; }
        public string? Customer { get; set; }
        public string? Name { get; set; }
        public string? BD { get; set; }
        public string? Reference { get; set; }
        public string? Type { get; set; }
        public string? curr { get; set; }
        public string? Against { get; set; }
        public string? amount { get; set; }
        public string? value_Date { get; set; }
        public string? Expiry_Date { get; set; }
        public string? Tenor { get; set; }
        public string? CFR_1 { get; set; }
        public string? CFR_2 { get; set; }
        public float? CFR_3 { get; set; }
        public float? CFR_Rate { get; set; }
        public float? Quote_Rate { get; set; }
        public float? TPR { get; set; }
        public string? Status { get; set; }
        public string? Txndate { get; set; }
        public string? TF_inputer { get; set; }
        public DateTime? TF_Inputer_Date { get; set; }
        public string? TF_Sale { get; set; }
        public DateTime? TF_Sale_Date { get; set; }
        public string? Delete_Flag { get; set; }        
        public DateTime? Time_stamp { get; set; }
        public string? Use_Tx { get; set; }
        public string? Delete_user { get; set; }
        public string? use_Tx_user { get; set; }
        public string? RM1 { get; set; }
        public string? RM2 { get; set; }
        public string? Cust_AoCode { get; set; }  // RC Code 
        public string? Cust_AoLev1 { get; set; }  // SBU
        public string? Cust_AoLev2 { get; set; }
        public string? Cust_AoLev3 { get; set; }
        public string? ZZUser { get; set; }
        public string? EditApprove_Flag { get; set; }
        public string? EditApprove_UID { get; set; }
        public string? EditApprove_Date { get; set; }
        public int? EditApprove_Seq { get; set; }
        public string? ZZStrdate { get; set; }
        public string? Facility_No { get; set; }
        public string? ZZDate { get; set; }
        public string? ReBOT { get; set; }
        public string? APPV_NO { get; set; }
        public string? AUTOISP { get; set; }
        public int? TranSEQ { get; set; }
        public string? CFRRemark { get; set; }

    }
}
