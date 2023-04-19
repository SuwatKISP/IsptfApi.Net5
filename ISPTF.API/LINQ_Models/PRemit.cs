﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PRemit
    {
        public string RemRefNo { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? RemDate { get; set; }
        public DateTime? RegistDate { get; set; }
        public string RemBankRefNo { get; set; }
        public string RemStatus { get; set; }
        public string RecStatus { get; set; }
        public string RemType { get; set; }
        public string InUse { get; set; }
        public string RemBank { get; set; }
        public string RemAddr { get; set; }
        public string CustBran { get; set; }
        public string CustCode { get; set; }
        public string CustCcid { get; set; }
        public string CustAo { get; set; }
        public string CustLo { get; set; }
        public string CustInfo1 { get; set; }
        public string CustInfo2 { get; set; }
        public string AppInfo1 { get; set; }
        public string AppInfo2 { get; set; }
        public string AppInfo3 { get; set; }
        public string AppInfo4 { get; set; }
        public string SenderInfo { get; set; }
        public string RelCode { get; set; }
        public string GoodsCode { get; set; }
        public string PurposeCode { get; set; }
        public string GoodsDesc { get; set; }
        public string RemAcc { get; set; }
        public string RemCcy { get; set; }
        public string RateType { get; set; }
        public double? ExchRate { get; set; }
        public string RmForward { get; set; }
        public double? RmCcyAmt { get; set; }
        public double? RmBhtAmt { get; set; }
        public double? CableMail { get; set; }
        public double? CommLieu { get; set; }
        public double? CommTrans { get; set; }
        public double? CommCerti { get; set; }
        public double? CommExch { get; set; }
        public double? CommBnet { get; set; }
        public double? Fbcharge { get; set; }
        public double? OthCharge { get; set; }
        public double? TotCharge { get; set; }
        public string TaxRefund { get; set; }
        public double? TaxAmt { get; set; }
        public double? RmFcd { get; set; }
        public string PaySubType { get; set; }
        public string PayMainType { get; set; }
        public string Fcddesc { get; set; }
        public string PayMethod { get; set; }
        public DateTime? DatePaid { get; set; }
        public string ReceiptNo { get; set; }
        public string FcdrecNo { get; set; }
        public string AppvNo { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string GenAccFlag { get; set; }
        public DateTime? DateGenAcc { get; set; }
        public string VoucherId { get; set; }
        public string Dms { get; set; }
        public string Mt103 { get; set; }
        public string Mt202 { get; set; }
        public string BhtNet { get; set; }
        public string F20 { get; set; }
        public string F21 { get; set; }
        public string F32a { get; set; }
        public string F23e { get; set; }
        public string F26 { get; set; }
        public string F71a { get; set; }
        public string Bank53 { get; set; }
        public string Addr53 { get; set; }
        public string Bank54 { get; set; }
        public string Addr54 { get; set; }
        public string Bank56 { get; set; }
        public string Uid56 { get; set; }
        public string Addr56 { get; set; }
        public string Bank57 { get; set; }
        public string Uid57 { get; set; }
        public string Addr57 { get; set; }
        public string Bank58 { get; set; }
        public string Uid58 { get; set; }
        public string Addr58 { get; set; }
        public string F79 { get; set; }
        public string F72 { get; set; }
        public string F33b { get; set; }
        public string F71f { get; set; }
        public string F70 { get; set; }
        public string SwiftInfo { get; set; }
        public string Allocation { get; set; }
        public string CenterId { get; set; }
    }
}
