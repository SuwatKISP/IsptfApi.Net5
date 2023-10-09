using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_SaveRevAllPayment_ListTypePay_req
    {
        public string? ListType { get; set; }
        public double? TxBhtIntTot { get; set; }
        public double? TxCCyIntTot { get; set; }
        public int? TxCalDay { get; set; }
        public double? TxNewInt { get; set; }
    }
}
