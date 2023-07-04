//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISPTF.Models.LoginRegis;
namespace ISPTF.Models.TradeLiabilityBank

{
    public class SelectReferenceNoBankSelectRsp
    {
        public pDocRegister pDocRegister { get; set; }
        public SelectForLoginIMLCRsp ForLoginIMLC { get; set; }
        public SelectCHKOverDueRsp CHKOverDue { get; set; }

    }
}
