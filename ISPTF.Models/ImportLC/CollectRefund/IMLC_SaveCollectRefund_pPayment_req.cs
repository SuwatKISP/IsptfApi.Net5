using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportLC
{
    public class IMLC_SaveCollectRefund_pPayment_req
    {
        public double? RpCashAmt { get; set; }
        public double? RpChqAmt { get; set; }
        public string RpChqNo { get; set; }
        public string RpChqBank { get; set; }
        public string RpChqBranch { get; set; }
        public string RpCustAc1 { get; set; }
        public double? RpCustAmt1 { get; set; }
        public string RpCustAc2 { get; set; }
        public double? RpCustAmt2 { get; set; }
        public string RpCustAc3 { get; set; }
        public double? RpCustAmt3 { get; set; }
    }
}
