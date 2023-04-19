using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class PLogFcdAccount
    {
        public DateTime LogDate { get; set; }
        public string LogTime { get; set; }
        public string LogEvent { get; set; }
        public string LogUser { get; set; }
        public string LogComp { get; set; }
        public string LogStatus { get; set; }
        public string LogFcdAccNo { get; set; }
        public string LogCustCode { get; set; }
        public double? LogFcdAmt { get; set; }
        public string LogFcdRef { get; set; }
        public string CenterId { get; set; }
    }
}
