using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MCustomerNewRsp
    {
        public MCustomerRsp customer { get; set; }
        public MCustRateRsp[] custrate{ get; set; }
    }
}
