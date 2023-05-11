//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeLiabilityCust

{
    public class ReferenceNoSelectRsp
    {
        public ReferenceRegister DocRegister { get; set; }
        public GetTotSumRsp GetTotSum { get; set; }
        public AutoFacNoSelect AutoFacNoSelect { get; set; }
    }

}
