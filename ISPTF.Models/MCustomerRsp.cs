using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models
{
    public class MCustomerRsp : MCustomer
    {
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        //public DateTime AuthDate { get; set; }
    }
}
