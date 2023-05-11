//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.TradeLiabilityCust;
using ISPTF.Models.TradeCreditLimit;
using ISPTF.Models.TradeLiabilityCustCancelReverse;

namespace ISPTF.Models.TradeLiabilityBankCancelReverse

{
    public class BankCancelReverseInsGrdAppvSelectRsp
    {
        public SumByRecStatusRsp SumByRecStatus { get; set; }
        public SumOriginAmtRsp SumOriginAmt { get; set; }
        public LaibFacAmtRsp LaibFacAmt { get; set; }
        public SumAvaliableByFacNoRsp SumAvaliableByFacNo { get; set; }
        public CustCancelReverseRefNo2PLUSRsp RefNo2PLUS { get; set; }
        public CheckOverDueRsp CheckOverDue { get; set; }
    }
}
