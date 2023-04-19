using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewPayInterest
    {
        public DateTime? EventDate { get; set; }
        public string Module { get; set; }
        public string KeyNumber { get; set; }
        public string EventName { get; set; }
        public double? IntPay { get; set; }
        public string FlagDue { get; set; }
        public string Ccy { get; set; }
    }
}
