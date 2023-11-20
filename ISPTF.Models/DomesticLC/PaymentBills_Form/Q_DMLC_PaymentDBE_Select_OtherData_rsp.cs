using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class Q_DMLC_PaymentDBE_Select_OtherData_rsp
    {
        public double? TxCurInt { get; set; }
        public DateTime? MaskLastInt {get; set;}
        public string? UserSwift {get; set;}
        public double? TxDayExch {get; set;}
        public int? TxCalDay {get; set;}
        public double? TxNewInt {get; set;}
        public double? TxIntAmt {get; set;}
        public double? TmpCharge {get; set;}
        public double? TxDiscAmt {get; set;}
        public int? TxSeq {get; set;}
    }
}
