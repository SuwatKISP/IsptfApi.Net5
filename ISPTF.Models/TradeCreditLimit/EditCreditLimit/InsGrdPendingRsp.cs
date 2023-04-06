//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit

{
    public class InsGrdPendingRsp
    {
        public int RCount { get; set; }
        public string Customer { get; set; }
        public string LFacility_No { get; set; }
        public string LLimit_Code { get; set; }
        public double LCredit_Amount { get; set; }
        public string LCredit_Ccy { get; set; }
        public DateTime? LStartDate { get; set; }
        public DateTime? LExpiryDate { get; set; }
        public string LFacility_Type  { get; set; }
        public string LRevol_Flag { get; set; }
        public string LShare_Flag { get; set; }
        public double LCredit_Share { get; set; }
        public string LCondition { get; set; }
        public string LShare_Type { get; set; }
        public string LRemark { get; set; }
        public string LCCS_NO  { get; set; }
        public double LOrigin_Amount { get; set; }
        public DateTime? LBlockDate { get; set; }
        public string LBlock_Note { get; set; }
        public string LBlock_Code { get; set; }
        public double LHold_Amount { get; set; }
        public double LCFRSpread { get; set; }
        public string LCampaign_Code { get; set; }
        public DateTime? Effective_Date { get; set; }
        public string LCust_Code { get; set; }
        public string Cust_Name { get; set; }

    }
}
