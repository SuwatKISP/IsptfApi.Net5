using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pFCDText
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
        public string Update_date { get; set; }
        public string EndMonthDate { get; set; }
        public double? OutBalCur { get; set; }
        public double? MidRate { get; set; }
        public double? OutBalTH { get; set; }
        public string Ccy { get; set; }
        public string DueDate { get; set; }
        public string OpenDate { get; set; }
        public string DateStartAccru { get; set; }
        public string DepositDate { get; set; }
        public string EventDate { get; set; }
        public string TranFFlag { get; set; }
        public double? IntRate { get; set; }
        public double? IntSpread { get; set; }
        public double? Exch_CA { get; set; }
        public double? Exch_SA { get; set; }
        public double? NewIntRate { get; set; }
        public double? EndMonthAccru { get; set; }
        public double? CurAccru { get; set; }
        public double? AccruCcyBal { get; set; }
        public double? AccruTHBal { get; set; }
        public int? Term { get; set; }
        public string TermUnit { get; set; }
        public string AccCode { get; set; }
        public string ERP_Acc_Code { get; set; }
        public string ZZDate { get; set; }
        public string ZZuser { get; set; }
        public string GenFlag { get; set; }
        public string AOCode { get; set; }
    }
}
