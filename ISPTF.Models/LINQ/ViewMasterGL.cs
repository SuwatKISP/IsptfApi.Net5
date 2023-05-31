using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewMasterGL
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
        public double COMMLC { get; set; }
        public double CABLE { get; set; }
        public double? PAYBLE { get; set; }
        public double DUTY { get; set; }
        public double? COMMOTHER { get; set; }
        public double? OVERDRAW { get; set; }
        public double? ENGAGE { get; set; }
        public double COMMLIEU { get; set; }
        public double COMMIBC { get; set; }
        public double PENALTY { get; set; }
        public double? COMMTRAN { get; set; }
        public double COMMAMEND { get; set; }
        public double COMMADVICE { get; set; }
        public double? POSTAGE { get; set; }
        public double COMMNEGO { get; set; }
        public double? TelexSwift { get; set; }
        public double? HandingFee { get; set; }
        public double TAXAMT { get; set; }
        public string collectrefund { get; set; }
        public string RecStatus { get; set; }
        public string TenorType { get; set; }
        public int? TenorDay { get; set; }
        public string TenorTerm { get; set; }
        public int? TENOR_TYPE { get; set; }
        public string CENTERID { get; set; }
        public string FlagDue { get; set; }
        public double? IntRate { get; set; }
        public string CCS_ACCT { get; set; }
        public string CCS_LmType { get; set; }
        public string CCS_CNUM { get; set; }
        public string CCS_CIFRef { get; set; }
        public string Facno { get; set; }
        public double RevAccru { get; set; }
        public string BName { get; set; }
        public string BCnty { get; set; }
        public string DNumber { get; set; }
        public string Corr_BANK { get; set; }
        public string Corr_Name { get; set; }
        public string Corr_Cnty { get; set; }
        public string WithOutFlag { get; set; }
        public string WithOutType { get; set; }
        public string Wref_Bank_ID { get; set; }
    }
}
