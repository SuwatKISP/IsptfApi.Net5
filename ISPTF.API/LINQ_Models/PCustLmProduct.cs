using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.API.LINQ_Models
{
    public partial class PCustLmProduct
    {
        public string CustCode { get; set; }
        public string FacilityNo { get; set; }
        public int SeqNo { get; set; }
        public string ProdCode { get; set; }
        public string ProdLimit { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public double? ProdAmount { get; set; }
        public string CcsNo { get; set; }
        public string CcsRef { get; set; }
        public string CcsLimit { get; set; }
    }
}
