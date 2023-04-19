using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewMasterGl
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public int Seqno { get; set; }
        public string EventName { get; set; }
        public string Reference { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double? OriginalAmt { get; set; }
        public double? BalanceAmt { get; set; }
        public DateTime? DueDate { get; set; }
        public string UserCode { get; set; }
        public string AuthCode { get; set; }
        public double Commlc { get; set; }
        public double Cable { get; set; }
        public double? Payble { get; set; }
        public double Duty { get; set; }
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
        public double Taxamt { get; set; }
        public string Collectrefund { get; set; }
        public string RecStatus { get; set; }
        public string TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string TenorTerm { get; set; }
        public int? TenorType1 { get; set; }
        public string Centerid { get; set; }
        public string FlagDue { get; set; }
        public double? IntRate { get; set; }
        public string CcsAcct { get; set; }
        public string CcsLmType { get; set; }
        public string CcsCnum { get; set; }
        public string CcsCifref { get; set; }
        public string Facno { get; set; }
        public double RevAccru { get; set; }
        public string Bname { get; set; }
        public string Bcnty { get; set; }
        public string Dnumber { get; set; }
        public string CorrBank { get; set; }
        public string CorrName { get; set; }
        public string CorrCnty { get; set; }
        public string WithOutFlag { get; set; }
        public string WithOutType { get; set; }
        public string WrefBankId { get; set; }
    }
}
