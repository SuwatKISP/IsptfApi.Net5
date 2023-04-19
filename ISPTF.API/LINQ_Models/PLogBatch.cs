using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PLogBatch
    {
        public DateTime RunDate { get; set; }
        public string StartTime { get; set; }
        public string LastTime { get; set; }
        public string ImpMidRate { get; set; }
        public string AutoPastDue { get; set; }
        public string GenAmort { get; set; }
        public string GenFloat { get; set; }
        public string GenAccru { get; set; }
        public string GenFcd { get; set; }
        public string PostAccru { get; set; }
        public string GenMapSap { get; set; }
        public string SumSap { get; set; }
        public string GenSapErp { get; set; }
        public string GenBpocam { get; set; }
        public string Ccsreve { get; set; }
    }
}
