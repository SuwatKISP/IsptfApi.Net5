//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityBank

{
    public class BankReleaseSelectRsp
    {
        public SumByRecStatusBankRsp SumByRecStatus { get; set; }
        public SumOriginAmtBankRsp SumOriginAmt { get; set; }
        public LaibFacAmtBankRsp LaibFacAmt { get; set; }
        public SumAvaliableByStatusBankRsp SumAvaliableByStatus { get; set; }
        public SumAvaliableByFacNoBankRsp SumAvaliableByFacNo { get; set; }
        public PlusBankRsp Plus { get; set; }
        public CheckOverDueBankRsp CheckOverDue { get; set; }
        public ComTradeEditBankRsp ComTradeEdit { get; set; }
    }
}
