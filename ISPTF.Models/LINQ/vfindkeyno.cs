using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class vfindkeyno
    {
        public string ISP_Custno { get; set; }
        public string ISP_cust { get; set; }
        public string TF_cust { get; set; }
        public string TF_Ref { get; set; }
        public string ISP_prod { get; set; }
        public string TF_prod { get; set; }
        public string ISP_ccs { get; set; }
        public string TF_ccs { get; set; }
        public string ISP_relate { get; set; }
        public string TF_relate { get; set; }
        public string ISP_ccy { get; set; }
        public string TF_ccy { get; set; }
        public string ISP_fac { get; set; }
        public double? ISP_cramt { get; set; }
        public decimal? TF_amt { get; set; }
    }
}
