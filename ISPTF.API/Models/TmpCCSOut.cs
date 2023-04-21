using System;
using System.Collections.Generic;

#nullable disable

namespace ISPTF.Models
{
    public partial class TmpCCSOut
    {
        public DateTime? CCS_Date { get; set; }
        public string CCS_Module { get; set; }
        public string CCS_FacNo { get; set; }
        public string CCS_Ccy { get; set; }
        public string CCS_Cust { get; set; }
        public string CCS_AccNo { get; set; }
        public string CCS_CRType { get; set; }
        public double? CCS_Balance { get; set; }
        public double? CCS_Credit { get; set; }
        public string CCS_AsDate { get; set; }
        public double? CCS_Accrued { get; set; }
    }
}
