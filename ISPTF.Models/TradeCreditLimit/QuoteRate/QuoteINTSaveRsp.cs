using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit.QuoteRate
{
    public class QuoteINTSaveRsp
    {
        public string? Txn_ID { get; set; }
        public string? CFR_1 { get; set; }
        public string? CFR_2 { get; set; }
        public float? CFR_3 { get; set; }
        public float? CFR_Rate { get; set; }
        public float? Quote_Rate { get; set; }
        public float? TPR { get; set; }
        public string? Status { get; set; }
        public string? TF_Sale { get; set; }
        public DateTime? TF_Sale_Date { get; set; }
        public DateTime? Time_stamp { get; set; }
        public string? RM1 { get; set; }
        public string? RM2 { get; set; }
        public string? EditApprove_Flag { get; set; }
        public string? EditApprove_UID { get; set; }
        public string? EditApprove_Date { get; set; }
        public int? EditApprove_Seq { get; set; }
        public string? ReBOT { get; set; }

    }
}
