using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class vLinkTFL
    {
        public string Cust_Code { get; set; }
        public string ISP_CIF { get; set; }
        public string TFL_CIF { get; set; }
        public string Cust_Name { get; set; }
        public string TFL_Ref { get; set; }
        public string ISP_CCS { get; set; }
        public string TFL_CCS { get; set; }
        public string TFL_CCS_Relate { get; set; }
        public string TFL_prod { get; set; }
        public string TFL_cur { get; set; }
        public decimal? TFL_amt { get; set; }
        public string New_Fac { get; set; }
    }
}
