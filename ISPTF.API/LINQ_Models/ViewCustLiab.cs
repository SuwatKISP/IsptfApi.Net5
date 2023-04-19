using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewCustLiab
    {
        public string CustCode { get; set; }
        public string FacilityNo { get; set; }
        public string Currency { get; set; }
        public double Liability { get; set; }
        public string ReferCust { get; set; }
        public string ReferFacility { get; set; }
        public string ShareFlag { get; set; }
    }
}
