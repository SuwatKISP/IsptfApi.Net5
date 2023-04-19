using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewDayTran
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public int Seqno { get; set; }
        public string EventName { get; set; }
        public string Collection { get; set; }
        public string Reference { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string Ccy { get; set; }
        public double? OriginalAmt { get; set; }
        public double? BalanceAmt { get; set; }
        public DateTime? DueDate { get; set; }
        public string UserCode { get; set; }
        public string AuthCode { get; set; }
        public double Commcic { get; set; }
        public double Commcip { get; set; }
        public double? Commlc { get; set; }
        public double? Cable { get; set; }
        public double? Payble { get; set; }
        public double? Duty { get; set; }
        public double? Commother { get; set; }
        public double? Overdraw { get; set; }
        public double? Engage { get; set; }
        public double Commlieu { get; set; }
        public double Commibc { get; set; }
        public double Penalty { get; set; }
        public double? Commtran { get; set; }
        public double Commamend { get; set; }
        public double Commadvice { get; set; }
        public double? Postage { get; set; }
        public double Commnego { get; set; }
        public double? TelexSwift { get; set; }
        public double? HandingFee { get; set; }
        public double? Commcertify { get; set; }
        public double Taxamt { get; set; }
        public string Collectrefund { get; set; }
        public string RecStatus { get; set; }
        public string RpReceiptNo { get; set; }
        public string PayFlag { get; set; }
        public string CenterId { get; set; }
        public double Discount { get; set; }
        public double? IntDelay { get; set; }
        public string Allocation { get; set; }
        public string EventFlag { get; set; }
        public string Amend { get; set; }
        public double? IntRate { get; set; }
        public double? Balpd { get; set; }
        public string FlagDue { get; set; }
        public string Bname { get; set; }
        public string Bcnty { get; set; }
        public string Dnumber { get; set; }
        public string IssBank { get; set; }
        public string CorrBank { get; set; }
        public string CorrName { get; set; }
        public string CorrCnty { get; set; }
        public int? TenorType { get; set; }
        public double IncreaseAmt { get; set; }
        public double DecreaseAmt { get; set; }
        public string FacNo { get; set; }
        public string PayMethod { get; set; }
        public string EventMode { get; set; }
        public string WithOutFlag { get; set; }
        public string WithOutType { get; set; }
        public string WrefBankId { get; set; }
        public string AcceptFlag { get; set; }
        public DateTime? AcceptDate { get; set; }
        public string Bpoflag { get; set; }
        public string CampaignCode { get; set; }
        public DateTime? CampaignEffDate { get; set; }
        public string Relation { get; set; }
        public string TenorType1 { get; set; }
        public int? TenorDay { get; set; }
        public string TenorTerm { get; set; }
    }
}
