using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class ViewRemTran
    {
        public string Module { get; set; }
        public string KeyNumber { get; set; }
        public string Cust_Code { get; set; }
        public string CustName { get; set; }
        public int COMMLC { get; set; }
        public double? CABLE { get; set; }
        public int PAYBLE { get; set; }
        public int DUTY { get; set; }
        public double? COMMOTHER { get; set; }
        public int OVERDRAW { get; set; }
        public int ENGAGE { get; set; }
        public double? COMMLIEU { get; set; }
        public int COMMIBC { get; set; }
        public int PENALTY { get; set; }
        public double? COMMTRAN { get; set; }
        public int COMMAMEND { get; set; }
        public int COMMADVICE { get; set; }
        public int POSTAGE { get; set; }
        public int COMMNEGO { get; set; }
        public double? TelexSwift { get; set; }
        public double? HandingFee { get; set; }
        public double? TAXAMT { get; set; }
        public string RemType { get; set; }
    }
}
