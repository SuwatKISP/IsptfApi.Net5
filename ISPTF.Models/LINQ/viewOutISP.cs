using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class viewOutISP
    {
        public DateTime? EventDate { get; set; }
        public string KeyNumber { get; set; }
        public string Module { get; set; }
        public string CustCode { get; set; }
        public string Ccy { get; set; }
        public double BalanceAmt { get; set; }
        public DateTime? DueDate { get; set; }
        public string Cust_CIF { get; set; }
        public string Cust_Name { get; set; }
        public string Facility_No { get; set; }
        public string CCS_No { get; set; }
        public string Limit_Code { get; set; }
        public double? Credit_Amount { get; set; }
        public string Facno { get; set; }
    }
}
