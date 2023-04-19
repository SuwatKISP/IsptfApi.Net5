using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewFcdout
    {
        public string Custcode { get; set; }
        public string RecStatus { get; set; }
        public string FcdFlag { get; set; }
        public string FcdResType { get; set; }
        public string FcdFinInst { get; set; }
        public string FcdAccType { get; set; }
        public string FcdSavFlag { get; set; }
        public string CheckLiab { get; set; }
        public DateTime? OpenDate { get; set; }
        public double? Accbalance { get; set; }
        public string FcdAccNo { get; set; }
        public string TranFflag { get; set; }
        public string FcdCcy { get; set; }
        public double? Fcdbalance { get; set; }
        public double? PrevFcdBal { get; set; }
        public int? FcdAccTerm { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DepositDate { get; set; }
        public DateTime? DateStartAccru { get; set; }
        public double? AccruCcy { get; set; }
        public double? AccruAmt { get; set; }
        public string Fcdtype { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public string FlagRate { get; set; }
        public string TranDoc { get; set; }
    }
}
