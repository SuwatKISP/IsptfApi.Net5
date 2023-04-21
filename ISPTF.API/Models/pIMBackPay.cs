using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pIMBackPay
    {
        public string Login { get; set; }
        public string RefNumber { get; set; }
        public int EventNo { get; set; }
        public DateTime? EventDate { get; set; }
        public string Event { get; set; }
        public string Status { get; set; }
        public string DocNumber { get; set; }
        public string DocStatus { get; set; }
        public double? DocBalance { get; set; }
        public double? FBCharge { get; set; }
        public double? FBInterest { get; set; }
        public DateTime? LastIntDate { get; set; }
        public double? LastIntAmt { get; set; }
        public double? IntBalance { get; set; }
        public double? OverDrawComm { get; set; }
        public double? EngageComm { get; set; }
        public double? OpenAmt { get; set; }
        public double? CableAmt { get; set; }
        public double? DutyAmt { get; set; }
        public double? PayableAmt { get; set; }
        public double? CommOther { get; set; }
        public double? IBCComm { get; set; }
        public double? CommLieu { get; set; }
        public double? CommTran { get; set; }
        public double? CommCertify { get; set; }
        public double? DiscFee { get; set; }
        public double? PosatgeAmt { get; set; }
        public double? TaxAmt { get; set; }
        public string Reverse { get; set; }
        public string VoucherID { get; set; }
        public string AuthCode { get; set; }
        public DateTime? AuthDate { get; set; }
    }
}
