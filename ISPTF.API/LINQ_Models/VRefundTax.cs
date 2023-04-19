using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class VRefundTax
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public string Reference { get; set; }
        public string CustCode { get; set; }
        public double? TaxAmt { get; set; }
        public string RpPayBy { get; set; }
        public string RpCustAc1 { get; set; }
        public double? RpCustAmt1 { get; set; }
        public string RpCustAc2 { get; set; }
        public double? RpCustAmt2 { get; set; }
        public string RpCustAc3 { get; set; }
        public double? RpCustAmt3 { get; set; }
        public double? RpCashAmt { get; set; }
        public double? RpChqAmt { get; set; }
        public string CenterId { get; set; }
    }
}
