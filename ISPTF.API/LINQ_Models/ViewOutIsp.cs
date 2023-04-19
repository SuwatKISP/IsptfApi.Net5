using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class ViewOutIsp
    {
        public DateTime? EventDate { get; set; }
        public string KeyNumber { get; set; }
        public string Module { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double BalanceAmt { get; set; }
        public DateTime? DueDate { get; set; }
        public string CustCif { get; set; }
        public string CustName { get; set; }
        public string FacilityNo { get; set; }
        public string CcsNo { get; set; }
        public string LimitCode { get; set; }
        public double? CreditAmount { get; set; }
        public string Facno { get; set; }
    }
}
