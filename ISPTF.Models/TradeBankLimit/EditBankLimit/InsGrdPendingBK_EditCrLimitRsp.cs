//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeBankLimit

{
    public class InsGrdPendingBK_EditCrLimitRsp
    {
        public int RCount { get; set; }
        public string BankCode { get; set; }
        public string LFacility_No { get; set; }
        public string LLimit_Code { get; set; }
        public double LCredit_Amount { get; set; }
        public string LCredit_Ccy { get; set; }
        public DateTime? LStartDate { get; set; }
        public DateTime? LExpiryDate { get; set; }
        public string LFacility_Type  { get; set; }
        public string LRevol_Flag { get; set; }
        public string LCondition { get; set; }
        public string LRemark { get; set; }
        public string LCCS_NO  { get; set; }
        public double LOrigin_Amount { get; set; }
        public DateTime? LBlockDate { get; set; }
        public string LBlock_Note { get; set; }
        public string LBlock_Code { get; set; }
        public double LHold_Amount { get; set; }
        public string LCnty_Code { get; set; }
        public string LBank_Code { get; set; }
        public string Bank_Name { get; set; }

    }
}
