using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewLcInfo
    {
        public string Product { get; set; }
        public string Keynumber { get; set; }
        public string Reference { get; set; }
        public string Event { get; set; }
        public DateTime? Eventdate { get; set; }
        public string Status { get; set; }
        public string Amendno { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Duedate { get; set; }
        public string Ccy { get; set; }
        public double? Orgamt { get; set; }
        public double? Balamt { get; set; }
        public string Custcode { get; set; }
        public string Custname { get; set; }
        public string Beninfo { get; set; }
        public string Bencnty { get; set; }
        public string Advbankcode { get; set; }
        public string Advname { get; set; }
        public string SwiftCode { get; set; }
        public string Goodscode { get; set; }
        public string GoodDet { get; set; }
        public string Centerid { get; set; }
        public string Tenortype { get; set; }
    }
}
