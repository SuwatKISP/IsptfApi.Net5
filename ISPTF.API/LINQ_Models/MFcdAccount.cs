using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class MFcdAccount
    {
        public string FcdAccNo { get; set; }
        public string RecStatus { get; set; }
        public string FcdStatus { get; set; }
        public string FcdFlag { get; set; }
        public DateTime? EventDate { get; set; }
        public string FcdResType { get; set; }
        public string FcdFinInst { get; set; }
        public string FcdAccBran { get; set; }
        public string FcdAccType { get; set; }
        public string FcdSavFlag { get; set; }
        public int? FcdAccTerm { get; set; }
        public string FcdAccName { get; set; }
        public string FcdDeposit { get; set; }
        public string RefAccount { get; set; }
        public string CheckLiab { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string FcdCcy { get; set; }
        public string FcdCcyName { get; set; }
        public double? FcdBalance { get; set; }
        public double? FcdAvalBal { get; set; }
        public double? PrevFcdBal { get; set; }
        public int? BaseDay { get; set; }
        public double? IntRate { get; set; }
        public double? Spread { get; set; }
        public string FlagRate { get; set; }
        public string HoldFlag { get; set; }
        public double? HoldAmt { get; set; }
        public double? PrevHoldAmt { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Remark { get; set; }
        public DateTime? LastmoveDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UserCode { get; set; }
        public DateTime? AuthDate { get; set; }
        public string AuthCode { get; set; }
        public string CenterId { get; set; }
    }
}
