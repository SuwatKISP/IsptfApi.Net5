using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PTranFcdBalance
    {
        public string FcdAccNo { get; set; }
        public string TranDoc { get; set; }
        public string TranFstatus { get; set; }
        public string FlagRate { get; set; }
        public string TranFtype { get; set; }
        public string TranFflag { get; set; }
        public string FcdSavFlag { get; set; }
        public string FcdCross { get; set; }
        public string CustCode { get; set; }
        public string FcdCcy { get; set; }
        public double? FcdAmt { get; set; }
        public double? FcdBalance { get; set; }
        public double? PrevFcdBal { get; set; }
        public double? FcdAvalBal { get; set; }
        public double? FcdIntBal { get; set; }
        public double? HoldAmt { get; set; }
        public double? PrevHoldAmt { get; set; }
        public string HoldFlag { get; set; }
        public int? FcdAccTerm { get; set; }
        public DateTime? DueDate { get; set; }
        public int? DueMonth { get; set; }
        public DateTime? DepositDate { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public DateTime? DateToStop { get; set; }
        public DateTime? DateLastAccru { get; set; }
        public double? LastAccruCcy { get; set; }
        public double? LastAccruAmt { get; set; }
        public double? NewAccruCcy { get; set; }
        public double? NewAccruAmt { get; set; }
        public double? AccruCcy { get; set; }
        public double? AccruAmt { get; set; }
        public double? AccruPending { get; set; }
        public string Remark { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string CenterId { get; set; }
    }
}
