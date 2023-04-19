using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PFcdtext
    {
        public string Module { get; set; }
        public string FcdAccNew { get; set; }
        public string TranDocNew { get; set; }
        public string FcdAccOld { get; set; }
        public string TranDocOld { get; set; }
        public string FcdAccType { get; set; }
        public string FcdSavFlag { get; set; }
        public string AccType { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public string UpdateDate { get; set; }
        public string EndMonthDate { get; set; }
        public double? OutBalCur { get; set; }
        public double? MidRate { get; set; }
        public double? OutBalTh { get; set; }
        public string Ccy { get; set; }
        public string DueDate { get; set; }
        public string OpenDate { get; set; }
        public string DateStartAccru { get; set; }
        public string DepositDate { get; set; }
        public string EventDate { get; set; }
        public string TranFflag { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public double? ExchCa { get; set; }
        public double? ExchSa { get; set; }
        public double? NewIntRate { get; set; }
        public double? EndMonthAccru { get; set; }
        public double? CurAccru { get; set; }
        public double? AccruCcyBal { get; set; }
        public double? AccruThbal { get; set; }
        public int? Term { get; set; }
        public string TermUnit { get; set; }
        public string AccCode { get; set; }
        public string ErpAccCode { get; set; }
        public string Zzdate { get; set; }
        public string Zzuser { get; set; }
        public string GenFlag { get; set; }
        public string Aocode { get; set; }
    }
}
