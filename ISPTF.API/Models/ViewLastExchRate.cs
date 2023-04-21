using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewLastExchRate
    {
        public string Exch_Ccy { get; set; }
        public DateTime? Exch_Date { get; set; }
        public string Exch_Time { get; set; }
    }
}
