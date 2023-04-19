using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewPayment
    {
        public string RpModule { get; set; }
        public string RpReceiptNo { get; set; }
        public string RpCustCode { get; set; }
        public string RpEvent { get; set; }
        public DateTime? RpPayDate { get; set; }
        public string RpPayBy { get; set; }
        public string RpDocNo { get; set; }
        public string RpRefer1 { get; set; }
        public string RpRefer2 { get; set; }
        public string RpApplicant { get; set; }
        public string RpIssBank { get; set; }
        public string RpNote { get; set; }
        public double? RpCashAmt { get; set; }
        public double? RpChqAmt { get; set; }
        public string RpChqNo { get; set; }
        public string RpChqBank { get; set; }
        public string RpChqBranch { get; set; }
        public double? RpCustAmt1 { get; set; }
        public double? RpCustAmt2 { get; set; }
        public double? RpCustAmt3 { get; set; }
        public string RpStatus { get; set; }
        public string RpRecStatus { get; set; }
        public string RpPrint { get; set; }
        public int DpSeq { get; set; }
        public string DpPayName { get; set; }
        public double? DpPayAmt { get; set; }
        public double? DpExchRate { get; set; }
        public string DpRemark { get; set; }
        public double? DpIntRate { get; set; }
        public DateTime? DpFromDate { get; set; }
        public DateTime? DpToDate { get; set; }
        public string RpCustAc2 { get; set; }
        public string RpCustAc3 { get; set; }
        public string RpCustAc1 { get; set; }
        public string DpContract { get; set; }
    }
}
