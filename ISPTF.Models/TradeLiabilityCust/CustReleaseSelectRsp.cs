//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCust

{
    public class CustReleaseSelectRsp
    {
        public SumByRecStatusRsp SumByRecStatus { get; set; }
        public SumOriginAmtRsp SumOriginAmt { get; set; }
        public LaibFacAmtRsp LaibFacAmt { get; set; }
        public SumAvaliableByStatusRsp SumAvaliableByStatus { get; set; }
        public SumAvaliableByFacNoRsp SumAvaliableByFacNo { get; set; }
        public PCustAppvRsp PCustAppv { get; set; }
        public PlusRsp Plus { get; set; }
        public CheckOverDueRsp CheckOverDue { get; set; }
        public ComTradeEditRsp ComTradeEdit { get; set; }
    }
}
