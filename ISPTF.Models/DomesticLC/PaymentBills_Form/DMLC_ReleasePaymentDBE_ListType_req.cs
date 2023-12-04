using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_ReleasePaymentDBE_ListType_req
    {
        public string? ListType { get; set; }
        public string? LoadPay { get; set; }
        public double? TxNewInt { get; set; }
        public double? TxIntAmt { get; set; }
        public double TxIntPay { get; set; }
        public double? TxAccInt { get; set; }
        public DateTime? MaskStopDate { get; set; }
    }
}
