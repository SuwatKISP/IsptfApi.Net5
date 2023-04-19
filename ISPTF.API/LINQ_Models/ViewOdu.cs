using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models.LINQ
{
    public partial class ViewOdu
    {
        public string CustCode { get; set; }
        public string FacilityNo { get; set; }
        public string Currency { get; set; }
        public double? IblsAmt { get; set; }
        public double? IbltAmt { get; set; }
        public double? ImtrAmt { get; set; }
        public double? ExpcAmt { get; set; }
        public double? XlcpAmt { get; set; }
        public double? XbcpAmt { get; set; }
    }
}
