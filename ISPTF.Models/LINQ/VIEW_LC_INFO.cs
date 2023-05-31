using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class VIEW_LC_INFO
    {
        public string PRODUCT { get; set; }
        public string KEYNUMBER { get; set; }
        public string REFERENCE { get; set; }
        public string EVENT { get; set; }
        public DateTime? EVENTDATE { get; set; }
        public string STATUS { get; set; }
        public string AMENDNO { get; set; }
        public DateTime? STARTDATE { get; set; }
        public DateTime? DUEDATE { get; set; }
        public string CCY { get; set; }
        public double? ORGAMT { get; set; }
        public double? BALAMT { get; set; }
        public string CUSTCODE { get; set; }
        public string CUSTNAME { get; set; }
        public string BENINFO { get; set; }
        public string BENCNTY { get; set; }
        public string ADVBANKCODE { get; set; }
        public string ADVNAME { get; set; }
        public string SWIFT_CODE { get; set; }
        public string GOODSCODE { get; set; }
        public string GOOD_DET { get; set; }
        public string CENTERID { get; set; }
        public string TENORTYPE { get; set; }
    }
}
