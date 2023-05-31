using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewMonInterest
    {
        public string DocMonth { get; set; }
        public string CenterID { get; set; }
        public string DocCust { get; set; }
        public string Login { get; set; }
        public string DocCcy { get; set; }
        public double? IntCcy { get; set; }
        public double? IntTHB { get; set; }
        public double? IntExchRate { get; set; }
        public string SendFlag { get; set; }
    }
}
