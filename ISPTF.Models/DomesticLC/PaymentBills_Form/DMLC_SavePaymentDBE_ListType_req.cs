using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_SavePaymentDBE_ListType_req
    {
        public string? ListType { get; set; }
        public string? LoadPay { get; set; }
        public double? txTotalPaid { get; set; }
        public double? TxPrinciple { get; set; }
        public double TxInterest { get; set; }
        public double? TxAccInt { get; set; }
        public double? TxNewInt { get; set; }
        //public string? ctext50K { get; set; }
        //public string? ctext59 { get; set; }
    }
}
