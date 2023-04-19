using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PImpayment
    {
        public string DocNumber { get; set; }
        public int DocSeqno { get; set; }
        public string RecStatus { get; set; }
        public string PayMode { get; set; }
        public string PayFlag { get; set; }
        public double? BalanceAmt { get; set; }
        public double? InterestAmt { get; set; }
        public double? InterestBl { get; set; }
        public DateTime? PaymentDate { get; set; }
        public double? PayCcyAmt { get; set; }
        public double? PayCcyInt { get; set; }
        public string PayFcd { get; set; }
        public double? PayAmtBht1 { get; set; }
        public double? PayExch1 { get; set; }
        public double? PayBaht1 { get; set; }
        public string FwdCont { get; set; }
        public double? PayAmtBht2 { get; set; }
        public double? PayExch2 { get; set; }
        public double? PayBaht2 { get; set; }
        public string FwdCont2 { get; set; }
        public double? PayAmtBht3 { get; set; }
        public double? PayExch3 { get; set; }
        public double? PayBaht3 { get; set; }
        public string FwdCont3 { get; set; }
        public double? PayAmtBht4 { get; set; }
        public double? PayExch4 { get; set; }
        public double? PayBaht4 { get; set; }
        public string FwdCont4 { get; set; }
        public double? PayAmtBht5 { get; set; }
        public double? PayExch5 { get; set; }
        public double? PayBaht5 { get; set; }
        public string FwdCont5 { get; set; }
        public double? PayAmtBht6 { get; set; }
        public double? PayExch6 { get; set; }
        public double? PayBaht6 { get; set; }
        public string FwdCont6 { get; set; }
        public double? PayIntBht1 { get; set; }
        public double? PayIntExch1 { get; set; }
        public double? PayIntBaht1 { get; set; }
        public string FwdContInt1 { get; set; }
        public double? PayIntBht2 { get; set; }
        public double? PayIntExch2 { get; set; }
        public double? PayIntBaht2 { get; set; }
        public string FwdContInt2 { get; set; }
        public string CenterId { get; set; }
        public string TrdueStatus { get; set; }
        public DateTime? OverDueDate { get; set; }
        public DateTime? PastdueDate { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public DateTime? DateLastAccru { get; set; }
        public DateTime? DateToStop { get; set; }
        public double? LastAccruCcy { get; set; }
        public double? LastAccruAmt { get; set; }
        public double? LastAccruBht { get; set; }
        public double? NewAccruCcy { get; set; }
        public double? NewAccruAmt { get; set; }
        public double? NewAccruBht { get; set; }
        public double? AccruCcy { get; set; }
        public double? AccruAmt { get; set; }
        public double? AccruBht { get; set; }
        public double? DaccruAmt { get; set; }
        public double? PaccruAmt { get; set; }
        public double? AccruPending { get; set; }
        public double? RevAccru { get; set; }
    }
}
