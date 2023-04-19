using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PSumDmsftu
    {
        public string EventType { get; set; }
        public string Product { get; set; }
        public string Keynumber { get; set; }
        public string Txseq { get; set; }
        public string System { get; set; }
        public string FxarrangeType { get; set; }
        public string CustCode { get; set; }
        public string BenCnty { get; set; }
        public string ExcInvPartyBusType { get; set; }
        public string InFlowTxpurpose { get; set; }
        public string OutFlowTxpurpose { get; set; }
        public string CurId { get; set; }
        public string LegType { get; set; }
        public double? ForeCurAmt { get; set; }
        public string AsAtDate { get; set; }
        public string RunDate { get; set; }
        public string RunTimeU { get; set; }
        public string PeriodFlag { get; set; }
    }
}
