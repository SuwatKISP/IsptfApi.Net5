using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.DomesticLC
{
    public class DMLC_ReleasePaymentDBE_pDOMBE_req
    {
        public string? BENumber { get; set; }
        public string? RecType { get; set; }
        public int? BESeqno { get; set; }
        public DateTime? EventDate { get; set; }
        public string? RecStatus { get; set; }
        public string? Event { get; set; }
        public string? BEStatus { get; set; }
        public string? BECcy { get; set; }
        public double? ExchBefore { get; set; }
        public string? PayMethod { get; set; }
        public double? PayBalance { get; set; }
        public DateTime? IntStartDate { get; set; }
        public double? PayInterest { get; set; }
        public string? PayFlag { get; set; }
        public string? LastReceiptNo { get; set; }
        public double? TaxAmt { get; set; }
        public double? OverAmt { get; set; }
        public double? NegoAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? CommOther { get; set; }
        public double? CommTran { get; set; }
        public double? CommCertify { get; set; }
        public double? CommEngage { get; set; }
        public double? Discfee { get; set; }
        public string? UserCode { get; set; }
        public string? CenterID { get; set; }
    }
}
