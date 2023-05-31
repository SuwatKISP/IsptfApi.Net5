using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pLogFcdAccount
    {
        public DateTime LogDate { get; set; }
        public string LogTime { get; set; }
        public string LogEvent { get; set; }
        public string LogUser { get; set; }
        public string LogComp { get; set; }
        public string LogStatus { get; set; }
        public string LogFcdAccNo { get; set; }
        public string LogCust_Code { get; set; }
        public double? LogFcdAmt { get; set; }
        public string LogFcdRef { get; set; }
        public string CenterID { get; set; }
    }
}
