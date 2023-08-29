using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.TradeCreditLimit.QuoteRate
{
    public class QuoteINTListRsp
    {
        public string? Txn_ID { get; set; }
        public string? Name { get; set; }
        public string? Reference { get; set; }
        public int? TranSEQ { get; set; }
        public string? Type { get; set; }
        public string? curr { get; set; }
        public string? Against { get; set; }
        public string? amount { get; set; }
        //public string? value_Date { get; set; }
        //public string? Expiry_Date { get; set; }
        //public int? Tenor { get; set; }
        public string? Status { get; set; }
        public string? Txndate { get; set; }
        public int rCount { get; set; }

    }
}
