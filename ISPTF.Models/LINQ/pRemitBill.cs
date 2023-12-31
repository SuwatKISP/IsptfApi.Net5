﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pRemitBill
    {
        public string RemTranNo { get; set; }
        public string RecType { get; set; }
        public int SeqNo { get; set; }
        public string RecStatus { get; set; }
        public string InUse { get; set; }
        public DateTime? EventDate { get; set; }
        public string Event { get; set; }
        public DateTime? ValueDate { get; set; }
        public string BankRefNo { get; set; }
        public string TranStatus { get; set; }
        public string TranResult { get; set; }
        public string TranType { get; set; }
        public string TranBank { get; set; }
        public string TranAddr { get; set; }
        public string Cust_Bran { get; set; }
        public string Cust_Code { get; set; }
        public string Cust_CCID { get; set; }
        public string Cust_AO { get; set; }
        public string CustInfo1 { get; set; }
        public string CustInfo2 { get; set; }
        public string AppInfo { get; set; }
        public string AppRefNo { get; set; }
        public string PrevRefNo { get; set; }
        public string CollectBank { get; set; }
        public string RelateCode { get; set; }
        public string GoodsCode { get; set; }
        public string PurposeCode { get; set; }
        public string GoodsDesc { get; set; }
        public string RmCcy { get; set; }
        public string RateType { get; set; }
        public double? ExchRate { get; set; }
        public string ForwardNo { get; set; }
        public double? RmCcyAmt { get; set; }
        public double? RmBhtAmt { get; set; }
        public double? RmFCD { get; set; }
        public double? CommAmt { get; set; }
        public double? CommLieu { get; set; }
        public double? CommBNet { get; set; }
        public double? CommOverAmt { get; set; }
        public double? CableMail { get; set; }
        public double? CommExch { get; set; }
        public double? DutyAmt { get; set; }
        public double? OthCharge { get; set; }
        public double? TotCharge { get; set; }
        public string TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public string MixPayment { get; set; }
        public string FCDACNo { get; set; }
        public string PaySubType { get; set; }
        public string PayMethod { get; set; }
        public DateTime? DatePaid { get; set; }
        public string ReceiptNo { get; set; }
        public string FCDRecNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string GenAccFlag { get; set; }
        public DateTime? DateGenAcc { get; set; }
        public string VoucherID { get; set; }
        public string DMS { get; set; }
        public string Remark { get; set; }
        public string Allocation { get; set; }
        public string MT110 { get; set; }
        public string F20 { get; set; }
        public string F21 { get; set; }
        public string F32A { get; set; }
        public string F30 { get; set; }
        public string F23E { get; set; }
        public string F26 { get; set; }
        public string Bank53 { get; set; }
        public string UID53 { get; set; }
        public string Addr53 { get; set; }
        public string Bank54 { get; set; }
        public string UID54 { get; set; }
        public string Addr54 { get; set; }
        public string F59 { get; set; }
        public string CenterID { get; set; }
    }
}
