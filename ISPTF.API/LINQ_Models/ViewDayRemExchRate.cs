using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewDayRemExchRate
    {
        public string RemRefNo { get; set; }
        public int SeqNo { get; set; }
        public double? RmCcyAmt { get; set; }
        public double? ExchRate { get; set; }
        public double? RmBhtAmt { get; set; }
        public string RmForward { get; set; }
        public string CenterId { get; set; }
        public DateTime? AuthDate { get; set; }
        public string CustCode { get; set; }
        public DateTime? EventDate { get; set; }
        public string RemType { get; set; }
        public string CustBran { get; set; }
        public string RemBank { get; set; }
        public string CustInfo1 { get; set; }
        public string RemCcy { get; set; }
        public DateTime? RemDate { get; set; }
        public string ReceiptNo { get; set; }
        public string RateType { get; set; }
        public string RecStatus { get; set; }
        public string RateFlag { get; set; }
        public string RateRemark { get; set; }
    }
}
