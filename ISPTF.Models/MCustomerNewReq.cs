using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MCustomerNewReq 
    {
        public MCustomer customer { get; set; }
        public MCustRate[] custRate { get; set; }
    }
}
