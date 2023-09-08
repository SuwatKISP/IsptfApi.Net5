using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.QuoteRate
{
    public class QuoteINTDeleteReq
    {
       public string? Txn_ID { get; set; }
        public string? RM1 { get; set; }
        public string? RM2 { get; set; }
        public string? Delete_user { get; set; }
  
    }
}
