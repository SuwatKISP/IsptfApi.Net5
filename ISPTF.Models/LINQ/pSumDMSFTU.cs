using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pSumDMSFTU
    {
        public string EventType { get; set; }
        public string Product { get; set; }
        public string Keynumber { get; set; }
        public string TXSeq { get; set; }
        public string System { get; set; }
        public string FXArrangeType { get; set; }
        public string CustCode { get; set; }
        public string BenCnty { get; set; }
        public string ExcInvPartyBusType { get; set; }
        public string InFlowTXPurpose { get; set; }
        public string OutFlowTXPurpose { get; set; }
        public string CurID { get; set; }
        public string LegType { get; set; }
        public double? ForeCurAmt { get; set; }
        public string AsAtDate { get; set; }
        public string RunDate { get; set; }
        public string RunTime_U { get; set; }
        public string PeriodFlag { get; set; }
    }
}
