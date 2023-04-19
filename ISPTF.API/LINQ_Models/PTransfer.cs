using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PTransfer
    {
        public string ExportAdviceNo { get; set; }
        public int SeqTransfer { get; set; }
        public int EventNo { get; set; }
        public string RecordType { get; set; }
        public string RecStatus { get; set; }
        public string EventType { get; set; }
        public string BusinessType { get; set; }
        public DateTime? EventDate { get; set; }
        public string LcNo { get; set; }
        public string LcCurrency { get; set; }
        public string TransferId { get; set; }
        public string TransferInfo { get; set; }
        public string TransferType { get; set; }
        public string SubstationDoc { get; set; }
        public string TypeOfChargeTransfer { get; set; }
        public DateTime? TransferDate { get; set; }
        public double? TransferAmount { get; set; }
        public DateTime? PrevExpiry { get; set; }
        public DateTime? TransferExpiryDate { get; set; }
        public double? TransferComRate { get; set; }
        public double? TransferRate { get; set; }
        public double? TransferCom { get; set; }
        public string TransferOther { get; set; }
        public double? TransferAmtCancel { get; set; }
        public string ReasonOfCancel { get; set; }
        public double? AmendCom { get; set; }
        public double? AmendtrnCom { get; set; }
        public double? AdviceCom { get; set; }
        public double? CableCom { get; set; }
        public double? Postage { get; set; }
        public double? ConfirmCom { get; set; }
        public double? OtherCharge { get; set; }
        public string PaymentInstru { get; set; }
        public string Method { get; set; }
        public string ReceiptNo { get; set; }
        public double? TotalCharge { get; set; }
        public double? RefundTax { get; set; }
        public string PayRefund { get; set; }
        public double? TotalAmount { get; set; }
        public string UserId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string AuthCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string VouchId { get; set; }
        public string InUse { get; set; }
        public string GenaccFlag { get; set; }
        public DateTime? GenaccDate { get; set; }
        public string Status { get; set; }
        public string Allocation { get; set; }
        public string Remark { get; set; }
        public string CenterId { get; set; }
    }
}
