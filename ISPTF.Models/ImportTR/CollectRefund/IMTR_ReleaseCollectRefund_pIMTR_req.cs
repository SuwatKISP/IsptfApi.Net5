using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPTF.Models.ImportTR
{
    public class IMTR_ReleaseCollectRefund_pIMTR_req
    {
        public string RefNumber { get; set; }
        public int? TRSeqno { get; set; }
        public string? CenterID { get; set; }
        public string? UserCode { get; set; }
        public string? TRNumber { get; set; }
        public string? TRCcy { get; set; }
        public double? OverDrawComm { get; set; }
        public double? FBCharge { get; set; }
        public double? FBInterest { get; set; }
        public double? EngageComm { get; set; }
        public double? OpenAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? CommOther { get; set; }
        public double? PostageAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? IBCComm { get; set; }
        public double? CommLieu { get; set; }
        public double? CommExch { get; set; }
        public double? CommTran { get; set; }
        public double? CommCertify { get; set; }
        public double? Discfee { get; set; }
        public string? TaxRefund { get; set; }
        public string? CommDesc { get; set; }
        public string? PayFlag { get; set; }
        public string? PayMethod { get; set; }
        public string? LastReceiptNo { get; set; }

    }
}
