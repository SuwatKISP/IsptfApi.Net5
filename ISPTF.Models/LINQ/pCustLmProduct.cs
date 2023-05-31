using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class pCustLmProduct
    {
        public string Cust_Code { get; set; }
        public string Facility_No { get; set; }
        public int SeqNo { get; set; }
        public string Prod_Code { get; set; }
        public string Prod_Limit { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public double? ProdAmount { get; set; }
        public string CCS_No { get; set; }
        public string CCS_ref { get; set; }
        public string CCS_Limit { get; set; }
    }
}
