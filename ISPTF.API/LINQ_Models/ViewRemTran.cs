using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewRemTran
    {
        public string Module { get; set; }
        public string KeyNumber { get; set; }
        public string CustCode { get; set; }
        public string CustName { get; set; }
        public int Commlc { get; set; }
        public double? Cable { get; set; }
        public int Payble { get; set; }
        public int Duty { get; set; }
        public double? Commother { get; set; }
        public int Overdraw { get; set; }
        public int Engage { get; set; }
        public double? Commlieu { get; set; }
        public int Commibc { get; set; }
        public int Penalty { get; set; }
        public double? Commtran { get; set; }
        public int Commamend { get; set; }
        public int Commadvice { get; set; }
        public int Postage { get; set; }
        public int Commnego { get; set; }
        public double? TelexSwift { get; set; }
        public double? HandingFee { get; set; }
        public double? Taxamt { get; set; }
        public string RemType { get; set; }
    }
}
